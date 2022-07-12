using Newtonsoft.Json;

namespace InfraccionesPedagogicas.Application.DTOs
{
    public  class UserDTO
    {
        [JsonProperty("username")]
        public string UserName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("rol")]
        public string Rol { get; set; }
    }

    public class CreateUserDTO:UserDTO
    {
    }

    public class UpdateUserDTO:UserDTO
    {
    }
    public class LogInUserDTO
    {
        [JsonProperty("username")]
        public string UserName { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
    public class GetUsersDTO
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("rol")]
        public string Rol { get; set; }
    }
}
