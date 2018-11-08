using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Security.AccessControl;

namespace Negocio
{
    public static class CarregaArquivoConfiguracao
    {
        // Declaração das funções não gerenciadas: GetPrivateProfileString e 
        // WritePrivateProfileString
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
        private static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);


        public static bool carregaArquivoConfiguração()
        {

            try
            {
                if (!File.Exists(CarregaArquivoConfiguracao.getCaminhoArquivoINI(Definicoes.diretorioSistema + @"\UltraviewConfig.ini")))
                {
                    throw new Exception("Não foi localizado o arquivo de configuração do Sistema");
                }

                string nomeArquivoINI = Path.Combine(Definicoes.diretorioSistema, "UltraviewConfig.ini");

                nomeArquivoINI = CarregaArquivoConfiguracao.getCaminhoArquivoINI(nomeArquivoINI);

                File.Decrypt(nomeArquivoINI);

                // Obtêm o valor contido no arquivo INI
                Definicoes.banco = Convert.ToInt32(Criptografia.DecryptString(CarregaArquivoConfiguracao.GetIniValue("Banco", "Banco", nomeArquivoINI)));
                Definicoes.server = Criptografia.DecryptString(CarregaArquivoConfiguracao.GetIniValue("Banco", "Servidor", nomeArquivoINI));
                Definicoes.usuario = Criptografia.DecryptString(CarregaArquivoConfiguracao.GetIniValue("Banco", "Usuario", nomeArquivoINI));
                Definicoes.senha = Criptografia.DecryptString(CarregaArquivoConfiguracao.GetIniValue("Banco", "Senha", nomeArquivoINI));

                // Atualiza ultimo Acesso Sistema.
                CarregaArquivoConfiguracao.WriteIniValue("DadosSistema", "UltimoAcesso", DateTime.Now.ToString(), nomeArquivoINI);

            }
            catch ( Exception e)
            {
                throw new Exception(e.Message);
            }
            
            return true;

        }

        public static bool gravaArquivoConfiguração()
        {
                       
            string nomeArquivoINI = Path.Combine(Definicoes.diretorioSistema, "UltraviewConfig.ini");

            nomeArquivoINI = CarregaArquivoConfiguracao.getCaminhoArquivoINI(nomeArquivoINI);
                        
            // Atualiza ultimo Acesso Sistema.
            CarregaArquivoConfiguracao.WriteIniValue("Banco", "Banco", Criptografia.EncryptString(Definicoes.banco.ToString()), nomeArquivoINI);
            CarregaArquivoConfiguracao.WriteIniValue("Banco", "Servidor", Criptografia.EncryptString(Definicoes.server), nomeArquivoINI);
            CarregaArquivoConfiguracao.WriteIniValue("Banco", "Usuario", Criptografia.EncryptString(Definicoes.usuario), nomeArquivoINI);
            CarregaArquivoConfiguracao.WriteIniValue("Banco", "Senha", Criptografia.EncryptString(Definicoes.senha), nomeArquivoINI);
            CarregaArquivoConfiguracao.WriteIniValue("DadosSistema", "UltimoAcesso", DateTime.Now.ToString(), nomeArquivoINI);

            return true;

        }
                

        private static string GetIniValue(string section, string key, string nomeArquivo)
        {
            try
            {
                int chars = 256;
                StringBuilder buffer = new StringBuilder(chars);
                string sDefault = "";
                if (GetPrivateProfileString(section, key, sDefault, buffer, chars, nomeArquivo) != 0)
                {
                    return buffer.ToString();
                }
                else
                {
                    // Verifica o último erro Win32.
                    int err = Marshal.GetLastWin32Error();
                    return null;
                }
            }
            catch(Exception e)
            {
                throw new Exception(GravaLogErr.MensagemErro(e.Message.ToString(), e));
            }
            
        }

        private static bool WriteIniValue(string section, string key, string value, string nomeArquivo)
        {
            return WritePrivateProfileString(section, key, value, nomeArquivo);
        }

        private static string getCaminhoArquivoINI(string caminhoArquivo)
        {
            if (caminhoArquivo.IndexOf("\\bin\\Debug") != -1)
            {
                caminhoArquivo = caminhoArquivo.Replace("\\bin\\Debug", "");
            }
            else if (caminhoArquivo.IndexOf("\\bin\\Release") != -1)
            {
                caminhoArquivo = caminhoArquivo.Replace("\\bin\\Release", "");
            }
            return caminhoArquivo;
        }
        //fim 


    }
}
