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

            /*Personnage perso1 = new Personnage("Mario");
            Personnage perso2 = new Personnage("Bowser");
            Serie Mario = new Serie("mario");
            Mario.AjouterUnPersonnage(perso1);
            Mario.AjouterUnPersonnage(perso1);
            Mario.AjouterUnPersonnage(perso2);
            Mario.Personnages[Mario.Personnages.IndexOf(perso1)].AjouterRelation("Ennemi", perso2);
            AfficherUneSerie(Mario);
            Console.WriteLine($"Mon nom est {perso1.Nom}");
            Console.WriteLine(AfficherLesRelations(perso1));
           //Console.WriteLine(perso1.ToString());
            
            perso1.AjouterRelation("frère", "Luigi");
            Console.WriteLine(AfficherLesRelations(perso1));
            Console.WriteLine(AfficherLesRelations(perso2));
            Console.WriteLine("Test contenu dans la liste :");
            // !!! MAUVAIS TEST : UTILISER UNE FONCTION ADAPTÉE
            if (perso1.Relations.Contains(new Relation("frère", "Luigi")))
                Console.WriteLine("OK");
            else
                Console.WriteLine("Pas OK");
            perso1.SupprimerUneRelation(new Relation("enfant", "Mario"));
            Console.WriteLine("Test supprimer une relation : ");
            if (perso1.Relations.Contains(new Relation("enfant", "Mario")))
                Console.WriteLine("Pas OK");
            else
                Console.WriteLine("OK");

            //Console.WriteLine($"Mon nom est {perso1.nom} relation : ");*/
            Chargeur chargeur1 = new Stub("");
            Manager manager = chargeur1.Charger();
            //Test de l'affichage de toutes les série
            AfficherLesSeries(manager.Series);


            //Test de l'affichage des membres d'une série
            manager.Series.TryGetValue(new Serie("mario"), out Serie serie);
            AfficherUneSerie(serie);
            //Test de l'affichage des relations d'un personnage (ayant des relations)
            serie.Personnages.TryGetValue(new Personnage("Mario", "mario"), out Personnage perso1);
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
            //Test de l'affichage du thème musical d'un perso
            AfficherLeThemeMusicalDUnPersonnage(perso2);
            //Test de l'affichage de tous les personnages de l'application
            AfficherTousLesPersonnages(manager);
            //Test de l'affichage de tous les groupes de personnages de l'application
            AfficherLaListeDesGroupes(manager.Groupes);
            //Test de l'affichage d'un groupe
            AfficherUnGroupe("Triforce", manager);
            //Test rechercher un personnage
            Serie test;
            manager.RechercherUneSerie("zelda", out test);
            manager.EnregistrerPersonnage("Bowser", test, out Personnage perso3);
            Console.WriteLine();
            Console.WriteLine("Je recherche le personnage \"bowser\" :");
            TestRechercherUnPerso("Bowser", "mario", manager);
            Console.WriteLine();
            Console.WriteLine("Je recherche le personnage \"bowse\" :");
            TestRechercherUnPerso("Bowse", "mario", manager);
            //Test rechercher une série
            Console.WriteLine();
            Console.WriteLine("Je recherche la série \"mario\" :");
            TestRechercherUneSerie("mario", manager);
            Console.WriteLine();
            Console.WriteLine("Je recherche la série \"mari\" :");
            TestRechercherUneSerie("mari", manager);

        }

        private static void AfficherUneSerie (Serie serie)
        {
            Console.WriteLine($"\nLa Série \"{serie.Nom}\" est composée de :");
            foreach (Personnage personnage in serie.Personnages)
            {
                Console.WriteLine(personnage);
            }
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
            Console.WriteLine($"Le théme de {personnage.Nom} :");
            Console.WriteLine(personnage.Theme);
        }

        private static void AfficherLesSeries(HashSet<Serie> Series)
        {
            Console.WriteLine("\nLa liste des séries :");
            foreach (Serie serie in Series)
            {
                Console.WriteLine(serie);
            }
        }

        private static void AfficherTousLesPersonnages(Manager manager)
        {
            var tousLesPerso = manager.Series.SelectMany(serie => serie.Personnages)
                                                .Distinct();
            Console.WriteLine("\nTous les personnages de l'application :");
            foreach (Personnage personnage in tousLesPerso)
            {
                Console.WriteLine(personnage);
            }

        }
        private static void AfficherLaListeDesGroupes(IDictionary<string, HashSet<Personnage>> groupes)
        {
            Console.WriteLine("\nListe des groupes : ");
            foreach ( string nomGroupe in groupes.Keys)
            {
                Console.WriteLine(nomGroupe);
            }
        }

        private static void AfficherUnGroupe(string nom, Manager manager)
        {
            manager.Groupes.TryGetValue(nom, out HashSet<Personnage> personnages);
            Console.WriteLine($"\nLe groupe \"{nom}\" est composé de :");
            foreach (Personnage personnage in personnages)
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



    }
}
