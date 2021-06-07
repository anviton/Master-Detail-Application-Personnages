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
using Modele;

namespace Vue_perso.Dialogs.UC_Dialogs
{
    /// <summary>
    /// Logique d'interaction pour UC_MusiqueUnique.xaml
    /// </summary>
    public partial class UC_Leitmotiv : UserControl
    {
        public Manager Mgr => (App.Current as App).MonManager;
        public Modele.ThemeMusical Theme => Mgr.PersonnageSelectionne.Theme;

        public UC_Leitmotiv()
        {
            InitializeComponent();
            DataContext = Theme;
        }

		private void AjouterTitre(object sender, RoutedEventArgs e)
		{
            NouveauTitreDialog dialog = new NouveauTitreDialog();
            if (dialog.ShowDialog() == true)
			{
                if (Theme.AjouterTitre(dialog.Titre, dialog.Lien))
				{
                    MessageBox.Show("Le titre a bien été ajouté.", "Ajouter un titre", MessageBoxButton.OK, MessageBoxImage.Information);
				}
                else
				{
                    MessageBox.Show("Le titre a déjà été ajouté au thème.", "Ajouter un titre", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
		}

        private void SupprimerTitre(object sender, RoutedEventArgs e)
		{
            Titre titreASupprimer = TitresListBox.SelectedItem as Titre;
            if (titreASupprimer == null)
            {
                MessageBox.Show("Vous devez sélectionner un titre à supprimer.", "Supprimer un titre", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBoxResult result = MessageBox.Show($"Voulez-vous vraiment supprimer ce titre ?",
                "Supprimer un titre", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Theme.SupprimerTitre(titreASupprimer);
            }
        }
	}
}
