using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraccionesPedagogicas.Application.DTOs
{
    public class SalaDTO
    {
        [JsonProperty("fecha")]
        public DateTime Fecha { get; set; }
        [JsonProperty("cupo")]
        public int Cupo { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("usuarioid")]
        public int UsuarioId { get; set; }
    }
    public class CreateSalaDTO
    {
        [JsonProperty("fecha")]
        public DateTime Fecha { get; set; }
        [JsonProperty("cupo")]
        public int Cupo { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("usuarioid")]
        public int UsuarioId { get; set; }
    }
    public class UpdateSalaDTO
    {
        [JsonProperty("fecha")]
        public DateTime Fecha { get; set; }
        [JsonProperty("cupo")]
        public int Cupo { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
    }
}
