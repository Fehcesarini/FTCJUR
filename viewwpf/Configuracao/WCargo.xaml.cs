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
using System.Collections.ObjectModel;
using System.Reflection;
using System.Data;
using ToastNotifications.Messages;
using ToastNotifications;
using ToastNotifications.Position;
using ToastNotifications.Lifetime;
using ViewWPF.Class;


namespace ViewWPF.Configuracao
{
    /// <summary>
    /// Lógica interna para WCargo.xaml
    /// </summary>
    public partial class WCargo : Window
    {
        CargosFuncionarios Cargo;
        object Cargo_id;
        int atualiza_id;


        public WCargo()
        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            buscaCargo();

            DataContext = _vm = new MainViewModelNotificacao();

            Unloaded += OnUnload;
        }       
        
        private readonly MainViewModelNotificacao _vm;

        private void OnUnload(object sender, RoutedEventArgs e)
        {
            _vm.OnUnloaded();
        }
      

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            datatool.Text = DateTime.Now.ToLongDateString();
            horatoll.Text = DateTime.Now.ToLongTimeString();
        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void PackIcon_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void populaCargo()
        {
            Cargo = new CargosFuncionarios();
            Cargo.id = atualiza_id;
            Cargo.nomecargo = txtNomeCargo.Text;
            Cargo.permissaoagenda = Convert.ToBoolean(ckbPermissaoAgenda.IsChecked.ToString());
            Cargo.permissaocadastro = Convert.ToBoolean(ckbPermissaoCadastro.IsChecked.ToString());
            Cargo.permissaoconsulta = Convert.ToBoolean(ckbPermissaoConsulta.IsChecked.ToString());
            Cargo.permissaofinanceiro = Convert.ToBoolean(ckbPermissaoFinanceiro.IsChecked.ToString());

        }

        // Será responsavel por passar os valores dos atributos para os textbox
        private void populaTextBox(CargosFuncionarios Cargo)
        {
            atualiza_id = Cargo.id;
            txtNomeCargo.Text = Cargo.nomecargo;
            ckbPermissaoAgenda.IsChecked = Convert.ToBoolean(Cargo.permissaoagenda);
            ckbPermissaoCadastro.IsChecked = Convert.ToBoolean(Cargo.permissaocadastro);
            ckbPermissaoConsulta.IsChecked = Convert.ToBoolean(Cargo.permissaoconsulta);
            ckbPermissaoFinanceiro.IsChecked = Convert.ToBoolean(Cargo.permissaofinanceiro);

        }

        private void LimparCampos()
        {
            txtNomeCargo.Text = "";
            ckbPermissaoAgenda.IsChecked = false;
            ckbPermissaoCadastro.IsChecked = false;
            ckbPermissaoConsulta.IsChecked = false;
            ckbPermissaoFinanceiro.IsChecked = false;

        }

        // Irá execultar a rotina de gravar e atualizar.
        private void gravaCargo()
        {
            try
            {
                populaCargo();
                CargosFuncionariosDAO dao = new CargosFuncionariosDAO();
                dao.cadastroCargosFuncionarios(Cargo);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void AtualizaCargo()
        {
            try
            {
                populaCargo();
                CargosFuncionariosDAO dao = new CargosFuncionariosDAO();
                dao.atualizaCargosFuncionarios(Cargo);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }




        private void btnCadastrarCargo_Click_1(object sender, EventArgs e)
        {
            try
            {             

                gravaCargo();                
                _vm.ShowSuccess("Cargo " + txtNomeCargo.Text + " cadastrado, com sucesso!");
                LimparCampos();
                buscaCargo();

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

       


        
        List<CargosFuncionarios> ListaCargos;
        CargosFuncionarios CargoDGV;

        public object AtualizaCargoFuncionario { get; private set; }

        // object Cargo_id;

        private void populaCargoDGV()
        {
            CargoDGV = new CargosFuncionarios();
            CargoDGV.id = Convert.ToInt32(txtPesquisa.Text.ToString());
            CargoDGV.nomecargo = txtPesquisa.Text.ToString();

        }

        // Método usado para buscar o Produto do Banco de dados.
        private void buscaCargo()
        {
            ListaCargos = new List<CargosFuncionarios>();
            CargosFuncionariosDAO dao = new CargosFuncionariosDAO();
            ListaCargos = dao.buscaCargosFuncionarios(); ;
            mostraCargo();
        }

        // Método usado para buscar o Produto do Banco de dados.
        private void buscaCargo(string busca)
        {
            ListaCargos = new List<CargosFuncionarios>();
            CargosFuncionariosDAO dao = new CargosFuncionariosDAO();
            ListaCargos = dao.buscaCargosFuncionarios(); ;
            mostraCargo(busca);
        }

        private void limpaDgvCargo()
        {
            dgvCargoFuncionario.ItemsSource = null;
        }

        // Mostra os dados dos Fornecedor nos TextBox
        private void mostraCargo()
        {
            var novaListCargo = ListaCargos.Select(CargoDGV => new
            {
                Codigo = CargoDGV.id,
                Cargo = CargoDGV.nomecargo,
                Cadastro = CargoDGV.permissaocadastro,
                Consulta = CargoDGV.permissaoconsulta,
                Agenda = CargoDGV.permissaoagenda,
                Financeiro = CargoDGV.permissaofinanceiro

            }).ToList();

            limpaDgvCargo();
            dgvCargoFuncionario.ItemsSource = novaListCargo;

            //dgvCargoFuncionario.Columns[1].Width = 280;//cargo
            //dgvCargoFuncionario.Columns[2].Width = 60;  // cadastro  
            //dgvCargoFuncionario.Columns[3].Width = 60;//consulta
            //dgvCargoFuncionario.Columns[4].Width = 60;//agenda
            //dgvCargoFuncionario.Columns[5].Width = 60;//financeiro 

        }

        // Mostra os dados dos Fornecedor nos TextBox
        private void mostraCargo(string busca)
        {

            List<CargosFuncionarios> listPesquisaCargo = ListaCargos.FindAll(e => e.nomecargo.Contains(busca));

            var novaListCargo = listPesquisaCargo.Select(CargoDGV => new
            {
                Codigo = CargoDGV.id,
                Cargo = CargoDGV.nomecargo,
                Cadastro = CargoDGV.permissaocadastro,
                Consulta = CargoDGV.permissaoconsulta,
                Agenda = CargoDGV.permissaoagenda,
                Financeiro = CargoDGV.permissaofinanceiro

            }).ToList();

            limpaDgvCargo();
            dgvCargoFuncionario.ItemsSource = novaListCargo;

            //dgvCargoFuncionario.Columns[1].Width = 280;//cargo
            //dgvCargoFuncionario.Columns[2].Width = 60;  // cadastro  
            //dgvCargoFuncionario.Columns[3].Width = 60;//consulta
            //dgvCargoFuncionario.Columns[4].Width = 60;//agenda
            //dgvCargoFuncionario.Columns[5].Width = 60;//financeiro 
        }







        private void btnPesquisa_Click(object sender, EventArgs e)
        {

            if (txtPesquisa.Equals(""))
            {
                MessageBox.Show("Informa um Nome");
            }
            else
            {
                buscaCargo(txtPesquisa.Text.Trim().ToUpper());
            }


        }

      



        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {

                CargosFuncionariosDAO deleta = new CargosFuncionariosDAO();
                deleta.deletaCargosFuncionarios(atualiza_id.ToString());
                buscaCargo();
                MessageBox.Show("Cargo exluído, com sucesso!");




            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AtualizaCargo();
                LimparCampos();
                buscaCargo();
                MessageBox.Show("Cargo Alterado, com sucesso!");
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void BtnLimpar_click(object sender, RoutedEventArgs e)
        {
            try
            {
                LimparCampos();
                btnCadastrarCargo.IsEnabled = true;
            }

            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
      

        private void dgvCargoFuncionario_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {                              
                CargosFuncionariosDAO dao = new CargosFuncionariosDAO();                
                populaTextBox(dao.buscaCargosFuncionariosPopulatextbox(getDataGridValueAt(dgvCargoFuncionario, 0)));
                btnCadastrarCargo.IsEnabled = false;    

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

        private void btnPesquisa_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}

