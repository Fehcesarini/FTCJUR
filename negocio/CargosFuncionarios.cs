using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Negocio
{
    public class CargosFuncionarios : INotifyPropertyChanged
    {

        public int _id;
        public string _nomecargo;
        public Boolean _permissaocadastro;
        public Boolean _permissaoconsulta;
        public Boolean _permissaoagenda;
        public Boolean _permissaofinanceiro;
        public int id { get { return _id; } set { _id = value; OnPropertyChanged(); } }
        public string nomecargo { get { return _nomecargo; } set { _nomecargo = value; OnPropertyChanged(); } }
        public Boolean permissaocadastro { get { return _permissaocadastro; } set { _permissaocadastro = value; OnPropertyChanged(); } }
        public Boolean permissaoconsulta { get { return _permissaoconsulta; } set { _permissaoconsulta = value; OnPropertyChanged(); } }
        public Boolean permissaoagenda { get { return _permissaoagenda; } set { _permissaoagenda = value; OnPropertyChanged(); } }
        public Boolean permissaofinanceiro { get { return _permissaofinanceiro; } set { _permissaofinanceiro = value; OnPropertyChanged(); } }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
