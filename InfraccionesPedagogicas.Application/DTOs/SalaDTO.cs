using Newtonsoft.Json;

namespace InfraccionesPedagogicas.Application.DTOs
{
    public class SalaDTO
    {
        [JsonProperty("salaId")]
        public int Id { get; set; }
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
        [JsonProperty("salaId")]
        public int Id { get; set; }
        [JsonProperty("fecha")]
        public DateTime Fecha { get; set; }
        [JsonProperty("cupo")]
        public int Cupo { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
    }
}
