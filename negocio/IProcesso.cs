using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    interface IProcesso
    {
        Object cadastroProcesso(Processo processo);
        Object atualizaProcesso(Processo processo);
        List<Processo> buscaProcesso();
        List<Processo> buscaProcesso(string id);
        Processo buscaProcessoPro(string id);
        List<Processo> buscaProcesso(string id = "", string descricao = "");
        bool deletaProcesso(string id);
        bool equals(Processo cliente);
    }
}
