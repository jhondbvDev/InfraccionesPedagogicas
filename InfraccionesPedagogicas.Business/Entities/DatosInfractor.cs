using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraccionesPedagogicas.Core.Entities
{
    public class DatosInfractor
    {
        public int Id { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }

    }
}
