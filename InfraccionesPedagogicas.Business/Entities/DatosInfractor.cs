namespace InfraccionesPedagogicas.Core.Entities
{
    public class DatosInfractor: BaseEntity<int>
    {
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
    }
}
