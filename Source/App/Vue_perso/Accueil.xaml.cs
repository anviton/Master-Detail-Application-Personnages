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

namespace Vue_perso
{
    /// <summary>
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Accueil : Window
    {
        public Manager Mgr => (App.Current as App).MonManager;
        public Accueil()
        {
            InitializeComponent();
            Mgr.SerieSelectionnee = null;
            Mgr.GroupeSelectionne = null;
            Mgr.PersonnageSelectionne = null;
            DataContext = Mgr;
        }

        private void Affiche_Perso(object sender, RoutedEventArgs e)
        {
            contentControlAccueil.Content = new UC_accueil.MosaiquePersonnages_UC();
        }

        private void Affiche_Series(object sender, RoutedEventArgs e)
        {
            contentControlAccueil.Content = new UC_accueil.MosaiqueJeux_UC();
        }

    }
}
