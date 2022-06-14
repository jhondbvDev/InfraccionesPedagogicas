using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
