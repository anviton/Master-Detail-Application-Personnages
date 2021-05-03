using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Personnage : Nommable
    {
        // Champs
        public IList<string> Citations { get; set; }
        public string Image { get; set; }
        public IList<JeuVideo> JeuxVideo { get; set; }
        public ThemeMusical Theme { get; set; }
        public IList<Relation> Relations { get; private set; }

        // Méthodes
        public Personnage(string nom) : base(nom)
        {
            Relations = new List<Relation>();
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
        /// Permet d'avoir les Relations du personnage dans une chaine de caractères
        /// </summary>
        /// <returns>Retourne toutes les Relations du personnage sous forme de chaine de caractères</returns>
        public string AfficherLesRelations()
        {
            string lesRelations = $"Les Relations de {nom} :";
            if (Relations.Count == 0)
                return lesRelations + "Aucune";

            else
                for (int i = 0; i< Relations.Count ; i++) 
                {
                    if(Relations[i].NomPersoNonRec == null)
                    {
                        lesRelations = lesRelations + $"\n {Relations[i].PersoRec.nom} : {Relations[i].Type}";
                    }
                    else
                        lesRelations = lesRelations + $"\n {Relations[i].NomPersoNonRec} : {Relations[i].Type}";
                }
                return lesRelations;
        }
    }
}
