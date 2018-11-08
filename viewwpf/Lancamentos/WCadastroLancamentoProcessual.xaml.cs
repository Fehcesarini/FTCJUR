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
using Microsoft.Win32;
using ViewWPF.Class;
using Negocio;
using Label = System.Reflection.Emit.Label;

namespace ViewWPF.Lancamentos
{
    /// <summary>
    /// Lógica interna para WCadastroLancamentoProcessual.xaml
    /// </summary>
    public partial class WCadastroLancamentoProcessual : Window
    {
        private int numeroprocesso = Definicoes.idProcessoSeleciona;
        public WCadastroLancamentoProcessual()
        {
            InitializeComponent();
            DataContext = _vm = new MainViewModelNotificacao();
            Unloaded += OnUnload;
            
        }

        private readonly MainViewModelNotificacao _vm;

        private void OnUnload(object sender, RoutedEventArgs e)
        {
            _vm.OnUnloaded();
        }
        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        AnexoProcesso proc = new AnexoProcesso();
        private void populaAnexoProcesso()
        {
            try
            {   
                
               if (CmbTipoAnexo.SelectedValue != null) { proc.AneProc_tipodoc = CmbTipoAnexo.Text.ToString(); }
                else { proc.AneProc_tipodoc = string.Empty; }
                proc.AneProc_Obs = TxtObs.Text;
                proc.AneProc_data = Convert.ToDateTime(DtpDataMovimentacao.Text);
                proc.AneProc_descricao = TxtDescricao.Text;
                proc.AneProc_documento = LabelCaminho.Content.ToString();
                proc.processo_PROC_ID = numeroprocesso;
            }
            catch (Exception er)
            {
                _vm.ShowError(er.Message);

            }

        }
        private void LimparAnexoProcesso()
        {
            try
            {
                CmbTipoAnexo.SelectedValue = null;
                TxtObs.Text = null;
                DtpDataMovimentacao.Text = null;
                TxtDescricao.Text = null;
                LabelCaminho.Content = null;
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
                populaAnexoProcesso();
                AnexoProcessoDAO dao = new AnexoProcessoDAO();
                dao.cadastroAnexoProc(proc);
                _vm.ShowSuccess("Andamento gravado com sucesso");
                LimparAnexoProcesso();

            }
            catch (Exception e)
            {
                _vm.ShowError(e.Message);

            }
        }


        public void gravaranexo()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                LabelCaminho.Content = openFileDialog.FileName;
           
            MessageBox.Show("Anexo  " + openFileDialog.FileName + " incluido com Sucesso!");
        }
        private void BtnAnexarDoc(object sender, RoutedEventArgs e)
        {
            try
            {
               gravaranexo();

            }
            catch(Exception er) { _vm.ShowError(er.Message); }
        }

        private void BtnGravarProcesso(object sender, RoutedEventArgs e)
        {
            try { gravaProcesso(); }
            catch(Exception er) { _vm.ShowError(er.Message);}
            
        }

        private void BtnLimparCampos(object sender, RoutedEventArgs e)
        {
            try { LimparAnexoProcesso(); }
            catch(Exception er) { _vm.ShowError(er.Message);}
        }
    }
}
