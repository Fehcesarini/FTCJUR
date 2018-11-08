using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using Negocio;
using System.Net.NetworkInformation;

namespace ViewWPF.Inicializacao
{
    /// <summary>
    /// Lógica interna para WCadastroAplicacao.xaml
    /// </summary>
    public partial class WCadastroAplicacao : Window
    {
        public WCadastroAplicacao()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
               SerialKey chave = new SerialKey();
               SerialKeyDAO dados = new SerialKeyDAO();
               chave = dados.buscaSerial(TxtCPFCNPJ.Text.ToString(), TxtSerial.Text.ToString());
                if (chave.idEmpresa == null)
                {
                    MessageBox.Show("CNPJ ou SerialKey invalido, verifique os valores digitados.");
                }
                else if (chave.macadress == "")
                {
                    string retornoMAC = getMacAddress();
                    try
                    {
                       SerialKey atualizaSerial = new SerialKey();
                        atualizaSerial.id = chave.id;
                        atualizaSerial.idEmpresa = chave.idEmpresa;
                        atualizaSerial.serialkey = chave.serialkey;
                        atualizaSerial.RazaoSocial = chave.RazaoSocial;
                        atualizaSerial.cnpjCPF = chave.cnpjCPF;
                        atualizaSerial.macadress = retornoMAC;
                        SerialKeyDAO dao = new SerialKeyDAO();
                        dao.atualizaSerial(atualizaSerial);


                        XmlTextWriter writer = new XmlTextWriter(Definicoes.diretorioSistema + Definicoes.configXML, null);
                        //inicia o documento xml
                        writer.WriteStartDocument();
                        //escreve o elmento raiz
                        writer.WriteStartElement("SerialKey");
                        //Escreve os sub-elementos
                        writer.WriteElementString("CNPJ", chave.cnpjCPF.ToString());
                        writer.WriteElementString("Serial", chave.serialkey.ToString());
                        writer.WriteElementString("MacAdress", retornoMAC);
                        // encerra o elemento raiz
                        writer.WriteEndElement();
                        //Escreve o XML para o arquivo e fecha o objeto escritor
                        writer.Close();

                        MessageBox.Show("Registro feito com sucesso, seja bem vindo! Vou redireciona-lo para tela de login...");
                        WLogin login = new WLogin();
                        login.Show();
                        this.Close();

                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Este serial Key já está sendo utilizado, para uma nova instalação, por gentileza contate o suporte.");
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        public static String getMacAddress()
        {
            return (from nic in NetworkInterface.GetAllNetworkInterfaces()
                where nic.OperationalStatus == OperationalStatus.Up
                select nic.GetPhysicalAddress().ToString()
            ).FirstOrDefault();
        }

        private void TxtCPFCNPJ_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                KeyConverter kv = new KeyConverter();
                if ((char.IsNumber((string)kv.ConvertTo(e.Key, typeof(string)), 0) == false))
                {
                    e.Handled = true;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

       
    }
}
