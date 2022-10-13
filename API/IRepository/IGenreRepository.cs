using API.Model;
using API.ModelDTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Repository
{
    public interface IGenreRepository
    {
        Task<IEnumerable<GenreDTO>> GetGenres();
        Task<Genre> GetGenreById(Guid id);
        Task<IEnumerable<Genre>> SearchGenreByName(string name);
        Task<Genre> GetGenreByName(string name);
        Task<ResponseMsg> PostGenre(Genre genre);
        Task<IActionResult> UpdateGenre(Guid id, Genre genre);
        Task DeleteGenre(Guid id);
    }
}
