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
using Modele;

namespace Vue_perso.Dialogs
{
    /// <summary>
    /// Logique d'interaction pour SupprimerGroupeDialog.xaml
    /// </summary>
    public partial class SupprimerGroupeDialog : Window
    {
        public Manager Mgr => (App.Current as App).MonManager;
        public SupprimerGroupeDialog()
        {
            InitializeComponent();
            DataContext = Mgr;
        }
    }
}
