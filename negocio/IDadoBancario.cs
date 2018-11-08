using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    interface IDadoBancario
    {
        Object cadastroDadoBancario(DadoBancario dadobancario);
        Object atualizaDadoBancario(DadoBancario dadobancario);
        List<DadoBancario> dadobancario();
        bool equals(DadoBancario dadobancario);
    }
}
