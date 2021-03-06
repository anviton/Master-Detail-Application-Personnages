using System;
using Modele;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace Tests_Series_et_Groupes
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager(new StubP.Stub());
            manager.ChargeDonnees();
            Console.WriteLine("Tests sur les SERIES ------");
            //Test de l'affichage de toutes les série
            AfficherLesSeries(manager.LesSeries.Series);
            //Test de l'affichage des membres d'une série
            manager.RechercherUneSerie("mario", out Serie serie);
            AfficherUneSerie(serie);
            //Test rechercher une série
            Console.WriteLine();
            Console.WriteLine("Je recherche la série \"mario\" :");
            TestRechercherUneSerie("mario", manager);
            Console.WriteLine();
            Console.WriteLine("Je recherche la série \"mari\" :");
            TestRechercherUneSerie("mari", manager);
            Console.WriteLine("\nTests sur les GROUPES ------");
            //Test de l'affichage de tous les groupes de personnages de l'application
            AfficherLaListeDesGroupes(manager.Groupes);
            //Test de l'affichage d'un groupe
            AfficherUnGroupe("Triforce", manager);
            //Test Ajouter un groupe + Ajouter Personnage a un groupe + supprimer un groupe
            Console.WriteLine("\nTests ajouter un groupe et ajouter perso à un groupe");
            manager.AjouterGroupe("toto");
            Personnage perso;
            manager.RechercherUnPersonnage("Bowser", "mario", out perso);
            manager.AjouterPersoAGroupe("toto", perso);
            AfficherLaListeDesGroupes(manager.Groupes);
            AfficherUnGroupe("toto", manager);
            manager.RetirerPersoDeGroupe("toto", perso);
            AfficherUnGroupe("toto", manager);
            manager.SupprimerGroupe("toto");
            AfficherLaListeDesGroupes(manager.Groupes);
        }

        private static void AfficherUneSerie(Serie serie)
        {
            Console.WriteLine($"\nLa Série \"{serie.Nom}\" est composée de :");
            foreach (Personnage personnage in serie.Personnages)
            {
                Console.WriteLine(personnage);
            }
        }

        private static void AfficherLesSeries(IEnumerable<Serie> Series)
        {
            Console.WriteLine("\nLa liste des séries :");
            foreach (Serie serie in Series)
            {
                Console.WriteLine(serie);
            }
        }

        public static void TestRechercherUneSerie(string nom, Manager manager)
        {
            if (manager.RechercherUneSerie(nom, out Serie serie))
            {
                Console.WriteLine(serie);
            }
            else
            {
                Console.WriteLine("Serie inxesistante");
            }
        }

        private static void AfficherLaListeDesGroupes(IDictionary<string, ObservableCollection<Personnage>> groupes)
        {
            Console.WriteLine("\nListe des groupes : ");
            foreach (string nomGroupe in groupes.Keys)
            {
                Console.WriteLine(nomGroupe);
            }
        }

        private static void AfficherUnGroupe(string nom, Manager manager)
        {
            manager.Groupes.TryGetValue(nom, out ObservableCollection<Personnage> personnages);
            Console.WriteLine($"\nLe groupe \"{nom}\" est composé de :");
            foreach (Personnage personnage in personnages)
            {
                Console.WriteLine(personnage);
            }
        }
    }
}
