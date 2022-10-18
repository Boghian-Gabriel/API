namespace API.ModelsDTO
{
    public class ActorAndAdressDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public virtual ActorAdressDTO? Adress { get; set; }
    }
}
