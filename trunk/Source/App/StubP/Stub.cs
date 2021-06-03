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
            LesSeries.Series[LesSeries.Series.IndexOf(new Serie("mario"))].Personnages.Add(mario);
            LesSeries.Series[LesSeries.Series.IndexOf(new Serie("mario"))].Personnages.Add(bowser);
            LesSeries.Series[LesSeries.Series.IndexOf(new Serie("zelda"))].Personnages.Add(link);
            LesSeries.Series[LesSeries.Series.IndexOf(new Serie("celeste"))].Personnages.Add(madeline);
            bowser.Image = "/Bibliothèques_Images;Component/Images_Personnages/bowser.jpg";
            mario.Image = "/Bibliothèques_Images;Component/Images_Personnages/mario.jpeg";
            mario.AjouterCitation("It's me Mario");
            mario.AjouterCitation("Bye bye");
            mario.AjouterRelation("Ennemi", bowser);
            mario.AjouterRelation("Frère", "Luigi");
            mario.AjouterUnJeu("Super Mario 64", 1997, out JeuVideo j);
            mario.AjouterUnJeu("Super Mario Bros.", 1982, out j);
            mario.AjouterUnJeu("Super Mario Bros. 2", 1983, out j);
            mario.Description = "Personnage emblématique du monde du Jeu Vidéo";
            bowser.Theme = new ThemeMusical(false); //je l'ai mis à true car sinon l'ajout ne marche pas (Du coup j'ai rien modifié dans la classe theme musical parce que j'ai pas trop compris ce que tu veux faire)
            bowser.Theme.AjouterTitre("Bowser's Theme", "https://www.youtube.com/watch?v=bq_jS6o3OoY");
            madeline.AjouterCitation("This is it, Madeline. Just breathe.");
            madeline.Theme = new ThemeMusical(true);
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
