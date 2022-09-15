using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Movie
    {
        public Guid Id { get; set; }

        [StringLength(25, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }

        [StringLength(25, MinimumLength = 3)]
        [Required]
        public string? Genre { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RealeseDate { get; set; }

        /*  EF Core is an object-relational mapping (ORM)
            framework that simplifies the data access code.
        Model classes don't have any dependency on EF Core.
        They just define the properties of the data that will be stored in the database.
          

            Using ORM -> EF Core -> Code First Approach(Abordare)

        GO: Manage NuGet Packages
        ADD: Microsoft.EntityFrameworkCore
             Microsoft.EntityFrameworkCore.SqlServer
             Microsoft.EntityFrameworkCore.Tools
         */
    }
}
