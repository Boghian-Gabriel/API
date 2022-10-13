using API.Model;

namespace API.ModelDTO
{
    public class ActorDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public ActorDTO(Actor actor) 
        {
            FirstName = actor.FirstName;
            LastName = actor.LastName;
        }

    }
}
