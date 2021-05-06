using System;
using System.Collections.Generic;
using System.Text;
using Classes;

namespace Data
{
    class Stub : Chargeur
    {
        public Stub(string chemin) : base(chemin)
        {
        }

        public override Donnees Charger(string chemin)
        {
            Donnees test = new Donnees();
            Personnage perso1 = new Personnage("Mario");
            Personnage perso2 = new Personnage("Bowser");
            Serie mario = new Serie("mario");
            mario.AjouterUnPersonnage(perso1);
            mario.AjouterUnPersonnage(perso1);
            mario.AjouterUnPersonnage(perso2);
            mario.Personnages[mario.Personnages.IndexOf(perso1)].AjouterRelation("Ennemi", perso2);
            mario.Personnages[mario.Personnages.IndexOf(perso1)].AjouterRelation("Fère", "Luigi");
            test.Series.Add(mario);
            return test;
        }
    }
}
