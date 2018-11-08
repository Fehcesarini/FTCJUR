using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
   public class AnexoProcesso
    {
        public int AneProc_id { get; set; }
        public string AneProc_documento { get; set; }
        public string AneProc_descricao { get; set; }
        public string AneProc_Obs { get; set; }
        public int processo_PROC_ID { get; set; }
        public string AneProc_tipodoc { get; set; }
        public DateTime AneProc_data { get; set; }
        public byte[] documentoreturn { get; set; }

    }
}
