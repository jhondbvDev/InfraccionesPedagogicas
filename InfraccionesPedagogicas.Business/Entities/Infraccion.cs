using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraccionesPedagogicas.Core.Entities
{
    public class Infraccion
    {
        public int Id { get; set; }
        public string NumeroInfraccion { get; set; }
        public DateTime Fecha { get; set; }
        public Infractor Infractor { get; set; }    
    }
}
