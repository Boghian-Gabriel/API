using API.Model;
using API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Xml.Linq;
using API.ModelDTO;

namespace API.Controllers
{
    [Route("api/[controller]/[Action]")]
    //[Route("api/[controller]")]
    [ApiController]
    public class GenresController : Controller
    {
        private IGenreRepository _genreRepository;

        public GenresController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        [HttpGet]
        public async Task<ActionResult<GenreDTO>> GetAllGenres()
        {
            try
            {
                var result = await _genreRepository.GetGenres();
                if (result != null)
                {
                    return Ok(result);
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


        [HttpGet("id")]
        public async Task<ActionResult<Genre>> GetGenreById(Guid id)
        {
            try
            {
                var result = await _genreRepository.GetGenreById(id);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound($"The genre with id: ' {id} ' was not foud!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database" + ex);
            }
        }

        [HttpGet("searchByName")]
        public async Task<ActionResult<Genre>> GetGenreByName(string searchByName)
        {
            try
            {
                var result = await _genreRepository.SearchGenreByName(searchByName);

                if(result != null) 
                { 
                    return Ok(result); 
                } else
                {
                    return NotFound($"The genre with name: ' {searchByName} ' was not foud!");
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

        [HttpPut("id")]
        public async Task<IActionResult> UpdateGenre(Guid id, Genre genre)
        {
            var result = await _genreRepository.UpdateGenre(id, genre);
            return result;
        }

        #region "Delete"
        [HttpDelete("id")]
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
    }
}
