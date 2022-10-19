using API.ModelsDTO.ActorDto;
using API.ModelsDTO.GenreDto;

namespace API.ModelsDTO.MovieDto
{
    public class MoviesWithDetailsDTO
    {
        public string? Title { get; set; }
        public DateTime RealeseDate { get; set; }
        public GenreDTO? GenreName { get; set; }

        public ICollection<ActorAndAdressDTO>? Actors { get; set; }
    }
}
