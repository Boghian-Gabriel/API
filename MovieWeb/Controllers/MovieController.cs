using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using MovieWeb.Models;

namespace MovieWeb.Controllers
{
    public class MovieController : Controller
    {
        #region GetMethod
        public IActionResult GetAllMovies()
        {
            IEnumerable<Movie>? movies = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Movies");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    //Add NuGetPackages -> Microsoft.AspNet.WebApi.Client  for shorter method
                    var readTask = result.Content.ReadAsAsync<IList<Movie>>();

                    readTask.Wait();

                    movies = readTask.Result;
                }
                else //web api sent error response
                {
                    // log response status here....
                    movies = Enumerable.Empty<Movie>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator");
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
                    return RedirectToAction("GetAllMovies");
                }
            }
            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator");

            return View(movie);
        }
        #endregion


        #region "Put Method"
        public IActionResult EditMovie(int id)
        {
            Movie? movie = null;

            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/api/");

                //Http Get
                var responseTask = client.GetAsync("Movies?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Movie>();
                    readTask.Wait();

                    movie = readTask.Result;
                }
            }

            return View(movie);
        }
        #endregion

        #region "Delete Method"
        public IActionResult Delete()
        {
            return View();
        }
        #endregion

        #region "Details Method"
        public IActionResult Details()
        {
            return View();
        }
        #endregion
    }
}
