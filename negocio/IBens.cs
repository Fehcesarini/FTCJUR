using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    interface IBens
    {
        Object cadastroBens(Bens bens);
        Object atualizaBens(Bens bens);
        List<Bens> buscaBens();
        Bens buscaBensDGV(string id);
        bool deletaBens(string id);
        bool equals(Bens bens);
    }
}
