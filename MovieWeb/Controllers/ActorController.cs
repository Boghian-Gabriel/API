using API.Model;
using AspNetCore.Reporting;
using Microsoft.AspNetCore.Mvc;
using MovieWeb.Models;
using Newtonsoft.Json;

namespace ActorWeb.Controllers
{
    public class ActorController : Controller
    {
        #region GetMethod
        public async Task<IActionResult> GetAllActors(string sortOrder, string currentFilter, string searchString, int page = 1)
        {
            /*
             The three ViewBag variables are used so that the view can configure the column heading hyperlinks with the appropriate query string values:
             */
            ViewBag.CurrentSort = sortOrder;
            ViewBag.FNameSortParam = String.IsNullOrEmpty(sortOrder) ? "fname_desc" : "";
            ViewBag.LNameSortParam = String.IsNullOrEmpty(sortOrder) ? "lname_desc" : "lname_asc";
            ViewBag.DofSortParam = sortOrder == "dof_asc" ? "dof_desc" : "dof_asc";
            ViewBag.EmailSortParam = String.IsNullOrEmpty(sortOrder) ? "email_desc" : "email_asc";

            List<Actor> Actors = new List<Actor>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage result = await client.GetAsync("api/Actors");
                if (result.IsSuccessStatusCode)
                {
                    var resTask = result.Content.ReadAsStringAsync().Result;
                    Actors = JsonConvert.DeserializeObject<List<Actor>>(resTask);
                }
            }

            //pagination
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var Actorsss = from a in Actors
                           select a;

            //searching
            if (!String.IsNullOrEmpty(searchString))
            {
                Actorsss = Actorsss.Where(a => a.FirsName.Contains(searchString)
                                       || a.LastName.Contains(searchString)
                                       || a.Email.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "fname_desc":
                    Actorsss = Actorsss.OrderByDescending(a => a.FirsName);
                    break;
                case "lname_desc":
                    Actorsss = Actorsss.OrderByDescending(a => a.LastName);
                    break;
                case "lname_asc":
                    Actorsss = Actorsss.OrderBy(a => a.LastName);
                    break;
                case "dof_desc":
                    Actorsss = Actorsss.OrderByDescending(a => a.Dof);
                    break;
                case "dof_asc":
                    Actorsss = Actorsss.OrderBy(a => a.Dof);
                    break;
                case "email_desc":
                    Actorsss = Actorsss.OrderByDescending(a => a.Email);
                    break;
                case "email_asc":
                    Actorsss = Actorsss.OrderBy(a => a.Email);
                    break;
                default:
                    Actorsss = Actorsss.OrderBy(a => a.FirsName);
                    break;
            }

            const int pageSize = 4;
            if (page < 1) page = 1;

            int movCount = Actorsss.Count();
            var pager = new Pager(movCount, page, pageSize);
            //if page no is 2 and page size is 5 then recSkip = (2-1)*5 =>5
            int recSkip = (page - 1) * pageSize;
            var data = Actorsss.Skip(recSkip).Take(pager.PageSize).ToList();
            ViewBag.Pager = pager;

            return View(data);
        }
        #endregion

        #region "Post Method"
        public IActionResult CreateActor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateActor(Actor Actor)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/api/Actors");

                //Http Post
                var postTask = client.PostAsJsonAsync<Actor>("Actors", Actor);
                postTask.Wait();

                var result = postTask.Result;
                //condition if it's ok
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.msg = "Added successfully";
                    //return RedirectToAction("GetAllActors");
                }
                else
                {
                    ViewBag.msg = "Something went wrong...";
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator");
                }
            }

            return View(Actor);
        }
        #endregion


        #region "Put Method"
        [HttpGet]
        public async Task<ActionResult> EditActorAsync(Guid id)
        {
            Actor Actor = new Actor();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/");

                //Http Get
                var responseTask = client.GetAsync("api/Actors/id?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var resTask = result.Content.ReadAsStringAsync().Result;
                    Actor = JsonConvert.DeserializeObject<Actor>(resTask);
                }
            }
           
            return View(Actor);
        }

        public IActionResult EditActor(Actor Actor)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/");

                //Http Post
                var postTask = client.PutAsJsonAsync<Actor>("api/Actors/" + Actor.Id.ToString(), Actor);
                postTask.Wait();

                var result = postTask.Result;
                //condition if it's ok
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.msg = "Edit successfully";
                    //return RedirectToAction("GetAllActors");
                }
                else
                {
                    ViewBag.msg = "Something went wrong...";
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator");
                }
            }
            return View(Actor);
        }
        #endregion

        #region "Delete Method"
        public IActionResult DeleteActor(Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("api/Actors/id?id=" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAllActors");
                }
            }

            return RedirectToAction("GetAllActors");
        }
        #endregion

        #region "Details Method"
        [HttpGet]
        public async Task<IActionResult> GetActor(Guid id)
        {
            Actor Actor = new Actor();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage result = await client.GetAsync("api/Actors/id?id=" + id.ToString());
                if (result.IsSuccessStatusCode)
                {
                    var resTask = result.Content.ReadAsStringAsync().Result;
                    Actor = JsonConvert.DeserializeObject<Actor>(resTask);
                }
            }
            return View(Actor);
        }
        #endregion
    }
}
