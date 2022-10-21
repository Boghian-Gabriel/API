using Newtonsoft.Json;

namespace API.ModelsDTO.UserDto
{
    public class UserLoginDTO
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
