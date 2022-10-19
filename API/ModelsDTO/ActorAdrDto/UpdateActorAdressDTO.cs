namespace API.ModelsDTO.ActorAdrDto
{
    public class UpdateActorAdressDTO
    {
        public Guid ActorAdressId { get; set; }

        public string? Adress1 { get; set; }
        public string? Adress2 { get; set; }
        public string? City { get; set; }
        public int ZipCode { get; set; }
        public string? Country { get; set; }
    }
}
