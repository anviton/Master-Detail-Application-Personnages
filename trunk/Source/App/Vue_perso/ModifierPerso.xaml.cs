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
using Vue_perso.Dialogs;

namespace Vue_perso
{
    /// <summary>
    /// Logique d'interaction pour ModifierPerso.xaml
    /// </summary>
    public partial class ModifierPerso : Window
    {
        public Manager Mgr => (App.Current as App).MonManager;
        public Personnage Perso { get; set; }
        public ModifierPerso(Personnage persoAModifier)
        {
            InitializeComponent();
            Perso = persoAModifier;
            //Perso.Citations = Mgr.PersonnageSelectionne.Citations;
            DataContext = Perso;
        }

        private void RenseignerImage(object sender, RoutedEventArgs e)
		{
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.DefaultExt = ".jpg | .png | .gif";
            dialog.Filter = "Tous les fichiers image (*.jpg, *.png, *.gif) | *.jpg; *.png; *.gif";

            if (dialog.ShowDialog() == true)
			{
                Perso.Image = dialog.FileName;
			}
		}

        private void RenseignerChamp(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;
            Window newWindow;
            /*
             * On regarde quel bouton a été cliqué.
             * Ensuite, on instancie un Window, contenant une référence vers une fenêtre demandée.
             */
            if (senderButton.Equals(CitationsButton))
            {
                newWindow = new CitationsDialog(Perso);
                newWindow.ShowDialog();
            }
            else if (senderButton.Equals(JVButton))
            {
                newWindow = new JeuxVideoDialog(Perso);
                newWindow.ShowDialog();
            }
            else if (senderButton.Equals(ThemeButton))
            {
                newWindow = new ThemeMusical();
                newWindow.ShowDialog();
            } // Reste des fenêtres ici
            else
            {
                MessageBox.Show("Pas encore implémenté !", "Pas encore implémenté !", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

    }
}
