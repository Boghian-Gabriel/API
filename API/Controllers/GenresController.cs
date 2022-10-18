using API.Model;
using API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Xml.Linq;
using API.ModelDTO;
using AutoMapper;
using API.ViewModel_BindModel_;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]/[Action]")]
    //[Route("api/[controller]")]
    [ApiController]
    public class GenresController : Controller
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        public GenresController(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<GenreDTO>> GetAllGenres()
        {
            try
            {
                var results = await _genreRepository.GetGenres();
                if (results != null)
                {
                    var resMapper = _mapper.Map<IEnumerable<GenreDTO>>(results);
                    return Ok(resMapper);
                }
                else
                {
                    return NotFound();
                }

            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database" + ex);
            }
            
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDTO>> GetGenreById(Guid id)
        {
            try
            {
                //GET THE INFORMATION FROM THE DATABASE!
                var result = await _genreRepository.GetGenreById(id);

                if (result != null)
                {
                    //I map to the GenreDTO table to provide to the client
                    var resGenreMapper = _mapper.Map<GenreDTO>(result);
                    return Ok(resGenreMapper);
                }
                else
                {
                    return NotFound($"The genre with id: ' {id} ' was not found!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database" + ex);
            }
        }

        [HttpGet("searchByName")]
        public async Task<ActionResult<GenreDTO>> GetGenreByName(string searchByName)
        {
            try
            {
                var result = await _genreRepository.SearchGenreByName(searchByName);
                if(result != null) 
                {
                    var resGenreMapper = _mapper.Map<GenreDTO>(result);
                    return Ok(resGenreMapper); 
                } else
                {
                    return NotFound($"The genre with name: ' {searchByName} ' was not found!");
                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database" + ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostGenre(Genre genre)
        {
            ResponseMsg response = new ResponseMsg();
            try
            {
                var isGenreExist = await _genreRepository.GetGenreByName(genre.GenreName);
                if(isGenreExist != null)
                {
                    ModelState.AddModelError("GenreName", "Genre name already exist");
                    return BadRequest(ModelState);
                }
                response = await _genreRepository.PostGenre(genre);

            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(Guid id, Genre genre)
        {
            var result = await _genreRepository.UpdateGenre(id, genre);
            return result;
        }

        #region "Delete"
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> DeleteGenre(Guid id)
        {
            try
            {
                var resultIdToDelete = await _genreRepository.GetGenreById(id);

                if (resultIdToDelete == null)
                {
                    return NotFound($"Genre with Id={id} not found!");
                }

                await _genreRepository.DeleteGenre(id);

                return Ok($"Genre with Id={id} is deleted!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database" + ex);
            }
        }
        #endregion

        [HttpGet("{genreId}")]
        //[Route("GetGenreWithDetails")]
        public async Task<ActionResult<GenreWithMovieDTO>> GetGenreWithMovies(Guid genreId)
        {
            try
            {
                var results = await _genreRepository.GetGenreWithMovies(genreId);
                if (results != null)
                {
                    var resGenreMapper = _mapper.Map<GenreWithMovieDTO>(results);
                    return Ok(resGenreMapper);
                }
                else
                {
                    return NotFound($"The genres was not found!");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database" + ex);
            }
        }
    }
}
