﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class MainWindow : Window, INotifyPropertyChanged

    {
        public Manager Mgr => (App.Current as App).MonManager;
        public SortedSet<Personnage> Personnages { get; set; }
        public Personnage PersonnageSelectionne
        {
            get => personnageSelectionne;
            set
            {
                if (personnageSelectionne != value)
                {
                    personnageSelectionne = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PersonnageSelectionne)));
                }
            }
        }

        private Personnage personnageSelectionne;

        public event PropertyChangedEventHandler PropertyChanged;
        public MainWindow()
        {
            InitializeComponent();
            if(Mgr.PersonnageSelectionne != null)
            {
                DataContext = Mgr;
                HeaderListe.Text = "Tous les personnages";
            }
            else
            {
                if(Mgr.SerieSelectionnee== null)
                {
                    DataContext = this;
                    Personnages = Mgr.Groupes[Mgr.GroupeSelectionne];
                    HeaderListe.Text = $"Personnages de {Mgr.GroupeSelectionne}";
                }
                else
                {
                    DataContext = Mgr.SerieSelectionnee;
                    HeaderListe.Text = $"Personnages de {Mgr.SerieSelectionnee.Nom}";
                }
                
            }
            
        }
        /*public MainWindow(Serie serie)
        {
            InitializeComponent();
            DataContext = serie;
            HeaderListe.Text = $"Personnages de {serie.Nom}";

        }*/

        /*public MainWindow(string nomGroupe, SortedSet<Personnage> Personnages)
        {
            InitializeComponent();
            DataContext = this;
            this.Personnages = Personnages;
            
            HeaderListe.Text = $"Personnages de {nomGroupe}";

        }*/


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void ModifierPersonnage(object sender, RoutedEventArgs e)
        {
            ModifierPerso nouveau = new ModifierPerso();
            nouveau.ShowDialog();
        }

        private void SupprimerPersonnage(object sender, RoutedEventArgs e)
        {
            //Mgr.SupprimerPersonnage(Mgr.Selected);
        }
    }
}
