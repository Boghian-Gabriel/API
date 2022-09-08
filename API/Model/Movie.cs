namespace API.Model
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
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
