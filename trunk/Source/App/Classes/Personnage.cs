using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Personnage : Nommable, IEquatable<Personnage>
    {
        // Champs

        //Atributs
        public HashSet<Relation> relations;
        //Propriétés
        public IList<string> Citations { get; set; }
        public string Image { get; set; }
        public IList<JeuVideo> JeuxVideo { get; set; }
        public ThemeMusical Theme { get; set; }

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
        public Personnage(string nom) : base(nom)
        {
            relations = new HashSet<Relation>();
            // INITIALISER LES LISTES ?
        }

        /// <summary>
        /// Ajouter une relation avec un personnage enregistré
        /// </summary>
        /// <param name="type">Le type de la relation exemple : "ennemi, "équipier"</param>
        /// <param name="perso">Personnage avec lequel la relation est réalisée</param>
        public void AjouterRelation(string type, Personnage perso)
        {
            relations.Add(new Relation(type, perso));
        }

        /// <summary>
        /// Ajouter une relation avec un personnage non enregistré
        /// </summary>
        /// <param name="type">Le type de la relation exemple : "ennemi, "équipier"</param>
        /// <param name="nomPerso">Nome du Personnage avec lequel la relation est réalisée</param>
        public void AjouterRelation(string type, string nomPerso)
        {
            relations.Add(new Relation(type, nomPerso));
        }


        /// <summary>
        /// Permet d'avoir les Relations du personnage dans une chaine de caractères
        /// </summary>
        /// <returns>Retourne toutes les Relations du personnage sous forme de chaine de caractères</returns>
        public string AfficherLesRelations()
        {
            string lesRelations = $"Les Relations de {Nom} :";
            if (relations.Count == 0)
                return lesRelations + "Aucune";

            else
                foreach (Relation relation in relations) 
                {
                    if(relation.NomPersoNonRec == null)
                    {
                        lesRelations = lesRelations + $"\n {relation.PersoRec.Nom} : {relation.Type}";
                    }
                    else
                        lesRelations = lesRelations + $"\n {relation.NomPersoNonRec} : {relation.Type}";
                }
            
                return lesRelations;
        }

        /// <summary>
        /// Permet de supprimer une relatiuon de la liste des relations
        /// </summary>
        /// <param name="relation">relation à supprimer</param>
       public void SupprimerUneRelation(Relation relation)
        {
            relations.Remove(relation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="relation"></param>
        public void ModifierUneRelation(Relation relation)
        {
            
        }

    }
}
