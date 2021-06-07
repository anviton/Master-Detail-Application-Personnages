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

		private void ChangerMode(object sender, MouseButtonEventArgs e)
		{
            
		}

		private void MusUniqButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void LeitmotivButton_Checked(object sender, RoutedEventArgs e)
		{
// On vérifie si le thème est défini (Titres.Count différent de 0)
            if (Perso.Theme.Titres.Count != 0)
			{
                var confirm = MessageBox.Show("Changer de type de thème entraîne la suppression de toutes les données du thème.\nÊtes-vous sûr de vouloir continuer ?",
                    "Thème musical", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirm == MessageBoxResult.Yes)
				{
                    // Si l'utilisateur confirme, on assigne à Leitmotiv true si le bouton radio "Leitmotiv" est coché.
                    Perso.Theme.Leitmotiv = (sender as RadioButton) == LeitmotivButton;
                    e.Handled = false;
				}
                else
				{
                    // On indique que l'événement est fini d'être géré.
                    e.Handled = true;
				}
			}
		}
	}
}
