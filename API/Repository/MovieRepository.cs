using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class MovieRepository : Controller, IMovieRepository
    {

        //inject the database context 
        private readonly ContextDB _dbContext;

        public MovieRepository(ContextDB dbContext)
        {
            _dbContext = dbContext;
        }

        //We will add CRUD action

        //1. GET Method:   api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            if (_dbContext.Movies == null)
            {
                return NotFound();
            }

            //Include another table
            var rezult = await _dbContext.Movies.Include(g => g.Genre).ToListAsync();

            return rezult;
        }

        //1. GET Method:   api/Movies/5

        [HttpGet("id")]
        public async Task<ActionResult<Movie>> GetMovie(Guid id)
        {
            if (_dbContext.Movies == null)
            {
                return NotFound();
            }

            //var movie =  await _dbContext.Movies.FindAsync(id);
            var movie = await _dbContext.Movies
               .Include(m => m.Genre)
               .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }

        //post
        /*
         Post movie

        {
          "Title": "Ceva Nou v2.0",
          "RealeseDate": "2022-10-03",
          "IdRefGenre": "d5581b46-80e8-4ba0-b357-824130f9a779",
          "Genre": {
            "IdGenre": "d5581b46-80e8-4ba0-b357-824130f9a679",
            "GenreName": "Historicaal",
            "Movies": []
            }
        }
         */
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovie), new { id = movie.IdRefGenre }, movie);

            //return await GetMovie(movie.IdRefGenre);
        }


        //PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(Guid id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(movie).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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

        private bool MovieExists(Guid id)
        {
            return (_dbContext.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        #region "Delete"
        //DELETE
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            if (_dbContext.Movies == null)
            {
                return NotFound();
            }

            var movie = await _dbContext.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
        #endregion
    }
}
