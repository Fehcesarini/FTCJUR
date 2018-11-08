using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    interface IEndereco
    {

        List<Estado> buscaEstado();
        List<Cidade> buscaCidade();
        List<Pais> buscaPais();

        DataTable buscaCepWeb(string cep);

    }
}
