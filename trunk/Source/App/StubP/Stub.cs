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
            //Stub Pour test
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

            /*SeriesTheque LesSeries = new SeriesTheque();
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
            mario.AjouterRelation("Ennemi", wario);
            yoshi.AjouterRelation("Ennemi", bowser);
            mario.AjouterRelation("Frère", "Luigi");
            yoshi.AjouterRelation("Acolyte", mario);
            wario.AjouterRelation("Ennemi", mario);
            link.AjouterRelation("Ma Princesse", zelda);
            bowser.AjouterRelation("Ennemi", mario);
            bowser.AjouterRelation("Collègue", wario);
            mario.AjouterUnJeu("Super Mario 64", 1997, out JeuVideo j);
            bowser.AjouterUnJeu("Super Mario 64", 1997, out j);
            bowser.AjouterUnJeu("Super Mario 3D World", 2013, out j);
            yoshi.AjouterUnJeu("Super Mario 64", 1997, out j);
            yoshi.AjouterUnJeu("Super Mario World 2: Yoshi's Island", 1995, out j);
            mario.AjouterUnJeu("Super Mario Bros.", 1982, out j);
            mario.AjouterUnJeu("Super Mario Bros. 2", 1983, out j);
            zelda.AjouterUnJeu("The Legend of Zelda: Breath of the Wild", null, out j);
            wario.AjouterUnJeu("Wario Land 2", 1998, out j);
            wario.AjouterUnJeu("Wario World", 2003, out j);
            link.AjouterUnJeu("The Legend of Zelda: Link's Awakening", 2019, out j);
            link.AjouterUnJeu("The Legend of Zelda: Majora's Mask", 2000, out j);
            zelda.Description = "La Princesse Zelda est un personnage de la série The Legend of Zelda créée par Shigeru Miyamoto. Elle apparaît le 21 février 1986 dès le premier jeu de la série. Son prénom a été choisi en référence à la romancière Zelda Fitzgerald1 par Miyamoto lui-même. Elle fait partie de la famille royale d’Hyrule, étant la descendante légitime du roi en place (Daltus, Roham, Dartas, Daphnès…). En tant que Princesse, son prénom est toujours identique d'un jeu à l'autre, cela est imposé depuis le début même de l'histoire et l'apparition de la première princesse dans le jeu Skyward Sword (chronologiquement le premier épisode)";
            mario.Description = "Personnage emblématique du monde du Jeu Vidéo";
            yoshi.Description = "Yoshi est un personnage fictif de jeu vidéo créé par le japonais Shigefumi Hino. Il apparaît dans les jeux vidéo édités par Nintendo, d'abord dans la série Super Mario où il accompagne Mario et Luigi.";
            wario.Description = "Wario est un personnage de jeu vidéo créé par Hiroji Kiyotake en 1992 pour l'entreprise japonaise Nintendo. Wario est le double maléfique de Mario et son ennemi principal après Bowser et Donkey Kong. Il a été conçu comme le contraire du célèbre petit plombier à casquette rouge et salopette bleue.";
            bowser.Description = "Bowser est un personnage de jeu vidéo anthropomorphe et principal antagoniste de la série Super Mario.Bien que possédant des caractéristiques de dragon(il crache du feu, possède des écailles, etc.), il est le plus souvent considéré comme une tortue et parfois comme un dinosaure.";
            link.Description = "Link est un Hylien, bien qu'il ait grandi parmi le peuple Kokiri dans Ocarina of Time. Il est le héros principal de la série de jeux vidéo The Legend of Zelda éditée par Nintendo. Cette série a été créée par Shigeru Miyamoto qui a également procédé au graphisme même de Link (vêtu de vert, aux oreilles pointues, tenant une épée ainsi qu'un bouclier).";
            bowser.Theme.AjouterTitre("Bowser's Theme", "https://www.youtube.com/watch?v=bq_jS6o3OoY");
            link.Theme.AjouterTitre("Overworld", "https://www.youtube.com/watch?v=KoJlwOUHsf8");
            madeline.AjouterCitation("This is it, Madeline. Just breathe.");
            wario.AjouterCitation("Wariooooooo!!!"); 
            wario.AjouterCitation("Wario Time !");
            bowser.AjouterCitation("AAAhhh... AAAh...!");
            bowser.AjouterCitation("GWA HA HA HA HA HA !GWA HI HOU HE HEU !");
            wario.Theme.AjouterTitre("Wario Ware", "https://www.youtube.com/watch?v=1AAhRrO5ySs");
            mario.Theme.AjouterTitre("Super Mario Bros. Theme Songe", "https://www.youtube.com/watch?v=NTa6Xbzfq1U");
            madeline.Theme.Leitmotiv = true;
            madeline.Theme.AjouterTitre("First Steps");
            madeline.Theme.AjouterTitre("Reach for the Summit");
            yoshi.Theme.Leitmotiv = true;
            yoshi.Theme.AjouterTitre("Athletic Theme", "https://www.youtube.com/watch?v=GlUeW7IOSFc");
            yoshi.Theme.AjouterTitre("Yoshi's Story: Theme", "https://www.youtube.com/watch?v=nghTrcPBp3s");
            zelda.Theme.Leitmotiv = true;
            zelda.Theme.AjouterTitre("Zelda Main Theme Song", "https://www.youtube.com/watch?v=cGufy1PAeTU");
            zelda.Theme.AjouterTitre("Zelda Main Theme Song Smash Bross", "https://www.youtube.com/watch?v=Ck-V6hRxLlk");
            groupes.Add("Triforce", new ObservableCollection<Personnage>());
            groupes.Add("Favoris", new ObservableCollection<Personnage>());
            groupes["Triforce"].Add(link);
            groupes["Triforce"].Add(zelda);
            groupes["Favoris"].Add(zelda);
            groupes["Favoris"].Add(yoshi);
            groupes["Favoris"].Add(mario);
            return (LesSeries, groupes);*/
        }
        public void Sauvegarder(SeriesTheque lesSeries, IDictionary<string, ObservableCollection<Personnage>> groupes)
        {
            Debug.WriteLine("Sauvegarde");
        }
    }
}
