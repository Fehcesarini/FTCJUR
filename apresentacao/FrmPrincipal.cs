using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TimerDataHora_Tick(object sender, EventArgs e)
        {
            ToolStripLabelHora.Text = DateTime.Now.ToLongTimeString();
            ToolStripLabelData.Text = DateTime.Now.ToLongDateString();            
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void MonthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            TabControl1.SelectTab(0);
        }

        private void MonthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            TabControl1.SelectTab(1);
        }

        private void incluirNovoProcessoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIncluirProcesso novoincluirprocesso = new FrmIncluirProcesso();
            novoincluirprocesso.Show();
        }

        private void funcionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void cadastroCargosToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void Button9_Click(object sender, EventArgs e)
        {

        }
    }
}
