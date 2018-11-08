using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    interface IPrevidenciario
    {
        Object cadastroPrevidenciario(Previdenciario previdenciario);
        Object atualizaPrevidenciario(Previdenciario previdenciario);
        List<Previdenciario> buscaPrevidenciario();
        bool equals(Previdenciario previdenciario);
    }
}
