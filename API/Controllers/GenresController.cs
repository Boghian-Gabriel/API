using API.Model;
using API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            var rezult = await _genreRepository.GetGenres();

            return rezult;
        }

        //1. GET Method:   api/Movies/5

        [HttpGet("id")]
        public async Task<ActionResult<Genre>> GetGenre(Guid id)
        {
           var rezult = await _genreRepository.GetGenre(id);
            return rezult;
        }

        //post
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
            var rezult = await _genreRepository.PostGenre(genre);

            return rezult;
        }

        //PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(Guid id, Genre genre)
        {
            var rezult = await _genreRepository.UpdateGenre(id, genre);
            return rezult;
        }


        #region "Delete"
        //DELETE
        [HttpDelete("id")]
        [Authorize]
        public async Task<IActionResult> DeleteGenre(Guid id)
        {
            var rezult = await _genreRepository.DeleteGenre(id);

            return rezult;
        }
        #endregion
    }
}
