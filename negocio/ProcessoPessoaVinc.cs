using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
   public class ProcessoPessoaVinc
    {
        public int cliente_CLI_ID { get; set; }
        public int processo_PROC_ID { get; set; }
        public string CLI_PRO_TIPOCLIENTEPROC { get; set; }
        public string CLI_PRO_CLIENTEESCRITORIO { get; set; }
        public Cliente Cliente { get; set; }
        public Processo Processo { get; set; }
        
        
    }
}
