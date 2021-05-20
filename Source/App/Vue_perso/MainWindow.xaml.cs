using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace Vue_perso
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Manager Mgr => (App.Current as App).MonManager;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Mgr;
            HeaderListe.Text = "Tous les personnages";
        }
        public MainWindow(Serie serie)
        {
            InitializeComponent();
            DataContext = serie;
            HeaderListe.Text = $"Personnages de {serie.Nom}";

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void RetourAccueil(object sender, RoutedEventArgs e)
        {
            Accueil accueil = new Accueil();
            Close();
            accueil.Show();
        }

        private void ModifierPersonnage(object sender, RoutedEventArgs e)
        {
            NouveauPerso nouveau = new NouveauPerso();
            nouveau.ShowDialog();
        }

        private void SupprimerPersonnage(object sender, RoutedEventArgs e)
        {
            //Mgr.SupprimerPersonnage(Mgr.Selected);
        }
    }
}
