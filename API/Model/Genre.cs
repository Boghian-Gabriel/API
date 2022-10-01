using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Genre
    {
        [Key]
        public Guid IdGenre { get; set; }

        [Required]
        public string? GenreName { get; set; }

        public ICollection<Movie>? Movies { get; set; }
    }
}
