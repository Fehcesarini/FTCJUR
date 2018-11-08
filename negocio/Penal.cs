using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Penal
    {
        public int id { get; set; }
        public string crime { get; set; }
        public string acao_penal { get; set; }
        public string rito_processual { get; set; }
        public string suspensao_condicional_processo { get; set; }
        public string livramento_condicional { get; set; }
        public string reincidente { get; set; }
        public string regime_prisional { get; set; }
        public string atenuantes { get; set; }
        public string agravantes { get; set; }
        public string majorantes { get; set; }
        public string minorantes { get; set; }
        public string qualificadoras { get; set; }
    }
}
