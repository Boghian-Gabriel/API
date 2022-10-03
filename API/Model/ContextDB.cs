using Microsoft.EntityFrameworkCore;

namespace API.Model
{
    /*
     The database context is the main class that coordinates 
     EF functionality for a data model. This class is created by deriving
     from the Microfost.EntityFrameworkCore.DbContext class.
     */
    public class ContextDB : DbContext
    {
        /*
         DbContextOptions<MovieContext> -> name DB
         */
        public ContextDB(DbContextOptions<ContextDB> option)
            : base(option)
        { 
        }
        //interesant ca pune la final !
        // fara ' ! ' => mesajul "Cannot convert null literal to non-nulable reference type"
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        /*
         In terminologia Entity Framework, 
        un set de entitati corespunde de obicei unui tabel al BD, 
        iar o entitate corespunde unui rand din tabel
         */

        /*
         In EntityFramework terminology, an entity set typically 
         corresponds to a database table and an entity corresponds to a row in the table.


        --
        The name of the connection string is passed into the context by calling a methodf
        on a DbContextOptions object. For local development, the ASP.NET Core
        configuration system reads the connectio nstring from the appsettings.json file.
         */


        /*
         asp.net corE is built with Dependecy Injection(DI).
       Services( such as the EF Core DB context) are registered with DI during application startup.
         */


        //Fluent API add default value from DB 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //populate default table Genre
            modelBuilder.Entity<Genre>().HasData(
                new Genre { IdGenre = Guid.Parse("D3DBC108-F55A-4ACB-28D7-08DAA4FF6E55"), GenreName = "Western", Movies = null },
                new Genre { IdGenre = Guid.Parse("7C6ABC48-36C0-4CEC-AED7-0A5161C22B0F"), GenreName = "Action", Movies = null },
                new Genre { IdGenre = Guid.Parse("133D337E-5A77-4107-89DE-210783900C1D"), GenreName = "Horror", Movies = null },
                new Genre { IdGenre = Guid.Parse("2B44EE54-2D50-437C-996D-40525E268186"), GenreName = "Drama", Movies = null },
                new Genre { IdGenre = Guid.Parse("7252F1BA-4885-411E-9AE2-5B8B801BE464"), GenreName = "Commedy", Movies = null },
                new Genre { IdGenre = Guid.Parse("1CE57EA2-8B3B-4074-9264-60A92872DD98"), GenreName = "Crime", Movies = null },
                new Genre { IdGenre = Guid.Parse("D5581B46-80E8-4BA0-B357-824130F9A779"), GenreName = "Historical", Movies = null },
                new Genre { IdGenre = Guid.Parse("917C3492-F531-44DE-A321-B9B17A7A90E4"), GenreName = "Science Fiction", Movies = null },
                new Genre { IdGenre = Guid.Parse("8650A45D-EE1D-46A4-8B7F-D8A8BAE09F83"), GenreName = "Science Fiction2 ", Movies = null }
                );

            //populate default table Movies
            modelBuilder.Entity<Movie>().HasData(
            new Movie { Id = Guid.NewGuid(), Title = "John Wick 1", RealeseDate = DateTime.Parse("2012-02-23"), IdRefGenre = Guid.Parse("7C6ABC48-36C0-4CEC-AED7-0A5161C22B0F") },
            new Movie { Id = Guid.NewGuid(), Title = "John Wick 2", RealeseDate = DateTime.Parse("207-02-14"), IdRefGenre = Guid.Parse("7C6ABC48-36C0-4CEC-AED7-0A5161C22B0F") },
            new Movie { Id = Guid.NewGuid(), Title = "Avatar 1", RealeseDate = DateTime.Parse("2008-02-15"), IdRefGenre = Guid.Parse("917C3492-F531-44DE-A321-B9B17A7A90E4") },
            new Movie { Id = Guid.NewGuid(), Title = "Avatar 2", RealeseDate = DateTime.Parse("2022-12-16"), IdRefGenre = Guid.Parse("917C3492-F531-44DE-A321-B9B17A7A90E4") },
            new Movie { Id = Guid.NewGuid(), Title = "Mr. Bean", RealeseDate = DateTime.Parse("2008-12-07"), IdRefGenre = Guid.Parse("7252F1BA-4885-411E-9AE2-5B8B801BE464") },
            new Movie { Id = Guid.NewGuid(), Title = "Film Example3", RealeseDate = DateTime.Parse("2010-06-01"), IdRefGenre = Guid.Parse("1CE57EA2-8B3B-4074-9264-60A92872DD98") },
            new Movie { Id = Guid.NewGuid(), Title = "Western P2", RealeseDate = DateTime.Parse("2008-04-23"), IdRefGenre = Guid.Parse("D3DBC108-F55A-4ACB-28D7-08DAA4FF6E55") },
            new Movie { Id = Guid.NewGuid(), Title = "Mascatul", RealeseDate = DateTime.Parse("2000-03-19"), IdRefGenre = Guid.Parse("133D337E-5A77-4107-89DE-210783900C1D") },
            new Movie { Id = Guid.NewGuid(), Title = "Film Example6", RealeseDate = DateTime.Parse("1934-01-07"), IdRefGenre = Guid.Parse("7C6ABC48-36C0-4CEC-AED7-0A5161C22B0F") },
            new Movie { Id = Guid.NewGuid(), Title = "Mascatul P2", RealeseDate = DateTime.Parse("1995-11-01"), IdRefGenre = Guid.Parse("133D337E-5A77-4107-89DE-210783900C1D") },
            new Movie { Id = Guid.NewGuid(), Title = "The horses", RealeseDate = DateTime.Parse("2007-08-02"), IdRefGenre = Guid.Parse("2B44EE54-2D50-437C-996D-40525E268186") }

             );
        }
    }
}
