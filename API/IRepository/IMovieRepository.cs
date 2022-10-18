using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.IRepository
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<IEnumerable<MovieGenre>> GetMoviesWithGenres();
        Task<IEnumerable<Movie>> GetMovieWithDetails(string  movieName, bool includeActor = false);
        Task<Movie> GetMovie(Guid id);
        Task<ActionResult<Movie>> PostMovie(Movie movie);
        Task<IActionResult> UpdateMovie(Guid id, Movie movie);
        Task<IActionResult> DeleteMovie(Guid id);
    }
}
