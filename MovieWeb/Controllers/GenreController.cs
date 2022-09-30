using API.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MovieWeb.Controllers
{
    public class GenreController : Controller
    {
        public async Task<IActionResult> GetAllGenres()
        {
            List<Genre> genres = new List<Genre>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage result = await client.GetAsync("api/Genres");
                if (result.IsSuccessStatusCode)
                {
                    var resTask = result.Content.ReadAsStringAsync().Result;
                    genres = JsonConvert.DeserializeObject<List<Genre>>(resTask);
                }
            }

            return View(genres);
        }

        #region "Post Method"
        public IActionResult CreateGenre()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateGenre(Genre genre)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/api/Genres");

                //Http Post
                var postTask = client.PostAsJsonAsync<Genre>("Genres", genre);
                postTask.Wait();

                var result = postTask.Result;
                //condition if it's ok
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.msg = "Added successfully";
                    //return RedirectToAction("GetAllMovies");
                }
                else
                {
                    ViewBag.msg = "Something went wrong...";
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator");
                }
            }

            return View(genre);
        }
        #endregion


        #region "Put Method"
        [HttpGet]
        public async Task<ActionResult> EditGenreAsync(Guid id)
        {
            Genre genre = new Genre();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/");

                //Http Get
                var responseTask = client.GetAsync("api/Genres/id?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var resTask = result.Content.ReadAsStringAsync().Result;
                    genre = JsonConvert.DeserializeObject<Genre>(resTask);
                }
            }
            return View(genre);
        }

        public IActionResult EditGenre(Genre genre)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/");

                //Http Post
                var postTask = client.PutAsJsonAsync<Genre>("api/Genres/" + genre.IdGenre.ToString(), genre);
                postTask.Wait();

                var result = postTask.Result;
                //condition if it's ok
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.msg = "Edit successfully";
                    //return RedirectToAction("GetAllMovies");
                }
                else
                {
                    ViewBag.msg = "Something went wrong...";
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator");
                }
            }
            return View(genre);
        }
        #endregion

        #region "Delete Method"
        public IActionResult DeleteGenre(Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("api/Genres/id?id=" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAllGenres");
                }
            }

            return RedirectToAction("GetAllGenres");
        }
        #endregion

        #region "Details Method"
        [HttpGet]
        public async Task<IActionResult> GetGenre(Guid id)
        {
            Genre genre = new Genre();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage result = await client.GetAsync("api/Genres/id?id=" + id.ToString());
                if (result.IsSuccessStatusCode)
                {
                    var resTask = result.Content.ReadAsStringAsync().Result;
                    genre = JsonConvert.DeserializeObject<Genre>(resTask);
                }
            }
            return View(genre);
        }
        #endregion
    }
}
