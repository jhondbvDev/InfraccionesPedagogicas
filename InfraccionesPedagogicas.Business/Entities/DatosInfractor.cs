namespace InfraccionesPedagogicas.Core.Entities
{
    public class DatosInfractor: BaseEntity<int>
    {
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string InfractorId { get; set; }
        public virtual Infractor Infractor { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
    }
}
