
namespace API.ModelsDTO
{
    public class MoviesWithDetailsDTO
    {
        public string? Title { get; set; }
        public DateTime RealeseDate { get; set; }
        public GenreDTO? Genre { get; set; }

        public ICollection<ActorAndAdressDTO> Actors { get; set; }
    }
}
