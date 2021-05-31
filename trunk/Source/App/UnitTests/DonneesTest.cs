using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modele;
using Data;
using System.Collections.Generic;
using System;

namespace UnitTests
{
    [TestClass]
    public class DonneesTest
    {
        [TestMethod]
        public void Test_AjouterSerie_SerieInexistante()
		{
            Chargeur chargeur = new Stub("");
            Manager donnees = chargeur.Charger();

            Serie serie = new Serie("Ori");

            Assert.IsFalse(donnees.Series.Contains(serie));
            Assert.IsTrue(donnees.AjouterSerie("Ori", out serie));
            Assert.IsTrue(donnees.Series.Contains(serie));
		}

        [TestMethod]
        public void Test_AjouterSerie_SerieExistante()
		{
            Chargeur chargeur = new Stub("");
            Manager donnees = chargeur.Charger();

            Serie serie = new Serie("zelda");

            Assert.IsTrue(donnees.Series.Contains(serie));
            Assert.IsFalse(donnees.AjouterSerie("zelda", out _));
        }

        [TestMethod]
        public void Test_EnregistrerPersonnage_PersonnageInexistant()
		{
            Chargeur chargeur = new Stub("");
            Manager donnees = chargeur.Charger();

            donnees.RechercherUneSerie("zelda", out Serie serie);
            Personnage personnage = new Personnage("Ganon", serie.Nom);

            Assert.IsFalse(serie.Personnages.Contains(personnage));
            Assert.IsTrue(donnees.EnregistrerPersonnage("Ganon", serie, out personnage));
            Assert.IsTrue(serie.Personnages.Contains(personnage));
        }

        [TestMethod]
        public void Test_EnregistrerPersonnage_PersonnageExistant()
		{
            Chargeur chargeur = new Stub("");
            Manager donnees = chargeur.Charger();

            donnees.RechercherUneSerie("zelda", out Serie serie);
            Personnage personnage = new Personnage("Link", serie.Nom);

            Assert.IsTrue(serie.Personnages.Contains(personnage));
            Assert.IsFalse(donnees.EnregistrerPersonnage("Link", serie, out _));
        }

        [TestMethod]
        public void Test_SupprimerPersonnage_PersonnageHorsGroupeAvecAutresPersonnagesDansSerieNonMentionneDansRelations()
		{
            Chargeur chargeur = new Stub("");
            Manager donnees = chargeur.Charger();

            donnees.RechercherUneSerie("mario", out Serie serie);
            serie.Personnages.TryGetValue(new Personnage("Mario", serie.Nom), out Personnage personnage);

            donnees.SupprimerPersonnage(personnage);

            Assert.IsTrue(donnees.Series.Contains(serie));
            Assert.IsFalse(serie.Personnages.Contains(personnage));
        }

        [TestMethod]
        public void Test_SupprimerPersonnage_AucunAutrePersonnageDansSerie()
		{
            Chargeur chargeur = new Stub("");
            Manager donnees = chargeur.Charger();

            donnees.RechercherUneSerie("celeste", out Serie serie);
            serie.Personnages.TryGetValue(new Personnage("Madeline", serie.Nom), out Personnage personnage);

            Assert.IsTrue(serie.Personnages.Contains(personnage));
            donnees.SupprimerPersonnage(personnage);
            Assert.IsFalse(donnees.Series.Contains(serie));
        }

        [TestMethod]
        public void Test_SupprimerPersonnage_PersonnageDansGroupe()
		{
            Chargeur chargeur = new Stub("");
            Manager donnees = chargeur.Charger();

            donnees.Series.TryGetValue(new Serie("zelda"), out Serie serie);
            serie.Personnages.TryGetValue(new Personnage("Link", serie.Nom), out Personnage personnage);

            Assert.IsTrue(donnees.Groupes["Triforce"].Contains(personnage));
            Assert.IsTrue(serie.Personnages.Contains(personnage));
            donnees.SupprimerPersonnage(personnage);
            Assert.IsFalse(donnees.Groupes["Triforce"].Contains(personnage));
            Assert.IsFalse(serie.Personnages.Contains(personnage));
        }

        [TestMethod]
        public void Test_SupprimerPersonnage_PersonnageMentionneDansRelation()
		{
            Chargeur chargeur = new Stub("");
            Manager donnees = chargeur.Charger();

            donnees.Series.TryGetValue(new Serie("mario"), out Serie serie);
            serie.Personnages.TryGetValue(new Personnage("Bowser", serie.Nom), out Personnage bowser);
            serie.Personnages.TryGetValue(new Personnage("Mario", serie.Nom), out Personnage mario);
            mario.Relations.TryGetValue(new Relation("Ennemi", bowser), out Relation relation);

            Assert.AreEqual(new Relation("Ennemi", bowser), relation);
            Assert.IsTrue(serie.Personnages.Contains(bowser));
            donnees.SupprimerPersonnage(bowser);
            Assert.AreEqual(new Relation("Ennemi", "Bowser"), relation);
            Assert.IsFalse(serie.Personnages.Contains(bowser));
        }

        [TestMethod]
        public void Test_AjouterGroupe_GroupeInexistant()
		{
            Chargeur chargeur = new Stub("");
            Manager donnees = chargeur.Charger();

            Assert.IsFalse(donnees.Groupes.ContainsKey("Héros"));
            Assert.IsTrue(donnees.AjouterGroupe("Héros"));
            Assert.IsTrue(donnees.Groupes.ContainsKey("Héros"));
        }

        [TestMethod]
        public void Test_AjouterGroupe_GroupeExistant()
		{
            Chargeur chargeur = new Stub("");
            Manager donnees = chargeur.Charger();

            Assert.IsTrue(donnees.Groupes.ContainsKey("Triforce"));
            Assert.IsFalse(donnees.AjouterGroupe("Triforce"));
        }

        [TestMethod]
        public void Test_SupprimerGroupe()
		{
            Chargeur chargeur = new Stub("");
            Manager donnees = chargeur.Charger();

            Assert.IsTrue(donnees.Groupes.ContainsKey("Triforce"));
            donnees.SupprimerGroupe("Triforce");
            Assert.IsFalse(donnees.Groupes.ContainsKey("Triforce"));
        }

        [TestMethod]
        public void Test_AjouterPersoAGroupe_PersoInexistantDansGroupe()
		{
            Chargeur chargeur = new Stub("");
            Manager donnees = chargeur.Charger();

            donnees.Series.TryGetValue(new Serie("mario"), out Serie serie);
            serie.Personnages.TryGetValue(new Personnage("Mario", serie.Nom), out Personnage personnage);

            Assert.IsFalse(donnees.Groupes["Triforce"].Contains(personnage));
            Assert.IsTrue(donnees.AjouterPersoAGroupe("Triforce", personnage));
            Assert.IsTrue(donnees.Groupes["Triforce"].Contains(personnage));
        }

        [TestMethod]
        public void Test_AjouterPersoAGroupe_PersoExistantDansGroupe()
		{
            Chargeur chargeur = new Stub("");
            Manager donnees = chargeur.Charger();

            donnees.Series.TryGetValue(new Serie("zelda"), out Serie serie);
            serie.Personnages.TryGetValue(new Personnage("Link", serie.Nom), out Personnage personnage);

            Assert.IsTrue(donnees.Groupes["Triforce"].Contains(personnage));
            Assert.IsFalse(donnees.AjouterPersoAGroupe("Triforce", personnage));
        }

        [TestMethod]
        public void Test_RetirerPersoDeGroupe()
		{
            Chargeur chargeur = new Stub("");
            Manager donnees = chargeur.Charger();

            donnees.Series.TryGetValue(new Serie("zelda"), out Serie serie);
            serie.Personnages.TryGetValue(new Personnage("Link", serie.Nom), out Personnage personnage);

            Assert.IsTrue(donnees.Groupes["Triforce"].Contains(personnage));
            donnees.RetirerPersoDeGroupe("Triforce", personnage);
            Assert.IsFalse(donnees.Groupes["Triforce"].Contains(personnage));
        }
    }
}
