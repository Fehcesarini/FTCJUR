using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Negocio
{
    public class Estado : INotifyPropertyChanged
    {
        public int _estado_id;
        public int _pai_id;
        public string _estado_sigla;
        public string _estado_descricao;
        public int estado_id { get { return _estado_id; } set { _estado_id = value; OnPropertyChanged(); } }
        public int pai_id { get { return _pai_id; } set { _pai_id = value; OnPropertyChanged(); } }
        public string estado_sigla { get { return _estado_sigla; } set { _estado_sigla = value; OnPropertyChanged(); } }
        public string estado_descricao { get { return _estado_descricao; } set { _estado_descricao = value; OnPropertyChanged(); } }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    
}
