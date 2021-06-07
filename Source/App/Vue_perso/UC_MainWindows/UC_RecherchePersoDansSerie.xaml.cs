using Modele;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vue_perso.UC_MainWindows
{
    /// <summary>
    /// Logique d'interaction pour UC_RecherchePersoDansSerie.xaml
    /// </summary>
    public partial class UC_RecherchePersoDansSerie : UserControl
    {
        public Manager Mgr => (App.Current as App).MonManager;
        public UC_RecherchePersoDansSerie()
        {
            DataContext = Mgr;
            InitializeComponent();
        }

        private void Recherche(object sender, TextChangedEventArgs e)
        {
            if (Mgr.SerieSelectionnee != null)
            {
                if (Mgr.RechercherUnPersonnage((sender as TextBox).Text, Mgr.SerieSelectionnee.Nom, out Personnage perso))
                {
                    Mgr.SerieSelectionnee.PersonnageSelectionne = perso;
                }
            }  
        }
    }
}
