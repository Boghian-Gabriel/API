using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using API.IRepository;
using API.UriApi;
using API.ModelDTO;
using AutoMapper;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MoviesController : Controller
    {
        //inject the database context 
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MoviesController(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetAllMovies()
        {
            try
            {
                var result = await _movieRepository.GetMovies();
                var resMovieMapper = _mapper.Map<IEnumerable<MovieDTO>>(result);
                if(resMovieMapper != null)
                {
                    return Ok(resMovieMapper);
                }
                else
                {
                    return NotFound("There is no information!");
                }

            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    "Error retrieving data from the database" + ex.Message);
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetMovie(Guid id)
        {
            try
            {
                var result = await _movieRepository.GetMovie(id);
                var resMovieMapper = _mapper.Map<MovieDTO>(result);
                if(resMovieMapper == null)
                {
                    return NotFound($"The movie with id: '{id}' was not found");
                }
                else
                {
                    return Ok(resMovieMapper);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    "Error retrieving data from the database" + ex.Message);
            }

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
        [HttpDelete("{id}")]
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


        [HttpGet("{movieId}")]
        //[Route("GetMoviesWithActors")]
        public async Task<ActionResult<MoviesWithDetails>> GetMovieWithDetails(Guid movieId)
        {
           
            try
            {
                var result = await _movieRepository.GetMovieWithDetails(movieId);
                var resMapper = _mapper.Map<MoviesWithDetails>(result);
                if(resMapper != null)
                {
                    return Ok(resMapper);
                }
                else
                {
                    return NotFound($"The movie with id: '{movieId}' was not found!");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database" + ex.Message);
            }
        }
    }
}
