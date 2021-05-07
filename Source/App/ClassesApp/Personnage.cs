using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Personnage : Nommable, IEquatable<Personnage>
    {
        // Champs

        //Atributs
        
        //Propriétés
        public IList<string> Citations { get; set; }
        public string Image { get; set; }
        public HashSet<JeuVideo> JeuxVideo { get; }
        public ThemeMusical Theme { get; set; }
        public HashSet<Relation> Relations { get; }
        //public Serie SerieDuPerso;

        // Méthodes
        public Personnage(string nom/*, Serie serie*/) : base(nom)
        {
            Relations = new HashSet<Relation>();
            JeuxVideo = new HashSet<JeuVideo>();
            //SerieDuPerso = serie;
        }

        //Protocole d'égalité
        public override bool Equals(object obj)
        {
            if (!(obj is Personnage))
            {
                return false;
            }

            return Equals((Personnage)obj);
        }

        public bool Equals(Personnage other)
        {
            return (base.Equals(other) /*&& this.SerieDuPerso.Equals(other.SerieDuPerso)*/);
        }

        /// <summary>
        /// Retourne un hashcode pour utiliser cete classe dans une table de hashage
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {

            return Nom.GetHashCode() % 31;
        }

        /// <summary>
        /// Ajouter une relation avec un personnage enregistré
        /// </summary>
        /// <param name="type">Le type de la relation exemple : "ennemi, "équipier"</param>
        /// <param name="perso">Personnage avec lequel la relation est réalisée</param>
        public void AjouterRelation(string type, Personnage perso)
        {
            Relations.Add(new Relation(type, perso));
        }

        /// <summary>
        /// Ajouter une relation avec un personnage non enregistré
        /// </summary>
        /// <param name="type">Le type de la relation exemple : "ennemi, "équipier"</param>
        /// <param name="nomPerso">Nome du Personnage avec lequel la relation est réalisée</param>
        public void AjouterRelation(string type, string nomPerso)
        {
            Relations.Add(new Relation(type, nomPerso));
        }

        /// <summary>
        /// Permet de supprimer une relatiuon de la liste des relations
        /// </summary>
        /// <param name="relation">relation à supprimer</param>
       public void SupprimerUneRelation(Relation relation)
        {
            Relations.Remove(relation);
        }

        /// <summary>
        /// Retourne le Personnage sous forme de string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Nom} {Image}";
        }

    }
}
