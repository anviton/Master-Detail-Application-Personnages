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
            test.EnregistrerPersonnage("Mario", "mario", out Personnage perso1);
            test.EnregistrerPersonnage("Bowser", "mario", out Personnage perso2);
            test.EnregistrerPersonnage("Link", "zelda", out Personnage perso3);
            HashSet<Relation> relations = new HashSet<Relation>
            {
                new Relation("Ennemi", perso2, perso1),
                new Relation("Frère", "Luigi")
            };
            perso1.Relations = relations;            
            perso1.JeuxVideo = new HashSet<JeuVideo>{
                new JeuVideo("Super Mario 64", 1997),
                new JeuVideo("Super Mario Bros", 1982),
                new JeuVideo("Super Mario Bros 2")
            };            test.AjouterGroupe("Triforce");
            test.AjouterPersoAGroupe("Triforce", perso3);
            return test;
        }
    }
}
