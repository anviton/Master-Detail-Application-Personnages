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
using Vue_perso.Dialogs;

namespace Vue_perso
{

    /// <summary>
    /// Logique d'interaction pour UC_Menu.xaml
    /// </summary>
    public partial class UC_Menu : UserControl
    {
        public Manager Mgr => (App.Current as App).MonManager;

        public UC_Menu()
        {
            InitializeComponent();
            DataContext = Mgr;
        }

        private void RetourAccueil(object sender, RoutedEventArgs e)
        {
            if (!(Window.GetWindow(this) is Accueil))
            {
                Accueil accueil = new Accueil();
                Window.GetWindow(this).Close();
                Mgr.PersonnageSelectionne = null;
                Mgr.GroupeSelectionne = null;
                Mgr.SerieSelectionnee = null;
                accueil.Show();
            }
        }

        private void NouveauGroupe(object sender, RoutedEventArgs e)
        {
            NouveauGroupeDialog dialog = new NouveauGroupeDialog();

            if (dialog.ShowDialog() == true)
            {
                if (Mgr.AjouterGroupe(dialog.groupName))
                {
                    MessageBox.Show($"Le groupe \"{dialog.groupName}\" a été créé avec succès.", "Nouveau groupe", MessageBoxButton.OK, MessageBoxImage.Information);
                } else
                {
                    MessageBox.Show($"Le groupe \"{dialog.groupName}\" n'a pas été créé car il existe déjà.", "Nouveau groupe", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ModifierPersonnage(object sender, RoutedEventArgs e)
        {
            NouveauPerso nouveau = new NouveauPerso();
            nouveau.ShowDialog();
        }

        private void SupprimerGroupe(object sender, RoutedEventArgs e)
        {
            
        }

        private void GroupeSelectionnee(object sender, RoutedEventArgs e)
        {
            /*
            MainWindow mainWindow = new MainWindow();
            Window.GetWindow(this).Close();
            mainWindow.Show();*/
            //MessageBox.Show($"Groupe {((sender as ListBox).SelectedItem as string)}");
            Mgr.GroupeSelectionne = (sender as ListBox).SelectedItem as string;
            //Window window = new MainWindow((sender as ListBox).SelectedItem as string, Mgr.Groupes[(sender as ListBox).SelectedItem as string]);
            Window window = new MainWindow();
            window.Show();
            Window.GetWindow(this).Close();
            return;
        }

    }
}
