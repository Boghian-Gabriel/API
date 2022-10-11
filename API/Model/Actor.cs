namespace API.Model
{
    public class Actor
    {
        public Actor() => this.Movies = new HashSet<Movie>();

        public Guid ActorId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public virtual ActorAdress Adress { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
