using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
   public class ArquivoAnexo
    {
        public string id { get; set; }
        public string nome { get; set; }
        public byte[] nomereturn { get; set; }
        public string caminho { get; set; }
        public string tipoanexo { get; set; }
        public string tipoprocesso { get; set; }
        public DateTime data_cadastro { get; set; }

    }
}
