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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tauchershop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MenuItemBeenden_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        #region MenuItemNeuerAuftrag
        private void MenuItemNeuerAuftrag_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region MenuItemAnsichten
        private void MenuItemAnsichtArtikel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemAnsichtAuftraege_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemAnsichtKunden_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemAnsichtLiferanten_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemAnsichtMitarbeiter_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion
    }
}
