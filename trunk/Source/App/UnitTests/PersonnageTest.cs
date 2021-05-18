using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Modele;

namespace UnitTests
{
	[TestClass]
	public class PersonnageTest
	{
		[TestMethod]
		public void Test_AjouterCitation_CitationInexistante()
		{
			Chargeur chargeur = new Stub("");
			Manager donnees = chargeur.Charger();

			donnees.Series.TryGetValue(new Serie("celeste"), out Serie serie);
			serie.Personnages.TryGetValue(new Personnage("Madeline", serie.Nom), out Personnage personnage);
			string nouvelleCitation = "Get up, Madeline. Think of the feather. You can save Theo.";

			Assert.IsFalse(personnage.Citations.Contains(nouvelleCitation));
			Assert.IsTrue(personnage.AjouterCitation(nouvelleCitation));
			Assert.IsTrue(personnage.Citations.Contains(nouvelleCitation));
		}

		[TestMethod]
		public void Test_AjouterCitation_CitationExistante()
		{
			Chargeur chargeur = new Stub("");
			Manager donnees = chargeur.Charger();

			donnees.Series.TryGetValue(new Serie("celeste"), out Serie serie);
			serie.Personnages.TryGetValue(new Personnage("Madeline", serie.Nom), out Personnage personnage);
			string nouvelleCitation = "This is it, Madeline. Just breathe.";

			Assert.IsTrue(personnage.Citations.Contains(nouvelleCitation));
			Assert.IsFalse(personnage.AjouterCitation(nouvelleCitation));
		}

		[TestMethod]
		public void Test_SupprimerCitation()
		{
			Chargeur chargeur = new Stub("");
			Manager donnees = chargeur.Charger();

			donnees.Series.TryGetValue(new Serie("celeste"), out Serie serie);
			serie.Personnages.TryGetValue(new Personnage("Madeline", serie.Nom), out Personnage personnage);
			string citation = "This is it, Madeline. Just breathe.";

			Assert.IsTrue(personnage.Citations.Contains(citation));
			personnage.SupprimerCitation(citation);
			Assert.IsFalse(personnage.Citations.Contains(citation));
		}

		[TestMethod]
		public void Test_AjouterRelation_RelationInexistanteAvecPersoRec()
		{
			Chargeur chargeur = new Stub("");
			Manager donnees = chargeur.Charger();

			donnees.Series.TryGetValue(new Serie("mario"), out Serie serieMario);
			donnees.Series.TryGetValue(new Serie("zelda"), out Serie serieZelda);
			serieMario.Personnages.TryGetValue(new Personnage("Mario", serieMario.Nom), out Personnage mario);
			serieZelda.Personnages.TryGetValue(new Personnage("Link", serieZelda.Nom), out Personnage link);

			Relation relation = new Relation("Parfait inconnu", link);

			Assert.IsFalse(mario.Relations.Contains(relation));
			Assert.IsFalse(link.EstMentionneDans.Contains(relation));
			Assert.IsTrue(mario.AjouterRelation("Parfait inconnu", link));
			Assert.IsTrue(mario.Relations.Contains(relation));
			Assert.IsTrue(link.EstMentionneDans.Contains(relation));
		}

		[TestMethod]
		public void Test_AjouterRelation_RelationInexistanteAvecPersoNonRec()
		{
			Chargeur chargeur = new Stub("");
			Manager donnees = chargeur.Charger();

			donnees.Series.TryGetValue(new Serie("mario"), out Serie serieMario);
			serieMario.Personnages.TryGetValue(new Personnage("Mario", serieMario.Nom), out Personnage mario);

			Relation relation = new Relation("Ennemi", "Donkey Kong");

			Assert.IsFalse(mario.Relations.Contains(relation));
			Assert.IsTrue(mario.AjouterRelation("Ennemi", "Donkey Kong"));
			Assert.IsTrue(mario.Relations.Contains(relation));
		}

		[TestMethod]
		public void Test_AjouterRelation_RelationExistanteAvecPersoRec()
		{
			Chargeur chargeur = new Stub("");
			Manager donnees = chargeur.Charger();

			donnees.Series.TryGetValue(new Serie("mario"), out Serie serieMario);
			serieMario.Personnages.TryGetValue(new Personnage("Mario", serieMario.Nom), out Personnage mario);
			serieMario.Personnages.TryGetValue(new Personnage("Bowser", serieMario.Nom), out Personnage bowser);

			Relation relation = new Relation("Ennemi", bowser);

			Assert.IsTrue(mario.Relations.Contains(relation));
			Assert.IsTrue(bowser.EstMentionneDans.Contains(relation));
			Assert.IsFalse(mario.AjouterRelation("Ennemi", bowser));
		}

		[TestMethod]
		public void Test_AjouterRelation_RelationExistanteAvecPersoNonRec()
		{
			Chargeur chargeur = new Stub("");
			Manager donnees = chargeur.Charger();

			donnees.Series.TryGetValue(new Serie("mario"), out Serie serieMario);
			serieMario.Personnages.TryGetValue(new Personnage("Mario", serieMario.Nom), out Personnage mario);

			Relation relation = new Relation("Frère", "Luigi");

			Assert.IsTrue(mario.Relations.Contains(relation));
			Assert.IsFalse(mario.AjouterRelation("Frère", "Luigi"));
		}

		[TestMethod]
		public void Test_SupprimerUneRelation_RelationAvecPersoRec()
		{
			Chargeur chargeur = new Stub("");
			Manager donnees = chargeur.Charger();

			donnees.Series.TryGetValue(new Serie("mario"), out Serie serieMario);
			serieMario.Personnages.TryGetValue(new Personnage("Mario", serieMario.Nom), out Personnage mario);
			serieMario.Personnages.TryGetValue(new Personnage("Bowser", serieMario.Nom), out Personnage bowser);

			Relation relation = new Relation("Ennemi", bowser);

			Assert.IsTrue(mario.Relations.Contains(relation));
			Assert.IsTrue(bowser.EstMentionneDans.Contains(relation));
			mario.SupprimerUneRelation(relation);
			Assert.IsFalse(mario.Relations.Contains(relation));
			Assert.IsFalse(bowser.EstMentionneDans.Contains(relation));
		}

		[TestMethod]
		public void Test_SupprimerUneRelation_RelationAvecPersoNonRec()
		{
			Chargeur chargeur = new Stub("");
			Manager donnees = chargeur.Charger();

			donnees.Series.TryGetValue(new Serie("mario"), out Serie serieMario);
			serieMario.Personnages.TryGetValue(new Personnage("Mario", serieMario.Nom), out Personnage mario);

			Relation relation = new Relation("Frère", "Luigi");

			Assert.IsTrue(mario.Relations.Contains(relation));
			mario.SupprimerUneRelation(relation);
			Assert.IsFalse(mario.Relations.Contains(relation));
		}

		[TestMethod]
		public void Test_AjouterUnJeu_JeuInexistantNomUniquement()
		{
			Chargeur chargeur = new Stub("");
			Manager donnees = chargeur.Charger();

			donnees.Series.TryGetValue(new Serie("mario"), out Serie serieMario);
			serieMario.Personnages.TryGetValue(new Personnage("Mario", serieMario.Nom), out Personnage mario);

			JeuVideo jeu = new JeuVideo("Super Mario Odyssey");

			Assert.IsFalse(mario.JeuxVideo.Contains(jeu));
			Assert.IsTrue(mario.AjouterUnJeu("Super Mario Odyssey"));
			Assert.IsTrue(mario.JeuxVideo.Contains(jeu));
		}

		[TestMethod]
		public void Test_AjouterUnJeu_JeuInexistantNomEtAnnee()
		{
			Chargeur chargeur = new Stub("");
			Manager donnees = chargeur.Charger();

			donnees.Series.TryGetValue(new Serie("mario"), out Serie serieMario);
			serieMario.Personnages.TryGetValue(new Personnage("Mario", serieMario.Nom), out Personnage mario);

			JeuVideo jeu = new JeuVideo("Super Mario Odyssey", 2017);

			Assert.IsFalse(mario.JeuxVideo.Contains(jeu));
			Assert.IsTrue(mario.AjouterUnJeu("Super Mario Odyssey", 2017));
			Assert.IsTrue(mario.JeuxVideo.Contains(jeu));
		}
		
		[TestMethod]
		public void Test_AjouterUnJeu_JeuExistantAjoutNomUniquementExistantNomUniquement()
		{
			Chargeur chargeur = new Stub("");
			Manager donnees = chargeur.Charger();

			donnees.Series.TryGetValue(new Serie("mario"), out Serie serieMario);
			serieMario.Personnages.TryGetValue(new Personnage("Mario", serieMario.Nom), out Personnage mario);

			JeuVideo jeu = new JeuVideo("Super Mario Bros. 2");

			Assert.IsTrue(mario.JeuxVideo.Contains(jeu));
			Assert.IsFalse(mario.AjouterUnJeu("Super Mario Bros. 2"));
		}

		[TestMethod]
		public void Test_AjouterUnJeu_JeuExistantAjoutNomEtAnneeExistantNomEtAnnee()
		{
			Chargeur chargeur = new Stub("");
			Manager donnees = chargeur.Charger();

			donnees.Series.TryGetValue(new Serie("mario"), out Serie serieMario);
			serieMario.Personnages.TryGetValue(new Personnage("Mario", serieMario.Nom), out Personnage mario);

			JeuVideo jeu = new JeuVideo("Super Mario 64", 1997);

			Assert.IsTrue(mario.JeuxVideo.Contains(jeu));
			Assert.IsFalse(mario.AjouterUnJeu("Super Mario 64", 1997));
		}

		[TestMethod]
		public void Test_AjouterUnJeu_JeuExistantAjoutNomUniquementExistantNomEtAnnee()
		{
			Chargeur chargeur = new Stub("");
			Manager donnees = chargeur.Charger();

			donnees.Series.TryGetValue(new Serie("mario"), out Serie serieMario);
			serieMario.Personnages.TryGetValue(new Personnage("Mario", serieMario.Nom), out Personnage mario);

			JeuVideo jeu = new JeuVideo("Super Mario 64");

			Assert.IsTrue(mario.JeuxVideo.Contains(jeu));
			Assert.IsFalse(mario.AjouterUnJeu("Super Mario 64"));
		}

		[TestMethod]
		public void Test_AjouterUnJeu_JeuExistantAjoutNomEtAnneeExistantNomUniquement()
		{
			Chargeur chargeur = new Stub("");
			Manager donnees = chargeur.Charger();

			donnees.Series.TryGetValue(new Serie("mario"), out Serie serieMario);
			serieMario.Personnages.TryGetValue(new Personnage("Mario", serieMario.Nom), out Personnage mario);

			JeuVideo jeu = new JeuVideo("Super Mario Bros. 2", 1988);

			Assert.IsTrue(mario.JeuxVideo.Contains(jeu));
			Assert.IsFalse(mario.AjouterUnJeu("Super Mario Bros. 2", 1988));
		}

		[TestMethod]
		public void Test_SupprimerUnJeu()
		{
			Chargeur chargeur = new Stub("");
			Manager donnees = chargeur.Charger();

			donnees.Series.TryGetValue(new Serie("mario"), out Serie serieMario);
			serieMario.Personnages.TryGetValue(new Personnage("Mario", serieMario.Nom), out Personnage mario);

			JeuVideo jeu = new JeuVideo("Super Mario Bros. 2");

			Assert.IsTrue(mario.JeuxVideo.Contains(jeu));
			mario.SupprimerUnJeu(jeu);
			Assert.IsFalse(mario.JeuxVideo.Contains(jeu));
		}
	}
}
