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

            return this.Equals(obj as Personnage);
        }

        /// <summary>
        /// Permet de vérifier si les champs Type, NomPersoNonRec, PersoRec relation et obj sont égaux
        /// </summary>
        /// <param name="autre"></param>
        /// <returns></returns>
        public bool Equals(Personnage autre)
        {
            return (this.Nom==autre.Nom);
        }

        /// <summary>
        /// Retourne un hashcode pour utiliser cete classe dans une table de hashage
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {

            return Nom.GetHashCode() % 31;
        }

        // Méthodes
        public Personnage(string nom) : base(nom.ToUpper())
        {
            Relations = new HashSet<Relation>();
            JeuxVideo = new HashSet<JeuVideo>();
            // INITIALISER LES LISTES ?
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
