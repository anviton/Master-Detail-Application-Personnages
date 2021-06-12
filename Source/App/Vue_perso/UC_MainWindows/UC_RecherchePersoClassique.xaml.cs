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

namespace Vue_perso.UC_MainWindows
{
    /// <summary>
    /// Logique d'interaction pour UC_RecherchePersoClassique.xaml
    /// </summary>
    public partial class UC_RecherchePersoClassique : UserControl
    {
        public Manager Mgr => (App.Current as App).MonManager;
        public UC_RecherchePersoClassique()
        {
            InitializeComponent();
        }

        private void Recherche(object sender, TextChangedEventArgs e)
        {
           if(Mgr.SerieSelectionnee != null)
            {
                if (Mgr.RechercherUnPersonnage((sender as TextBox).Text, Mgr.SerieSelectionnee.Nom, out Personnage perso))
                {
                    
                    if(Mgr.GroupeSelectionne != null)
                    {
                        if (Mgr.Groupes[Mgr.GroupeSelectionne].Contains(perso))
                        {
                            Mgr.PersonnageSelectionne = perso;
                        }
                    }
                    else
                    {
                        Mgr.PersonnageSelectionne = perso;
                    }
                }
            }
        }
    }
}
