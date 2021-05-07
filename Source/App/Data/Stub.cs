﻿using System;
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
            Serie mario = test.AjouterSerie("mario");
            Serie zelda = test.AjouterSerie("Zelda");
            Personnage perso1 = new Personnage("Mario", "mario");
            Personnage perso2 = new Personnage("Bowser", "mario");
            Personnage perso3 = new Personnage("Link", "Zelda");
            mario.AjouterUnPersonnage(perso1);
            mario.AjouterUnPersonnage(perso2);
            zelda.AjouterUnPersonnage(perso3);
            perso1.AjouterRelation("Ennemi", perso2);
            perso1.AjouterRelation("Fère", "Luigi");
            test.AjouterGroupe("Triforce");
            test.AjouterPersoAGroupe("Triforce", perso3);
            return test;
        }
    }
}