using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Trabalhista
    {
        public int id { get; set; }
        public string PIS { get; set; }
        public string CTPS { get; set; }
        public string FGTS { get; set; }
        public string seguroDesemprego { get; set; }
        public string avisoPrevio { get; set; }
        public string licencaMaternidade { get; set; }
        public string advertencia { get; set; }
        public string obs { get; set; }
    }
}
