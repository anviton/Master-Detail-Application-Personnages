using Modele;
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
                }
                else
                {
                    HeaderListe.Text = $"{Mgr.GroupeSelectionne}";
                }
            }
            else
            {
                HeaderListe.Text = $"Personnages de {Mgr.SerieSelectionnee.Nom}";
            }
        }

        private void SupprimerPersonnageClick(object sender, RoutedEventArgs e)
        {
            if (PersonnageSelect != null)
            {
                Mgr.PersonnageSelectionne = PersonnageSelect;
                SuppressionConfirmation window = new SuppressionConfirmation();
                window.ShowDialog();
            }
            if (ListePersonnages.Count != 0)
            {
                PersonnageSelect = ListePersonnages[0];
            }
        }

        private void ModifierPersonnageClick(object sender, RoutedEventArgs e)
        {
            if (PersonnageSelect != null)
            {
                Mgr.PersonnageSelectionne = PersonnageSelect;
                var window = new ModifierPerso(Mgr.PersonnageSelectionne);
                window.ShowDialog();
            }
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
    }
}

