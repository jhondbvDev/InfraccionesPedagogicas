namespace InfraccionesPedagogicas.Core.Entities
{
    public class Infraccion: BaseEntity<int> 
    {
        public string NumeroInfraccion { get; set; }
        public DateTime Fecha { get; set; }
        public string CodigoInfraccion { get; set; }
        public string InfractorId { get; set; }    
    }
}
