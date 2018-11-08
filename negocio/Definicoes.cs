using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class Definicoes
    {
        // Senha de segurança da Criptografia.
        public static string senhaCriptografia = "JesusMyLord";

        // Diretorios do sistema
        public static string diretorioSistema = Directory.GetCurrentDirectory();
        public static string diretorioFotos = @"\Foto";
        public static string diretorioLog = @"\Log";

        // Arquivo de Configuração
        public static string configXML = @"\config.XML";

        // Definições do Banco de Dados.
        public static int banco = 1;
        public static string server = "localhost";
        public static string usuario = "root";
        public static string senha = "admin";
        
        //Definições Banco de dados Serial Key
        public static int bancoSerial = 2;
        public static string serverSerial = "mysql873.umbler.com";
        public static string usuarioSerial = "feh126";
        public static string senhaSerial = "Thami_feh11";

        //Variaveis validacao sistemas 
        public static string CNPJ;
        public static string serial;
        public static string macadress;


        //Variaveis Globais
        public static int idClienteSelecionado;
        public static int idProcessoSeleciona;
        public static string nomeClienteselecionado;
        public static string idConjuge;
        public static string idPrevidenciario;
        public static string idPenal;
        public static string idBanco;
        public static string idTrabalhista;

        public static int codigoreturn;


    }
}
