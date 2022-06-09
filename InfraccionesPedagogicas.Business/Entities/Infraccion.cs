using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraccionesPedagogicas.Core.Entities
{
    public class Infraccion: BaseEntity<int>
    {

        public string NumeroInfraccion { get; set; }
        public DateTime Fecha { get; set; }
        public virtual Infractor Infractor { get; set; }    
    }
}
