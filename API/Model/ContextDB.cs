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
    }
}
