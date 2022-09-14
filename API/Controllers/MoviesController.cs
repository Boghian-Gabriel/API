using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]

    //Acest atribut indica faptul ca controlul raspunde la solicitarile API-ului web
    [ApiController]
    public class MoviesController : Controller
    {
        //inject the database context 
        private readonly MovieDB _dbContext;

        public MoviesController(MovieDB dbContext)
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

            return await _dbContext.Movies.ToListAsync();
        }


        //1. GET Method:   api/Movies/5
        
        [HttpGet("id")]
        public async Task<ActionResult<Movie>> GetMovie(Guid id)
        {
            if (_dbContext.Movies == null)
            {
                return NotFound();
            }

            var movie =  await _dbContext.Movies.FindAsync(id);
        
            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        //post
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }


        //PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(Guid id, Movie movie)
        {
            if( id != movie.Id)
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
            if(_dbContext.Movies == null)
            {
                return NotFound();
            }

            var movie = await _dbContext.Movies.FindAsync(id);
            if(movie == null)
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
