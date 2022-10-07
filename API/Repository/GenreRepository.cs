using API.IRepository;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class GenreRepository : Controller, IGenreRepository
    {
        //connectio to DB
        private readonly ContextDB _dbContext;
        //constructor
        public GenreRepository(ContextDB dbContext)
        {
            
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Genre>> GetGenres()
        {

            var rezult = await _dbContext.Genres.ToListAsync();

            return rezult;
        }

        //1. GET Method:   api/Movies/5

        public async Task<Genre> GetGenreById(Guid id)
        {
            var rezult = await _dbContext.Genres.FindAsync(id);

            return rezult;
        }

        public async Task<IEnumerable<Genre>> SearchGenreByName(string name)
        {
            IQueryable<Genre> genres = _dbContext.Genres;
            //var rezult = await _dbContext.Genres.FindAsync(name);
            //la inceput intra cu genrename == null apoi caut eu si inta in genrename == name (?) in verificare
            genres = genres.Where(p => p.GenreName == name || p.GenreName == null);

            return await genres.ToListAsync();
        }

        //post
        public async Task<ResponseMsg> PostGenre(Genre genre)
        {
            ResponseMsg response = new ResponseMsg();
            response.isSuccess = true;
            response.Message = "Success";
            try
            {
                _dbContext.Genres.Add(genre);
                await _dbContext.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;
            }

            return response;
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
        public async Task DeleteGenre(Guid id)
        {
            var genreDelete = await _dbContext.Genres.FindAsync(id);

            if (genreDelete != null)
            {
                _dbContext.Genres.Remove(genreDelete);
                await _dbContext.SaveChangesAsync();
            }
        }
        #endregion

        public async Task<Genre> GetGenreByName(string name)
        {
            var rezult = await _dbContext.Genres.Where(g=> g.GenreName == name).FirstOrDefaultAsync();

            return rezult;
        }
    }
}
