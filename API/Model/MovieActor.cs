using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class MovieActor
    {
        // am adaugat [Key] deoarece trebuia specificat care este id ul unic aici
        // altfel nu mergea sa facem add-migraion many-to-many
        [Key]
        public Guid IdMovieActor { get; set; }

        public Guid ActorId { get; set; }
        public Actor Actor { get; set; }

        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
