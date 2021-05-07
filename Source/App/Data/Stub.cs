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
            Serie mario = new Serie("mario");
            Personnage perso1 = new Personnage("Mario", mario);
            Personnage perso2 = new Personnage("Bowser", mario);
            mario.AjouterUnPersonnage(perso1);
            mario.AjouterUnPersonnage(perso2);
            mario.Personnages[mario.Personnages.IndexOf(perso1)].AjouterRelation("Ennemi", perso2);
            mario.Personnages[mario.Personnages.IndexOf(perso1)].AjouterRelation("Fère", "Luigi");
            test.Series.Add(mario);
            return test;
        }
    }
}
