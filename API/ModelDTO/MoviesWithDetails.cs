using API.Model;

namespace API.ModelDTO
{
    public class MoviesWithDetails
    {
        public string? Title { get; set; }
        public DateTime RealeseDate { get; set; }

        public ICollection<ActorAndAdressDTO> Actors { get; set; }
    }
}
