using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Modele
{
    [DataContract(Name = "relation")]
    public class Relation : IEquatable<Relation>
    {
        // Champs
        [DataMember(EmitDefaultValue = false, Name = "type")]
        public string Type { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "persoNonRec")]
        public string NomPersoNonRec { get; private set; }

        [DataMember(EmitDefaultValue = false, Name = "persoRec")]
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
            NomPersoNonRec = nomduperso;
            PersoRec = null;
        }

        /// <summary>
        /// Constructeur
        /// créer une relation avec un personnage enregistré
        /// </summary>
        /// <param name="type">Le type de relation avec le personnage</param>
        /// <param name="persoDeLaRelation">Le personnage inscrit sur la relation (celui qui apparaîtra sur la fiche)</param>
        public Relation(string type, Personnage persoDeLaRelation)
        {
            Type = type;
            PersoRec = persoDeLaRelation;
        }

        //Protocole d'égalité
        /// <summary>
        /// Permet de vérifier si relation et obj sont égaaux
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Relation))
			{
                return false;
			}
            return Equals((Relation)obj);
        }

        /// <summary>
        /// Permet de vérifier si les champs Type, NomPersoNonRec, PersoRec relation et obj sont égaux
        /// </summary>
        /// <param name="autre"></param>
        /// <returns></returns>
        public bool Equals(Relation autre)
        {
            return (this.NomPersoNonRec==autre.NomPersoNonRec && this.PersoRec==autre.PersoRec);
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
        public void ModifierRelation (string nom)
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
                return $"{NomPersoNonRec} ({Type})";
            else
                return $"{PersoRec.Nom} ({Type})";
        }

        
        

    }
}
