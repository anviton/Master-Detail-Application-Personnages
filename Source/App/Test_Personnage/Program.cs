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
            Console.WriteLine($"Mon nom est {perso1.nom}");
            Console.WriteLine(perso1.AfficherLesRelations());
           //Console.WriteLine(perso1.ToString());
            perso1.AjouterRelation("père", perso2);
            perso1.AjouterRelation("enfant", "Mario");
            Console.WriteLine(perso1.AfficherLesRelations());
            Console.WriteLine(perso2.AfficherLesRelations());
            // !!! MAUVAIS TEST : UTILISER UNE FONCTION ADAPTÉE
            if (perso1.Relations.Contains(new Relation("enfant", "Mario")))
                Console.WriteLine("OK");
            else
                Console.WriteLine("Pas OK");
            //Console.WriteLine($"Mon nom est {perso1.nom} relation : ");

        }
    }
}
