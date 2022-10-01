using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Genre
    {
        [Key]
        public Guid IdGenre { get; set; }

        [Required]
        public string? GenreName { get; set; }

        //mai multe filme pot avea acelasi gen
        public ICollection<Movie>? Movies { get; set; }
    }
}
