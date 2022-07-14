namespace InfraccionesPedagogicas.Core.Entities
{
    public class Sala: BaseEntity<int>
    {
       
        public DateTime Fecha { get; set; }
        public int Cupo { get; set; }
        public string Link { get; set; }
        public int TotalCupo { get; set; }
        public string UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
