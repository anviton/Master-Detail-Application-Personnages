using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Vue_perso.Dialogs
{
    /// <summary>
    /// Logique d'interaction pour NouveauPerso.xaml
    /// </summary>
    public partial class NouveauPerso : Window
    {
        public Manager Mgr => (App.Current as App).MonManager;
        public string NomPerso { get; set; }
        public Serie SerieDuPerso { get; set; }

        public NouveauPerso()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void NouvelleSerie(object sender, RoutedEventArgs e)
        {
            NouvelleSerieDialog dialog = new NouvelleSerieDialog();
            
            if (dialog.ShowDialog() == true)
            {
                if (Mgr.AjouterSerie(dialog.NomSerie, out Serie serie))
                {
                    MessageBox.Show($"La série \"{dialog.NomSerie}\" a été ajoutée.", "Nouvelle série", MessageBoxButton.OK, MessageBoxImage.Information);
                    SeriesBox.SelectedItem = serie;
                }
                else
                {
                    MessageBox.Show($"La série \"{dialog.NomSerie}\" existe déjà !", "Nouvelle série", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void OKButtonPressed(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButtonPressed(object sender, RoutedEventArgs e)
        {
            if((SeriesBox.SelectedItem as Serie).Personnages.Count == 0)
            {
                Mgr.LesSeries.Series.Remove((SeriesBox.SelectedItem as Serie));
            }
            this.DialogResult = false;
        }
    }
}
