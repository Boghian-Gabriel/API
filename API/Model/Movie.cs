﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RealeseDate { get; set; }

        //reference to Genre table
        //IdRefGenre is FK in Movie and OK in Genre
        [ForeignKey("Genre")]
        public Guid IdRefGenre { get; set; }
        public Genre Genre { get; set; }

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
