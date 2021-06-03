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
    /// Logique d'interaction pour CitationsDialog.xaml
    /// </summary>
    public partial class CitationsDialog : Window
    {
        public Personnage Perso { get; set; }

        public CitationsDialog(Personnage perso)
        {
            InitializeComponent();
            Perso = perso;
            DataContext = Perso;
        }

        private void AjouterCitation(object sender, RoutedEventArgs e)
        {
            NouvelleCitationDialog dialog = new NouvelleCitationDialog();
            if (dialog.ShowDialog() == true)
            {
                if (Perso.AjouterCitation(dialog.Citation))
                {
                    MessageBox.Show($"La citation a été ajoutée.", "Ajouter une citation", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show($"La citation a déjà été ajoutée au personnage !", "Ajouter une citation", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void SupprimerCitation(object sender, RoutedEventArgs e)
        {
            string citationASupprimer = CitationsListBox.SelectedItem as string;
            if (citationASupprimer == null)
            {
                MessageBox.Show("Vous devez sélectionner une citation à supprimer.", "Supprimer un jeu", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBoxResult result = MessageBox.Show($"Voulez-vous vraiment supprimer cette citation ?",
                "Supprimer une citation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Perso.SupprimerCitation(citationASupprimer);
            }
        }

        private void OKButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
