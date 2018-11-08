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
using Negocio;

namespace ViewWPF.Lancamentos
{
    /// <summary>
    /// Lógica interna para WSelecionaCliente.xaml
    /// </summary>
    public partial class WSelecionaCliente : Window
    {
        string tipoabertura;
        public WSelecionaCliente(string tipo)
        {
            tipoabertura = tipo;
            InitializeComponent();
            buscaCliente();
            if (tipo == "processo") {
                btnnovocliente.IsEnabled = true;
            }
        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        List<Cliente> ListaCliente;
        Cliente ClienteDGV;
        string iddgv;
        string nomedgv;

        public object AtualizaCargoFuncionario { get; private set; }

        // object Cargo_id;

        private void populaClienteDGV()
        {
            ClienteDGV = new Cliente();
            ClienteDGV.id = Convert.ToInt32(txtPesquisa.Text.ToString());
            ClienteDGV.nome = txtPesquisa.Text.ToString();
            ClienteDGV.cpf_cnpj = txtPesquisa.Text.ToString();
            

        }

        // Método usado para buscar o Produto do Banco de dados.
        private void buscaCliente()
        {
            ListaCliente = new List<Cliente>();
            ClienteDAO dao = new ClienteDAO();
            ListaCliente = dao.buscaCliente(); ;
            mostracliente();
        }

        // Método usado para buscar o Produto do Banco de dados.
        private void buscaCliente(string busca)
        {
            ListaCliente = new List<Cliente>();
            ClienteDAO dao = new ClienteDAO();
            ListaCliente = dao.buscaCliente();
            mostracliente(busca);
        }

        private void limpaDGVCliente()
        {
            DgvCliente.ItemsSource = null;
        }

        // Mostra os dados dos Fornecedor nos TextBox
        private void mostracliente()
        {
            var novaListCargo = ListaCliente.Select(ClienteDGV => new
            {
                Codigo = ClienteDGV.id,
                Nome = ClienteDGV.nome,
                CPF = ClienteDGV.cpf_cnpj,
                Nascimento = ClienteDGV.data_nascimento.ToShortDateString(),
                Telefone = ClienteDGV.telefone,
                Endereço = ClienteDGV.endereco.logradouro

            }).ToList();

            limpaDGVCliente();
            DgvCliente.ItemsSource = novaListCargo;

            //dgvCargoFuncionario.Columns[1].Width = 280;//cargo
            //dgvCargoFuncionario.Columns[2].Width = 60;  // cadastro  
            //dgvCargoFuncionario.Columns[3].Width = 60;//consulta
            //dgvCargoFuncionario.Columns[4].Width = 60;//agenda
            //dgvCargoFuncionario.Columns[5].Width = 60;//financeiro 

        }

        // Mostra os dados dos Fornecedor nos TextBox
        private void mostracliente(string busca)
        {

            List<Cliente> listPesquisaCargo = ListaCliente.FindAll(e => e.nome.Contains(busca));

            var novaListCargo = listPesquisaCargo.Select(ClienteDGV => new
            {
                Codigo = ClienteDGV.id,
                Nome = ClienteDGV.nome,
                CPF = ClienteDGV.cpf_cnpj,
                Nascimento = ClienteDGV.data_nascimento.ToShortDateString(),
                Telefone = ClienteDGV.telefone,
                Endereço = ClienteDGV.endereco.logradouro

            }).ToList();

            limpaDGVCliente();
            DgvCliente.ItemsSource = novaListCargo;

            //dgvCargoFuncionario.Columns[1].Width = 280;//cargo
            //dgvCargoFuncionario.Columns[2].Width = 60;  // cadastro  
            //dgvCargoFuncionario.Columns[3].Width = 60;//consulta
            //dgvCargoFuncionario.Columns[4].Width = 60;//agenda
            //dgvCargoFuncionario.Columns[5].Width = 60;//financeiro 
        }







        private void btnPesquisa_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtPesquisa.Equals(""))
                {
                    MessageBox.Show("Informa um Nome");
                }
                else
                {
                    buscaCliente(txtPesquisa.Text.Trim().ToUpper());
                }

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
                 ListaCliente = new List<Cliente>();
                ClienteDAO dao = new ClienteDAO();
                ListaCliente = dao.buscaCliente(getDataGridValueAt(DgvCliente, 0));
                Negocio.Definicoes.idClienteSelecionado = ListaCliente[0].id;
                Negocio.Definicoes.nomeClienteselecionado = ListaCliente[0].nome;
                LabelClienteSelecionado.Content = Negocio.Definicoes.idClienteSelecionado + "  " + Negocio.Definicoes.nomeClienteselecionado;

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
                MessageBoxResult result = MessageBox.Show("Selecionar o Cliente: " + Negocio.Definicoes.idClienteSelecionado + "  " + Negocio.Definicoes.nomeClienteselecionado + " ?", "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                    if(tipoabertura != "processo") { 
                    WAdicionarProcesso NovoProcesso = new WAdicionarProcesso();

                    NovoProcesso.Show();
                    }
                    else
                    {
                        this.Close();

                    }
                }
            }

            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }

        private void btnnovocliente_click(object sender, RoutedEventArgs e)
        {
            WCadastroCliente cadastro = new WCadastroCliente();
            cadastro.ShowDialog();
            buscaCliente();
        }
    }
}
