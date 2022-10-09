namespace API.Model
{
    //abstract class can not be instantiated, is only to be sub-classesd
    public abstract class MovieLinq
    {
        public Guid MovieId { get; set; }
        public string MovieTitle { get; set; }
        public DateTime MovieRealeaseDate { get; set; }
    }
}
