using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    interface IProcessoPessoaVinc
    {
        Object cadastroProcesso(ProcessoPessoaVinc processopessoavinc);
        Object atualizaProcesso(ProcessoPessoaVinc processopessoavinc);
        List<ProcessoPessoaVinc> buscaProcesso();
        List<ProcessoPessoaVinc> buscaProcesso(string id);
        ProcessoPessoaVinc buscaProcessoPro(string id);
        List<ProcessoPessoaVinc> buscaProcesso(string id = "", string descricao = "");
        bool deletaProcesso(string id);
        bool equals(ProcessoPessoaVinc processopessoavinc);
    }
}
