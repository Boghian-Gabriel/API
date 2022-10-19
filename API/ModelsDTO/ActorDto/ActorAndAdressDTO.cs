using API.ModelsDTO.ActorAdrDto;

namespace API.ModelsDTO.ActorDto
{
    public class ActorAndAdressDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public virtual ActorAdressDTO? Adress { get; set; }
    }
}
