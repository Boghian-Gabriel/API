using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Actor
    {
        public Guid Id { get; set; }

        [StringLength(25, MinimumLength = 3)]
        [Required]
        public string? FirsName { get; set; }

        [StringLength(25, MinimumLength = 3)]
        [Required]
        public string? LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Date of birdh")]
        public DateTime Dof { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? Email { get;set; }   

        //Navigation Properties
        public List<MovieActor> MovieActors { get; set; }


    }
}
