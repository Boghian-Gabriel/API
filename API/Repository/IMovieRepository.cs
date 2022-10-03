using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Repository
{
    public interface IMovieRepository
    {
        Task<ActionResult<IEnumerable<Movie>>> GetMovies();
        Task<ActionResult<Movie>> GetMovie(Guid id);
        Task<ActionResult<Movie>> PostMovie(Movie movie);
        Task<IActionResult> UpdateMovie(Guid id, Movie movie);
        Task<IActionResult> DeleteMovie(Guid id);
    }
}
