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
    public class Relation : IEquatable<Relation>
    {
        // Champs
        public string Type { get; set; }
        public string NomPersoNonRec { get; private set; }
        public Personnage PersoRec { get; private set; }

        /// <summary>
        /// Constructeur
        /// créer une relation avec un personnage non enregistré
        /// </summary>
        /// <param name="type"></param>
        /// <param name="nomduperso"></param>
        public Relation(string type, string nomduperso)
        {
            Type = type;
            NomPersoNonRec = nomduperso.ToUpper();
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

        //Protocole d'égalité
        /// <summary>
        /// Permet de vérifier si relation et obj sont égaaux
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj, null))
            {
                return false;
            }

            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            return this.Equals(obj as Relation);
        }

        /// <summary>
        /// Permet de vérifier si les champs Type, NomPersoNonRec, PersoRec relation et obj sont égaux
        /// </summary>
        /// <param name="autre"></param>
        /// <returns></returns>
        public bool Equals(Relation autre)
        {
            return (this.Type == autre.Type && this.NomPersoNonRec==autre.NomPersoNonRec && this.PersoRec==autre.PersoRec);
        }

        /// <summary>
        /// Retourne un hashcode pour utiliser cete classe dans une table de hashage
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int a;
            if(NomPersoNonRec == null)
            {
                a = PersoRec.GetHashCode() % 31;
            }
            else
            {
                a = NomPersoNonRec.GetHashCode() % 31;
            }
            return Type.GetHashCode() % 31 + a ;
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

        /// <summary>
        /// Retourne une relation sous forme de chaine de charactère
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (NomPersoNonRec != null)
                return $"Nom : {NomPersoNonRec} \n\t\tRelation : {Type}";
            else
                return $"Nom  : {PersoRec.Nom} \n\t\t Relation : {Type}";
        }

        
        

    }
}
