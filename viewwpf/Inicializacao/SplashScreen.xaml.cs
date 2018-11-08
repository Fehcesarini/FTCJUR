using System;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows;
using System.Xml;
using Negocio;

namespace ViewWPF.Inicializacao
{
    /// <summary>
    /// Lógica interna para SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        public SplashScreen()
        {
            InitializeComponent();
            this.Show();
            Entrar();
           
        }

        private void Entrar()
        {
            
            int tempo = 0;
            while (tempo <= 50000)
            {
                tempo++;
            }
            
            Verificaarquivo();
            
        }

        private void Verificaarquivo()
        {
            try
            {
                if (File.Exists(Definicoes.diretorioSistema + Definicoes.configXML))

                {
                    //Cria uma instância de um documento XML
                    XmlDocument oXML = new XmlDocument();

                    //Define o caminho do arquivo XML 
                    string ArquivoXML = Definicoes.diretorioSistema + Definicoes.configXML;
                    //carrega o arquivo XML
                    oXML.Load(ArquivoXML);

                    //Lê o filho de um Nó Pai específico 
                    Definicoes.CNPJ = oXML.SelectSingleNode("SerialKey").ChildNodes[0].InnerText;
                    Definicoes.serial = oXML.SelectSingleNode("SerialKey").ChildNodes[1].InnerText;
                    Definicoes.macadress = oXML.SelectSingleNode("SerialKey").ChildNodes[2].InnerText;
                    string nomemac = getMacAddress();
                    if (Definicoes.macadress == getMacAddress())
                    {
                        WLogin login = new WLogin();
                        login.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Está estação não está configurada com a chave correta, entre em contato com o suporte.");
                        Application.Current.Shutdown();
                    }}
                else
                {
                    try
                    {
                        SerialKeyDAO conecta = new SerialKeyDAO();
                        conecta.buscaSerial("0","0");
                        WCadastroAplicacao cadastro = new WCadastroAplicacao();
                        cadastro.ShowDialog();
                        this.Close();
                        

                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("Maquina não configurada para usar o sistema, e sem sinal de internet para prosseguir. Conecte-se a internet e tente novamente.");
                        Application.Current.Shutdown();
                    }
                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }
        public static String getMacAddress()
        {
            return (from nic in NetworkInterface.GetAllNetworkInterfaces()
                where nic.OperationalStatus == OperationalStatus.Up
                select nic.GetPhysicalAddress().ToString()
            ).FirstOrDefault();
        }

    }
}
