using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using API.Model;
using Newtonsoft.Json;

namespace MovieWeb.Controllers
{
    public class MovieController : Controller
    {
        #region GetMethod
        public async Task<IActionResult> GetAllMovies()
        {
            //IEnumerable<Movie>? movies = null;

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://localhost:7165/api/");
            //    //HTTP GET
            //    var responseTask = client.GetAsync("Movies");
            //    responseTask.Wait();

            //    var result = responseTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        //Add NuGetPackages -> Microsoft.AspNet.WebApi.Client  for shorter method
            //        var readTask = result.Content.ReadAsAsync<IList<Movie>>();

            //        readTask.Wait();

            //        movies = readTask.Result;
            //    }
            //    else //web api sent error response
            //    {
            //        // log response status here....
            //        movies = Enumerable.Empty<Movie>();

            //        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator");
            //    }
            //}
           
            List<API.Model.Movie> movies = new List<API.Model.Movie>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage result = await client.GetAsync("api/Movies");
                if (result.IsSuccessStatusCode)
                {
                    var resTask = result.Content.ReadAsStringAsync().Result;
                    movies = JsonConvert.DeserializeObject<List<Movie>>(resTask);
                }
            }
            return View(movies);
        }
        #endregion

        #region "Post Method"
        public IActionResult CreateMovie()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateMovie(Movie movie)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/api/Movies");

                //Http Post
                var postTask = client.PostAsJsonAsync<Movie>("Movies", movie);
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

            return View(movie);
        }
        #endregion


        #region "Put Method"
    
        [HttpGet("id")]
        public async Task<ActionResult> EditMovie(Guid id)
        {
            //Movie? movie = null;

            //using(var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://localhost:7165/");

            //    //Http Get
            //    var responseTask = client.GetAsync("api/Movies/id?id=" + id.ToString());
            //    responseTask.Wait();

            //    var result = responseTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        var resTask = result.Content.ReadAsStringAsync().Result;
            //        movie = JsonConvert.DeserializeObject<Movie>(resTask);

            //    }
            //}
            Movie movie = new Movie();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage result = await client.GetAsync("api/Movies/id?id=" + id.ToString());
                if (result.IsSuccessStatusCode)
                {
                    var resTask = result.Content.ReadAsStringAsync().Result;
                    movie = JsonConvert.DeserializeObject<Movie>(resTask);
                }
            }
            return View(movie);
        }

        public IActionResult EditMovie(Movie movie)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/");

                //Http Post
                var postTask = client.PutAsJsonAsync<Movie>("api/Movies/"+movie.Id, movie);
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

            return View(movie);
        }
        #endregion

        #region "Delete Method"
        public IActionResult DeleteMovie(Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("api/Movies/id?id=" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAllMovies");
                }
            }

            return RedirectToAction("GetAllMovies");
        }
        #endregion

        #region "Details Method"
        [HttpGet]
        public async Task<IActionResult> GetMovie(Guid id)
        {
            Movie movie = new Movie();
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage result = await client.GetAsync("api/Movies/id?id=" + id.ToString());
                if (result.IsSuccessStatusCode)
                {
                    var resTask = result.Content.ReadAsStringAsync().Result;
                    movie = JsonConvert.DeserializeObject<Movie>(resTask);
                }
            }
            return View(movie);
        }
        #endregion
    }
}
