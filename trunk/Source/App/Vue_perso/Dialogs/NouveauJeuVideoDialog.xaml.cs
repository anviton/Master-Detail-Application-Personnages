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
using System.Text.RegularExpressions;
using Modele;

namespace Vue_perso.Dialogs
{
    /// <summary>
    /// Logique d'interaction pour NouveauJeuVideoDialog.xaml
    /// </summary>
    public partial class NouveauJeuVideoDialog : Window
    {
        public string NomJeuVideo { get; set; }
        public int? Annee { get; set; }

        public NouveauJeuVideoDialog()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void GestionSaisieAnnee(object sender, TextCompositionEventArgs e)
        {
            // On crée un Regex correspondant à une chaîne contenant au moins un caractère qui n'est pas un nombre.
            Regex regex = new Regex("[^0-9]+");
            // Si le texte qui vient d'être saisi correspond à notre expression régulière,
            // on n'accepte pas la saisie.
            // Pour cela, on marque l'événement comme "géré".
            e.Handled = regex.IsMatch(e.Text);
        }

        private void GestionCollageAnnee(object sender, DataObjectPastingEventArgs e)
        {
            // On crée un Regex correspondant à une chaîne contenant au moins un caractère qui n'est pas un nombre.
            Regex regex = new Regex("[^0-9]+");

            // On récupère les données collées, en type string.
            string texteColle = (e.DataObject.GetData(typeof(string)) as string);
            // Si le texte qui vient d'être collé correspond à notre expression régulière,
            // on ne l'accepte pas.
            // Pour cela, on annule la commande Coller.
            if (regex.IsMatch(texteColle))
            {
                e.CancelCommand();
            }
        }

        private void VerifSaisieVide(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Text == "")
            {
                Annee = null;
            }
        }

        private void OKButtonPressed(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButtonPressed(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
