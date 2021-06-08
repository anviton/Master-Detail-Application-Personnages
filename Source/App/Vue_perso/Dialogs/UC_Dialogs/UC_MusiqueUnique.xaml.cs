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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Modele;

namespace Vue_perso.Dialogs.UC_Dialogs
{
    /// <summary>
    /// Logique d'interaction pour UC_MusiqueUnique.xaml
    /// </summary>
    public partial class UC_MusiqueUnique : UserControl
    {
        public Manager Mgr => (App.Current as App).MonManager;

        public Modele.ThemeMusical Theme => Mgr.PersonnageSelectionne.Theme;
        

        public UC_MusiqueUnique()
        {
            InitializeComponent();
            DataContext = this;
        }

		private void TextBox_LostFocus(object sender, RoutedEventArgs e)
		{
            if (Lien.Text == "")
            {
                Theme.AjouterTitre(Titre.Text);
            }
            else
			{
                Theme.AjouterTitre(Titre.Text, Lien.Text);
			}
		}
	}
}
