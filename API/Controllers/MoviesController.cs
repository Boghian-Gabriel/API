using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using API.IRepository;
using API.UriApi;
using AutoMapper;
using API.ModelsDTO;

namespace API.Controllers
{
    #region "MoviesController class"
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MoviesController : Controller
    {
        #region "Properties"
        //inject the database context 
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        #endregion

        #region "Constructor"
        public MoviesController(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        #endregion

        #region "GetAllMovies"
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetAllMovies()
        {
            try
            {
                var results = await _movieRepository.GetMovies();
                if(results != null)
                {
                    var resMovieMapper = _mapper.Map<IEnumerable<MovieDTO>>(results);
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
        #endregion

        #region "GetMovie"
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
        #endregion

        #region "PostMovie"
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(InsertMovieDTO movieDTO)
        {
            var movie = _mapper.Map<Movie>(movieDTO);

            var result = await _movieRepository.PostMovie(movie);

            return result;
        }
        #endregion

        #region "UpdateMovie"
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(Guid id,  UpdateMovieDTO movieDTO)
        {
            var movie = _mapper.Map<Movie>(movieDTO);
            var result = await _movieRepository.UpdateMovie(id, movie);

            return result;
        }
        #endregion

        #region "Delete"
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            var result = await _movieRepository.DeleteMovie(id);

            return result;
        }
        #endregion

        #region "GetMoviesWithGenreName"
        [HttpGet]
        [Route("GetMoviesWithGenreName")]
        public async Task<IEnumerable<MovieGenre>> GetMoviesWithGenreName()
        {
            var results = await _movieRepository.GetMoviesWithGenres();

            return results;
        }
        #endregion

        #region "GetMovieWithDetails"
        [HttpGet("movieName")]
        //[Route("GetMoviesWithActors")]
        public async Task<ActionResult<IEnumerable<MoviesWithDetailsDTO>>> GetMovieWithDetails(string movieName, bool includeActors = false)
        {
           
            try
            {
                var result = await _movieRepository.GetMovieWithDetails(movieName, includeActors);
                if(result != null)
                {
                    var resMapper = _mapper.Map<IEnumerable<MoviesWithDetailsDTO>>(result);
                    return Ok(resMapper);
                }
                else
                {
                    return NotFound($"The movie with title: '{movieName}' was not found!");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database" + ex.Message);
            }
        }
        #endregion
    }
    #endregion
}
