using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraccionesPedagogicas.Core.Entities
{
    public class Sala
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Cupo { get; set; }
        public string Link { get; set; }

        public Usuario Usuario { get; set; }
    }
}
