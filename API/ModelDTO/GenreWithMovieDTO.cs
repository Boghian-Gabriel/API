using API.Model;

namespace API.ModelDTO
{
    public class GenreWithMovieDTO : GenreDTO
    {
        public ICollection<MovieDTO>? Movies { get; set; }
    }
}
