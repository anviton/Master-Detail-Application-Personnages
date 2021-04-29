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
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Accueil : Window
    {
        public Accueil()
        {
            InitializeComponent();
        }

        private void Affiche_Perso(object sender, RoutedEventArgs e)
        {
            contentControlAccueil.Content = new MosaiquePersonnages_UC();
        }

        private void Affiche_Jeux(object sender, RoutedEventArgs e)
        {
            contentControlAccueil.Content = new MosaiqueJeux_UC();
        }
    }
}
