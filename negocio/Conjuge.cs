using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Conjuge : Pessoa
    {
        public Domicilio Domicilio { get; set; }

        public string estado_civil { get; set; }
        public string nacionalidade { get; set; }
    }
}
