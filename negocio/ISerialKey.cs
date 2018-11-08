using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    interface ISerialKey
    {
        Object atualizaSerial(SerialKey serialkey);
       SerialKey buscaSerial(string CNPJ, string serialkey);
       SerialKey buscaSerial(string CNPJ, string serialkey, string macadress);
        bool equals(SerialKey serialkey);
    }
}
