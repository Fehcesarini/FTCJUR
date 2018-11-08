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

namespace ViewWPF.Configuracao
{
    /// <summary>
    /// Lógica interna para WFuncionario.xaml
    /// </summary>
    public partial class WFuncionario : Window
    {
        public WFuncionario()
        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            buscaCargo();
            buscaFuncionario();

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

        List<CargosFuncionarios> ListCargo;
        Funcionario funcionario;
        Object funcionario_id = 0;

        //Class Funcionando 20/01
        private void buscaCargo()
        {
            ListCargo = new List<CargosFuncionarios>();
            CargosFuncionariosDAO dao = new CargosFuncionariosDAO();
            ListCargo = dao.buscaCargosFuncionarios(); ;
            populaListCargo();
        }

        //Class Funcionando 20/01
        private void populaListCargo()
        {
            var novaListCargo = ListCargo.Select(cargo => new
            {
                Codigo = cargo.id,
                Cargo = cargo.nomecargo,

            }).ToList();



            cbCargo.DataContext = novaListCargo;
            cbCargo.SelectedValuePath = "Codigo";
            cbCargo.DisplayMemberPath = "Cargo";

            


        }



        private void populaFuncionario()
        {

            funcionario = new Funcionario();
            funcionario.id = Convert.ToInt32(funcionario_id.ToString());
            funcionario.nome = txtNome.Text;
            funcionario.cpf_cnpj = txtCpf.Text;
            funcionario.rg_ie = txtRg.Text;
            funcionario.data_nascimento = Convert.ToDateTime(txtNascimento.Text);
            funcionario.email = txtEmail.Text;
            funcionario.telefone = txtTelefone.Text;
            funcionario.celular = txtCelular.Text;
            funcionario.salario = txtSalario.Text;
            funcionario.comissao = Convert.ToDecimal(txtComissao.Text);
            funcionario.data_admissao = Convert.ToDateTime(txtAdimissao.Text);
            funcionario.sexo = cbSexo.Text.ToString(); ;

            funcionario.Login = new Login();
            funcionario.Login.usuario = txtLogin.Text;
            funcionario.Login.senha = txtSenha.Password.ToString();

            funcionario.endereco = new Endereco();
            funcionario.endereco.logradouro = txtEndereco.Text;
            funcionario.endereco.cep = txtCep.Text;

            funcionario.CargoFuncionarios = new CargosFuncionarios();
            funcionario.CargoFuncionarios.id = Convert.ToInt32(cbCargo.SelectedValue);

        }

        private void populaTextBox()
        {

            funcionario = new Funcionario();
            funcionario.id = Convert.ToInt32(funcionario_id.ToString());
            txtNome.Text = funcionario.nome;
            txtCpf.Text = funcionario.cpf_cnpj;
            txtRg.Text = funcionario.rg_ie;
            txtNascimento.Text = funcionario.data_nascimento.ToString();
            txtEmail.Text = funcionario.email;
            txtTelefone.Text = funcionario.telefone;
            txtCelular.Text = funcionario.celular;
            txtSalario.Text = funcionario.salario;
            txtComissao.Text = funcionario.comissao.ToString();
            txtAdimissao.Text = funcionario.data_admissao.ToString();
            cbSexo.SelectedValue = funcionario.sexo;

            funcionario.Login = new Login();
            txtLogin.Text = funcionario.Login.usuario;
            txtSenha.DataContext = funcionario.Login.senha;

            funcionario.endereco = new Endereco();
            txtEndereco.Text = funcionario.endereco.logradouro;
            txtCep.Text = funcionario.endereco.cep;

            funcionario.CargoFuncionarios = new CargosFuncionarios();
            cbCargo.SelectedValue = funcionario.CargoFuncionarios.id;

        }

        private void populaTextBox(Funcionario funcionarios)
        {

            funcionario = new Funcionario();
            funcionario.id = Convert.ToInt32(funcionario_id.ToString());
            txtNome.Text = funcionario.nome;
            txtCpf.Text = funcionario.cpf_cnpj;
            txtRg.Text = funcionario.rg_ie;
            txtNascimento.Text = funcionario.data_nascimento.ToString();
            txtEmail.Text = funcionario.email;
            txtTelefone.Text = funcionario.telefone;
            txtCelular.Text = funcionario.celular;
            txtSalario.Text = funcionario.salario;
            txtComissao.Text = funcionario.comissao.ToString();
            txtAdimissao.Text = funcionario.data_admissao.ToString();
            cbSexo.SelectedValue = funcionario.sexo;

            funcionario.Login = new Login();
            txtLogin.Text = funcionario.Login.usuario;
            txtSenha.DataContext = funcionario.Login.senha;

            funcionario.endereco = new Endereco();
            txtEndereco.Text = funcionario.endereco.logradouro;
            txtCep.Text = funcionario.endereco.cep;

            funcionario.CargoFuncionarios = new CargosFuncionarios();
            cbCargo.SelectedValue = funcionario.CargoFuncionarios.id;

        }



        //Class Funcionando 20/01
        private void limpaCampos()
        {

            funcionario = new Funcionario();
            funcionario.id = 0;
            txtNome.Text = null;
            txtCpf.Text = null;
            txtRg.Text = null;
            txtNascimento.Text = null;
            txtEmail.Text = null;
            txtTelefone.Text = null;
            txtCelular.Text = null;
            txtSalario.Text = null;
            txtComissao.Text = null;
            txtAdimissao.Text = null;
            cbSexo.SelectedValue = null;

            funcionario.Login = new Login();
            txtLogin.Text = null;
            txtSenha.Password = null;

            funcionario.endereco = new Endereco();
            txtEndereco.Text = null;
            txtCep.Text = null;

            funcionario.CargoFuncionarios = new CargosFuncionarios();
            cbCargo.SelectedValue = null;

        }

        private void gravaFuncionario()
        {
            try
            {
                populaFuncionario();
                FuncionarioDAO dao = new FuncionarioDAO();
                dao.cadastroFuncionario(funcionario);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        
            

     

        private void btnSalvarFuncionario_Click(object sender, EventArgs e)
        {
            try
            {
              
                    gravaFuncionario();
                    MessageBox.Show("Funcionario cadastrado, com sucesso!");
                    limpaCampos();
                

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void AtualizaFuncionario()
        {
            try
            {
                populaFuncionario();
                FuncionarioDAO dao = new FuncionarioDAO();
                dao.atualizaFuncionario(funcionario);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
               

        private void populaTextBox(List<Funcionario> listFuncionario)
        {


            funcionario_id = Convert.ToInt32(listFuncionario[0].id.ToString());
            txtNome.Text = listFuncionario[0].nome.ToString();
            txtCpf.Text = listFuncionario[0].cpf_cnpj.ToString();
            txtRg.Text = listFuncionario[0].rg_ie.ToString();
            txtNascimento.Text = listFuncionario[0].data_nascimento.ToString();
            txtEmail.Text = listFuncionario[0].email.ToString();
            txtTelefone.Text = listFuncionario[0].telefone.ToString();
            txtCelular.Text = listFuncionario[0].celular.ToString();
            txtSalario.Text = listFuncionario[0].salario.ToString();
            txtComissao.Text = listFuncionario[0].comissao.ToString();
            txtAdimissao.Text = listFuncionario[0].data_admissao.ToString();
            cbSexo.Text = listFuncionario[0].sexo.ToString();


            txtLogin.Text = listFuncionario[0].Login.usuario.ToString();
            txtSenha.Password = listFuncionario[0].Login.senha.ToString();


            txtEndereco.Text = listFuncionario[0].endereco.logradouro.ToString();
            txtCep.Text = listFuncionario[0].endereco.cep.ToString();


            cbCargo.SelectedValue = listFuncionario[0].CargoFuncionarios.id.ToString();

        }

       

        private void Button_Atualizar(object sender, RoutedEventArgs e)
        {
            try { 
                    AtualizaFuncionario();
                    limpaCampos();
                    MessageBox.Show("Funcionario Alterado, com sucesso!");
                 }
                catch (Exception ers)
                {
                    MessageBox.Show(ers.Message);
                }
         }

        private void BtnLimpar_click(object sender, RoutedEventArgs e)
        {
            try
            {              
                limpaCampos();
                btnSalvarFuncionario.IsEnabled = true;
            }
            catch (Exception ers)
            {
                MessageBox.Show(ers.Message);
            }
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                FuncionarioDAO deleta = new FuncionarioDAO();
                deleta.deletafuncionario(funcionario_id.ToString());                
                MessageBox.Show("Funcionario exluído, com sucesso!");
                
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }


        List<Funcionario> listFuncionario;
        Funcionario Funcionarios;

        

        private void Funcionario()
        {
            Funcionarios = new Funcionario();
            Funcionarios.id = Convert.ToInt32(txtPesquisa.Text.ToString());
            Funcionarios.nome = txtPesquisa.Text.ToString();
        }

        //função funcionando 20/01
        private void buscaFuncionario()
        {
            listFuncionario = new List<Funcionario>();
            FuncionarioDAO dao = new FuncionarioDAO();
            listFuncionario = dao.buscaFuncionario(); ;
            mostraFuncionario();
        }
        //Função Funcionando 20/01
        private void buscaFuncionario(string busca)
        {
            listFuncionario = new List<Funcionario>();
            FuncionarioDAO dao = new FuncionarioDAO();
            listFuncionario = dao.buscaFuncionario(); ;
            mostraFuncionario(busca);
        }
        //Função Funcionando 20/01
        private void limpaDgvFuncionario()
        {
            dgvCliente.ItemsSource = null;
        }
        //Função Funcionando 20/01
        private void mostraFuncionario()
        {
            var novaListCargo = listFuncionario.Select(Funcionarios => new
            {
                Codigo = Funcionarios.id,
                Nome = Funcionarios.nome,
                CPF = Funcionarios.cpf_cnpj,
                Admissão = Funcionarios.data_admissao,
                Cargo = Funcionarios.CargoFuncionarios.nomecargo,
                Salario = Funcionarios.salario,
                Comissão = Funcionarios.comissao,
                Telefone = Funcionarios.telefone,
                Login = Funcionarios.Login.usuario

            }).ToList();

            limpaDgvFuncionario();
            dgvCliente.ItemsSource = novaListCargo;
            


        }
        //Função funcionando 20/01
        private void mostraFuncionario(string busca)
        {
            List<Funcionario> listPesquisaCargo = listFuncionario.FindAll(e => e.nome.Contains(busca));

            var novaListCargo = listPesquisaCargo.Select(Funcionarios => new
            {
                Codigo = Funcionarios.id,
                Nome = Funcionarios.nome,
                CPF = Funcionarios.cpf_cnpj,
                Admissão = Funcionarios.data_admissao,
                Cargo = Funcionarios.CargoFuncionarios.nomecargo,
                Salario = Funcionarios.salario,
                Comissão = Funcionarios.comissao,
                Telefone = Funcionarios.telefone,
                Login = Funcionarios.Login.usuario

            }).ToList();

            limpaDgvFuncionario();
            dgvCliente.ItemsSource = novaListCargo;
            


        }
          
        

       
        //Função Funcionando 20/01
        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            if (txtPesquisa.Equals(""))
            {
                MessageBox.Show("Informa um Nome");
            }
            else
            {
                buscaFuncionario(txtPesquisa.Text.Trim().ToUpper());
            }
        }

       
        private void atualizaFuncionario()
        {
            try
            {

                listFuncionario = new List<Funcionario>();
                FuncionarioDAO dao = new FuncionarioDAO();
                listFuncionario = dao.buscaFuncionario(getDataGridValueAt(dgvCliente, 0));
                            
                buscaFuncionario();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                
                    FuncionarioDAO deleta = new FuncionarioDAO();
                    deleta.deletafuncionario(getDataGridValueAt(dgvCliente, 0));
                    buscaFuncionario();
                    MessageBox.Show("Funcionario exluído, com sucesso!");              


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
                FuncionarioDAO dao = new FuncionarioDAO();
                populaTextBox(dao.buscaFuncionario(getDataGridValueAt(dgvCliente, 0)));
                btnSalvarFuncionario.IsEnabled = false;

            }

            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
    }
}

