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
    /// Logique d'interaction pour NouveauPerso.xaml
    /// </summary>
    public partial class NouveauPerso : Window
    {
        public NouveauPerso()
        {
            InitializeComponent();
        }

        private void RenseignerChamp(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;
            Window newWindow;
            /*
             * On regarde quel bouton a été cliqué.
             * Ensuite, on instancie un Window, contenant une référence vers une fenêtre demandée.
             */
            if (senderButton.Equals(ThemeButton))
            {
                newWindow = new ThemeMusical();
                newWindow.Show();
            } // Reste des fenêtres ici
        }
    }
}
