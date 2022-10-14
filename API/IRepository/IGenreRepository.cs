using API.Model;
using API.ModelDTO;
using API.ViewModel_BindModel_;
using Microsoft.AspNetCore.Mvc;

namespace API.Repository
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetGenres();
        Task<Genre> GetGenreById(Guid id);
        Task<Genre> SearchGenreByName(string name);
        Task<Genre> GetGenreByName(string name);
        Task<IEnumerable<GenreWithMovies>> GetGenreWithMovies();
        Task<ResponseMsg> PostGenre(Genre genre);
        Task<IActionResult> UpdateGenre(Guid id, Genre genre);
        Task DeleteGenre(Guid id);
    }
}
