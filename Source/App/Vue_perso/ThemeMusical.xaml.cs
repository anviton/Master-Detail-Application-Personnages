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
using Vue_perso.Dialogs.UC_Dialogs;

namespace Vue_perso
{
    /// <summary>
    /// Logique d'interaction pour ThemeMusical.xaml
    /// </summary>
    public partial class ThemeMusical : Window
    {
        public Manager Mgr => (App.Current as App).MonManager;
        public Personnage Perso => Mgr.PersonnageSelectionne;
        public Modele.ThemeMusical Theme => Perso.Theme;

        public ThemeMusical()
        {
            InitializeComponent();
            DataContext = Theme;
            EditeurSelect();
        }

        private void EditeurSelect()
		{
            if (Theme.Leitmotiv)
			{
                Editeur.Content = new UC_Leitmotiv();
			}
            else
			{
                Editeur.Content = new UC_MusiqueUnique();
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
            var confirm = MessageBox.Show(
                "Attention : changer de type de thème musical entraîne la suppression des données du thème !\n" +
                "Voulez-vous continuer ?", "Thème musical", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirm == MessageBoxResult.Yes)
			{
                Theme.Leitmotiv = !Theme.Leitmotiv;
                EditeurSelect();
			}
		}

        private void OKButton(object sender, RoutedEventArgs e)
		{
            this.Close();
		}
	}
}
