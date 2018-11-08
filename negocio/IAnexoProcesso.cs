using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    interface IAnexoProcesso
    {
        Object cadastroAnexoProc(AnexoProcesso anexoprocesso);
        Object deletaAnexoProc(string deleta);
        List<AnexoProcesso> buscaAnexoProc(string id, string tipoprocesso);
        bool equals(AnexoProcesso anexoprocesso);

    }
}
