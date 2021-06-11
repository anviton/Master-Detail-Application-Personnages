using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using StubP;
using Modele;

namespace UnitTests
{
	[TestClass]
	public class PersonnageTest
	{
		[TestMethod]
		public void AjouterCitation_CitationInexistante()
		{
			Manager Mgr = new Manager(new Stub());
			Mgr.ChargeDonnees();
			string citation = "Citation inexistante";
			Personnage madeline = new Personnage("Madeline", "celeste");
			madeline = Mgr.Personnages[Mgr.Personnages.IndexOf(madeline)];

			Assert.IsFalse(madeline.Citations.Contains(citation));
			Assert.IsTrue(madeline.AjouterCitation(citation));
			Assert.IsTrue(madeline.Citations.Contains(citation));
		}

		[TestMethod]
		public void AjouterCitation_CitationExistante()
		{
			Manager Mgr = new Manager(new Stub());
			Mgr.ChargeDonnees();
			string citation = "This is it, Madeline. Just breathe.";
			Personnage madeline = new Personnage("Madeline", "celeste");
			madeline = Mgr.Personnages[Mgr.Personnages.IndexOf(madeline)];

			Assert.IsTrue(madeline.Citations.Contains(citation));
			Assert.IsFalse(madeline.AjouterCitation(citation));
		}

		[TestMethod]
		public void SupprimerCitation()
		{
			Manager Mgr = new Manager(new Stub());
			Mgr.ChargeDonnees();
			string citation = "This is it, Madeline. Just breathe.";
			Personnage madeline = new Personnage("Madeline", "celeste");
			madeline = Mgr.Personnages[Mgr.Personnages.IndexOf(madeline)];

			Assert.IsTrue(madeline.Citations.Contains(citation));
			madeline.SupprimerCitation(citation);
			Assert.IsFalse(madeline.Citations.Contains(citation));
		}

		[TestMethod]
		public void AjouterRelation_RelationPersoNonRecInexistante()
		{
			Manager Mgr = new Manager(new Stub());
			Mgr.ChargeDonnees();
			Relation relation = new Relation("anyType", "un personnage non enregistré");
			Personnage mario = new Personnage("Mario", "mario");
			mario = Mgr.Personnages[Mgr.Personnages.IndexOf(mario)];

			Assert.IsFalse(mario.Relations.Contains(relation));
			Assert.IsTrue(mario.AjouterRelation(relation.Type, relation.NomPersoNonRec));
			Assert.IsTrue(mario.Relations.Contains(relation));
		}

		[TestMethod]
		public void AjouterRelation_RelationPersoNonRecExistante()
		{
			Manager Mgr = new Manager(new Stub());
			Mgr.ChargeDonnees();
			Relation relation = new Relation("anyType", "Luigi");
			Personnage mario = new Personnage("Mario", "mario");
			mario = Mgr.Personnages[Mgr.Personnages.IndexOf(mario)];

			Assert.IsTrue(mario.Relations.Contains(relation));
			Assert.IsFalse(mario.AjouterRelation(relation.Type, relation.NomPersoNonRec));
		}

		[TestMethod]
		public void AjouterRelation_RelationPersoRecInexistante()
		{
			Manager Mgr = new Manager(new Stub());
			Mgr.ChargeDonnees();
			Personnage mario = new Personnage("Mario", "mario");
			Personnage wario = new Personnage("Wario", "mario");
			mario = Mgr.Personnages[Mgr.Personnages.IndexOf(mario)];
			wario = Mgr.Personnages[Mgr.Personnages.IndexOf(wario)];
			Relation relation = new Relation("anyType", wario);

			Assert.IsFalse(mario.Relations.Contains(relation));
			Assert.IsTrue(mario.AjouterRelation(relation.Type, relation.PersoRec));
			Assert.IsTrue(mario.Relations.Contains(relation));
		}

		[TestMethod]
		public void AjouterRelation_RelationPersoRecExistante()
		{
			Manager Mgr = new Manager(new Stub());
			Mgr.ChargeDonnees();
			Personnage mario = new Personnage("Mario", "mario");
			Personnage bowser = new Personnage("Bowser", "mario");
			mario = Mgr.Personnages[Mgr.Personnages.IndexOf(mario)];
			bowser = Mgr.Personnages[Mgr.Personnages.IndexOf(bowser)];
			Relation relation = new Relation("anyType", bowser);

			Assert.IsTrue(mario.Relations.Contains(relation));
			Assert.IsFalse(mario.AjouterRelation(relation.Type, relation.PersoRec));
		}

		[TestMethod]
		public void SupprimerRelation_RelationPersoNonRec()
		{
			Manager Mgr = new Manager(new Stub());
			Mgr.ChargeDonnees();
			Relation relation = new Relation("anyType", "Luigi");
			Personnage mario = new Personnage("Mario", "mario");
			mario = Mgr.Personnages[Mgr.Personnages.IndexOf(mario)];

			Assert.IsTrue(mario.Relations.Contains(relation));
			mario.SupprimerUneRelation(relation);
			Assert.IsFalse(mario.Relations.Contains(relation));
		}

		[TestMethod]
		public void AjouterUnJeu_JeuInexistant()
		{
			Manager Mgr = new Manager(new Stub());
			Mgr.ChargeDonnees();
			JeuVideo jeu = new JeuVideo("Super Mario Odyssey", null);
			Personnage mario = new Personnage("Mario", "mario");
			mario = Mgr.Personnages[Mgr.Personnages.IndexOf(mario)];

			Assert.IsFalse(mario.JeuxVideo.Contains(jeu));
			Assert.IsTrue(mario.AjouterUnJeu(jeu.Nom, jeu.AnneeDeCreation, out _));
			Assert.IsTrue(mario.JeuxVideo.Contains(jeu));
		}

		[TestMethod]
		public void AjouterUnJeu_JeuExistant()
		{
			Manager Mgr = new Manager(new Stub());
			Mgr.ChargeDonnees();
			JeuVideo jeu = new JeuVideo("Super Mario 64", null);
			Personnage mario = new Personnage("Mario", "mario");
			mario = Mgr.Personnages[Mgr.Personnages.IndexOf(mario)];

			Assert.IsTrue(mario.JeuxVideo.Contains(jeu));
			Assert.IsFalse(mario.AjouterUnJeu(jeu.Nom, jeu.AnneeDeCreation, out _));
		}

		[TestMethod]
		public void SupprimerUnJeu()
		{
			Manager Mgr = new Manager(new Stub());
			Mgr.ChargeDonnees();
			JeuVideo jeu = new JeuVideo("Super Mario 64", null);
			Personnage mario = new Personnage("Mario", "mario");
			mario = Mgr.Personnages[Mgr.Personnages.IndexOf(mario)];

			Assert.IsTrue(mario.JeuxVideo.Contains(jeu));
			mario.SupprimerUnJeu(jeu);
			Assert.IsFalse(mario.JeuxVideo.Contains(jeu));
		}
	}
}
