using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraccionesPedagogicas.Core.Entities
{
    public class Usuario: BaseEntity<int>
    {
        
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual Rol Rol { get; set; }   
        
        public virtual ICollection<Sala> Salas { get; set; }
    }
}
