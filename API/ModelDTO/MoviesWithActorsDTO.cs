using API.Model;

namespace API.ModelDTO
{
    public class MoviesWithActorsDTO
    {
        public string? Title { get; set; }
        public DateTime RealeseDate { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public virtual ICollection<Actor>? Actors { get; set; }
    }
}
