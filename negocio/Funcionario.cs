using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Funcionario : Pessoa
    {
        public Login Login { get; set; }
        public CargosFuncionarios CargoFuncionarios { get; set; }

        public decimal comissao { get; set; }
        public string salario { get; set; }
        public DateTime data_admissao { get; set; }


    }
}
