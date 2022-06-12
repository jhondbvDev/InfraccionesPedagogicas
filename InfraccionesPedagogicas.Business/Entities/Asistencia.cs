namespace InfraccionesPedagogicas.Core.Entities
{
    public class Asistencia:BaseEntity<int>
    {
        public string InfractorId { get; set; }
        public virtual Infractor Infractor { get; set; }
        public bool Asistio { get; set; }
        public int SalaId { get; set; }
        public virtual Sala Sala { get; set; }
    }
}
