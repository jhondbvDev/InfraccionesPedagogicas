using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraccionesPedagogicas.Core.Entities
{
    public class Asistencia
    {
        public int Id { get; set; }
        public string Documento { get; set; }
        public bool Asistio { get; set; }
        public int IdSala { get; set; }

    }
}
