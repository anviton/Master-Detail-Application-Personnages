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
        public void Test_AjouterSerie_SExistant()
        {
            Chargeur chargeur1 = new Stub("");
            Donnees donnees = chargeur1.Charger();

            Assert.ThrowsException<ArgumentException>(() => donnees.AjouterSerie("mario"));
        }

        [TestMethod]
        public void Test_AjouterSerie_SInexistant()
        {
            Chargeur chargeur1 = new Stub("");
            Donnees donnees = chargeur1.Charger();

            donnees.AjouterSerie("ori");
            Assert.IsTrue(donnees.Series.Contains(new Serie("ori")));

        }

        [TestMethod]
        public void Test_SupprimerSerie_SExistantPHorsGroupe()
        {
            Chargeur chargeur1 = new Stub("");
            Donnees donnees = chargeur1.Charger();

            Serie serieASupprimer;

            donnees.Series.TryGetValue(new Serie("mario"), out serieASupprimer);
            donnees.SupprimerSerie(serieASupprimer);
            Assert.IsFalse(donnees.Series.Contains(serieASupprimer));
        }

        [TestMethod]
        public void Test_SupprimerSerie_SInexistant()
		{
            Chargeur chargeur1 = new Stub("");
            Donnees donnees = chargeur1.Charger();

            Serie serieASupprimer;

            donnees.Series.TryGetValue(new Serie("ori"), out serieASupprimer);
            Assert.ThrowsException<ArgumentException>(() => donnees.SupprimerSerie(serieASupprimer));
        }

        [TestMethod]
        public void Test_SupprimerSerie_SExistantPDansGroupe()
		{
            Chargeur chargeur1 = new Stub("");
            Donnees donnees = chargeur1.Charger();

			donnees.Series.TryGetValue(new Serie("zelda"), out Serie serieASupprimer);
			donnees.SupprimerSerie(serieASupprimer);
            // On récupère toutes les séries dont au moins un personnage est dans un groupe
            ISet<Serie> seriesDansGroupes = new HashSet<Serie>();
            foreach (KeyValuePair<string, HashSet<Personnage>> paires in donnees.Groupes)
            {
                foreach (Personnage perso in paires.Value)
                {
                    seriesDansGroupes.Add(new Serie(perso.SerieDuPerso));
                }
            }

            Assert.IsFalse(donnees.Series.Contains(serieASupprimer));
            Assert.IsFalse(seriesDansGroupes.Contains(serieASupprimer));
        }

        [TestMethod]
        public void Test_AjouterGroupe_GExistant()
		{
            Chargeur chargeur = new Stub("");
            Donnees donnees = chargeur.Charger();

            Assert.ThrowsException<ArgumentException>(() => donnees.AjouterGroupe("Triforce"));
		}

        [TestMethod]
        public void Test_AjouterGroupe_GInexistant()
		{
            Chargeur chargeur = new Stub("");
            Donnees donnees = chargeur.Charger();

            donnees.AjouterGroupe("Héros");
            Assert.IsTrue(donnees.Groupes.ContainsKey("Héros"));
        }

        [TestMethod]
        public void Test_SupprimerGroupe_GExistant()
		{
            Chargeur chargeur = new Stub("");
            Donnees donnees = chargeur.Charger();

            donnees.SupprimerGroupe("Triforce");
            Assert.IsFalse(donnees.Groupes.ContainsKey("Triforce"));
		}

        [TestMethod]
        public void Test_SupprimerGroupe_GInexistant()
		{
            Chargeur chargeur = new Stub("");
            Donnees donnees = chargeur.Charger();

            Assert.ThrowsException<ArgumentException>(() => donnees.SupprimerGroupe("Héros"));
        }

        [TestMethod]
        public void Test_AjouterPersoAGroupe_GInexistant()
		{
            Chargeur chargeur = new Stub("");
            Donnees donnees = chargeur.Charger();

			donnees.Series.TryGetValue(new Serie("mario"), out Serie mario);

			mario.Personnages.TryGetValue(new Personnage("Mario", "mario"), out Personnage marioPersonnage);

            ArgumentException ex;

            ex = Assert.ThrowsException<ArgumentException>(() => donnees.AjouterPersoAGroupe("Héros", marioPersonnage));
            Assert.AreEqual(ex.Message, "Le groupe \"Héros\" n'existe pas.");
		}

        [TestMethod]
        public void Test_AjouterPersoAGroupe_GExistantPDansGroupe()
		{
            Chargeur chargeur = new Stub("");
            Donnees donnees = chargeur.Charger();

			donnees.Series.TryGetValue(new Serie("Zelda"), out Serie zelda);

			zelda.Personnages.TryGetValue(new Personnage("Link", "Zelda"), out Personnage link);

            ArgumentException ex;

            ex = Assert.ThrowsException<ArgumentException>(() => donnees.AjouterPersoAGroupe("Triforce", link));
            Assert.AreEqual(ex.Message, $"Le personnage \"{link.Nom}\" est déjà dans le groupe \"Triforce\".");
        }

        [TestMethod]
        public void Test_AjouterPersoAGroupe_GExistantPHorsGroupe()
		{
            Chargeur chargeur = new Stub("");
            Donnees donnees = chargeur.Charger();

            donnees.Series.TryGetValue(new Serie("mario"), out Serie mario);

			mario.Personnages.TryGetValue(new Personnage("Mario", "mario"), out Personnage marioPersonnage);

			donnees.AjouterPersoAGroupe("Triforce", marioPersonnage);
            Assert.IsTrue(donnees.Groupes["Triforce"].Contains(marioPersonnage));
        }

        [TestMethod]
        public void Test_RetirerPersoDeGroupe_GInexistant()
		{
            Chargeur chargeur = new Stub("");
            Donnees donnees = chargeur.Charger();

			donnees.Series.TryGetValue(new Serie("mario"), out Serie mario);
			donnees.Series.TryGetValue(new Serie("Zelda"), out Serie zelda);

			mario.Personnages.TryGetValue(new Personnage("Mario", "mario"), out Personnage marioPersonnage);
			zelda.Personnages.TryGetValue(new Personnage("Link", "Zelda"), out Personnage link);

            ArgumentException ex;

            ex = Assert.ThrowsException<ArgumentException>(() => donnees.RetirerPersoDeGroupe("Héros", link));
            Assert.AreEqual(ex.Message, "Le groupe \"Héros\" n'existe pas.");
        }

        [TestMethod]
        public void Test_RetirerPersoDeGroupe_GExistantPDansGroupe()
		{
            Chargeur chargeur = new Stub("");
            Donnees donnees = chargeur.Charger();

            donnees.Series.TryGetValue(new Serie("Zelda"), out Serie zelda);

            zelda.Personnages.TryGetValue(new Personnage("Link", "Zelda"), out Personnage link);

            donnees.RetirerPersoDeGroupe("Triforce", link);
            Assert.IsFalse(donnees.Groupes["Triforce"].Contains(link));
        }

        [TestMethod]
        public void Test_RetirerPersoDeGroupe_GExistantPHorsGroupe()
		{
            Chargeur chargeur = new Stub("");
            Donnees donnees = chargeur.Charger();

            donnees.Series.TryGetValue(new Serie("mario"), out Serie mario);

            mario.Personnages.TryGetValue(new Personnage("Mario", "mario"), out Personnage marioPersonnage);

            ArgumentException ex;

            ex = Assert.ThrowsException<ArgumentException>(() => donnees.RetirerPersoDeGroupe("Triforce", marioPersonnage));
            Assert.AreEqual(ex.Message, $"Le personnage \"{marioPersonnage.Nom}\" n'est pas dans le groupe \"Triforce\".");
        }
    }
}
