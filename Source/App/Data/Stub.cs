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
            test.AjouterSerie("mario");
            test.AjouterSerie("Zelda");
            Personnage perso1 = test.EnregistrerPersonnage("Mario", "mario");
            Personnage perso2 = test.EnregistrerPersonnage("Bowser", "mario");
            Personnage perso3 = test.EnregistrerPersonnage("Link", "Zelda");
            perso1.AjouterRelation("Ennemi", perso2);
            perso1.AjouterRelation("Fère", "Luigi");
            test.AjouterGroupe("Triforce");
            test.AjouterPersoAGroupe("Triforce", perso3);
            return test;
        }
    }
}
