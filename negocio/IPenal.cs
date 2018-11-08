using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    interface IPenal
    {

        Object cadastroPenal(Penal penal);
        Object atualizaPenal(Penal penal);
        List<Penal> buscaPenal();
        bool equals(Penal penal);
    }
}
