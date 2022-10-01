using API.Model;
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
        public readonly ContextDB _dbContext;

        public GenresController(ContextDB dbContext)
        {
            _dbContext = dbContext;
        }
        //We will add CRUD action

        //1. GET Method:   api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            if (_dbContext.Genres == null)
            {
                return NotFound();
            }

            //Include another table
            var rezult = await _dbContext.Genres.ToListAsync();

            return rezult;
        }

        //1. GET Method:   api/Movies/5

        [HttpGet("id")]
        public async Task<ActionResult<Genre>> GetGenre(Guid id)
        {
            if (_dbContext.Genres == null)
            {
                return NotFound();
            }

            var rezult = await _dbContext.Genres.FindAsync(id);

            if (rezult == null)
            {
                return NotFound();
            }
            return rezult;
        }

        //post
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
            _dbContext.Genres.Add(genre);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGenre), new { id = genre.IdGenre }, genre);
        }


        //PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(Guid id, Genre genre)
        {
            if (id != genre.IdGenre)
            {
                return BadRequest();
            }

            _dbContext.Entry(genre).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private bool GenreExists(Guid id)
        {
            return (_dbContext.Genres?.Any(e => e.IdGenre == id)).GetValueOrDefault();
        }

        #region "Delete"
        //DELETE
        [HttpDelete("id")]
        [Authorize]
        public async Task<IActionResult> DeleteGenre(Guid id)
        {
            if (_dbContext.Genres == null)
            {
                return NotFound();
            }

            var genre = await _dbContext.Genres.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            _dbContext.Genres.Remove(genre);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
        #endregion
    }
}
