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
            LesSeries.Series[LesSeries.Series.IndexOf(new Serie("mario"))].Personnages.Add(mario);
            LesSeries.Series[LesSeries.Series.IndexOf(new Serie("mario"))].Personnages.Add(bowser);
            LesSeries.Series[LesSeries.Series.IndexOf(new Serie("zelda"))].Personnages.Add(link);
            LesSeries.Series[LesSeries.Series.IndexOf(new Serie("celeste"))].Personnages.Add(madeline);
            LesSeries.Series[LesSeries.Series.IndexOf(new Serie("mario"))].Personnages.Add(yoshi);
            bowser.Image = "bowser.jpg";
            mario.Image = "mario.jpeg";
            link.Image = "link.jpeg";
            yoshi.Image = "yoshi.jpeg";
            mario.AjouterCitation("It's me Mario");
            mario.AjouterCitation("Bye bye");
            yoshi.AjouterCitation("Yaoouh!");
            mario.AjouterRelation("Ennemi", bowser);
            mario.AjouterRelation("Frère", "Luigi");
            yoshi.AjouterRelation("Acolyte", mario);
            mario.AjouterUnJeu("Super Mario 64", 1997, out JeuVideo j);
            yoshi.AjouterUnJeu("Super Mario 64", 1997, out j);
            mario.AjouterUnJeu("Super Mario Bros.", 1982, out j);
            mario.AjouterUnJeu("Super Mario Bros. 2", 1983, out j);
            mario.Description = "Personnage emblématique du monde du Jeu Vidéo";
            yoshi.Description = "Plus fidèle compagnon de Mario";
            bowser.Theme.AjouterTitre("Bowser's Theme", "https://www.youtube.com/watch?v=bq_jS6o3OoY");
            madeline.AjouterCitation("This is it, Madeline. Just breathe.");
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
