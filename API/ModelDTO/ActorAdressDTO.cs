using API.Model;

namespace API.ModelDTO
{
    public class ActorAdressDTO
    {
        public string? Adress1 { get; set; }
        public string? Adress2 { get; set; }
        public string? City { get; set; }
        public int ZipCode { get; set; }
        public string? Country { get; set; }

        public ActorAdressDTO(ActorAdress actorAdress)
        {
            Adress1 = actorAdress.Adress1;
            Adress2 = actorAdress.Adress2;
            City = actorAdress.City;
            ZipCode = actorAdress.ZipCode;
            Country = actorAdress.Country;
        }
    }
}
