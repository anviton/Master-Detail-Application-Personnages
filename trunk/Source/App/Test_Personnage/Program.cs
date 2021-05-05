using System;
using Classes;
namespace Test_Personnage
{
    class Program
    {
        static void Main(string[] args)
        {
            Personnage perso1 = new Personnage("Mario");
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

            //Console.WriteLine($"Mon nom est {perso1.nom} relation : ");

        }

        private static void AfficherUneSerie (Serie serie)
        {
            Console.WriteLine($"La Série \"{serie.Nom}\" est composée de :");
            foreach (Personnage personnage in serie.Personnages)
            {
                Console.WriteLine(personnage);
            }
        }

        private static string AfficherLesRelations(Personnage personnage)
        {
            string lesRelations = $"Les Relations de {personnage.Nom} :";
            if (personnage.Relations.Count == 0)
                return lesRelations + "Aucune";

            else
                foreach (Relation relation in personnage.Relations)
                {
                    if (relation.NomPersoNonRec == null)
                    {
                        lesRelations = lesRelations + $"\n {relation.PersoRec.Nom} : {relation.Type}";
                    }
                    else
                        lesRelations = lesRelations + $"\n {relation.NomPersoNonRec} : {relation.Type}";
                }

            return lesRelations;
        }

    }
}
