using Newtonsoft.Json;

namespace InfraccionesPedagogicas.Application.DTOs
{
    public class InfraccionDTO
    {
        [JsonProperty("numeroInfraccion")]
        public string NumeroInfraccion { get; set; }
        [JsonProperty("fecha")]
        public DateTime Fecha { get; set; }
    }
}
