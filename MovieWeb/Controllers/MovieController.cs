﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using API.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Linq;
using PagedList;
using AspNetCore.Reporting;

namespace MovieWeb.Controllers
{
    public class MovieController : Controller
    {
        //for reporting
        public readonly IWebHostEnvironment _webHostEnvironment;
        public MovieController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        public IActionResult Report()
        {
            return View();
        }
        public IActionResult PrintReport()
        {
            string mintype = "";
            int extension = 1;
            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\RptMovies.rdlc";
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("rp1", "Raport with movies details");

            LocalReport localReport = new LocalReport(path);
            var result = localReport.Execute(RenderType.Pdf, extension, param, mintype);

            return File(result.MainStream, "application/pdf");
        }

        #region GetMethod
        public async Task<IActionResult> GetAllMovies(string sortOrder, string currentFilter, string searchString, int? page)
        {
            #region "Method1"
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
            #endregion
            /*
             The three ViewBag variables are used so that the view can configure the column heading hyperlinks with the appropriate query string values:
             */
            ViewBag.CurrentSort = sortOrder;
            ViewBag.TitleSortParam = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.GenreSortParam = String.IsNullOrEmpty(sortOrder) ? "genre_desc" : "genre_asc";
            ViewBag.DateSortParam = sortOrder == "Date" ? "date_desc" : "Date";           
            
            List<Movie> movies = new List<Movie>();
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

            //pagination
            if(searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

             var moviesss = from m in movies
                            select m;

            //searching
            if (!String.IsNullOrEmpty(searchString))
            {
                moviesss = moviesss.Where(m => m.Title.Contains(searchString)
                                       || m.Genre.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "title_desc":
                    moviesss = moviesss.OrderByDescending(m => m.Title);
                    break;
                case "genre_desc":
                    moviesss = moviesss.OrderByDescending(m => m.Genre);
                    break;
                case "genre_asc":
                    moviesss = moviesss.OrderBy(m => m.Genre);
                    break;
                case "date_desc":
                    moviesss = moviesss.OrderByDescending(m => m.RealeseDate);
                    break;
                case "Date":
                    moviesss = moviesss.OrderBy(m => m.RealeseDate);
                    break;
                default:
                    moviesss = moviesss.OrderBy(m => m.Title);
                    break;
            }

            int pageSize = 3;
            /*
           The null-coalescing operator ?? returns the value of its left-hand operand if it isn't null; 
           otherwise, it evaluates the right-hand operand and returns its result. The ?? operator doesn't evaluate its right-hand operand if the left-hand operand evaluates to non-null.
           */
            int pageNumber = (page ?? 1);
            //return View(moviesss.ToPagedList(pageNumber,pageSize));
            return View(moviesss);
        }
        #endregion

        #region "Post Method"
        public IActionResult CreateMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMovie(Movie movie)
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
        [HttpGet]
        public async Task<ActionResult> EditMovieAsync(Guid id)
        {
            Movie movie = new Movie();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/");

                //Http Get
                var responseTask = client.GetAsync("api/Movies/id?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var resTask = result.Content.ReadAsStringAsync().Result;
                    movie = JsonConvert.DeserializeObject<Movie>(resTask);
                }
            }

            #region "Method 2"
            //    using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://localhost:7165/");
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //    HttpResponseMessage result = await client.GetAsync("api/Movies/id?id=" + id.ToString());
            //    if (result.IsSuccessStatusCode)
            //    {
            //        var resTask = result.Content.ReadAsStringAsync().Result;
            //        movie = JsonConvert.DeserializeObject<Movie>(resTask);
            //    }
            //}
            #endregion
            return View(movie);
        }

        public IActionResult EditMovie(Movie movie)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/");

                //Http Post
                var postTask = client.PutAsJsonAsync<Movie>("api/Movies/" + movie.Id.ToString(), movie);
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
            #region "Method 2" 
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://localhost:7165/");
            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //    HttpResponseMessage result = client.PutAsJsonAsync("api/Movies/" + movie.Id.ToString(), movie).Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        ViewBag.msg = "Edit successfully";
            //        ModelState.Clear();
            //    }
            //    else
            //    {
            //        ViewBag.msg = "Something went wrong...";
            //    }
            //}
            #endregion

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
