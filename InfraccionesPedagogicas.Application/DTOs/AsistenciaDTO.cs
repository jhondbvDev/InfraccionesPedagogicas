using Newtonsoft.Json;

namespace InfraccionesPedagogicas.Application.DTOs
{
    public  class AsistenciaDTO
    {
        [JsonProperty("asistenciaId")]
        public int Id { get; set; }
        [JsonProperty("documento")]
        public string InfractorId { get; set; }
        [JsonProperty("asistio")]
        public bool Asistio { get; set; }
        [JsonProperty("sala")]
        public int SalaId { get; set; }
    }

    public class AsistenciaDeepDTO
    {
        [JsonProperty("asistenciaId")]
        public int Id { get; set; }
        [JsonProperty("nombreInfractor")]
        public string NombreInfractor { get; set; }
        [JsonProperty("asistio")]
        public bool Asistio { get; set; }
    }

    public class CreateAsistenciaDTO
    {
        [JsonProperty("documento")]
        public string InfractorId { get; set; }
        [JsonProperty("sala")]
        public int SalaId { get; set; }
    }

    public class UpdateAsistenciaDTO
    {
        [JsonProperty("asistenciaId")]
        public int Id { get; set; }
        [JsonProperty("asistio")]
        public bool Asistio { get; set; }
    }
}
