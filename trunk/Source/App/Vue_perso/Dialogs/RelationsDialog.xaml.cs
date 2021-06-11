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
	/// Logique d'interaction pour RelationsDialog.xaml
	/// </summary>
	public partial class RelationsDialog : Window
	{
        public Manager Mgr => (App.Current as App).MonManager;
        public Personnage Perso => Mgr.PersonnageSelectionne;

        public RelationsDialog()
        {
            InitializeComponent();
            DataContext = Perso;
        }

        private void AjouterRelation(object sender, RoutedEventArgs e)
        {
            NouvelleRelationDialog dialog = new NouvelleRelationDialog();
            bool canAdd;
            if (dialog.ShowDialog() == true)
            {
                if (dialog.PersoRec == null) // On essaye de créer une relation avec un personnage non enregistré
				{
                    canAdd = Perso.AjouterRelation(dialog.Type, dialog.NomPersoNonRec);
				}
                else // On essaye de créer une relation avec un personnage enregistré
				{
                    canAdd = Perso.AjouterRelation(dialog.Type, dialog.PersoRec);
				}

                if (canAdd)
                {
                    MessageBox.Show("La relation a été ajoutée.", "Ajouter une relation", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("La relation existe déjà !", "Ajouter un jeu", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void SupprimerRelation(object sender, RoutedEventArgs e)
        {
            Relation relationASupprimer = RelationsListBox.SelectedItem as Relation;
            if (relationASupprimer == null)
            {
                MessageBox.Show("Vous devez sélectionner une relation à supprimer.", "Supprimer une relation", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment supprimer cette relation ?",
                "Supprimer une relation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Perso.SupprimerUneRelation(relationASupprimer);
            }
        }

        private void OKButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
