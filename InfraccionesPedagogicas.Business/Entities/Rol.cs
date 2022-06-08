using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraccionesPedagogicas.Core.Entities
{
    public class Rol : BaseEntity<int>
    {
        
        public string Descripcion { get; set; }
    }
}
