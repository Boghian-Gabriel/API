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

        //inject the database context 
        private readonly ContextDB _dbContext;

        public MovieRepository(ContextDB dbContext)
        {
            _dbContext = dbContext;
        }

        //We will add CRUD action

        //1. GET Method:   api/Movies
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            if (_dbContext.Movies == null)
            {
                return NotFound();
            }

            //Include another table
            var rezult2 = await _dbContext.Movies
                                .Include(g => g.Genre)
                                //.Include(a => a.Actors)
                                .ToListAsync();          
  

            return rezult2;
        }

        //1. GET Method:   api/Movies/5
        public async Task<ActionResult<Movie>> GetMovie(Guid id)
        {
            if (_dbContext.Movies == null)
            {
                return NotFound();
            }

            //LINQ Method syntax
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

            //obs in Entity Framework, many-to-many relationship are automatically joined
            //tabela de jonctiune o vom vedea in baza de date, nu si in entity framework
            return await rezAnotherWay;
        }

        public async Task<IEnumerable<MovieActor>> GetMoviesWithActors()
        {
            /*
             This is because in Entity Framework, many-to-many relationship are automatically joined. 
             So, there is no need to join them again in the query. 
            As you can see the Entity data model designer below, both Departments and Rooms are not connected with a junction table, as it would with the database diagram.
             */
            var rezAnotherWay = (from m in _dbContext.Movies
                                 from a in _dbContext.Actors
                                 select new MovieActor()
                                 {
                                     MovieTitle = m.Title,
                                     MovieRealeaseDate = m.RealeseDate,
                                     FirstName = a.FirstName,
                                     LastName = a.LastName
                                 }).ToListAsync();

            //obs in Entity Framework, many-to-many relationship are automatically joined
            //tabela de jonctiune o vom vedea in baza de date, nu si in entity framework
            return await rezAnotherWay;
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
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
            //return await GetMovie(movie.IdRefGenre);
        }

        //put
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
