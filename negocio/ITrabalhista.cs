using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    interface ITrabalhista
    {
        Object cadastroTrabalhista(Trabalhista trabalhista);
        Object atualizaTrabalhista(Trabalhista trabalhista);
        List<Trabalhista> buscaTrabalhista();
        bool equals(Trabalhista trabalhista);
    }
}
