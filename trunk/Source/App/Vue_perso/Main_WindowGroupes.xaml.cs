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
using Vue_perso.Dialogs;

namespace Vue_perso
{
    /// <summary>
    /// Logique d'interaction pour Main_WindowGroupes.xaml
    /// </summary>
    public partial class Main_WindowGroupes : Window
    {
        public Manager Mgr => (App.Current as App).MonManager;
        public Main_WindowGroupes()
        {
            InitializeComponent();
            DataContext = Mgr;
            if(Mgr.GroupeSelectionne != null)
            {
                Mgr.ListeDePersonnagesActive = Mgr.Groupes[Mgr.GroupeSelectionne];
            }
            if(Mgr.ListeDePersonnagesActive.Count > 0)
            {
                Mgr.PersonnageSelectionne = Mgr.ListeDePersonnagesActive[0];
            }  
        }
    }
}
