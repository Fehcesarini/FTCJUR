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
using System.IO;
using Microsoft.Win32;


namespace ViewWPF.Lancamentos
{
    /// <summary>
    /// Lógica interna para WAdicionarProcesso.xaml
    /// </summary>
    public partial class WAdicionarProcesso : Window
    {
        //Variaveis locais Carregadas na abertura da Pagina
        public int IdCliente = Definicoes.idClienteSelecionado;
        public string NomeCliente = Definicoes.nomeClienteselecionado;
        public string IDConjuge = Definicoes.idConjuge;
        public string IdPrevidenciario = Definicoes.idPrevidenciario;
        public string IdPenal = Definicoes.idPenal;
        public string IdBanco = Definicoes.idBanco;
        public string IdTrabalhista = Definicoes.idTrabalhista;
        public string IdFilho;
        public string IdBens;

        //Funções cabeçalho, minimizar, voltar, hora, carregar nome cliente. 
        public WAdicionarProcesso()
        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            NomeCabecalho.Text = NomeCabecalho.Text + " " + IdCliente.ToString() + " " + NomeCliente.ToString();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            //busca cliente text box 
            CarregaVariavel();
            BuscaClienteTextBox();
            

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
        //funcção carrega valor variaveis
        public void CarregaVariavel()
        {
              IdCliente = Definicoes.idClienteSelecionado;
              NomeCliente = Definicoes.nomeClienteselecionado;
             IDConjuge = Definicoes.idConjuge;
             IdPrevidenciario = Definicoes.idPrevidenciario;
             IdPenal = Definicoes.idPenal;
             IdBanco = Definicoes.idBanco;
             IdTrabalhista = Definicoes.idTrabalhista;

    }
        //Funções dados clientes
        Cliente cli;
        object Cliente_id;
        int atualiza_id = 0;
        private void populaCliente()
        {
            cli = new Cliente();
            cli.id = atualiza_id;
            cli.nome = txtnome.Text.ToString().ToUpper().Trim();
            cli.cpf_cnpj = mktCPF.Text.ToString().ToUpper().Trim();
            cli.rg_ie = txtRG.Text.ToString().ToUpper().Trim();
            if(dtpDataNascimento.Text != "") { cli.data_nascimento = Convert.ToDateTime(dtpDataNascimento.Text.ToString()); }
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
            if(cmbSexo.SelectedValue != null) { cli.sexo = cmbSexo.Text.ToString().ToUpper().Trim(); }
            else { cli.sexo = string.Empty; }
           

        }        
        private void LimparCamposCliente()
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

        //Funções para Conjuge
        Conjuge con;
        private void populaConjuge()
        {
            con = new Conjuge();
            if (IDConjuge != "")
            {
                con.id = Convert.ToInt32(IDConjuge);
            }
            con.nome = txtNomeConjugue.Text.ToString().ToUpper().Trim();
            con.cpf_cnpj = txtCpfConjugue.Text.ToString().ToUpper().Trim();
            con.rg_ie = txtRgConjugue.Text.ToString().ToUpper().Trim();
            if (dtpDataNascimentoConjuge.Text != "") { con.data_nascimento = Convert.ToDateTime(dtpDataNascimentoConjuge.Text.ToString()); }
            else { con.data_nascimento = Convert.ToDateTime(string.Empty); }
            con.nacionalidade = txtNacionalidadeConjuge.Text.ToString().ToUpper().Trim();
            if (cmbEstadoCivilConjuge.SelectedValue != null) { con.estado_civil = cmbEstadoCivilConjuge.Text.ToString().ToUpper().Trim(); }
            else { con.estado_civil = string.Empty; }
            con.Domicilio = new Domicilio();
            con.Domicilio.logradouro = txtDomicilioConjugye.Text.ToString().ToUpper().Trim();
            con.Domicilio.cep = txtCepDomicilioConjugue.Text.ToString().ToUpper().Trim();
            con.endereco = new Endereco();
            con.endereco.logradouro = txtEnderecoConjugye.Text.ToString().ToUpper().Trim();
            con.endereco.cep = txtCepEnderecoConjugue.Text.ToString().ToUpper().Trim();
            con.telefone = txtTelefoneConjugue.Text.ToString().ToUpper().Trim();
            con.celular = txtCelularConjugue.Text.ToString().ToUpper().Trim();
            con.email = txtEmailConjugue.Text.ToString().ToUpper().Trim();
            if (cmbSexoConjuge.SelectedValue != null) { con.sexo = cmbSexoConjuge.Text.ToString().ToUpper().Trim(); }
            else { con.sexo = string.Empty; }
            

        }
        private void LimparCamposConjuge()
        {
            txtNomeConjugue.Text = null;
            txtCpfConjugue.Text = null;
            txtRgConjugue.Text = null;
            dtpDataNascimentoConjuge.Text = null;
            txtNacionalidadeConjuge.Text = null;
            cmbEstadoCivilConjuge.SelectedValue = null;
            txtDomicilioConjugye.Text = null;
            txtCepDomicilioConjugue.Text = null;
            txtEnderecoConjugye.Text = null;
            txtCepEnderecoConjugue.Text = null;
            txtTelefoneConjugue.Text = null;
            txtCelularConjugue.Text = null;
            txtEmailConjugue.Text = null;
            cmbSexoConjuge.SelectedValue = null;

        }
        private void gravaConjuge()
        {
            try
            {
                if(IDConjuge == "") // Grava um Novo Conjuge
                {
                    populaConjuge();
                    ConjugeDAO dao = new ConjugeDAO();
                    dao.cadastroConjuge(con);
                    MessageBox.Show("Gravado novo conjuge com sucesso");

                }
                else // Atualiza o Conjuge
                {
                    populaConjuge();
                    ConjugeDAO dao = new ConjugeDAO();
                    dao.atualizaConjuge(con);
                    MessageBox.Show("Atualizado conjuge com sucesso");
                }
               

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Funções para Banco
        DadoBancario ban;
        private void populaBanco()
        {
            ban = new DadoBancario();
            if (IdBanco != "")
            {
                ban.id = Convert.ToInt32(IdBanco);
            }
            ban.Agencia = txtAgencia.Text.ToString().ToUpper();
            ban.banco = txtBanco.Text.ToString().ToUpper();
            if(cmbConta.SelectedValue != null) { ban.TipoConta = cmbConta.Text.ToString(); }
            else { ban.TipoConta = string.Empty; }
            ban.numero = txtConta.Text.ToString().ToUpper();        


        }
        private void LimparBanco()
        {
            txtBanco.Text = null;
            txtAgencia.Text = null;
            cmbConta.SelectedValue = null;
            txtConta.Text = null;

        }
        private void gravaBanco()
        {
            try
            {
                if (IdBanco == "") // Grava um Novo Conjuge
                {
                    populaBanco();
                    DadoBancarioDAO dao = new DadoBancarioDAO();
                    dao.cadastroDadoBancario(ban);
                    MessageBox.Show("Gravado novo Dados Bancários com sucesso");

                }
                else // Atualiza o Conjuge
                {
                    populaBanco();
                    DadoBancarioDAO dao = new DadoBancarioDAO();
                    dao.atualizaDadoBancario(ban);
                    MessageBox.Show("Atualizado Dados Bancários com sucesso");
                }


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Funções para Penal
        Penal pen;
        private void populaPenal()
        {
            pen = new Penal();
            if (IdPenal != "")
            {
                pen.id = Convert.ToInt32(IdPenal);
            }
            pen.crime = txtCrime.Text.ToString().ToUpper();
            pen.acao_penal = txtAcaoPenal.Text.ToString().ToUpper();
            if(cmbRitoProcessual.SelectedValue != null) { pen.rito_processual = cmbRitoProcessual.Text.ToString(); }
            else { pen.rito_processual = string.Empty; }
            pen.suspensao_condicional_processo = txtSuspensaoCondicional.Text.ToString().ToUpper();
            pen.livramento_condicional = TxtLivramentoCondiconal.Text.ToString().ToUpper();
            pen.reincidente = txtReincidente.Text.ToString().ToUpper();
            pen.regime_prisional = txtRegimePrisional.Text.ToString().ToUpper();
            pen.atenuantes = txtAtenuantes.Text.ToString().ToUpper();
            pen.agravantes = txtAgravantes.Text.ToString().ToUpper();
            pen.majorantes = txtMajorantes.Text.ToString().ToUpper();
            pen.minorantes = txtMinorantes.Text.ToString().ToUpper();
            pen.qualificadoras = txtQualificadoras.Text.ToString().ToUpper();


        }
        private void LimparPenal()
        {
            txtCrime.Text = null;
            txtAcaoPenal.Text = null;
            cmbRitoProcessual.SelectedValue = null;
            txtSuspensaoCondicional.Text = null;
            TxtLivramentoCondiconal.Text = null;
            txtReincidente.Text = null;
            txtRegimePrisional.Text = null;
            txtAtenuantes.Text = null;
            txtAgravantes.Text = null;
            txtMajorantes.Text = null;
            txtMinorantes.Text = null;
            txtQualificadoras.Text = null;

        }
        private void gravaPenal()
        {
            try
            {
                if (IdPenal == "") // Grava um Novo Conjuge
                {
                    populaPenal();
                    PenalDAO dao = new PenalDAO();
                    dao.cadastroPenal(pen);
                    MessageBox.Show("Gravado novo Penal com sucesso");

                }
                else // Atualiza o Conjuge
                {
                    populaPenal();
                    PenalDAO dao = new PenalDAO();
                    dao.atualizaPenal(pen);
                    MessageBox.Show("Atualizado Penal com sucesso");
                }


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Funções para Previdenciario
        Previdenciario prev;
        private void populaPrevidenciario()
        {
            prev = new Previdenciario();
            if (IdPrevidenciario != "")
            {
                prev.id = Convert.ToInt32(IdPrevidenciario);
            }
            prev.carteiraTrabalho = txtCTPS.Text.ToString().ToUpper();
            prev.CNIS = txtCnis.Text.ToString().ToUpper();
            prev.benificio = txtBeneficios.Text.ToString().ToUpper();
            prev.aposentadoria = txtAposentadoria.Text.ToString().ToUpper();
            prev.procedimentoADM = txtProcedimentoAdministrativo.Text.ToString().ToUpper();

        }
        private void LimparPrevidenciario()
        {
            txtCTPS.Text = null;
            txtCnis.Text = null;
            txtBeneficios.Text = null;
            txtAposentadoria.Text = null;
            txtProcedimentoAdministrativo.Text = null;

        }
        private void gravaPrevidenciario()
        {
            try
            {
                if (IdPrevidenciario == "") // Grava um Novo Conjuge
                {
                    populaPrevidenciario();
                    PrevidenciarioDAO dao = new PrevidenciarioDAO();
                    dao.cadastroPrevidenciario(prev);
                    MessageBox.Show("Gravado novo Previdenciario com sucesso");

                }
                else // Atualiza o Conjuge
                {
                    populaPrevidenciario();
                    PrevidenciarioDAO dao = new PrevidenciarioDAO();
                    dao.atualizaPrevidenciario(prev);
                    MessageBox.Show("Atualizado Previdenciario com sucesso");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Funções para Trabalhista
        Trabalhista trab;
        private void populaTrabalhista()
        {
            trab = new Trabalhista();
            if (IdTrabalhista != "")
            {
                trab.id = Convert.ToInt32(IdTrabalhista);
            }
            trab.PIS = txtNumeroPis.Text.ToString().ToUpper();
            trab.CTPS = txtRegistoCTPS.Text.ToString().ToUpper();
            trab.FGTS = txtFGTS.Text.ToString().ToUpper();
            trab.seguroDesemprego = txtSeguroDesemprego.Text.ToString().ToUpper();
            trab.avisoPrevio = txtAvisoPrevio.Text.ToString().ToUpper();
            trab.licencaMaternidade = txtLicencas.Text.ToString().ToUpper();
            trab.advertencia = txtAdvertenciasEtc.Text.ToString().ToUpper();
            trab.obs = txtObsTrabalhista.Text.ToString().ToUpper();

        }
        private void LimparTrabalhista()
        {
            txtNumeroPis.Text = null;
            txtRegistoCTPS.Text = null;
            txtFGTS.Text = null;
            txtSeguroDesemprego.Text = null;
            txtAvisoPrevio.Text = null;
            txtLicencas.Text = null;
            txtAdvertenciasEtc.Text = null;
            txtObsTrabalhista.Text = null;

        }
        private void gravaTrabalhista()
        {
            try
            {
                if (IdTrabalhista == "") // Grava um Novo Conjuge
                {
                    populaTrabalhista();
                    TrabalhistaDAO dao = new TrabalhistaDAO();
                    dao.cadastroTrabalhista(trab);
                    MessageBox.Show("Gravado novo Trabalhista com sucesso");

                }
                else // Atualiza o Conjuge
                {
                    populaTrabalhista();
                    TrabalhistaDAO dao = new TrabalhistaDAO();
                    dao.atualizaTrabalhista(trab);
                    MessageBox.Show("Atualizado Trabalhista com sucesso");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        //Funções para Filhos
        Filhos fil;
        List<Filhos> ListaFilhos;
        private void populaFilhos()
        {
            fil = new Filhos();
            fil.id = Convert.ToInt32(IdFilho);
            fil.nome = txtNomeFilho.Text.ToString().ToUpper().Trim();
            fil.cpf = txtCpfFilho.Text.ToString().ToUpper().Trim();
            fil.rg = txtRgFilho.Text.ToString().ToUpper().Trim();
            fil.obs = txtObsFilho.Text.ToString().ToUpper().Trim();
            if (dtpDataNascimentoFilho.Text != "") { fil.dtnascimento = Convert.ToDateTime(dtpDataNascimentoFilho.Text.ToString()); }
            else { fil.dtnascimento = Convert.ToDateTime(string.Empty); }
            if(cmbSexoFilho.SelectedValue != null) { fil.sexo = cmbSexoFilho.Text.ToString(); }
            else { fil.sexo = string.Empty; }

            
           


        }
        private void LimparCamposFilhos()
        {
            txtNomeFilho.Text = null;
            txtCpfFilho.Text = null;
            txtRgFilho.Text = null;
            txtObsFilho.Text = null;
            cmbSexoFilho.SelectedValue = null;
            dtpDataNascimentoFilho.Text = null;
            IdFilho = null;

            btndeletarfilhos.IsEnabled = false;
            btneditarfilho.IsEnabled = false;
            btnSalvarfilho.IsEnabled = true;

        }
        private void gravaFilhos()
        {
            try
            {
                populaFilhos();
                FilhosDAO dao = new FilhosDAO();
                dao.cadastroFilhos(fil);
                LimparCamposFilhos();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void AtualizaFilhos()
        {
            try
            {
                populaFilhos();
                FilhosDAO dao = new FilhosDAO();
                dao.atualizaFilhos(fil);
                LimparCamposFilhos();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void buscaFilho()
        {
            ListaFilhos = new List<Filhos>();
            FilhosDAO dao = new FilhosDAO();
            ListaFilhos = dao.buscaFilhos(); ;
            mostraFilho();
        }
        private void mostraFilho()
        {
            var novaListFilhos = ListaFilhos.Select(filhosDGV => new
            {
                Codigo = filhosDGV.id,
                Nome = filhosDGV.nome,
                CPF = filhosDGV.cpf,
                RG = filhosDGV.rg,
                DtNascimento = filhosDGV.dtnascimento,
                Sexo = filhosDGV.sexo,
                Obs = filhosDGV.obs

            }).ToList();

            DgvFilhos.ItemsSource = null;
            DgvFilhos.ItemsSource = novaListFilhos;


        }

        //DataGridFilhos
        private void populaFilhosDGV( Filhos fil)
        {
            IdFilho = fil.id.ToString();
            txtNomeFilho.Text = fil.nome;
            txtCpfFilho.Text = fil.cpf;
            txtRgFilho.Text = fil.rg;
            txtObsFilho.Text = fil.obs;
            dtpDataNascimentoFilho.Text = fil.dtnascimento.ToString();
            cmbSexoFilho.Text = fil.sexo;            
        }
        private void ButtonsDemoChip_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {

                MaterialDesignThemes.Wpf.Chip tb = (MaterialDesignThemes.Wpf.Chip)sender;
                object data = tb.DataContext;



                string valorespecifico = tb.DataContext.ToString();
                string parte = valorespecifico.Substring(0, valorespecifico.IndexOf(","));


                IdFilho = parte.Substring(10);
                FilhosDAO dao = new FilhosDAO();
                populaFilhosDGV(dao.buscaFilhosDGV(IdFilho.ToString()));
                btnSalvarfilho.IsEnabled = false;
                btneditarfilho.IsEnabled = true;
                btndeletarfilhos.IsEnabled = true;


            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        

        //Botões de ações Filhos
        private void DeletarFilhos(object sender, RoutedEventArgs e)
        {
            try
            {
                FilhosDAO deleta = new FilhosDAO();
                deleta.deletaFilhos(IdFilho);
                buscaFilho();
                LimparCamposFilhos();
                MessageBox.Show("Filho exluído, com sucesso!");
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        private void limparcamosfilhos(object sender, RoutedEventArgs e)
        {
            try
            {               
                LimparCamposFilhos();                
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }
        private void salvarfilho(object sender, RoutedEventArgs e)
        {
            try
            {
                gravaFilhos();
                LimparCamposFilhos();
                buscaFilho();
                MessageBox.Show("Filho cadastrado, com sucesso!");
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }
        private void editarfilho(object sender, RoutedEventArgs e)
        {
            try
            {
                AtualizaFilhos();
                LimparCamposFilhos();
                buscaFilho();
                MessageBox.Show("Filho alterado, com sucesso!");
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        private void ButtonsDemoChip_OnDeleteClick(object sender, RoutedEventArgs e)
        {

            try
            {
                MaterialDesignThemes.Wpf.Chip tb = (MaterialDesignThemes.Wpf.Chip)sender;
                object data = tb.DataContext;
                string valorespecifico = tb.DataContext.ToString();
                string parte = valorespecifico.Substring(0, valorespecifico.IndexOf(","));
                IdFilho = parte.Substring(10);

                MessageBoxResult result = MessageBox.Show("Excluir filho?", "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)                {
                    
                    FilhosDAO deleta = new FilhosDAO();
                    deleta.deletaFilhos(IdFilho);
                    buscaFilho();
                    LimparCamposFilhos();
                    MessageBox.Show("Filho exluído, com sucesso!");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }


        //Funções para Bens
        Bens bens;
        List<Bens> ListaBens;
        private void populaBens()
        {
            bens = new Bens();
            bens.id = Convert.ToInt32(IdBens);
            bens.descricaodoben = txtDescricaoBen.Text.ToString().ToUpper().Trim();
            bens.valorBens = txtValorEstimadoBen.Text.ToString().ToUpper().Trim();
            bens.obs = txtobsBen.Text.ToString().ToUpper().Trim();
            if (radioImoveis.IsChecked == true) { bens.tipoImovel = radioImoveis.Content.ToString(); }
            else { bens.tipoImovel = radioMoveis.Content.ToString(); }      
        }
        private void LimparCamposBens()
        {
            txtDescricaoBen.Text = null;
            txtValorEstimadoBen.Text = null;
            txtobsBen.Text = null;
            radioMoveis.IsChecked = false;
            radioImoveis.IsChecked = false;
            IdBens = null;

            btndeletarbens.IsEnabled = false;
            btnalterarbens.IsEnabled = false;
            btnsalvarbens.IsEnabled = true;

        }
        private void gravaBens()
        {
            try
            {
                populaBens();
                BensDAO dao = new BensDAO();
                dao.cadastroBens(bens);
                LimparCamposBens();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void AtualizaBens()
        {
            try
            {
                populaBens();
                BensDAO dao = new BensDAO();
                dao.atualizaBens(bens);
                LimparCamposBens();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void buscaBens()
        {
            ListaBens = new List<Bens>();
            BensDAO dao = new BensDAO();
            ListaBens = dao.buscaBens(); ;
            mostraBens();
        }
        private void mostraBens()
        {
            var novaListBens = ListaBens.Select(BensDGV => new
            {
                Codigo = BensDGV.id,
                Descrição = BensDGV.descricaodoben,
                Valor = BensDGV.valorBens,
                Tipo = BensDGV.tipoImovel,
                Obs = BensDGV.obs,
               

            }).ToList();

            DgvBens.ItemsSource = null;
            DgvBens.ItemsSource = novaListBens;


        }

        //DataGridBens
        private void populaBensDGV(Bens bens)
        {
            txtDescricaoBen.Text = bens.descricaodoben;
            txtValorEstimadoBen.Text = bens.valorBens;
            txtobsBen.Text = bens.obs;
            if(bens.tipoImovel != "Ben Móveis") { radioMoveis.IsChecked = true;}
            else { radioImoveis.IsChecked = true; }
            IdBens = bens.id.ToString();
        }
        private void DgvBens_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                BensDAO dao = new BensDAO();
                populaBensDGV(dao.buscaBensDGV(getDataGridValueAt(DgvBens, 0)));
                btnsalvarbens.IsEnabled = false;
                btnalterarbens.IsEnabled = true;
                btndeletarbens.IsEnabled = true;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        //Botões de ações Bens
        private void DeletarBens(object sender, RoutedEventArgs e)
        {
            try
            {
                BensDAO deleta = new BensDAO();
                deleta.deletaBens(IdBens);
                buscaBens();
                LimparCamposBens();
                MessageBox.Show("Bens exluído, com sucesso!");
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        private void limparcamosBens(object sender, RoutedEventArgs e)
        {
            try
            {
                LimparCamposBens();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }
        private void salvarBens(object sender, RoutedEventArgs e)
        {
            try
            {
                gravaBens();
                LimparCamposBens();
                buscaBens();
                MessageBox.Show("Bens cadastrado, com sucesso!");
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }
        private void editarBens(object sender, RoutedEventArgs e)
        {
            try
            {
                AtualizaBens();
                buscaBens();
                MessageBox.Show("Bens alterado, com sucesso!");
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        //Funções para Anexo
        ArquivoAnexo ane;
        List<ArquivoAnexo> ListaAnexo;     
        
        private void buscaAnexo()
        {
            ListaAnexo = new List<ArquivoAnexo>();
            ArquivoAnexoDAO dao = new ArquivoAnexoDAO();
            // Busca anexos "Cível / Direto de Família"           
            ListaAnexo = dao.buscaAnexo(null, "Cível / Direto de Família"); 
            mostraAnexo("Cível / Direto de Família");
            // Busca Anexo Trabalhista
            ListaAnexo = dao.buscaAnexo(null, "Trabalhista");
            mostraAnexo("Trabalhista");
            // Busca Anexo Previdenciário
            ListaAnexo = dao.buscaAnexo(null, "Previdenciário");
            mostraAnexo("Previdenciário");

        }
        private void mostraAnexo(string tipoprocesso)
        {
            if(tipoprocesso == "Cível / Direto de Família")
            {
                var novaListAnexo = ListaAnexo.Select(AnexoDGV => new
                {
                    Codigo = AnexoDGV.id,
                    Documento = AnexoDGV.nome,
                    TipoDocumento = AnexoDGV.tipoanexo

                }).ToList();

                DgvAnexoDiretoFamilia.ItemsSource = null;
                DgvAnexoDiretoFamilia.ItemsSource = novaListAnexo;
                


            }
            else if (tipoprocesso == "Trabalhista")
            {
                var novaListAnexo = ListaAnexo.Select(AnexoDGV => new
                {
                    Codigo = AnexoDGV.id,
                    Documento = AnexoDGV.nome,
                    TipoDocumento = AnexoDGV.tipoanexo

                }).ToList();

                DgvAnexoTrabalhista.ItemsSource = null;
                DgvAnexoTrabalhista.ItemsSource = novaListAnexo;

            }
            else if (tipoprocesso == "Previdenciário")
            {
                var novaListAnexo = ListaAnexo.Select(AnexoDGV => new
                {
                    Codigo = AnexoDGV.id,
                    Documento = AnexoDGV.nome,
                    TipoDocumento = AnexoDGV.tipoanexo

                }).ToList();

                DgvAnexoPrevidenciario.ItemsSource = null;
                DgvAnexoPrevidenciario.ItemsSource = novaListAnexo;

            }
            
        }

        //DataGridAnexo Direito Familia
        private void abrirdgvanexofamilia_click(object sender, RoutedEventArgs e)
        {
            try
            {
                ArquivoAnexo arquivoreturn = new ArquivoAnexo();
                ArquivoAnexoDAO dao = new ArquivoAnexoDAO();
                arquivoreturn = dao.buscaAnexoRetornoDGV(getDataGridValueAt(DgvAnexoDiretoFamilia, 0), null);
                File.WriteAllBytes(System.Environment.CurrentDirectory + "\\" + arquivoreturn.nome, arquivoreturn.nomereturn);
                System.Diagnostics.Process.Start(System.Environment.CurrentDirectory + "\\" + arquivoreturn.nome);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        private void DeletarAnexoDireitoFamilia(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Tem certeza que deseja Excluir?", "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    ArquivoAnexoDAO deleta = new ArquivoAnexoDAO();
                    deleta.deletaAnexo(getDataGridValueAt(DgvAnexoDiretoFamilia, 0));
                    MessageBox.Show("Anexo exluído, com sucesso!");
                    buscaAnexo();
                }     
 
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        //DataGridAnexo Direito Trabalhista
        private void abrirdgvanexoTrabalhista_click(object sender, RoutedEventArgs e)
        {
            try
            {
                ArquivoAnexo arquivoreturn = new ArquivoAnexo();
                ArquivoAnexoDAO dao = new ArquivoAnexoDAO();
                arquivoreturn = dao.buscaAnexoRetornoDGV(getDataGridValueAt(DgvAnexoTrabalhista, 0), null);
                File.WriteAllBytes(System.Environment.CurrentDirectory + "\\" + arquivoreturn.nome, arquivoreturn.nomereturn);
                System.Diagnostics.Process.Start(System.Environment.CurrentDirectory + "\\" + arquivoreturn.nome);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }
        private void DeletarAnexoDireitoTrabalhista(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Tem certeza que deseja Excluir?", "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    ArquivoAnexoDAO deleta = new ArquivoAnexoDAO();
                    deleta.deletaAnexo(getDataGridValueAt(DgvAnexoTrabalhista, 0));
                    MessageBox.Show("Anexo exluído, com sucesso!");
                    buscaAnexo();
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }
        //DataGridAnexo Direito previdenciario
        private void abrirdgvanexoPrevidenciario_click(object sender, RoutedEventArgs e)
        {
            try
            {
                ArquivoAnexo arquivoreturn = new ArquivoAnexo();
                ArquivoAnexoDAO dao = new ArquivoAnexoDAO();
                arquivoreturn = dao.buscaAnexoRetornoDGV(getDataGridValueAt(DgvAnexoPrevidenciario, 0), null);
                File.WriteAllBytes(System.Environment.CurrentDirectory + "\\" + arquivoreturn.nome, arquivoreturn.nomereturn);
                System.Diagnostics.Process.Start(System.Environment.CurrentDirectory + "\\" + arquivoreturn.nome);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }
        private void DeletarAnexoDireitoPrevidenciario(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Tem certeza que deseja Excluir?", "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    ArquivoAnexoDAO deleta = new ArquivoAnexoDAO();
                    deleta.deletaAnexo(getDataGridValueAt(DgvAnexoPrevidenciario, 0));
                    MessageBox.Show("Anexo exluído, com sucesso!");
                    buscaAnexo();
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }



        public string caminhoarquivo;
        //Botões para Gravar/Anexar o arquivo.  Direito de Familia - Trabalhista e Previdenciario. 
        private void btnanexarCivel_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (CmbAnexoDireitoFamilia.SelectedValue != null)
                {
                    gravaranexo(CmbAnexoDireitoFamilia.Text.ToString());
                    buscaAnexo();
                }
                else { MessageBox.Show("Por favor selecione o tipo de documento que deseja anexar. Obrigado!"); }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }
        private void anexaraneotrabalhista_click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (cmbAnexoTrabalhista.SelectedValue != null)
                {
                    gravaranexo(cmbAnexoTrabalhista.Text.ToString());
                    buscaAnexo();
                }
                else { MessageBox.Show("Por favor selecione o tipo de documento que deseja anexar. Obrigado!"); }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }
        private void anexaprevidenciario_click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (cmbAnexoPrevidenciario.SelectedValue != null)
                {
                    gravaranexo(cmbAnexoPrevidenciario.Text.ToString());
                    buscaAnexo();
                }
                else { MessageBox.Show("Por favor selecione o tipo de documento que deseja anexar. Obrigado!"); }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }


       



        //Função para popular todos os campos
        private void BuscaClienteTextBox()
        {
            ClienteDAO dao = new ClienteDAO();
            populaClienteTextBox(dao.buscaClienteCli(IdCliente.ToString()));
            
        }
        private void BuscaClienteId()
        {
            ClienteDAO dao = new ClienteDAO();
            populaClienteid(dao.buscaClienteCli(IdCliente.ToString()));

        }
        private void populaClienteTextBox(Cliente cli)
        {
            CarregaVariavel();
            atualiza_id = cli.id;
            txtnome.Text = cli.nome;
            mktCPF.Text = cli.cpf_cnpj;
            txtRG.Text = cli.rg_ie;
            dtpDataNascimento.Text = cli.data_nascimento.ToString();
            txtNacionalidade.Text = cli.nacionalidade;
            cmbEstadoCivil.Text = cli.estado_civil;
            txtDomicilio.Text = cli.Domicilio.logradouro;
            mktCepDomicilio.Text = cli.Domicilio.cep;
            txtResidencia.Text = cli.endereco.logradouro;
            mktCepResidencia.Text = cli.endereco.cep;
            mktTelefone.Text = cli.telefone;
            mktCelular.Text = cli.celular;
            txtEmail.Text = cli.email;
            cmbSexo.Text = cli.sexo;
            if (IDConjuge != "")
            {
                txtNomeConjugue.Text = cli.Conjuge.nome;
                txtCpfConjugue.Text = cli.Conjuge.cpf_cnpj;
                txtRgConjugue.Text = cli.Conjuge.rg_ie;
                dtpDataNascimentoConjuge.Text = cli.Conjuge.data_nascimento.ToLongDateString();
                txtNacionalidadeConjuge.Text = cli.Conjuge.nacionalidade;
                cmbEstadoCivilConjuge.Text = cli.Conjuge.estado_civil;
                txtDomicilioConjugye.Text = cli.Conjuge.Domicilio.logradouro;
                txtCepDomicilioConjugue.Text = cli.Conjuge.Domicilio.cep;
                txtEnderecoConjugye.Text = cli.Conjuge.endereco.logradouro;
                txtCepEnderecoConjugue.Text = cli.Conjuge.endereco.cep;
                txtTelefoneConjugue.Text = cli.Conjuge.telefone;
                txtCelularConjugue.Text = cli.Conjuge.celular;
                txtEmailConjugue.Text = cli.Conjuge.email;
                cmbSexoConjuge.Text = cli.Conjuge.sexo;
            }
            if (IdBanco != "")
            {
                txtBanco.Text = cli.DadoBancario.banco;
                txtAgencia.Text = cli.DadoBancario.Agencia;
                cmbConta.Text = cli.DadoBancario.TipoConta;
                txtConta.Text = cli.DadoBancario.numero;
            }
            if (IdPenal != "")
            {
                txtCrime.Text = cli.Penal.crime;
                txtAcaoPenal.Text = cli.Penal.acao_penal;
                cmbRitoProcessual.Text = cli.Penal.rito_processual;
                txtSuspensaoCondicional.Text = cli.Penal.suspensao_condicional_processo;
                TxtLivramentoCondiconal.Text = cli.Penal.livramento_condicional;
                txtReincidente.Text = cli.Penal.reincidente;
                txtRegimePrisional.Text = cli.Penal.regime_prisional;
                txtAtenuantes.Text = cli.Penal.atenuantes;
                txtAgravantes.Text = cli.Penal.agravantes;
                txtMajorantes.Text = cli.Penal.majorantes;
                txtMinorantes.Text = cli.Penal.minorantes;
                txtQualificadoras.Text = cli.Penal.qualificadoras;
            }
            if (IdPrevidenciario != "")
            {
                txtCTPS.Text = cli.Previdenciario.carteiraTrabalho;
                txtCnis.Text = cli.Previdenciario.CNIS;
                txtBeneficios.Text = cli.Previdenciario.benificio;
                txtAposentadoria.Text = cli.Previdenciario.aposentadoria;
                txtProcedimentoAdministrativo.Text = cli.Previdenciario.procedimentoADM;
            }
            if (IdTrabalhista != "")
            {
                txtNumeroPis.Text = cli.Trabalhista.PIS;
                txtRegistoCTPS.Text = cli.Trabalhista.CTPS;
                txtFGTS.Text = cli.Trabalhista.FGTS;
                txtSeguroDesemprego.Text = cli.Trabalhista.seguroDesemprego;
                txtAvisoPrevio.Text = cli.Trabalhista.avisoPrevio;
                txtLicencas.Text = cli.Trabalhista.licencaMaternidade;
                txtAdvertenciasEtc.Text = cli.Trabalhista.advertencia;
                txtObsTrabalhista.Text = cli.Trabalhista.obs;
            }
            buscaFilho();
            buscaBens();
            buscaAnexo();


        }
        private void populaClienteid(Cliente cli)
        {
            CarregaVariavel();
            


        }
        //Função para Salvar todos os campos
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                gravaConjuge();
                AtualizaCliente();
                gravaBanco();
                gravaPenal();
                gravaPrevidenciario();
                gravaTrabalhista();

                BuscaClienteId();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }


        //Função para converter ID do Data Grid view
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

        //Função para Gravar o Anexo de todos
        public void gravaranexo(string tipocmbanexo)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                caminhoarquivo = openFileDialog.FileName;
            TabItem ti = default(TabItem);
            ti = (TabItem)Tabs1.SelectedItem;
            ArquivoAnexo ane = new ArquivoAnexo();
            ane.caminho = caminhoarquivo;
            ane.nome = openFileDialog.SafeFileName;
            ane.tipoprocesso = ti.Header.ToString();
            ane.tipoanexo = tipocmbanexo;
            ArquivoAnexoDAO dao = new ArquivoAnexoDAO();
            dao.cadastroAnexo(ane);
            MessageBox.Show("Anexo  " + ane.nome + " incluido com Sucesso!");
        }

         

       

       
        }
    }

