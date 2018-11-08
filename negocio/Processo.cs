using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
   public class Processo
    {
        public int funcionario_fun_id { get; set; }
        public int PROC_ID { get; set; }
        public string PROC_NUMEROPROCESSO { get; set; }
        public string PROC_CLASSEPROCEDIMENTO { get; set; }
        public string PROC_AREA { get; set; }
        public string PROC_COMPETENCIA { get; set; }
        public string PROC_FORUM { get; set; }
        public string PROC_COMARCA { get; set; }
        public string PROC_VARA { get; set; }
        public string PROC_INSTANCIA { get; set; }
        public string PROC_VALORDACAUSA { get; set; }
        public string PROC_ASSUNTO { get; set; }
        public string PROC_DTCADASTRO { get; set; }
        public string PROC_PALAVRACHAVE { get; set; }
        public string PROC_NATUREZA { get; set; }
        public Funcionario Funcionario { get; set; }

    }
}
