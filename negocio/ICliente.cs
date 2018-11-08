using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    interface ICliente
    {
        Object cadastroCliente(Cliente cliente);
        Object atualizaCliente(Cliente cliente);
        List<Cliente> buscaCliente();
        List<Cliente> buscaCliente(string id);
        Cliente buscaClienteCli(string id);
        List<Cliente> buscaCliente(string id = "", string descricao = "");
        bool deletaCliente(string id);
        bool equals(Cliente cliente);
    }
}
