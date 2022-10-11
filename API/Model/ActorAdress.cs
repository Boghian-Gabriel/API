using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    public class ActorAdress
    {
        [ForeignKey("Actor")]
        public Guid ActorAdressId { get; set; }

        public string? Adress1 { get; set; }
        public string? Adress2 { get; set; }
        public string? City { get; set; }
        public int ZipCode { get; set; }
        public string? Country { get; set; }

        public virtual Actor? Actor { get; set; }
    }
}
