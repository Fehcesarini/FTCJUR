using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class GravaLogErr
    {

        private static string tcc = "Grupo TCC\n"+
                                     "Telefone: (11) 11111-1111\n"+
                                     "Skype: xxxxxxxxx\n\n";

        private static string Geovani = "Geovani\n" +
                                        "Telefone: (11) 11111-1111\n" +
                                        "Skype: xxxxxxxxx\n\n";

        private static string Mensagem = "Ocorreu uma falha de exceção no Sistema.\n\n" +
                                         "Entre em contato com o suporte técnico\n" + tcc + Geovani;


        public static string MensagemErro(String erro, Exception e)
        {

            string tratamento = Mensagem;

            tratamento += "Erro: " + erro;

            GravaLogErroArquivo(erro, e, tratamento);

            return tratamento;
        
        }

        private static void GravaLogErroArquivo(String erro, Exception e, string mensagem)
        {

            string arquivo = "LogErr.txt";
            string log = Definicoes.diretorioSistema + Definicoes.diretorioLog + "\\" + arquivo;

            if (!Directory.Exists(Definicoes.diretorioSistema + Definicoes.diretorioLog))
            {
                Directory.CreateDirectory(Definicoes.diretorioSistema + Definicoes.diretorioLog);
            }

            //Declaração do método StreamWriter passando o caminho e nome do arquivo que deve ser salvo
            StreamWriter writer = new StreamWriter(log, true);
            
            //Escrevendo o Arquivo e pulando uma linha
            writer.WriteLine("------------------------------------------------------------------------");
            
            //Escrevendo o Arquivo sem pular linha
            writer.WriteLine("Data: " + DateTime.Now.ToShortDateString());
            writer.WriteLine("Hora: " + DateTime.Now.ToLongTimeString());
            writer.WriteLine("Mensagem: " + mensagem.ToString());
            writer.WriteLine("Erro: " + erro.ToString());
            writer.WriteLine("Pilha: " + e.StackTrace);
            writer.WriteLine();
            
            //Fechando o arquivo
            writer.Close();

            //Limpando a referencia dele da memória
            writer.Dispose();
        }


    }
}
