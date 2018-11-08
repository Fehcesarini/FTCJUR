using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class metodosStaticos
    {
              
        public static string completaZeroEsquerda(String texto, int quantidade)
        {
            string textoZero;

            textoZero = texto.PadLeft(quantidade, '0');

            return textoZero;
        }

        public static string limpaCaracteres(String texto)
        {
            string textoLimpo = texto;

            textoLimpo = textoLimpo.Replace("-", "").Trim();
            textoLimpo = textoLimpo.Replace("/", "").Trim();
            textoLimpo = textoLimpo.Replace(")", "").Trim();
            textoLimpo = textoLimpo.Replace("(", "").Trim();
            textoLimpo = textoLimpo.Replace(".", "").Trim();
            textoLimpo = textoLimpo.Replace(",", "").Trim();

            return textoLimpo;
        }


        public static void gravaFotoDiretorio(string caminhoFoto, string nomeFoto)
        {

            string foto = Definicoes.diretorioSistema + Definicoes.diretorioFotos + "\\" + nomeFoto;

            if (!Directory.Exists(Definicoes.diretorioSistema + Definicoes.diretorioFotos))
            {
                Directory.CreateDirectory(Definicoes.diretorioSistema + Definicoes.diretorioFotos);
            }

            File.Copy(caminhoFoto, foto, true);
           
        }


    }
}
