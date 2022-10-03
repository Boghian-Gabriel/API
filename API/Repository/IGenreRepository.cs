using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Repository
{
    public interface IGenreRepository
    {
        Task<ActionResult<IEnumerable<Genre>>> GetGenres();
        Task<ActionResult<Genre>> GetGenre(Guid id);
        Task<ActionResult<Genre>> PostGenre(Genre genre);
        Task<IActionResult> UpdateGenre(Guid id, Genre genre);
        Task<IActionResult> DeleteGenre(Guid id);
    }
}
