using System;
using Modele;
using System.Collections.Generic;
using Data;
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
            Donnees donnees = chargeur1.Charger();
            //Test de l'affichage de toutes les série
            AfficherLesSeries(donnees.Series);
            donnees.SupprimerSerie(new Serie("mario"));
            AfficherLesSeries(donnees.Series);

            //Test de l'affichage des membres d'une série
            //AfficherUneSerie(donnees.Series[donnees.Series.IndexOf(new Serie("mario"))]);
            //Test de l'affichage des relations d'un personnage (ayant des relations)
            //AfficherLesRelations(donnees.Series[donnees.Series.IndexOf(new Serie("mario"))].Personnages[0]);
            //Test de l'afichage des relations d'un personnage (n'ayant pas de relations)
            //AfficherLesRelations(donnees.Series[donnees.Series.IndexOf(new Serie("mario"))].Personnages[1]);
        }

        private static void AfficherUneSerie (Serie serie)
        {
            Console.WriteLine($"La Série \"{serie.Nom}\" est composée de :");
            foreach (Personnage personnage in serie.Personnages)
            {
                Console.WriteLine(personnage);
            }
        }

        private static void AfficherLesRelations(Personnage personnage)
        {
            Console.WriteLine($"Les Relations de {personnage.Nom} :");
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
            foreach (JeuVideo jeu in personnage.JeuxVideo)
            {
                Console.WriteLine(jeu);
            }
        }

        private static void AfficherLesSeries(HashSet<Serie> Series)
        {
            Console.WriteLine("La liste des séries :");
            foreach (Serie serie in Series)
            {
                Console.WriteLine(serie);
            }
        }



    }
}
