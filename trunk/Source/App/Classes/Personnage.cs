using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Personnage : Nommable
    {
        // Champs
        public List<string> Citations { get; set; }
        public string Image { get; set; }
        public List<JeuVideo> JeuxVideo { get; set; }
        public ThemeMusical Theme { get; set; }
        public List<Relation> relations;

        // Méthodes
        public Personnage(string nom) : base(nom)
        {
            relations = new List<Relation>();
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
        /// Permet d'avoir les relations du personnage dans une chaine de caractères
        /// </summary>
        /// <returns>Retourne toutes les relations du personnage sous forme de chaine de caractères</returns>
        public string AfficherLesRelations()
        {
            string lesRelations = $"Les Relations de {nom} :";
            if (relations.Count == 0)
                return lesRelations + "Aucune";

            else
                for (int i = 0; i< relations.Count ; i++) 
                {
                    if(relations[i].NomPersoNonRec == null)
                    {
                        lesRelations = lesRelations + $"\n {relations[i].PersoRec.nom} : {relations[i].Type}";
                    }
                    else
                        lesRelations = lesRelations + $"\n {relations[i].NomPersoNonRec} : {relations[i].Type}";
                }
                return lesRelations;
        }

        public int ChercherUneRelation(string nomPerso, string type)
        {
            int index = relations.IndexOf(new Relation(type, nomPerso));
            return index;
        }
    }
}
