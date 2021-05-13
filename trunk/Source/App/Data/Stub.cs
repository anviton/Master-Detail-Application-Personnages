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
            test.AjouterSerie("mario", out Serie serieMario);
            test.AjouterSerie("zelda", out Serie serieZelda);
            test.AjouterSerie("celeste", out Serie serieCeleste);
            test.EnregistrerPersonnage("Mario", "mario", out Personnage perso1);
            test.EnregistrerPersonnage("Bowser", "mario", out Personnage perso2);
            test.EnregistrerPersonnage("Link", "zelda", out Personnage perso3);
            test.EnregistrerPersonnage("Madeline", "celeste", out Personnage perso4);
            perso1.AjouterRelation("Ennemi", perso2);
            perso1.AjouterRelation("Frère", "Luigi");
            perso1.AjouterUnJeu(new JeuVideo("Super Mario 64", 1997);
            perso1.AjouterUnJeu(new JeuVideo("Super Mario Bros.", 1982));
            perso1.AjouterUnJeu(new JeuVideo("Super Mario Bros. 2"));
            perso2.Theme = new ThemeMusical(false);
            perso2.Theme.AjouterTitre("Bowser's Theme", "https://www.youtube.com/watch?v=bq_jS6o3OoY");
            perso4.AjouterCitation("This is it, Madeline. Just breathe.");
            test.AjouterGroupe("Triforce");
            test.AjouterPersoAGroupe("Triforce", perso3);
            return test;
        }
    }
}
