using System;
using System.Collections.Generic;
using System.Text;
using Modele;

namespace Data
{
    public class Stub : Chargeur
    {
        public Stub(string chemin) : base(chemin)
        {
        }

        public override Donnees Charger()
        {
            Donnees test = new Donnees();
            Serie mario = new Serie("mario");
            Serie zelda = new Serie("Zelda");
            test.AjouterSerie("mario");
            test.AjouterSerie("Zelda");
            Personnage perso1 = new Personnage("Mario");
            Personnage perso2 = new Personnage("Bowser");
            Personnage perso3 = new Personnage("Link");
            mario.AjouterUnPersonnage(perso1);
            mario.AjouterUnPersonnage(perso2);
            zelda.AjouterUnPersonnage(perso3);
            perso1.AjouterRelation("Ennemi", perso2);
            perso1.AjouterRelation("Fère", "Luigi");
            //test.Series.Add(mario);
            //test.Series.Add(zelda);
            test.AjouterGroupe("Triforce");
            test.AjouterPersoAGroupe("Triforce", perso3);
            return test;
        }
    }
}
