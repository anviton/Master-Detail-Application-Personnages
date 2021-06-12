using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Modele;
namespace StubP
{
    public class Stub : IPersistance
    {
        public (SeriesTheque lesSeries, IDictionary<string, ObservableCollection<Personnage>> groupes) Charger()
        {
            return ChargeSerieEtGroupes();
        }

        private (SeriesTheque lesSeries, IDictionary<string, ObservableCollection<Personnage>> groupes) ChargeSerieEtGroupes()
        {
            SeriesTheque LesSeries = new SeriesTheque();
            IDictionary<string, ObservableCollection<Personnage>> groupes = new Dictionary<string, ObservableCollection<Personnage>>();
            LesSeries.Series.Add(new Serie("mario"));
            LesSeries.Series.Add(new Serie("zelda"));
            LesSeries.Series.Add(new Serie("celeste"));
            Personnage mario = new Personnage("Mario", "mario");
            Personnage bowser = new Personnage("Bowser", "mario");
            Personnage link = new Personnage("Link", "zelda");
            Personnage madeline = new Personnage("Madeline", "celeste");
            Personnage yoshi = new Personnage("Yoshi", "mario");
            Personnage zelda = new Personnage("Zelda", "zelda");
            Personnage wario = new Personnage("Wario", "mario");
            LesSeries.Series[LesSeries.Series.IndexOf(new Serie("mario"))].Personnages.Add(mario);
            LesSeries.Series[LesSeries.Series.IndexOf(new Serie("mario"))].Personnages.Add(bowser);
            LesSeries.Series[LesSeries.Series.IndexOf(new Serie("zelda"))].Personnages.Add(link);
            LesSeries.Series[LesSeries.Series.IndexOf(new Serie("zelda"))].Personnages.Add(zelda);
            LesSeries.Series[LesSeries.Series.IndexOf(new Serie("celeste"))].Personnages.Add(madeline);
            LesSeries.Series[LesSeries.Series.IndexOf(new Serie("mario"))].Personnages.Add(yoshi);
            LesSeries.Series[LesSeries.Series.IndexOf(new Serie("mario"))].Personnages.Add(wario);
            bowser.Image = "bowser.png";
            mario.Image = "mario.png";
            link.Image = "Link.png";
            yoshi.Image = "yoshi.png";
            zelda.Image = "Zelda.png";
            wario.Image = "wario.png";
            mario.AjouterCitation("It's me Mario");
            mario.AjouterCitation("Bye bye");
            yoshi.AjouterCitation("Yaoouh!");
            zelda.AjouterCitation("Sois Fort Link");
            zelda.AjouterRelation("Mon Prince", link);
            mario.AjouterRelation("Ennemi", bowser);
            mario.AjouterRelation("Frère", "Luigi");
            yoshi.AjouterRelation("Acolyte", mario);
            wario.AjouterRelation("Ennemi", mario);
            mario.AjouterUnJeu("Super Mario 64", 1997, out JeuVideo j);
            yoshi.AjouterUnJeu("Super Mario 64", 1997, out j);
            mario.AjouterUnJeu("Super Mario Bros.", 1982, out j);
            mario.AjouterUnJeu("Super Mario Bros. 2", 1983, out j);
            zelda.AjouterUnJeu("The Legend of Zelda: Breath of the Wild", null, out j);
            wario.AjouterUnJeu("Wario Land 2", 1998, out j);
            wario.AjouterUnJeu("Wario World", 2003, out j);
            zelda.Description = "La Princesse Zelda est un personnage de la série The Legend of Zelda créée par Shigeru Miyamoto. Elle apparaît le 21 février 1986 dès le premier jeu de la série. Son prénom a été choisi en référence à la romancière Zelda Fitzgerald1 par Miyamoto lui-même. Elle fait partie de la famille royale d’Hyrule, étant la descendante légitime du roi en place (Daltus, Roham, Dartas, Daphnès…). En tant que Princesse, son prénom est toujours identique d'un jeu à l'autre, cela est imposé depuis le début même de l'histoire et l'apparition de la première princesse dans le jeu Skyward Sword (chronologiquement le premier épisode)";
            mario.Description = "Personnage emblématique du monde du Jeu Vidéo";
            yoshi.Description = "Plus fidèle compagnon de Mario";
            wario.Description = "L'un des ennemis les plus corriaces de Mario";
            bowser.Theme.AjouterTitre("Bowser's Theme", "https://www.youtube.com/watch?v=bq_jS6o3OoY");
            madeline.AjouterCitation("This is it, Madeline. Just breathe.");
            wario.AjouterCitation("Wariooooooo!!!");
            wario.AjouterCitation("Wario Time !");
            wario.Theme.AjouterTitre("Wario Ware", "https://www.youtube.com/watch?v=1AAhRrO5ySs");
            madeline.Theme.Leitmotiv = true;
            madeline.Theme.AjouterTitre("First Steps");
            madeline.Theme.AjouterTitre("Reach for the Summit");
            groupes.Add("Triforce", new ObservableCollection<Personnage>());
            groupes["Triforce"].Add(link);
            return (LesSeries, groupes);
        }
        public void Sauvegarder(SeriesTheque lesSeries, IDictionary<string, ObservableCollection<Personnage>> groupes)
        {
            Debug.WriteLine("Sauvegarde");
        }
    }
}
