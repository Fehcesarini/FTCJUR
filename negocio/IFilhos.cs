using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    interface IFilhos
    {
        Object cadastroFilhos(Filhos filhos);
        Object atualizaFilhos(Filhos filhos);
        List<Filhos> buscaFilhos();
        bool deletaFilhos(string id);
        bool equals(Filhos filhos);
    }
}
