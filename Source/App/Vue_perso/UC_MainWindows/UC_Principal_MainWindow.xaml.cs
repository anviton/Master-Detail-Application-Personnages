using Modele;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
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
using Vue_perso.Dialogs;


namespace Vue_perso.UC_MainWindows
{
    /// <summary>
    /// Logique d'interaction pour UC_Principal_MainWindon.xaml
    /// </summary>
    public partial class UC_Principal_MainWindow : UserControl
    {
        public Manager Mgr => (App.Current as App).MonManager;


        public IList<Personnage> ListePersonnages
        {
            get { return (IList<Personnage>)GetValue(ListePersonnagesProperty); }
            set { SetValue(ListePersonnagesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ListePersonnages.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ListePersonnagesProperty =
            DependencyProperty.Register("ListePersonnages", typeof(IList<Personnage>), typeof(UC_Principal_MainWindow), new PropertyMetadata());



        public Color Couleur
        {
            get { return (Color)GetValue(CouleurProperty); }
            set { SetValue(CouleurProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Couleur.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CouleurProperty =
            DependencyProperty.Register("Couleur", typeof(Color), typeof(UC_Principal_MainWindow));


        public Personnage PersonnageSelect
        {
            get { return (Personnage)GetValue(PersonnageSelectProperty); }
            set { SetValue(PersonnageSelectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PersonnageSelect.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PersonnageSelectProperty =
            DependencyProperty.Register("PersonnageSelect", typeof(Personnage), typeof(UC_Principal_MainWindow), new PropertyMetadata());

        public UC_Principal_MainWindow()
        {
            InitializeComponent();
            if (Mgr.SerieSelectionnee==null)
            {
                if (Mgr.GroupeSelectionne == null)
                {
                    HeaderListe.Text = "Tous les Personnages";
                    Pour_Recherche.Content = new UC_RecherchePersoClassique();
                }
                else
                {
                    Suppression_Perso.Header = "Suppr du Groupe";
                    Suppression_Perso.ToolTip = "Supprimer du Groupe";
                    HeaderListe.Text = $"{Mgr.GroupeSelectionne}";
                    Pour_Recherche.Content = new UC_RecherchePersoClassique();
                }
            }
            else
            {
                HeaderListe.Text = $"Personnages de {Mgr.SerieSelectionnee.Nom}";
                Pour_Recherche.Content = new UC_RecherchePersoDansSerie();
            }
        }

        private void SupprimerPersonnageClick(object sender, RoutedEventArgs e)
        {
            if(Mgr.SerieSelectionnee != null)
            {
                if(Mgr.SerieSelectionnee.PersonnageSelectionne != null)
                {
                    Mgr.PersonnageSelectionne = Mgr.SerieSelectionnee.PersonnageSelectionne;
                }
            }
            if (Mgr.PersonnageSelectionne != null)
            {
                MessageBoxResult confirmation = MessageBox.Show($"Voulez-vous vraiment supprimer {Mgr.PersonnageSelectionne.Nom} ?", "Supprimer un personnage",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirmation == MessageBoxResult.Yes)
                {
                    if(Mgr.GroupeSelectionne != null)
                    {
                        Mgr.RetirerPersoDeGroupe(Mgr.GroupeSelectionne, Mgr.PersonnageSelectionne);
                    }
                    else Mgr.SupprimerPersonnage(Mgr.PersonnageSelectionne);
                    MessageBox.Show("Le personnage a été supprimé.", "Supprimer un personnage", MessageBoxButton.OK, MessageBoxImage.Information);
                    if(ListePersonnages.Count > 0)
                    {
                        PersonnageSelect = ListePersonnages[0];
                    }
                    Mgr.SauvegaderDonnees();
                }
            }
        }

        private void ModifierPersonnageClick(object sender, RoutedEventArgs e)
        {
            if (PersonnageSelect != null)
            {
                Mgr.PersonnageSelectionne = PersonnageSelect;
                var window = new ModifierPerso();
                window.ShowDialog();
            }
            Mgr.SauvegaderDonnees();
        }
        private void AjouterAUnGroupe(object sender, RoutedEventArgs e)
        {
            if (PersonnageSelect != null)
            {
                
                Mgr.PersonnageSelectionne = PersonnageSelect;
                var window = new AjouterAUnGroupe();
                window.Show();
                
            }
        }

        private void Exporter(object sender, RoutedEventArgs e)
        {
            if (PersonnageSelect != null)
            {
                Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
                dialog.DefaultExt = ".xml";
                dialog.Filter = "Fichier (*.xml) | *.xml";
                if (dialog.ShowDialog() == true)
                {
                    Mgr.EcrireUnPersonnageEnXml(Mgr.PersonnageSelectionne, dialog.FileName);
                }
            }
        }

		private void OuvertureLienTitre(object sender, MouseButtonEventArgs e)
		{
            if ((sender as ListBox).SelectedItem != null)
			{
                Titre titreSelect = (sender as ListBox).SelectedItem as Titre;
                if (titreSelect.Lien != null && titreSelect.Lien != "")
				{
                    var psi = new ProcessStartInfo()
                    {
                        FileName = titreSelect.Lien,
                        UseShellExecute = true
                    };
                    try
                    {
                        Process.Start(psi);
                    }
                    catch (Win32Exception)
					{
                        MessageBox.Show("Impossible d'ouvrir le lien (est-il valide ?)", "Lien invalide", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
			}
		}

		private void AllerSurFichePersoRec(object sender, MouseButtonEventArgs e)
		{
            if ((sender as ListBox).SelectedItem != null)
			{
                Personnage perso = ((sender as ListBox).SelectedItem as Relation).PersoRec;

                if (perso != null)
				{
                    PersonnageSelect = perso;
                    if (Mgr.GroupeSelectionne != null && !Mgr.Groupes[Mgr.GroupeSelectionne].Contains(perso))
                    {
                        Suppression_Perso.IsEnabled = false;
                    }
                    else
                        Suppression_Perso.IsEnabled = true;

                    
				}
			}
		}

        private void ListBoxPersonnages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Suppression_Perso.IsEnabled = true;
        }
    }
}

