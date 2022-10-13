using API.Model;

namespace API.ModelDTO
{
    public class GenreDTO
    {
        public string? GenreName { get; set; }

        public GenreDTO(Genre genre)
        {
            GenreName = genre.GenreName;
        }
    }
}
