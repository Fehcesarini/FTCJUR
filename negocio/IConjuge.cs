using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    interface IConjuge 
    {
        Object cadastroConjuge(Conjuge conjuge);
        Object atualizaConjuge(Conjuge conjuge);
        List<Conjuge> buscaConjuge();
        List<Conjuge> buscaConjuge(string id);
        List<Conjuge> buscaConjuge(string id = "", string nome = "");
        bool equals(Conjuge conjuge);
    }
}
