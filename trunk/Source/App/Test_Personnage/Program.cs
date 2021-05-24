using System;
using Modele;
using System.Collections.Generic;
using Data;
using System.Linq;
namespace Test_Personnage
{
    class Program
    {
        static void Main(string[] args)
        {
            Chargeur chargeur1 = new Stub("");
            Manager manager = chargeur1.Charger();
            //Test de l'affichage des relations d'un personnage (ayant des relations) (+ ajout et suppression Relation)
            manager.Series.TryGetValue(new Serie("mario"), out Serie serie);
            serie.Personnages.TryGetValue(new Personnage("Mario", "mario"), out Personnage perso1);
            AfficherLesRelations(perso1);
            bool toto = manager.RechercherUnPersonnage("Link", "zelda", out Personnage perso1_2);
            perso1.AjouterRelation("Copain", perso1_2);
            manager.RechercherUnPersonnage("Bowser", "mario", out Personnage perso1_3);
            perso1.SupprimerUneRelation(new Relation("Ennemi", perso1_3));
            AfficherLesRelations(perso1);
            //Test de l'afichage des relations d'un personnage (n'ayant pas de relations)
            serie.Personnages.TryGetValue(new Personnage("Bowser", "mario"), out Personnage perso2);
            AfficherLesRelations(perso2);
            //Test de l'affichage des jeux d'un personnage (+ de la suppression d'un jeu + ajout d'un jeu)
            AfficherLalisteDesJeuxDunPerso(perso1);
            perso1.SupprimerUnJeu(new JeuVideo("Super Mario Bros."));
            AfficherLalisteDesJeuxDunPerso(perso1);
            perso1.AjouterUnJeu("Super Mario Bros.", 1985);
            AfficherLalisteDesJeuxDunPerso(perso1);
            //Test de l'affichage de la description d'un oerso
            Console.WriteLine($"\nLa descrption de {perso1.Nom} :");
            Console.WriteLine($"{perso1.Description}");
            //Test de l'affichage du thème musical d'un perso
            AfficherLeThemeMusicalDUnPersonnage(perso2);
            // A compléter

            //Test de l'affichage des citations
            manager.RechercherUnPersonnage("Madeline", "celeste", out Personnage perso4);
            AfficherLalisteDesCitationsDunPerso(perso4);
            perso4.SupprimerCitation("This is it, Madeline. Just breathe.");
            perso4.AjouterCitation("Tests");
            AfficherLalisteDesCitationsDunPerso(perso4);
            //Test de l'affichage de tous les personnages de l'application
            AfficherTousLesPersonnages(manager);
            //Test Enregistrer un personnage
            Serie test;
            manager.RechercherUneSerie("zelda", out test);
            manager.EnregistrerPersonnage("Bowser", test, out Personnage perso3);
            Console.WriteLine();
            //Test rechercher un personnage
            Console.WriteLine("Je recherche le personnage \"bowser\" :");
            TestRechercherUnPerso("Bowser", "mario", manager);
            Console.WriteLine();
            Console.WriteLine("Je recherche le personnage \"bowse\" :");
            TestRechercherUnPerso("Bowse", "mario", manager);
            //Test suppression personnage (suppression de mario)
            manager.SupprimerPersonnage(perso1);
            manager.Series.TryGetValue(new Serie("mario"), out Serie serie1);
            AfficherUneSerie(serie1);
            AfficherTousLesPersonnages(manager);
            //Test exporter personnage
            manager.EcrireUnPersonnageEnXml(perso4);
            manager.SupprimerPersonnage(perso4);
            AfficherTousLesPersonnages(manager);
            manager.LireUnPersonnageEnXml("Madeline.xml");
            AfficherTousLesPersonnages(manager);
        }

        

        private static void AfficherLesRelations(Personnage personnage)
        {
            Console.WriteLine($"\nLes Relations de {personnage.Nom} :");
            if (personnage.Relations.Count == 0)
               Console.WriteLine("Aucune");

            else
                foreach (Relation relation in personnage.Relations)
                {
                    if (relation.NomPersoNonRec == null)
                    {
                        Console.WriteLine($"\n {relation.PersoRec.Nom} : {relation.Type}");
                    }
                    else
                        Console.WriteLine($"\n {relation.NomPersoNonRec} : {relation.Type}");
                }

            
        }

        private static void AfficherLalisteDesJeuxDunPerso(Personnage personnage)
        {
            Console.WriteLine($"\nLes jeux de {personnage.Nom} sont : ");
            foreach (JeuVideo jeu in personnage.JeuxVideo)
            {
                Console.WriteLine(jeu);
            }
        }

        private static void AfficherLeThemeMusicalDUnPersonnage(Personnage personnage)
        {
            Console.WriteLine($"\nLe théme de {personnage.Nom} :");
            Console.WriteLine(personnage.Theme);
        }

        

        private static void AfficherTousLesPersonnages(Manager manager)
        {
            Console.WriteLine("\nTous les personnages de l'application :");
            foreach (Personnage personnage in manager.Personnages)
            {
                Console.WriteLine(personnage);
            }

        }
        

        public static void TestRechercherUnPerso(string nom, string nomSerie, Manager manager)
        {
            if (manager.RechercherUnPersonnage(nom, nomSerie, out Personnage perso))
            {
                Console.WriteLine(perso);
            }
            else
            {
                Console.WriteLine("Personnage inxesistant");
            }
        }

        private static void AfficherLalisteDesCitationsDunPerso(Personnage personnage)
        {
            Console.WriteLine($"\nLes citations de {personnage.Nom} sont : ");
            foreach (string citation in personnage.Citations)
            {
                Console.WriteLine(citation);
            }

        }

        private static void AfficherUneSerie(Serie serie)
        {
            Console.WriteLine($"\nLa Série \"{serie.Nom}\" est composée de :");
            foreach (Personnage personnage in serie.Personnages)
            {
                Console.WriteLine(personnage);
            }
        }

    }
}
