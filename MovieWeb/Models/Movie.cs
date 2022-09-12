namespace MovieWeb.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public DateTime RealeseDate { get; set; }
    }
}
