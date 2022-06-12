using Newtonsoft.Json;

namespace InfraccionesPedagogicas.Application.DTOs
{
    public class DatosInfractorDTO
    {
        [JsonProperty("telefono")]
        public string Telefono { get; set; }
        [JsonProperty("celular")]
        public string Celular { get; set; }
        [JsonProperty("direccion")]
        public string Direccion { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }
    public class CreateDatosInfractorDTO
    {
        [JsonProperty("telefono")]
        public string Telefono { get; set; }
        [JsonProperty("celular")]
        public string Celular { get; set; }
        [JsonProperty("documento")]
        public string Documento { get; set; }
        [JsonProperty("direccion")]
        public string Direccion { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }
    public class UpdateDatosInfractorDTO
    {
        [JsonProperty("telefono")]
        public string Telefono { get; set; }
        [JsonProperty("celular")]
        public string Celular { get; set; }
        [JsonProperty("documento")]
        public string Documento { get; set; }
        [JsonProperty("direccion")]
        public string Direccion { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
