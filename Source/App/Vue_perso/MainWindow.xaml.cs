using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Modele;
using Vue_perso.Dialogs;

namespace Vue_perso
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        public Manager Mgr => (App.Current as App).MonManager;

        public MainWindow()
        {
            InitializeComponent();
            if (Mgr.SerieSelectionnee == null && Mgr.PersonnageSelectionne == null && Mgr.GroupeSelectionne == null) 
            {
                Close();
            }
            else
            {
                if (Mgr.PersonnageSelectionne != null)
                {
                    DataContext = Mgr;
                }
                else
                {
                    DataContext = Mgr.SerieSelectionnee;
                    Mgr.ListeDePersonnagesActive = Mgr.SerieSelectionnee.Personnages;
                    if (Mgr.ListeDePersonnagesActive.Count() != 0)
                    {
                        Mgr.SerieSelectionnee.PersonnageSelectionne = Mgr.ListeDePersonnagesActive[0];
                    }
                }
               
            }
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void ModifierPersonnageClick(object sender, RoutedEventArgs e)
        {
            if (Mgr.PersonnageSelectionne != null)
            {
                var window = new ModifierPerso();
                window.ShowDialog();
            }
        }
        private void AjouterAUnGroupe(object sender, RoutedEventArgs e)
        {
            if (Mgr.PersonnageSelectionne != null)
            {
                var window = new AjouterAUnGroupe();
                window.Show();
            }
        }
    }
}
