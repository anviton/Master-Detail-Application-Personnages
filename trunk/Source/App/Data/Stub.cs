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

        /*public override Manager Charger()
        {
            Manager test = new Manager();
            test.AjouterSerie("mario", out Serie serieMario);
            test.AjouterSerie("zelda", out Serie serieZelda);
            test.AjouterSerie("celeste", out Serie serieCeleste);
            test.EnregistrerPersonnage("Mario", serieMario, out Personnage perso1);
            test.EnregistrerPersonnage("Bowser", serieMario, out Personnage perso2);
            test.EnregistrerPersonnage("Link", serieZelda, out Personnage perso3);
            test.EnregistrerPersonnage("Madeline", serieCeleste, out Personnage perso4);
            perso2.Image = "/Bibliothèques_Images;Component/Images_Personnages/bowser.jpg";
            perso1.Image= "/Bibliothèques_Images;Component/Images_Personnages/mario.jpeg";
            perso1.AjouterCitation("It's me Mario");
            perso1.AjouterCitation("Bye bye");
            perso1.AjouterRelation("Ennemi", perso2);
            perso1.AjouterRelation("Frère", "Luigi");
            perso1.AjouterUnJeu("Super Mario 64", 1997, out JeuVideo j);
            perso1.AjouterUnJeu("Super Mario Bros.", 1982, out j);
            perso1.AjouterUnJeu("Super Mario Bros. 2", 1983 ,out j);
            perso1.Description = "Personnage emblématique du monde du Jeu Vidéo";
            perso2.Theme = new ThemeMusical(false); //je l'ai mis à true car sinon l'ajout ne marche pas (Du coup j'ai rien modifié dans la classe theme musical parce que j'ai pas trop compris ce que tu veux faire)
            perso2.Theme.AjouterTitre("Bowser's Theme", "https://www.youtube.com/watch?v=bq_jS6o3OoY");
            perso4.AjouterCitation("This is it, Madeline. Just breathe.");
            perso4.Theme = new ThemeMusical(true);
            perso4.Theme.AjouterTitre("First Steps");
            perso4.Theme.AjouterTitre("Reach for the Summit");

            test.AjouterGroupe("Triforce");
            test.AjouterPersoAGroupe("Triforce", perso3);
            return test;
        }*/
    }
}
