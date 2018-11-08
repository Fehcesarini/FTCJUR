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
    /// Lógica interna para WCadastroCliente.xaml
    /// </summary>
    public partial class WCadastroCliente : Window
    {
        Cliente cli;
        object Cliente_id;
        int atualiza_id = 0;

        public WCadastroCliente()

        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

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
        // Será responsavel por iniciar a classe CargosFuncionarios, e passar os valores dos textBox para os atributos.
        private void populaCliente()
        {
            cli = new Cliente();
            cli.id = atualiza_id;
            cli.nome = txtnome.Text.ToString().ToUpper().Trim();
            cli.cpf_cnpj = mktCPF.Text.ToString().ToUpper().Trim();
            cli.rg_ie = txtRG.Text.ToString().ToUpper().Trim();
            if (dtpDataNascimento.Text != "") { cli.data_nascimento = Convert.ToDateTime(dtpDataNascimento.Text.ToString()); }
            else { cli.data_nascimento = Convert.ToDateTime(string.Empty); }
            cli.nacionalidade = txtNacionalidade.Text.ToString().ToUpper().Trim();
            if (cmbEstadoCivil.SelectedValue != null) { cli.estado_civil = cmbEstadoCivil.Text.ToString().ToUpper().Trim(); }
            else { cli.estado_civil = string.Empty; }
            cli.Domicilio = new Domicilio();
            cli.Domicilio.logradouro = txtDomicilio.Text.ToString().ToUpper().Trim();
            cli.Domicilio.cep = mktCepDomicilio.Text.ToString().ToUpper().Trim();
            cli.endereco = new Endereco();
            cli.endereco.logradouro = txtResidencia.Text.ToString().ToUpper().Trim();
            cli.endereco.cep = mktCepResidencia.Text.ToString().ToUpper().Trim();
            cli.telefone = mktTelefone.Text.ToString().ToUpper().Trim();
            cli.celular = mktCelular.Text.ToString().ToUpper().Trim();
            cli.email = txtEmail.Text.ToString().ToUpper().Trim();
            if (cmbSexo.SelectedValue != null) { cli.sexo = cmbSexo.Text.ToString().ToUpper().Trim(); }
            else { cli.sexo = string.Empty; }

        }
        private void populaTextBox(Cliente cli)
        {
            atualiza_id = cli.id;
            txtnome.Text = cli.nome;
            mktCPF.Text = cli.cpf_cnpj;
            txtRG.Text = cli.rg_ie;
            dtpDataNascimento.Text = cli.data_nascimento.ToString();
            txtNacionalidade.Text = cli.nacionalidade;
            cmbEstadoCivil.SelectedItem = cli.estado_civil;
            txtDomicilio.Text = cli.Domicilio.logradouro;
            mktCepDomicilio.Text = cli.Domicilio.cep;
            txtResidencia.Text = cli.endereco.logradouro;
            mktCepResidencia.Text = cli.endereco.cep;
            mktTelefone.Text = cli.telefone;
            mktCelular.Text = cli.celular;
            txtEmail.Text = cli.email;
            cmbSexo.SelectedItem = cli.sexo;

        }

        private void LimparCampos()
        {
            atualiza_id = 0;
            txtnome.Text = null;
            mktCPF.Text = null;
            txtRG.Text = null;
            dtpDataNascimento.Text = null;
            txtNacionalidade.Text = null;
            cmbEstadoCivil.SelectedItem = null;
            txtDomicilio.Text = null;
            mktCepDomicilio.Text = null;
            txtResidencia.Text = null;
            mktCepResidencia.Text = null;
            mktTelefone.Text = null;
            mktCelular.Text = null;
            txtEmail.Text = null;
            cmbSexo.SelectedItem = null;

        }

        private void gravaCliente()
        {
            try
            {
                populaCliente();
                ClienteDAO dao = new ClienteDAO();
                dao.cadastroCliente(cli);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void AtualizaCliente()
        {
            try
            {
                populaCliente();
                ClienteDAO dao = new ClienteDAO();
                dao.atualizaCliente(cli);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //private void button3_Click(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        if (btnSalvar.Text == "Atualizar")
        //        {
        //            AtualizaCliente();
        //            LimparCampos();
        //            MessageBox.Show("Cliente Alterado, com sucesso!");
        //            this.Close();
        //        }
        //        else
        //        {
        //            gravaCliente();
        //            MessageBox.Show("Cargo cadastrado, com sucesso!");
        //            LimparCampos();
        //        }

        //    }
        //    catch (Exception er)
        //    {
        //        MessageBox.Show(er.Message);
        //    }
        //}

        private void BtnLimpar_click(object sender, RoutedEventArgs e)
        {

            try
            {
                LimparCampos();
                btnSalvarCliente.IsEnabled = true;


            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnSalvarCliente_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                gravaCliente();
                MessageBox.Show("Cargo Cliente, com sucesso!");
                LimparCampos();


            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }
    }
}
