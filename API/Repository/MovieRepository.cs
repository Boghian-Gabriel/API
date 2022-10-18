using API.Context;
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

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var results = await _dbContext.Movies.ToListAsync();
            return results;
        }

        public async Task<Movie> GetMovie(Guid id)
        {
            //LINQ Method syntax
            var movie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
            return movie;
        }

        public async Task<IEnumerable<MovieGenre>> GetMoviesWithGenres()
        {
            //Linq query syntax
            var resAnotherWay = (from m in _dbContext.Movies
                                 join g in _dbContext.Genres on m.IdRefGenre equals g.IdGenre
                                 select new MovieGenre
                                 {
                                     //MovieId = m.Id,
                                     MovieTitle = m.Title,
                                     MovieRealeaseDate = m.RealeseDate,
                                     GenreName = g.GenreName

                                 }).ToListAsync();

            return await resAnotherWay;
        }

        public async Task<IEnumerable<Movie>> GetMovieWithDetails(string movieName, bool includeActors = false)
        {

            IQueryable<Movie> queryResults = _dbContext.Movies
                                        .Include(g => g.Genre);

            if (includeActors)
            {
                queryResults = queryResults.Include(a => a.Actors)
                                    .ThenInclude(ad => ad.Adress);
            }

            queryResults = queryResults.Where(m => m.Title.Equals(movieName));

            return await queryResults.ToListAsync();
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
