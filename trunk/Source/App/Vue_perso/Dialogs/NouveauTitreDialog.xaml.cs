using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using Modele;

namespace Vue_perso.Dialogs
{
    public partial class NouveauTitreDialog : Window
    {
        public string Titre { get; set; }
        public string Lien { get; set; }

        public NouveauTitreDialog()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void OKButtonPressed(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButtonPressed(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void VerifSaisieVide(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Text == "")
            {
                Lien = null;
            }
        }
    }
}
