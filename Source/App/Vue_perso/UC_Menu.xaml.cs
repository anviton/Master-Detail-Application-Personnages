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
            if (Mgr.GroupeSelectionne == null)
            {
                MenuSupprimerUnGroupe.IsEnabled = true;
            }
            else
            {
                MenuSupprimerUnGroupe.IsEnabled = false;
            }
        }

        private void RetourAccueil(object sender, RoutedEventArgs e)
        {
            if (!(Window.GetWindow(this) is Accueil))
            {
                Mgr.PersonnageSelectionne = null;
                Mgr.GroupeSelectionne = null;
                if (Mgr.SerieSelectionnee != null) Mgr.SerieSelectionnee.PersonnageSelectionne = null;
                Mgr.SerieSelectionnee = null;
                Accueil accueil = new Accueil();
                Window.GetWindow(this).Close();
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
                    Mgr.SauvegaderDonnees();
                } else
                {
                    MessageBox.Show($"Le groupe \"{dialog.groupName}\" n'a pas été créé car il existe déjà.", "Nouveau groupe", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void NouveauPersonnage(object sender, RoutedEventArgs e)
        {
            NouveauPerso dialog = new NouveauPerso();

            if (dialog.ShowDialog() == true)
            {
                if (Mgr.EnregistrerPersonnage(dialog.NomPerso, dialog.SerieDuPerso, out Personnage nouveauPerso))
                {
                    MessageBox.Show($"Le personnage \"{dialog.NomPerso}\", de la série \"{dialog.SerieDuPerso}\", a été ajouté.", "Nouveau personnage",
                        MessageBoxButton.OK, MessageBoxImage.Information);

                    Mgr.PersonnageSelectionne = nouveauPerso;
                    ModifierPerso modifierPerso = new ModifierPerso();
                    modifierPerso.Show();
                    Mgr.SauvegaderDonnees();
                }
                else
                {
                    MessageBox.Show($"Le personnage \"{dialog.NomPerso}\" existe déjà dans la série \"{dialog.SerieDuPerso}\" !", "NouveauPersonnage",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void SupprimerGroupe(object sender, RoutedEventArgs e)
        {
            
            var window = new SupprimerGroupeDialog();
            window.ShowDialog();
            Mgr.SauvegaderDonnees();
            Mgr.GroupeSelectionne = null;
        }
        private void GroupeSelectionnee(object sender, RoutedEventArgs e)
        {
            /*
            MainWindow mainWindow = new MainWindow();
            Window.GetWindow(this).Close();
            mainWindow.Show();*/
            //MessageBox.Show($"Groupe {((sender as ListBox).SelectedItem as string)}");
            Mgr.PersonnageSelectionne = null;
            if (Mgr.SerieSelectionnee != null) Mgr.SerieSelectionnee.PersonnageSelectionne = null;
            Mgr.SerieSelectionnee = null;
            Mgr.GroupeSelectionne = (sender as ListBox).SelectedItem as string;
            //Window window = new MainWindow((sender as ListBox).SelectedItem as string, Mgr.Groupes[(sender as ListBox).SelectedItem as string]);
            if (Mgr.GroupeSelectionne != null)
            {
                Window window = new Main_WindowGroupes();
                Window.GetWindow(this).Close();
                window.Show();
            }

        }

        private void ImporterPersonnage(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.DefaultExt = ".xml ";
            dialog.Filter = "Tous les fichiers xml (*.xml) | *.xml";
            if (dialog.ShowDialog() == true)
            {

                try
                {
                    if (Mgr.LireUnPersonnageEnXml(dialog.FileName))
                    {
                        MessageBox.Show($"Le Personnage a été ajoutée.", "Nouveau Personnage", MessageBoxButton.OK, MessageBoxImage.Information);
                        Mgr.SauvegaderDonnees();
                    }
                    else
                    {
                        MessageBox.Show($"Le Personnage existe déjà !", "Nouveau Personnage", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show($"Fichier corrompu !", "Nouveau Personnage", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
                
            }

        }


    }
}
