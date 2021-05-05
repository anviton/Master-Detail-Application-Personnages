using System;
using Classes;
namespace Test_Personnage
{
    class Program
    {
        static void Main(string[] args)
        {
            Personnage perso1 = new Personnage("TOTO");
            Personnage perso2 = new Personnage("TOTO2");
            Console.WriteLine($"Mon nom est {perso1.Nom}");
            Console.WriteLine(perso1.AfficherLesRelations());
           //Console.WriteLine(perso1.ToString());
            perso1.AjouterRelation("père", perso2);
            perso1.AjouterRelation("père", perso2);
            perso1.AjouterRelation("enfant", "Mario");
            perso1.AjouterRelation("enfant", "Mario");
            Console.WriteLine(perso1.AfficherLesRelations());
            Console.WriteLine(perso2.AfficherLesRelations());
            Console.WriteLine("Test contenu dans la liste :");
            // !!! MAUVAIS TEST : UTILISER UNE FONCTION ADAPTÉE
            if (perso1.relations.Contains(new Relation("enfant", "Mario")))
                Console.WriteLine("OK");
            else
                Console.WriteLine("Pas OK");
            perso1.SupprimerUneRelation(new Relation("enfant", "Mario"));
            Console.WriteLine("Test supprimer une relation : ");
            if (perso1.relations.Contains(new Relation("enfant", "Mario")))
                Console.WriteLine("Pas OK");
            else
                Console.WriteLine("OK");

            //Console.WriteLine($"Mon nom est {perso1.nom} relation : ");

        }
    }
}
