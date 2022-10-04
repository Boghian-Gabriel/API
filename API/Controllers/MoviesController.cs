using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using API.IRepository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    //Acest atribut indica faptul ca controlul raspunde la solicitarile API-ului web
    [ApiController]
    public class MoviesController : Controller
    {
        //inject the database context 
        private IMovieRepository _movieRepository;
        //Dependency Injection => atunci cand  este nevoie se instantiaza clasa 
        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        //We will add CRUD action

        //1. GET Method:   api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            var rezult = await _movieRepository.GetMovies();

            return rezult;
        }

        //1. GET Method:   api/Movies/5
        
        [HttpGet("id")]
        public async Task<ActionResult<Movie>> GetMovie(Guid id)
        {
            var rezult = await _movieRepository.GetMovie(id);

            return rezult;
        }

        //post
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            var rezult = await _movieRepository.PostMovie(movie);

            return rezult;
        }


        //PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(Guid id, Movie movie)
        {
            var rezult = await _movieRepository.UpdateMovie(id, movie);

            return rezult;
        }

        #region "Delete"
        //DELETE
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            var rezult = await _movieRepository.DeleteMovie(id);

            return rezult;
        }
        #endregion
    }
}
