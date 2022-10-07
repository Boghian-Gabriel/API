using API.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MovieWeb.Controllers
{
    public class GenreController : Controller
    {
        string  baseUri = "https://localhost:7165/api/Genres/";

        [HttpGet]
        public async Task<IActionResult> GetAllGenres(string search)
        {
            List<Genre> genres = new List<Genre>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage result = null;
                if (search == null)
                {
                    result = await client.GetAsync("GetAllGenres");

                }
                else
                {
                    result = await client.GetAsync("GetGenreByName/searchByName?searchByName=" + search);

                }
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
                client.BaseAddress = new Uri(baseUri);

                //Http Post
                var postTask = client.PostAsJsonAsync<Genre>("PostGenre", genre);
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
                client.BaseAddress = new Uri(baseUri);

                //Http Get
                var responseTask = client.GetAsync("GetGenreById/id?id=" + id.ToString());
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
                client.BaseAddress = new Uri(baseUri);

                //Http Post
                var postTask = client.PutAsJsonAsync<Genre>("UpdateGenre/id?id=" + genre.IdGenre.ToString(), genre);
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
            //v2
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://localhost:7165/api/");
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //    HttpResponseMessage result = client.PutAsJsonAsync("Genres/" + genre.IdGenre.ToString(), genre).Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        ViewBag.msg = "Edit successfully";
            //        ModelState.Clear();
            //    }
            //    else
            //    {
            //        ViewBag.msg = "Something went wrong...";
            //        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator");

            //    }
            //}
            return View(genre);
        }
        #endregion

        #region "Delete Method"
        public IActionResult DeleteGenre(Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("DeleteGenre/id?id=" + id.ToString());
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
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage result = await client.GetAsync("GetGenreById/id?id=" + id.ToString());
                if (result.IsSuccessStatusCode)
                {
                    var resTask = result.Content.ReadAsStringAsync().Result;
                    genre = JsonConvert.DeserializeObject<Genre>(resTask);
                }
            }
            return View(genre);
        }
        #endregion

        #region "Search Method By Name"
        [HttpGet]
        public async Task<IActionResult> SearchGenreByName(string genreByname)
        {
            Genre genre = new Genre();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage result = await client.GetAsync("GetGenreByName/search=" + genreByname);
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
