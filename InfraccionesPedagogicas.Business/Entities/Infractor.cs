using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraccionesPedagogicas.Core.Entities
{
    public class Infractor: BaseEntity<string>
    {
        
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [StringLength(15)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override string Id { get; set; }

        public virtual ICollection<Infraccion> Infracciones { get; set; }

    }
}
