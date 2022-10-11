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

        public ICollection<Movie>? Movies { get; set; }
    }
}
