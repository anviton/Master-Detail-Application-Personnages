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
using System.Windows.Shapes;

namespace Vue_perso.Dialogs
{
    /// <summary>
    /// Logique d'interaction pour SuppressionConfirmation.xaml
    /// </summary>
    public partial class SuppressionConfirmation : Window
    {
        public Manager Mgr => (App.Current as App).MonManager;
        public SuppressionConfirmation()
        {
            DataContext = Mgr;
            InitializeComponent();
        }

        private void SupprmierLePersonnage(object sender, RoutedEventArgs e)
        {
            if (Mgr.GroupeSelectionne == null)
            {
                Mgr.SupprimerPersonnage(Mgr.PersonnageSelectionne);
            }
            else
            {
                Mgr.RetirerPersoDeGroupe(Mgr.GroupeSelectionne, Mgr.PersonnageSelectionne);
            }
            Close();
        }

        private void AnnulerLaSupression(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
