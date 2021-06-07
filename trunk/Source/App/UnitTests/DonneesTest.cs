using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modele;
//using Data;
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
            Manager mgr = new Manager(new StubP.Stub());
            mgr.ChargeDonnees();
            Serie serie = new Serie("Ori");

            Assert.IsFalse(mgr.LesSeries.Series.Contains(serie));
            Assert.IsTrue(mgr.AjouterSerie("Ori", out serie));
            Assert.IsTrue(mgr.LesSeries.Series.Contains(serie));
		}

        [TestMethod]
        public void Test_AjouterSerie_SerieExistante()
		{
            Manager mgr = new Manager(new StubP.Stub());
            mgr.ChargeDonnees();

            Serie serie = new Serie("zelda");

            Assert.IsTrue(mgr.LesSeries.Series.Contains(serie));
            Assert.IsFalse(mgr.AjouterSerie("zelda", out _));
        }

        [TestMethod]
        public void Test_EnregistrerPersonnage_PersonnageInexistant()
		{
            Manager mgr = new Manager(new StubP.Stub());
            mgr.ChargeDonnees();

            mgr.RechercherUneSerie("zelda", out Serie serie);
            Personnage personnage = new Personnage("Ganon", serie.Nom);

            Assert.IsFalse(serie.Personnages.Contains(personnage));
            Assert.IsTrue(mgr.EnregistrerPersonnage("Ganon", serie, out personnage));
            Assert.IsTrue(serie.Personnages.Contains(personnage));
        }

        [TestMethod]
        public void Test_EnregistrerPersonnage_PersonnageExistant()
		{
            Manager mgr = new Manager(new StubP.Stub());
            mgr.ChargeDonnees();

            mgr.RechercherUneSerie("zelda", out Serie serie);
            Personnage personnage = new Personnage("Link", serie.Nom);

            Assert.IsTrue(serie.Personnages.Contains(personnage));
            Assert.IsFalse(mgr.EnregistrerPersonnage("Link", serie, out _));
        }

        [TestMethod]
        public void Test_SupprimerPersonnage_PersonnageHorsGroupeAvecAutresPersonnagesDansSerieNonMentionneDansRelations()
		{
            Manager mgr = new Manager(new StubP.Stub());
            mgr.ChargeDonnees();

            mgr.RechercherUneSerie("mario", out Serie serie);
            mgr.RechercherUnPersonnage("Mario", "mario", out Personnage personnage);

            mgr.SupprimerPersonnage(personnage);

            Assert.IsTrue(mgr.LesSeries.Series.Contains(serie));
            Assert.IsFalse(serie.Personnages.Contains(personnage));
        }

        [TestMethod]
        public void Test_SupprimerPersonnage_AucunAutrePersonnageDansSerie()
		{
            Manager mgr = new Manager(new StubP.Stub());
            mgr.ChargeDonnees();

            mgr.RechercherUneSerie("celeste", out Serie serie);
            mgr.RechercherUnPersonnage("Madeline", "celeste", out Personnage personnage);

            Assert.IsTrue(serie.Personnages.Contains(personnage));
            mgr.SupprimerPersonnage(personnage);
            Assert.IsFalse(mgr.LesSeries.Series.Contains(serie));
        }

        [TestMethod]
        public void Test_SupprimerPersonnage_PersonnageDansGroupe()
		{
            Manager mgr = new Manager(new StubP.Stub());
            mgr.ChargeDonnees();

            mgr.RechercherUneSerie("zelda", out Serie serie);
            mgr.RechercherUnPersonnage("Link", "zelda", out Personnage personnage);

            Assert.IsTrue(mgr.Groupes["Triforce"].Contains(personnage));
            Assert.IsTrue(serie.Personnages.Contains(personnage));
            mgr.SupprimerPersonnage(personnage);
            Assert.IsFalse(mgr.Groupes["Triforce"].Contains(personnage));
            Assert.IsFalse(serie.Personnages.Contains(personnage));
        }

        [TestMethod]
        public void Test_SupprimerPersonnage_PersonnageMentionneDansRelation()
		{
            Manager mgr = new Manager(new StubP.Stub());
            mgr.ChargeDonnees();

            mgr.RechercherUneSerie("mario", out Serie serie);
            mgr.RechercherUnPersonnage("Bowser", "mario", out Personnage bowser);
            mgr.RechercherUnPersonnage("Mario", "mario", out Personnage mario);
            //mario.Relations.TryGetValue(new Relation("Ennemi", bowser), out Relation relation);
            Relation relation = mario.Relations[mario.Relations.IndexOf(new Relation("Ennemi", bowser))];

            Assert.AreEqual(new Relation("Ennemi", bowser), relation);
            Assert.IsTrue(serie.Personnages.Contains(bowser));
            mgr.SupprimerPersonnage(bowser);
            Assert.AreEqual(new Relation("Ennemi", "Bowser"), relation);
            Assert.IsFalse(serie.Personnages.Contains(bowser));
        }

        [TestMethod]
        public void Test_AjouterGroupe_GroupeInexistant()
		{
            Manager mgr = new Manager(new StubP.Stub());
            mgr.ChargeDonnees();

            Assert.IsFalse(mgr.Groupes.ContainsKey("Héros"));
            Assert.IsTrue(mgr.AjouterGroupe("Héros"));
            Assert.IsTrue(mgr.Groupes.ContainsKey("Héros"));
        }

        [TestMethod]
        public void Test_AjouterGroupe_GroupeExistant()
		{
            Manager mgr = new Manager(new StubP.Stub());
            mgr.ChargeDonnees();

            Assert.IsTrue(mgr.Groupes.ContainsKey("Triforce"));
            Assert.IsFalse(mgr.AjouterGroupe("Triforce"));
        }

        [TestMethod]
        public void Test_SupprimerGroupe()
		{
            Manager mgr = new Manager(new StubP.Stub());
            mgr.ChargeDonnees();

            Assert.IsTrue(mgr.Groupes.ContainsKey("Triforce"));
            mgr.SupprimerGroupe("Triforce");
            Assert.IsFalse(mgr.Groupes.ContainsKey("Triforce"));
        }

        [TestMethod]
        public void Test_AjouterPersoAGroupe_PersoInexistantDansGroupe()
		{
            Manager mgr = new Manager(new StubP.Stub());
            mgr.ChargeDonnees();

            mgr.RechercherUneSerie("mario", out Serie serie);
            mgr.RechercherUnPersonnage("Mario", "mario", out Personnage personnage);

            Assert.IsFalse(mgr.Groupes["Triforce"].Contains(personnage));
            Assert.IsTrue(mgr.AjouterPersoAGroupe("Triforce", personnage));
            Assert.IsTrue(mgr.Groupes["Triforce"].Contains(personnage));
        }

        [TestMethod]
        public void Test_AjouterPersoAGroupe_PersoExistantDansGroupe()
		{
            Manager mgr = new Manager(new StubP.Stub());
            mgr.ChargeDonnees();

            mgr.RechercherUneSerie("zelda", out Serie serie);
            mgr.RechercherUnPersonnage("Link", "zelda", out Personnage personnage);

            Assert.IsTrue(mgr.Groupes["Triforce"].Contains(personnage));
            Assert.IsFalse(mgr.AjouterPersoAGroupe("Triforce", personnage));
        }

        [TestMethod]
        public void Test_RetirerPersoDeGroupe()
		{
            Manager mgr = new Manager(new StubP.Stub());
            mgr.ChargeDonnees();

            mgr.RechercherUneSerie("zelda", out Serie serie);
            mgr.RechercherUnPersonnage("Link", "zelda", out Personnage personnage);

            Assert.IsTrue(mgr.Groupes["Triforce"].Contains(personnage));
            mgr.RetirerPersoDeGroupe("Triforce", personnage);
            Assert.IsFalse(mgr.Groupes["Triforce"].Contains(personnage));
        }
    }
}
