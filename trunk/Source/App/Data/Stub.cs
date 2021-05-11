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
            test.AjouterSerie("zelda");
            Personnage perso1 = test.EnregistrerPersonnage("Mario", "mario");
            Personnage perso2 = test.EnregistrerPersonnage("Bowser", "mario");
            Personnage perso3 = test.EnregistrerPersonnage("Link", "zelda");
            perso1.JeuxVideo = new HashSet<JeuVideo>{
                new JeuVideo("Super Mario 64", 1997),
                new JeuVideo("Super Mario Bros", 1982),
                new JeuVideo("Super Mario Bros 2")
            };
            perso1.AjouterRelation("Ennemi", perso2);
            perso1.AjouterRelation("Fère", "Luigi");
            test.AjouterGroupe("Triforce");
            test.AjouterPersoAGroupe("Triforce", perso3);
            return test;
        }
    }
}
