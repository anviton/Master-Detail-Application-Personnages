/*
 * Constructeur : comment le faire ???
 * Soit on définit AvecPersoRec en fonction du constructeur appelé
 * (si il a pour argument persoRec ou NomPersoNonRec), soit c'est un argument du constructeur.
 * À mon avis, c'est mieux la première solution mais je sais pas si c'est exploitable
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Relation
    {
        // Champs
        public string Type { get; set; }
        public string NomPersoNonRec { get; set; }
        public Personnage PersoRec { get; set; }

        /// <summary>
        /// Constructeur
        /// créer une relation avec un personnage non enregistré
        /// </summary>
        /// <param name="type"></param>
        /// <param name="nomduperso"></param>
        public Relation(string type, string nomduperso)
        {
            Type = type;
            NomPersoNonRec = nomduperso;
            PersoRec = null;
        }

        /// <summary>
        /// Constructeur
        /// créer une relation avec un personnage enregistré
        /// </summary>
        /// <param name="type"></param>
        /// <param name="perso"></param>
        public Relation(string type, Personnage perso)
        {
            Type = type;
            NomPersoNonRec = null;
            PersoRec = perso;
        }


        // Méthodes

        /// <summary>
        /// On transforme une relation avec un personnage non enregistré en relation avec un personnage enregistré dans l'application
        /// </summary>
        /// <param name="perso">personnage qui est enregistré</param>
        public void ModifierRelation (Personnage perso)
        {
            PersoRec = perso;
            NomPersoNonRec = null;
        }

        /// <summary>
        /// On transforme une relation avec un personnage enregistré en relation avec un personnage non enregistré
        /// </summary>
        /// <param name="nom">nom du personnage non enregistré</param>
        public void ModifierRelation (String nom)
        {
            PersoRec = null;
            NomPersoNonRec = nom;
        }

        public override string ToString()
        {
            if (NomPersoNonRec != null)
                return $"Nom : {NomPersoNonRec} \n\t\tRelation : {Type}";
            else
                return $"Nom  : {PersoRec.nom} \n\t\t Relation : {Type}";
        }

        

    }
}
