using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using ViewWPF.Class;

namespace ViewWPF.Lancamentos
{
    /// <summary>
    /// Lógica interna para WNovoProcesso.xaml
    /// </summary>
    public partial class WNovoProcesso : Window
    {
        //Variaveis locais Carregadas na abertura da Pagina
        public int IdCliente = Definicoes.idClienteSelecionado;
        public string NomeCliente = Definicoes.nomeClienteselecionado;

        public WNovoProcesso()
        {
            InitializeComponent();
            GeraNumeroPasta();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            buscaCargoFuncionario();
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
            try { 
            
            this.Close();
        }
            catch (Exception er)
            {
                _vm.ShowError(er.Message);
                
            }
}
        private void PackIcon_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        List<Funcionario> ListCargoFuncionario;        
        private void buscaCargoFuncionario()
        {
            try { 
            ListCargoFuncionario = new List<Funcionario>();
            FuncionarioDAO dao = new FuncionarioDAO();
            ListCargoFuncionario = dao.buscaFuncionario(); ;
            populaListCargoFuncionario();
            }
            catch (Exception er)
            {
                _vm.ShowError(er.Message);

            }
        }        
        private void populaListCargoFuncionario()
        {
            try { 
            var novaListCargo = ListCargoFuncionario.Select(cargo => new
            {
                Codigo = cargo.id,
                Funcionario = cargo.nome,

            }).ToList();



            cmbFuncionario.DataContext = novaListCargo;
            cmbFuncionario.SelectedValuePath = "Codigo";
            cmbFuncionario.DisplayMemberPath = "Funcionario";
            }
            catch (Exception er)
            {
                _vm.ShowError(er.Message);

            }
        }
        


        List<Cliente> listaCliente = new List<Cliente>();
        List<Cliente> listaClienteReu = new List<Cliente>();
        List<ProcessoPessoaVinc> ClienteEscritorio = new List<ProcessoPessoaVinc>();
        
        private void mostraCliente()
        {
            try { 
            string ecliente = null;
            IdCliente = Definicoes.idClienteSelecionado;
            NomeCliente = Definicoes.nomeClienteselecionado;
                try
                {
                    var retorno = listaCliente.Single(r => r.id == IdCliente);
                    _vm.ShowWarning("Você já incluiu essa pessoa!");

                }
                catch (Exception )     {
                                  

                MessageBoxResult result = MessageBox.Show("É cliente?", "", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    { ecliente = "C"; }
                    Cliente cliente = new Cliente();


                    cliente.id = IdCliente;
                    cliente.nome = NomeCliente;
                    cliente.cpf_cnpj = null;
                    cliente.rg_ie = null;
                    cliente.data_nascimento = Convert.ToDateTime(null);
                    cliente.nacionalidade = null;
                    cliente.estado_civil = null;
                    cliente.telefone = null;
                    cliente.celular = null;
                    cliente.email = null;
                    cliente.sexo = null;
                    cliente.excluido = false;


                    cliente.endereco = new Endereco();
                    cliente.endereco.logradouro = null;
                    cliente.endereco.cep = null;

                    cliente.Domicilio = new Domicilio();
                    cliente.Domicilio.logradouro = null;
                    cliente.Domicilio.cep = ecliente;
                    listaCliente.Add(cliente);

                    var novalistacliente = listaCliente.Select(clientedgv => new
                    {

                        Codigo = clientedgv.id,
                        Nome = clientedgv.nome,
                        Merda = clientedgv.Domicilio.cep,



                    }).ToList();

                    ListAutor.ItemsSource = null;
                    ListAutor.ItemsSource = novalistacliente;
                }
            }
            catch (Exception er)
            {
                _vm.ShowError(er.Message);

            }


}
        private void mostraClienteReu()
        {
            try {
                string ecliente = null;
                IdCliente = Definicoes.idClienteSelecionado;
                NomeCliente = Definicoes.nomeClienteselecionado;
                try
                {
                    var retorno = listaClienteReu.Single(r => r.id == IdCliente);
                    _vm.ShowWarning("Você já incluiu essa pessoa!");

                }
                catch (Exception)
                {

                    MessageBoxResult result = MessageBox.Show("É cliente?", "", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    { ecliente = "C"; }
                    Cliente cliente = new Cliente();

                    cliente.id = IdCliente;
                    cliente.nome = NomeCliente;
                    cliente.cpf_cnpj = null;
                    cliente.rg_ie = null;
                    cliente.data_nascimento = Convert.ToDateTime(null);
                    cliente.nacionalidade = null;
                    cliente.estado_civil = null;
                    cliente.telefone = null;
                    cliente.celular = null;
                    cliente.email = null;
                    cliente.sexo = null;
                    cliente.excluido = false;


                    cliente.endereco = new Endereco();
                    cliente.endereco.logradouro = null;
                    cliente.endereco.cep = null;

                    cliente.Domicilio = new Domicilio();
                    cliente.Domicilio.logradouro = null;
                    cliente.Domicilio.cep = ecliente;
                    listaClienteReu.Add(cliente);

                    var novalistacliente = listaClienteReu.Select(clientedgv => new
                    {

                        Codigo = clientedgv.id,
                        Nome = clientedgv.nome,
                        Merda = clientedgv.Domicilio.cep,

                    }).ToList();

                    ListReu.ItemsSource = null;
                    ListReu.ItemsSource = novalistacliente;
                }
           
            }
            catch (Exception er)
            {
                _vm.ShowError(er.Message);

            }

        }
        


        //Funções para Incluir Processo
        Processo proc;
        private void populaProcesso()
        {
            try { 
            proc = new Processo();
            if (cmbFuncionario.SelectedValue != null) { proc.funcionario_fun_id = Convert.ToInt32(cmbFuncionario.SelectedValue.ToString()); }
            else { proc.funcionario_fun_id = Convert.ToInt32(string.Empty); }
            if (cmbnatureza.SelectedValue != null) { proc.PROC_NATUREZA = cmbnatureza.Text.ToString(); }
            else { proc.PROC_NATUREZA = string.Empty; }
            proc.PROC_ID = Convert.ToInt32(txtpastaprocesso.Text);
            proc.PROC_NUMEROPROCESSO = txtnumeroprocesso.Text;
            proc.PROC_PALAVRACHAVE = txtpalavrachave.Text;
            proc.PROC_CLASSEPROCEDIMENTO = txtclaseprocedimento.Text;
            proc.PROC_AREA = txtareaprocesso.Text;
            proc.PROC_COMPETENCIA = txtcompetenciaprocesso.Text;
            proc.PROC_FORUM = txtforumprocesso.Text;
            proc.PROC_COMARCA = txtcomarcaprocesso.Text;
            proc.PROC_VARA = txtvaraprocesso.Text;            
            proc.PROC_INSTANCIA = txtInstanciaprocesso.Text;
            proc.PROC_VALORDACAUSA = txtvalordacausaestimativaprocesso.Text;
            proc.PROC_ASSUNTO = txtassuntoprocesso.Text;
            proc.PROC_DTCADASTRO = DateTime.Now.ToShortDateString();
            }
            catch (Exception er)
            {
                _vm.ShowError(er.Message);

            }

        }
        private void LimparProcesso()
        {
            try { 
            proc = new Processo();
            cmbFuncionario.SelectedValue = null;
            cmbnatureza.SelectedValue = null;
            txtnumeroprocesso.Text = null;
            txtpastaprocesso.Text = null;
            txtpalavrachave.Text = null;
            txtclaseprocedimento.Text = null;
            txtareaprocesso.Text = null;
            txtcompetenciaprocesso.Text = null;
            txtforumprocesso.Text = null;
            txtcomarcaprocesso.Text = null;
            txtvaraprocesso.Text = null;
            txtInstanciaprocesso.Text = null;
            txtvalordacausaestimativaprocesso.Text = null;
            txtassuntoprocesso.Text = null;
                ListAutor.ItemsSource = null;
                ListReu.ItemsSource = null;
                listaCliente.Clear();
                listaClienteReu.Clear();
            }
            catch (Exception er)
            {
                _vm.ShowError(er.Message);

            }
        }
        private void gravaProcesso()
        {
            try
            {
                populaProcesso();
                ProcessoDAO dao = new ProcessoDAO();
                dao.cadastroProcesso(proc);
                gravaProcessoPessoaVinc();
                _vm.ShowSuccess("Processo gravado com sucesso");
                LimparProcesso();

            }
            catch (Exception e)
            {
                _vm.ShowError(e.Message);
                
            }
        }
        private void gravaProcessoPessoaVinc()
        {
            try
            {                              
                for (int i = 0; i < listaCliente.Count; i++)
                {
                    ProcessoPessoaVinc proc = new ProcessoPessoaVinc();
                    proc.cliente_CLI_ID = listaCliente[i].id;
                    proc.processo_PROC_ID = Convert.ToInt32(txtpastaprocesso.Text);
                    proc.CLI_PRO_TIPOCLIENTEPROC = "Autor";
                    proc.CLI_PRO_CLIENTEESCRITORIO = listaCliente[i].Domicilio.cep;                    
                    ProcessoPessoaVincDAO dao = new ProcessoPessoaVincDAO();
                    dao.cadastroProcesso(proc);

                }

                for (int i = 0; i < listaClienteReu.Count; i++)
                {
                    ProcessoPessoaVinc proc = new ProcessoPessoaVinc();
                    proc.cliente_CLI_ID = listaClienteReu[i].id;
                    proc.processo_PROC_ID = Convert.ToInt32(txtpastaprocesso.Text);
                    proc.CLI_PRO_TIPOCLIENTEPROC = "Reu";
                    proc.CLI_PRO_CLIENTEESCRITORIO = listaClienteReu[i].Domicilio.cep;                   
                    ProcessoPessoaVincDAO dao = new ProcessoPessoaVincDAO();
                    dao.cadastroProcesso(proc);

                }


                

            }
            catch (Exception e)
            {
                _vm.ShowError(e.Message);

            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                gravaProcesso();
                
                
        }
            catch (Exception er)
            {
                _vm.ShowError(er.Message);
                
            }

}
        private void Clic_NovoAutor(object sender, RoutedEventArgs e)
        {
            try
            {
                WSelecionaCliente selecionacliente = new WSelecionaCliente("processo");
                selecionacliente.ShowDialog();               
                mostraCliente();               
            }
            catch (Exception er)
            {
                _vm.ShowError(er.Message);

            }
        }
        private void Clic_NovoReu(object sender, RoutedEventArgs e)
        {
            try
            {
                WSelecionaCliente selecionacliente = new WSelecionaCliente("processo");
                selecionacliente.ShowDialog();
                mostraClienteReu();
            }
            catch (Exception er)
            {
                _vm.ShowError(er.Message);

            }
        }
        private void click_deletarReu(object sender, RoutedEventArgs e)
        {
            try { 
            MaterialDesignThemes.Wpf.Chip tb = (MaterialDesignThemes.Wpf.Chip)sender;
            object data = tb.DataContext;
            string valorespecifico = tb.DataContext.ToString();
            string parte = valorespecifico.Substring(0, valorespecifico.IndexOf(","));
            IdCliente = Convert.ToInt32(parte.Substring(10));
            string partenome = valorespecifico.Substring(20 + Convert.ToString(IdCliente).Length);
            partenome = partenome.Replace(" }", "");     
            

            Cliente cliente = new Cliente();

            cliente.id = IdCliente;
            cliente.nome = partenome;
            cliente.cpf_cnpj = null;
            cliente.rg_ie = null;
            cliente.data_nascimento = Convert.ToDateTime(null);
            cliente.nacionalidade = null;
            cliente.estado_civil = null;
            cliente.telefone = null;
            cliente.celular = null;
            cliente.email = null;
            cliente.sexo = null;
            cliente.excluido = false;


            cliente.endereco = new Endereco();
            cliente.endereco.logradouro = null;
            cliente.endereco.cep = null;

            cliente.Domicilio = new Domicilio();
            cliente.Domicilio.logradouro = null;
            cliente.Domicilio.cep = null;
            listaClienteReu.Remove(cliente);

            var itemToRemove = listaClienteReu.Single(r => r.id == IdCliente);
            listaClienteReu.Remove(itemToRemove);

            var novalistacliente = listaClienteReu.Select(clientedgv => new
            {
                Codigo = clientedgv.id,
                Nome = clientedgv.nome,
                Merda = clientedgv.Domicilio.cep,

            }).ToList();

            ListReu.ItemsSource = null;
            ListReu.ItemsSource = novalistacliente;
            }
            catch (Exception er)
            {
                _vm.ShowError(er.Message);

            }


        }
        private void Click_deletarAutor(object sender, RoutedEventArgs e)
        {
            try { 
            MaterialDesignThemes.Wpf.Chip tb = (MaterialDesignThemes.Wpf.Chip)sender;
            object data = tb.DataContext;
            string valorespecifico = tb.DataContext.ToString();
            string parte = valorespecifico.Substring(0, valorespecifico.IndexOf(","));
            IdCliente = Convert.ToInt32(parte.Substring(10));
            string partenome = valorespecifico.Substring(20 + Convert.ToString(IdCliente).Length);
            partenome = partenome.Replace(" }", "");


            Cliente cliente = new Cliente();

            cliente.id = IdCliente;
            cliente.nome = partenome;
            cliente.cpf_cnpj = null;
            cliente.rg_ie = null;
            cliente.data_nascimento = Convert.ToDateTime(null);
            cliente.nacionalidade = null;
            cliente.estado_civil = null;
            cliente.telefone = null;
            cliente.celular = null;
            cliente.email = null;
            cliente.sexo = null;
            cliente.excluido = false;


            cliente.endereco = new Endereco();
            cliente.endereco.logradouro = null;
            cliente.endereco.cep = null;

            cliente.Domicilio = new Domicilio();
            cliente.Domicilio.logradouro = null;
            cliente.Domicilio.cep = null;
            listaCliente.Remove(cliente);

            var itemToRemove = listaCliente.Single(r => r.id == IdCliente);
            listaCliente.Remove(itemToRemove);

            var novalistacliente = listaCliente.Select(clientedgv => new
            {
                Codigo = clientedgv.id,
                Nome = clientedgv.nome,
                Merda = clientedgv.Domicilio.cep,

            }).ToList();

            ListAutor.ItemsSource = null;
            ListAutor.ItemsSource = novalistacliente;
            }
            catch (Exception er)
            {
                _vm.ShowError(er.Message);

            }
        }
        private void click_autor(object sender, RoutedEventArgs e)
        {
            try { 
            MaterialDesignThemes.Wpf.Chip tb = (MaterialDesignThemes.Wpf.Chip)sender;
            object data = tb.DataContext;
            string valorespecifico = tb.DataContext.ToString();
            string parte = valorespecifico.Substring(0, valorespecifico.IndexOf(","));
            IdCliente = Convert.ToInt32(parte.Substring(10));
            string partenome = valorespecifico.Substring(20 + Convert.ToString(IdCliente).Length);
            NomeCliente = partenome.Replace(" }", "");

            WAdicionarProcesso adicionaprocesso = new WAdicionarProcesso();
            adicionaprocesso.Show();
            }
            catch (Exception er)
            {
                _vm.ShowError(er.Message);

            }

        }
        private void GeraNumeroPasta()
        {try
            {
                txtpastaprocesso.Text = Convert.ToString(30 * 5 + 3 + Convert.ToInt32(DateTime.Now.Day.ToString()) + Convert.ToInt32(DateTime.Now.Millisecond.ToString()) * Convert.ToInt32(DateTime.Now.Second.ToString()) + Convert.ToInt32(DateTime.Now.Month.ToString() + Convert.ToInt32(DateTime.Now.Millisecond.ToString()) * Convert.ToInt32(DateTime.Now.Minute.ToString())));
            }
            catch (Exception er)
            {
                _vm.ShowError(er.Message);

            }
        }
    }
}
