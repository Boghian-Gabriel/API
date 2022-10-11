using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    public class Movie
    {
        public Movie() => this.Actors = new HashSet<Actor>();

        [Key]
        public Guid Id { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RealeseDate { get; set; }

        [ForeignKey("Genre")]
        public Guid? IdRefGenre { get; set; }
        public Genre? Genre { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }
    }
}
