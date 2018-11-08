using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ViewWPF.Lancamentos
{
    /// <summary>
    /// Lógica interna para WSelecionaProcesso.xaml
    /// </summary>
    public partial class WSelecionaProcesso : Window
    {
        public WSelecionaProcesso()
        {
            InitializeComponent();
        }
        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        List<ProcessoPessoaVinc> ListaProcesso;
        ProcessoPessoaVinc ProcessoDGV;
        string iddgv;
        string nomedgv;

        private void populaClienteDGV()
        {
            ProcessoDGV = new ProcessoPessoaVinc();
            ProcessoDGV.Processo.PROC_ID = Convert.ToInt32(txtPesquisa.Text.ToString());
            ProcessoDGV.Cliente.nome = txtPesquisa.Text.ToString();
            ProcessoDGV.Processo.PROC_NUMEROPROCESSO = txtPesquisa.Text.ToString();
            ProcessoDGV.Processo.PROC_PALAVRACHAVE = txtPesquisa.Text.ToString();
            ProcessoDGV.Cliente.cpf_cnpj = txtPesquisa.Text.ToString();


        }
        private static bool IsNumeric(string data)
        {
            bool isnumeric = false;
            int valor;
            try { valor = Convert.ToInt32(data.ToString()); isnumeric = true; }
            catch (Exception) { isnumeric = false; }


            return isnumeric;
        }
        private void buscaCliente()
        {
            ListaProcesso = new List<ProcessoPessoaVinc>();
            ProcessoPessoaVincDAO dao = new ProcessoPessoaVincDAO();

            if (IsNumeric(txtPesquisa.Text) == true)
            {
                ListaProcesso = dao.buscaProcesso(txtPesquisa.Text.ToString(), txtPesquisa.Text.ToString());
            }
            else {ListaProcesso = dao.buscaProcesso(null, txtPesquisa.Text.ToString()); }

            mostracliente();
        }                
        private void limpaDGVCliente()
        {
            DgvCliente.ItemsSource = null;
        }        
        private void mostracliente()
        {
            var novaListCargo = ListaProcesso.Select(ProcessoDGV => new
            {
                Pasta = ProcessoDGV.processo_PROC_ID,
                NProcesso = ProcessoDGV.Processo.PROC_NUMEROPROCESSO,
                Pessoa = ProcessoDGV.Cliente.nome,
                CPF = ProcessoDGV.Cliente.cpf_cnpj,
                Tipo = ProcessoDGV.CLI_PRO_TIPOCLIENTEPROC,
                Cliente = ProcessoDGV.CLI_PRO_CLIENTEESCRITORIO,
                Advogado = ProcessoDGV.Processo.Funcionario.nome,
                Data = ProcessoDGV.Processo.PROC_DTCADASTRO,
                PalavraChve = ProcessoDGV.Processo.PROC_PALAVRACHAVE,

            }).ToList();
           // ICollectionView employeesView =
           //CollectionViewSource.GetDefaultView(novaListCargo);
           // employeesView.GroupDescriptions.Add(new PropertyGroupDescription("Pasta"));
            

            limpaDGVCliente();
            DgvCliente.ItemsSource = novaListCargo;          

        }                
        private void btnPesquisa_Click(object sender, EventArgs e)
        {

            try
            {
                buscaCliente();

            }

            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }
        private void dgvCliente_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ListaProcesso = new List<ProcessoPessoaVinc>();
                ProcessoPessoaVincDAO dao = new ProcessoPessoaVincDAO();
                ListaProcesso = dao.buscaProcesso(getDataGridValueAt(DgvCliente, 0), getDataGridValueAt(DgvCliente, 0));
                Negocio.Definicoes.idProcessoSeleciona = ListaProcesso[0].processo_PROC_ID;
                Negocio.Definicoes.nomeClienteselecionado = ListaProcesso[0].Cliente.nome;
                LabelClienteSelecionado.Content = Negocio.Definicoes.idProcessoSeleciona + "  " + Negocio.Definicoes.nomeClienteselecionado;

            }

            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        public static string getDataGridValueAt(DataGrid dGrid, int columnIndex)
        {
            if (dGrid.SelectedItem == null)
                return "";
            string str = dGrid.SelectedItem.ToString(); // Take the selected line
            str = str.Replace("}", "").Trim().Replace("{", "").Trim(); // Delete useless characters
            if (columnIndex < 0 || columnIndex >= str.Split(',').Length) // case where the index can't be used 
                return "";
            str = str.Split(',')[columnIndex].Trim();
            str = str.Split('=')[1].Trim();
            return str;
        }
        private void BtnSelecionar_click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Selecionar o Processo: " + Negocio.Definicoes.idProcessoSeleciona + "  " + Negocio.Definicoes.nomeClienteselecionado + " ?", "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                  
                        WManutencaoProcesso NovoProcesso = new WManutencaoProcesso();

                        NovoProcesso.Show();
                  
                }
            }

            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }



    }
}
