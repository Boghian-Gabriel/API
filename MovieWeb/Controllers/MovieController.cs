using Microsoft.AspNetCore.Mvc;
using MovieWeb.Models;

namespace MovieWeb.Controllers
{
    public class MovieController : Controller
    {
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
    }
}
