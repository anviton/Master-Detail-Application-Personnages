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

namespace Vue_perso
{
    /// <summary>
    /// Logique d'interaction pour ThemeMusical.xaml
    /// </summary>
    public partial class ThemeMusical : Window
    {
        public Manager Mgr => (App.Current as App).MonManager;
        public Personnage Perso => Mgr.PersonnageSelectionne;

        public ThemeMusical()
        {
            InitializeComponent();
            DataContext = this;
        }


        /*
         * Pour l'instant, les boutons "Enregistrer" et "Annuler" ne font que fermer la fenêtre.
         * On devra modifier le code pour récupérer les données saisies.
         */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MusUniqButton_Click(object sender, RoutedEventArgs e)
        {
            // Si le thème est défini et que c'est un leitmotiv
            if (Perso.Theme != null && Perso.Theme.Leitmotiv)
            {
                MessageBoxResult confirm = MessageBox.Show("Attention : changer de type de thème supprimera les données de l'ancien thème ! Voulez-vous continuer ?",
                    "Thème musical du personnage", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirm == MessageBoxResult.Yes)
                {
                    Perso.Theme = new Modele.ThemeMusical(false);
                }
            }
        }
    }
}
