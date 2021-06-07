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
    /// Logique d'interaction pour AjouterAUnGroupe.xaml
    /// </summary>
    public partial class AjouterAUnGroupe : Window
    {
        public Manager Mgr => (App.Current as App).MonManager;
        public string NomPerso { get; set; }
        public AjouterAUnGroupe()
        {
            InitializeComponent();
            DataContext = Mgr;
        }

        private void NouveauGroupe(object sender, RoutedEventArgs e)
        {
            NouveauGroupeDialog dialog = new NouveauGroupeDialog();

            if (dialog.ShowDialog() == true)
            {
                if (Mgr.AjouterGroupe(dialog.groupName))
                {
                    MessageBox.Show($"Le groupe \"{dialog.groupName}\" a été créé avec succès.", "Nouveau groupe", MessageBoxButton.OK, MessageBoxImage.Information);
                    Mgr.SauvegaderDonnees();
                }
                else
                {
                    MessageBox.Show($"Le groupe \"{dialog.groupName}\" n'a pas été créé car il existe déjà.", "Nouveau groupe", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void OKButtonPressed(object sender, RoutedEventArgs e)
        {
            //this.DialogResult = true;
            Mgr.AjouterPersoAGroupe(Mgr.GroupeSelectionne, Mgr.PersonnageSelectionne);
            Mgr.SauvegaderDonnees();
            Close();
        }

        private void CancelButtonPressed(object sender, RoutedEventArgs e)
        {
            //this.DialogResult = false;
            Close();
        }
    }
}
