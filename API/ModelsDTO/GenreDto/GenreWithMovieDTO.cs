using API.ModelsDTO.MovieDto;
namespace API.ModelsDTO.GenreDto
{
    public class GenreWithMovieDTO : GenreDTO
    {
        public ICollection<MovieDTO>? Movies { get; set; }
    }
}
