using API.Model;
using API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Xml.Linq;

namespace API.Controllers
{
    [Route("api/[controller]/[Action]")]
    //[Route("api/[controller]")]
    [ApiController]
    public class GenresController : Controller
    {
        private IGenreRepository _genreRepository;

        //Dependency Injection => atunci cand  este nevoie se instantiaza clasa 
        public GenresController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        //We will add CRUD action

        //1. GET Method:   api/Movies
        [HttpGet]
        public async Task<ActionResult<Genre>> GetAllGenres()
        {
            try
            {
                var rezult = await _genreRepository.GetGenres();
                if (rezult != null)
                {
                    return Ok(rezult);
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

        //1. GET Method:   api/Movies/5

        [HttpGet("id")]
        public async Task<ActionResult<Genre>> GetGenreById(Guid id)
        {
            try
            {
                var rezult = await _genreRepository.GetGenreById(id);

                if (rezult != null)
                {
                    return Ok(rezult);
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

        //ceea ce trimit prin parametru la functie trebuie sa fie la fel numele cu parametrul de la HttpGet
        [HttpGet("searchByName")]
        public async Task<ActionResult<Genre>> GetGenreByName(string searchByName)
        {
            try
            {
                var rezult = await _genreRepository.SearchGenreByName(searchByName);

                if(rezult != null) 
                { 
                    return Ok(rezult); 
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

        //post
        [HttpPost]
        // [Authorize]
        /*
        example post API  in Swagger or PostMan
        {
            "GenreName": "Action X2",
            "Movies": []
        }
        */
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

        //PUT
        [HttpPut("id")]
        //[Authorize]
        /*
         example update API

         */
        public async Task<IActionResult> UpdateGenre(Guid id, Genre genre)
        {
            var rezult = await _genreRepository.UpdateGenre(id, genre);
            return rezult;
        }

        #region "Delete"
        //DELETE
        [HttpDelete("id")]
        //auth
        //[Authorize]
        public async Task<IActionResult> DeleteGenre(Guid id)
        {
            try
            {
                var rezultIdToDelete = await _genreRepository.GetGenreById(id);

                if (rezultIdToDelete == null)
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
