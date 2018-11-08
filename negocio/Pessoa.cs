using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
    public abstract class Pessoa 
    {
        // Essas informações são as Gerericas.
        public int id { get; set; }
        public string codigo { get; set; }
        public string nome { get; set; }
        public Endereco endereco { get; set; }

        public string telefone { get; set; }
        public string celular { get; set; }
        public string email { get; set; }

        public string cpf_cnpj { get; set; }
        public string rg_ie { get; set; }
        public DateTime data_nascimento { get; set; }
        public string sexo { get; set; }



        public bool bloqueado { get; set; }
        public bool excluido { get; set; }
        public DateTime dtCadastro { get; set; }


    }
}
