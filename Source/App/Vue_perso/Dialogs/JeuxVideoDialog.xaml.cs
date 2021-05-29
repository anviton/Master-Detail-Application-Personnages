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
    /// Logique d'interaction pour JeuVideoDialog.xaml
    /// </summary>
    public partial class JeuxVideoDialog : Window
    {
        public Personnage Perso { get; set; }

        public JeuxVideoDialog(Personnage perso)
        {
            InitializeComponent();
            Perso = perso;
            DataContext = Perso;
        }

        private void AjouterJeu(object sender, RoutedEventArgs e)
        {
            NouveauJeuVideoDialog dialog = new NouveauJeuVideoDialog();
            if (dialog.ShowDialog() == true)
            {
                if (Perso.AjouterUnJeu(dialog.NomJeuVideo, dialog.Annee, out JeuVideo jeu))
                {
                    MessageBox.Show($"Le jeu video \"{jeu.Nom}\" a été ajouté.", "Ajouter un jeu", MessageBoxButton.OK, MessageBoxImage.Information);
                } else
				{
                    MessageBox.Show($"Le jeu vidéo \"{jeu.Nom}\" a déjà été ajouté à ce personnage !", "Ajouter un jeu", MessageBoxButton.OK, MessageBoxImage.Error);
				}
            }
        }

        private void SupprimerJeu(object sender, RoutedEventArgs e)
        {
            JeuVideo jeuASupprimer = JVListBox.SelectedItem as JeuVideo;
            if (jeuASupprimer == null)
			{
                MessageBox.Show("Vous devez sélectionner un jeu à supprimer.", "Supprimer un jeu", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
			}

            MessageBoxResult result = MessageBox.Show($"Voulez-vous vraiment supprimer le jeu \"{jeuASupprimer.Nom}\" ?",
                "Supprimer un jeu", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
			{
                Perso.SupprimerUnJeu(jeuASupprimer);
			}
        }

		private void OKButton(object sender, RoutedEventArgs e)
		{
            Close();
		}
	}
}
