using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraccionesPedagogicas.Application.DTOs
{
    public class InfractorDTO
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
        [JsonProperty("apellido")]
        public string Apellido { get; set; }
    }
}
