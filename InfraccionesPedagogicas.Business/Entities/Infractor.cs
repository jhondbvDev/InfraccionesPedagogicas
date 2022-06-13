using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfraccionesPedagogicas.Core.Entities
{
    public class Infractor: BaseEntity<string>
    {
        [StringLength(15)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public virtual ICollection<Infraccion> Infracciones { get; set; }
        public virtual ICollection<Asistencia> Asistencias { get; set; }
    }
}
