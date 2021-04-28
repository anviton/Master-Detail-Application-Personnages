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

namespace Vue_perso
{
    /// <summary>
    /// Logique d'interaction pour ThemeMusical.xaml
    /// </summary>
    public partial class ThemeMusical : Window
    {
        public ThemeMusical()
        {
            InitializeComponent();
        }

        private void ChangerModeSaisie(object sender, RoutedEventArgs e)
        {
            RadioButton senderButton = sender as RadioButton;

            if (senderButton.Equals(MusUniqButton))
            {
                // Masquer la saisie pour le leitmotiv : LeitmotivGrid.Visibility = Visibility.Hidden;
                MusUniqGrid.Visibility = Visibility.Visible;
            } else
            {
                MusUniqGrid.Visibility = Visibility.Hidden;
                // Afficher la saisie pour le leitmotiv : LeitmotivGrid.Visibility = Visibility.Visible
            }
        }


        /*
         * Pour l'instant, les boutons "Enregistrer" et "Annuler" ne font que fermer la fenêtre.
         * On devra modifier le code pour récupérer les données saisies.
         */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
