using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Endereco
    {

        // Essas informações são genericas.
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string cep { get; set; }
        public string bairro { get; set; }
        public string complento { get; set; }

        // Irá receber as informações da tabela CIDADE
        public Cidade Cidade { get; set; }

        // Irá receber as informações da tabela ESTADO
        public Estado Estado { get; set; }

        // Irá receber as informações da tabela PAIS
        public Pais Pais { get; set; }

    }
}
