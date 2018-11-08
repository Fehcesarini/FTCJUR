using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
     interface ICargosFuncionarios
    {
        Object cadastroCargosFuncionarios(CargosFuncionarios cargosfuncionarios);
        Object atualizaCargosFuncionarios(CargosFuncionarios cargosfuncionarios);
        List<CargosFuncionarios> buscaCargosFuncionarios();
        List<CargosFuncionarios> buscaCargosFuncionarios(string id);
        List<CargosFuncionarios> buscaCargosFuncionarios(string id = "", string descricao = "");
        bool deletaCargosFuncionarios(string id);
        bool equals(CargosFuncionarios Cargosfuncionarios);
    }
}
