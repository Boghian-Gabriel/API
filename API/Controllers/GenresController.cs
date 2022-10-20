using API.Model;
using API.Repository;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using API.ModelsDTO.GenreDto;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    #region "GenresControler class"
    [Route("api/[controller]/[Action]")]
    //[Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        #region "Properties"
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        #endregion

        #region "Constructor"
        public GenresController(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }
        #endregion

        #region "GetAllGenres"
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
        #endregion

        #region "GetGenreById"
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
        #endregion

        #region "GetGenreByName"
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
        #endregion

        #region "PostGenre"
        [HttpPost]
        public async Task<ActionResult> PostGenre(GenreDTO genreDTO)
        {
            ResponseMsg response = new ResponseMsg();
            try
            {
                var existGenre = await _genreRepository.GetGenreByName(genreDTO.GenreName);
                if(existGenre != null)
                {
                    ModelState.AddModelError("GenreName", "The genre name already exists");
                    return BadRequest(ModelState);
                }

                var genre = _mapper.Map<Genre>(genreDTO);
                //or manually mapper 
                //var genre = new Genre();
                //genre.GenreName = genreDTO.GenreName;

                response = await _genreRepository.PostGenre(genre);
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }
        #endregion

        #region "UpdateGenre"
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(Guid id, UpdateGenreDTO genreDTO)
        {
            try
            {
                if(id != genreDTO.IdGenre)
                {
                    ModelState.AddModelError("Id", $"The id: '{id}' and id:'{genreDTO.IdGenre}'  are not the same!");
                    return BadRequest(ModelState);
                }

                var genre = _mapper.Map<Genre>(genreDTO);
                if (genre != null)
                {
                    var result = await _genreRepository.UpdateGenre(genre.IdGenre, genre);
                    return StatusCode(StatusCodes.Status200OK, "The information has been updated");
                }
                else
                {
                    return NotFound($"The genres with id: ' {id} ' was not found!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   "Error" + ex);
            }
        }
        #endregion

        #region "Delete"
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteGenre(Guid id)
        {
            try
            {
                var resultIdToDelete = await _genreRepository.GetGenreById(id);

                if (resultIdToDelete == null)
                {
                    return NotFound($"Genre with Id: ' {id} ' not found!");
                }
                await _genreRepository.DeleteGenre(id);

                return Ok($"Genre with Id: ' {id} ' is deleted!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error" + ex.Message);
            }
        }
        #endregion

        #region "GetGenreWithMovies"
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
        #endregion
    }
    #endregion
}
