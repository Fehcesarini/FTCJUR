using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Cliente : Pessoa
    {
        
        public Conjuge Conjuge { get; set; }
        public Domicilio Domicilio { get; set; }
        public Previdenciario Previdenciario { get; set; }
        public Trabalhista Trabalhista { get; set; }
        public Penal Penal { get; set; }
        public Bens Bens { get; set; }
        public DadoBancario DadoBancario { get; set; }
        public ArquivoAnexo ArquivoAnexo { get; set; }
        public Filhos Filhos { get; set; }

        public string estado_civil { get; set; }
        public string nacionalidade { get; set; }


        
    }

}
