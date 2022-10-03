using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdGenre { get; set; }

        [Required]
        public string? GenreName { get; set; }

        //mai multe filme pot avea acelasi gen
        // N:1 (Movies:Genre)
        public ICollection<Movie>? Movies { get; set; }
    }
}
