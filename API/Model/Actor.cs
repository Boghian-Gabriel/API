namespace API.Model
{
    public class Actor
    {
        public Actor() => this.Movies = new HashSet<Movie>();

        //primary key
        public Guid ActorId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        // 1:1 Actor - ActorAdress
        public virtual ActorAdress Adress { get; set; }

        /*
         note:
        Codul async permite utilizarea mai eficienta a resurselor serverului
        iar acesta este activat sa gestioneze mai mult trafic fara intarziere
         */
        //many to many Movie:Actor
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
