using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Modele;

namespace UnitTests
{
	[TestClass]
	public class SerieTest
	{
		[TestMethod]
		public void Test_EnregistrerPersonnage_SerieInexistante()
		{
			Chargeur chargeur = new Stub("");
			Donnees donnees = chargeur.Charger();

			ArgumentException ex;

			ex = Assert.ThrowsException<ArgumentException>(() => donnees.EnregistrerPersonnage("Sein", "Ori"));
			Assert.AreEqual(ex.Message, "La série \"Ori\" n'existe pas.");
		}

		[TestMethod]
		public void Test_EnregistrerPersonnage_SerieExistantePersoExistant()
		{
			Chargeur chargeur = new Stub("");
			Donnees donnees = chargeur.Charger();

			ArgumentException ex;

			ex = Assert.ThrowsException<ArgumentException>(() => donnees.EnregistrerPersonnage("Link", "Zelda"));
			Assert.AreEqual(ex.Message, "Le personnage \"Link\" est déjà enregistré dans la série \"Zelda\".");
		}

		[TestMethod]
		public void Test_EnregistrerPersonnage_SerieExistantePersoNonExistant()
		{
			Chargeur chargeur = new Stub("");
			Donnees donnees = chargeur.Charger();

			Personnage persoAjoute = donnees.EnregistrerPersonnage("Ganon", "Zelda");

			Assert.AreEqual(new Personnage("Ganon", "Zelda"), persoAjoute);
		}

		[TestMethod]
		public void Test_SupprimerPersonnage_PersoExistantHorsGroupe()
		{
			Chargeur chargeur = new Stub("");
			Donnees donnees = chargeur.Charger();

			donnees.Series.TryGetValue(new Serie("mario"), out Serie serieMario);
			serieMario.Personnages.TryGetValue(new Personnage("Mario", "mario"), out Personnage persoMario);

			donnees.SupprimerPersonnage(persoMario);
			Assert.IsFalse(serieMario.Personnages.Contains(persoMario));
		}

		[TestMethod]
		public void Test_SupprimerPersonnage_PersoExistantDansGroupe()
		{
			Chargeur chargeur = new Stub("");
			Donnees donnees = chargeur.Charger();

			donnees.Series.TryGetValue(new Serie("Zelda"), out Serie serieZelda);
			serieZelda.Personnages.TryGetValue(new Personnage("Link", "Zelda"), out Personnage link);

			IList<Personnage> personnagesDansGroupes = new List<Personnage>();

			donnees.SupprimerPersonnage(link);
			foreach (KeyValuePair<string, HashSet<Personnage>> groupe in donnees.Groupes) {
				foreach (Personnage perso in groupe.Value)
				{
					personnagesDansGroupes.Add(perso);
				}
			}

			Assert.IsFalse(serieZelda.Personnages.Contains(link));
			Assert.IsFalse(personnagesDansGroupes.Contains(link));
		}

		[TestMethod]
		public void Test_SupprimerPersonnage_PersoNonExistant()
		{
			Chargeur chargeur = new Stub("");
			Donnees donnees = chargeur.Charger();

			donnees.Series.TryGetValue(new Serie("mario"), out Serie serieMario);
			serieMario.Personnages.TryGetValue(new Personnage("Mario", "mario"), out Personnage persoMario);

			donnees.SupprimerPersonnage(persoMario);

			// On va retenter une suppression. Si le personnage a bien été supprimé, la suppression ne fonctionnera pas.
			Assert.ThrowsException<ArgumentException>(() => donnees.SupprimerPersonnage(persoMario));
		}
	}
}
