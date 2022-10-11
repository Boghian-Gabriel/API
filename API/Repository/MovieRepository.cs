using API.IRepository;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Web.Http;

namespace API.Repository
{
    public class MovieRepository : Controller, IMovieRepository
    {

        private readonly ContextDB _dbContext;

        public MovieRepository(ContextDB dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            if (_dbContext.Movies == null)
            {
                return NotFound();
            }

            var result2 = await _dbContext.Movies
                                .Include(g => g.Genre)
                                //.Include(a => a.Actors)
                                .ToListAsync();          
  

            return result2;
        }

        //1. GET Method:   api/Movies/{GUID}
        public async Task<ActionResult<Movie>> GetMovie(Guid id)
        {
            if (_dbContext.Movies == null)
            {
                return NotFound();
            }

            //LINQ Method syntax
            var movie = await _dbContext.Movies
               .Include(m => m.Genre)
               .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }

        public async Task<IEnumerable<MovieGenre>> GetMoviesWithGenres()
        {
            //Linq query syntax
            var rezAnotherWay = (from m in _dbContext.Movies
                                 join g in _dbContext.Genres on m.IdRefGenre equals g.IdGenre
                                 select new MovieGenre
                                 {
                                     MovieId = m.Id,
                                     MovieTitle = m.Title,
                                     MovieRealeaseDate = m.RealeseDate,
                                     GenreName = g.GenreName

                                 }).ToListAsync();

            return await rezAnotherWay;
        }

        public async Task<IEnumerable<MovieActor>> GetMoviesWithActors()
        {
            var rezAnotherWay = (from m in _dbContext.Movies
                                 from a in _dbContext.Actors
                                 select new MovieActor()
                                 {
                                     MovieTitle = m.Title,
                                     MovieRealeaseDate = m.RealeseDate,
                                     FirstName = a.FirstName,
                                     LastName = a.LastName
                                 }).ToListAsync();

            return await rezAnotherWay;
        }


        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }


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
