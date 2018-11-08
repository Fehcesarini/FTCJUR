using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio; 

namespace Apresentacao
{
    public partial class FrmClienteCadastro : Form
    {
        Cliente cli;
        object Cliente_id;
        int atualiza_id = 0;

        public FrmClienteCadastro()
        {
            InitializeComponent();
        }

        // Será responsavel por iniciar a classe CargosFuncionarios, e passar os valores dos textBox para os atributos.
        private void populaCliente()
        {
            cli = new Cliente();
            cli.id = atualiza_id;
            cli.nome = txtnome.Text.ToString().ToUpper().Trim();
            cli.cpf_cnpj = mktCPF.Text.ToString().ToUpper().Trim();
            cli.rg_ie = txtRG.Text.ToString().ToUpper().Trim();
            cli.data_nascimento = dtpDataNascimento.Value;
            cli.nacionalidade = txtNacionalidade.Text.ToString().ToUpper().Trim();
            cli.estado_civil = cmbEstadoCivil.SelectedText.ToString().ToUpper().Trim();
            cli.Domicilio = new Domicilio();
            cli.Domicilio.logradouro = txtDomicilio.Text.ToString().ToUpper().Trim();
            cli.Domicilio.cep = mktCepDomicilio.Text.ToString().ToUpper().Trim();
            cli.endereco  = new Endereco();
            cli.endereco.logradouro = txtResidencia.Text.ToString().ToUpper().Trim();
            cli.endereco.cep = mktCepResidencia.Text.ToString().ToUpper().Trim();
            cli.telefone = mktTelefone.Text.ToString().ToUpper().Trim();
            cli.celular = mktCelular.Text.ToString().ToUpper().Trim();
            cli.email = txtEmail.Text.ToString().ToUpper().Trim();
            cli.sexo = cmbSexo.SelectedText.ToString().ToUpper().Trim();           

        }
        private void populaTextBox(Cliente cli)
        {
            atualiza_id = cli.id;
            txtnome.Text = cli.nome;
            mktCPF.Text = cli.cpf_cnpj;
            txtRG.Text = cli.rg_ie;
            dtpDataNascimento.Value = cli.data_nascimento;
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
                MessageBox.Show(e.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(e.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                if (btnSalvar.Text == "Atualizar")
                {
                    AtualizaCliente();
                    LimparCampos();
                    MessageBox.Show("Cliente Alterado, com sucesso!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    gravaCliente();
                     MessageBox.Show("Cargo cadastrado, com sucesso!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
