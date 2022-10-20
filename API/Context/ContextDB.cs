using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    #region "ContextDB class"
    public class ContextDB : DbContext
    {
        #region "constructor"
        public ContextDB(DbContextOptions<ContextDB> option)
            : base(option)
        {
        }
        #endregion

        #region "properties"
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Actor> Actors { get; set; } = null!;
        public DbSet<ActorAdress> ActorAdress { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        #endregion

        #region "OnModelCreating"
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
                new Genre { IdGenre = Guid.Parse("7252F1BA-4885-411E-9AE2-5B8B801BE464"), GenreName = "Comedy", Movies = null },
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

            //populate default actor table
            modelBuilder.Entity<Actor>().HasData(
            new Actor { ActorId = Guid.Parse("2771A534-6DDF-440C-AA65-06363EE53892"), FirstName = "Johnny", LastName = "Depp" },
            new Actor { ActorId = Guid.Parse("17885E02-8E62-4E12-8819-064EB88732C3"), FirstName = "Vin", LastName = "Vin Diesel" },
            new Actor { ActorId = Guid.Parse("C1E8C4B6-1BA4-4753-B4CE-4E3745D686A8"), FirstName = "Murphy", LastName = "Eddie" },
            new Actor { ActorId = Guid.Parse("AE83328F-B078-4ED0-8FC4-769A29A99E77"), FirstName = "Schwarzenegger", LastName = "Arnold" },
            new Actor { ActorId = Guid.Parse("E742BE86-5178-484C-82F5-84DEF99225EC"), FirstName = "Cage", LastName = "Nicolas" },
            new Actor { ActorId = Guid.Parse("F41A8A8C-8A55-4F19-8FB3-885CD898ACEB"), FirstName = "Statham", LastName = "Jason Statham" },
            new Actor { ActorId = Guid.Parse("08992976-E714-4C2C-9F07-902CD74D62AB"), FirstName = "Keanu", LastName = "Charles Reeves" },
            new Actor { ActorId = Guid.Parse("53217A0C-D050-4AD6-A70B-A0B8552DA9C8"), FirstName = "Dwayne", LastName = "Johnson" },
            new Actor { ActorId = Guid.Parse("82107BD1-C4C2-4EAF-B0F6-B4B9D0D354A4"), FirstName = "Jackie", LastName = "Chan" },
            new Actor { ActorId = Guid.Parse("7E7ADA24-4C7A-4127-BCB7-F3A47907BFE2"), FirstName = "Van Damme", LastName = "Jean-Claude" }
                );

            //populate default actoradress table
            modelBuilder.Entity<ActorAdress>().HasData(
                new ActorAdress { ActorAdressId = Guid.Parse("2771A534-6DDF-440C-AA65-06363EE53892"), Adress1 = "Florida str.Florida", Adress2 = "Miami str Miami", City = "New York", ZipCode = 254758, Country = "Country2" },
                new ActorAdress { ActorAdressId = Guid.Parse("17885E02-8E62-4E12-8819-064EB88732C3"), Adress1 = "London", Adress2 = "Lewisham", City = "Doncaster", ZipCode = 193256, Country = "United Kingdom" },
                new ActorAdress { ActorAdressId = Guid.Parse("C1E8C4B6-1BA4-4753-B4CE-4E3745D686A8"), Adress1 = "Torquay 1", Adress2 = "Torquay 2", City = "Torquay", ZipCode = 462896, Country = "United Kingdom" },
                new ActorAdress { ActorAdressId = Guid.Parse("AE83328F-B078-4ED0-8FC4-769A29A99E77"), Adress1 = "Birmingham", Adress2 = "Birmingham 2", City = "Lancashire", ZipCode = 189345, Country = "United Kingdom" },
                new ActorAdress { ActorAdressId = Guid.Parse("E742BE86-5178-484C-82F5-84DEF99225EC"), Adress1 = "Colchester", Adress2 = "Leeds 2", City = "Lancashire1", ZipCode = 192675, Country = "United Kingdom" },
                new ActorAdress { ActorAdressId = Guid.Parse("F41A8A8C-8A55-4F19-8FB3-885CD898ACEB"), Adress1 = "Canterbury", Adress2 = "Benfleet 1", City = "Lancashire 12", ZipCode = 715289, Country = "United Kingdom" },
                new ActorAdress { ActorAdressId = Guid.Parse("08992976-E714-4C2C-9F07-902CD74D62AB"), Adress1 = "Chichester", Adress2 = "Bristol", City = "Lancashire 23", ZipCode = 267397, Country = "United Kingdom" },
                new ActorAdress { ActorAdressId = Guid.Parse("53217A0C-D050-4AD6-A70B-A0B8552DA9C8"), Adress1 = "York", Adress2 = "Sandown", City = "Lancashire13", ZipCode = 254758, Country = "United Kingdom" },
                new ActorAdress { ActorAdressId = Guid.Parse("82107BD1-C4C2-4EAF-B0F6-B4B9D0D354A4"), Adress1 = "Scunthorpe", Adress2 = "Birmingham", City = "Lancashire", ZipCode = 876123, Country = "United Kingdom" },
                new ActorAdress { ActorAdressId = Guid.Parse("7E7ADA24-4C7A-4127-BCB7-F3A47907BFE2"), Adress1 = "Hove", Adress2 = "Wigan", City = "Lancashire 2", ZipCode = 657234, Country = "United Kingdom" }
                );

            //add default user admin and admin -> user / pass
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, UserName = "admin", Password = "admin", Email="admin@email.com" },
                new User { UserId = 2, UserName = "admin123", Password = "pass123", Email= "admin123@gmail.com" }
                );
        }
        #endregion
    }
    #endregion
}
