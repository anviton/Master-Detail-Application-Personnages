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
           //Console.WriteLine($"Mon nom est {perso1.nom} relation : ");
           //Console.WriteLine(perso1.ToString());
            perso1.AjouterRelation("père", perso2);
            perso1.AjouterRelation("enfant", "Mario");
            Console.WriteLine(perso1.AfficherLesRelations());
            int i = perso1.ChercherUneRelation("enfant", "Mario");
            Console.WriteLine(i);
            //Console.WriteLine($"Mon nom est {perso1.nom} relation : ");

        }
    }
}
