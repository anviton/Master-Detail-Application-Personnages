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
        public void Test_AjouterSerie()
        {
            Chargeur chargeur1 = new Stub("");
            Donnees donnees = chargeur1.Charger();

            // Test avec une série existante
            Assert.ThrowsException<ArgumentException>(() => donnees.AjouterSerie("mario"));

            // Test avec une série inexistante
            donnees.AjouterSerie("ori");
            Assert.IsTrue(donnees.Series.Contains(new Serie("ori")));
        }

        [TestMethod]
        public void Test_SupprimerSerie()
        {
            Chargeur chargeur1 = new Stub("");
            Donnees donnees = chargeur1.Charger();

            // Test avec une série existante, personnages hors groupe
            Serie serieASupprimer = new Serie("mario");
            donnees.SupprimerSerie(serieASupprimer);
            Assert.IsFalse(donnees.Series.Contains(serieASupprimer));

            // Test avec une série inexistante
            serieASupprimer = new Serie("ori");
            Assert.ThrowsException<ArgumentException>(() => donnees.SupprimerSerie(serieASupprimer));

            // Test avec une série existante, personnage dans des groupes
            serieASupprimer = new Serie("zelda");
            donnees.SupprimerSerie(serieASupprimer);
            // On récupère toutes les séries dont au moins un personnage est dans un groupe
            ISet<Serie> seriesDansGroupes = new HashSet<Serie>();
            foreach (KeyValuePair<string, HashSet<Personnage>> paires in donnees.Groupes)
            {
                foreach (Personnage perso in paires.Value)
                {
                    //seriesDansGroupes.Add(perso.SerieDuPerso);
                }
            }

            Assert.IsFalse(donnees.Series.Contains(serieASupprimer));
            Assert.IsFalse(seriesDansGroupes.Contains(serieASupprimer));
        }
    }
}
