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
            Console.WriteLine($"Mon nom est {perso1.nom} relation : {perso1.Relations}");
            perso1.AjouterRelationAvecPersoEnr("père", perso2);
            Console.WriteLine($"Mon nom est {perso1.nom} relation : {perso1.Relations}");
        }
    }
}
