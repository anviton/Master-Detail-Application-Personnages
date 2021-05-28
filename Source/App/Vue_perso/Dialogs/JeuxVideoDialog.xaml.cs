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
                    MessageBox.Show($"Le jeu video \"{jeu}\" a été ajouté.", "Ajouter un jeu", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
