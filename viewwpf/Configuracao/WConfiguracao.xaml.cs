﻿using System;
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

namespace ViewWPF.Configuracao
{
    /// <summary>
    /// Lógica interna para WConfiguracao.xaml
    /// </summary>
    public partial class WConfiguracao : Window
    {
        public WConfiguracao()
        {
            InitializeComponent();
        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WCargo newcargo = new WCargo();
            this.Close();
            newcargo.Show();

            
        }

        private void Grid_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            WFuncionario newfuncionario = new WFuncionario();
            newfuncionario.ShowDialog();
            this.Close();
        }
    }
}
