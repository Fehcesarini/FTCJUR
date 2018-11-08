using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    interface IArquivoAnexo
    {
        Object cadastroAnexo(ArquivoAnexo arquivoanexo);
        Object deletaAnexo(string deleta);
        List<ArquivoAnexo> buscaAnexo(string id, string tipoprocesso);
        bool equals(ArquivoAnexo arquivoanexo);
    }
}
