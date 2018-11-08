using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    interface IFuncionario
    {
        Object cadastroFuncionario(Funcionario funcionario);
        Object atualizaFuncionario(Funcionario funcionario);
        List<Funcionario> buscaFuncionario();
        List<Funcionario> buscaFuncionario(string id);
        List<Funcionario> buscaFuncionario(string id = "", string descricao = "");
        bool deletafuncionario(string id);
        bool equals(Funcionario funcionario);
    }
}
