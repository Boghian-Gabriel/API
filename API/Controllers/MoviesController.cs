using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using API.IRepository;
using API.UriApi;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MoviesController : Controller
    {
        //inject the database context 
        private IMovieRepository _movieRepository;
        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
        {
            var result = await _movieRepository.GetMovies();

            return result;
        }

        
        [HttpGet("id")]
        public async Task<ActionResult<Movie>> GetMovie(Guid id)
        {
            var result = await _movieRepository.GetMovie(id);

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            var result = await _movieRepository.PostMovie(movie);

            return result;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(Guid id, Movie movie)
        {
            var result = await _movieRepository.UpdateMovie(id, movie);

            return result;
        }

        #region "Delete"
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            var result = await _movieRepository.DeleteMovie(id);

            return result;
        }
        #endregion

        [HttpGet]
        [Route("GetMoviesWithGenreName")]
        public async Task<IEnumerable<MovieGenre>> GetMoviesWithGenreName()
        {
            var result = await _movieRepository.GetMoviesWithGenres();

            return result;
        }


        [HttpGet]
        [Route("GetMoviesWithActors")]
        public async Task<IEnumerable<MovieActor>> GetMoviesWithActors()
        {
            var result = await _movieRepository.GetMoviesWithActors();

            return result;
        }
    }
}
