using API.IRepository;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class GenreRepository : Controller, IGenreRepository
    {

        private readonly ContextDB _dbContext;
        //constructor
        public GenreRepository(ContextDB dbContext)
        {
            _dbContext = dbContext;
        }

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

        public async Task<ActionResult<Genre>> GetGenreById(Guid id)
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

        public async Task<ActionResult<Genre>> GetGenreByName(string name)
        {
            if (_dbContext.Genres == null)
            {
                return NotFound();
            }
            List<Genre> genres = new List<Genre>();
            genres = await _dbContext.Genres.ToListAsync();
            var rezult = genres.Where(p => p.GenreName == name).FirstOrDefault();
            //var rezult = await _dbContext.Genres.FinWdAsync(name);

            if (rezult == null)
            {
                return NotFound();
            }
            return rezult;
        }

        //post
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
            _dbContext.Genres.Add(genre);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGenreById), new { id = genre.IdGenre }, genre);
        }


        //PUT
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
