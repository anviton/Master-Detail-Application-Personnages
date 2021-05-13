/*
 * NOTES
 * Deux constructeurs : en vrai, on en supprimera un des deux
 * en fonction de celui qui est concrètement utilisé
 */
using System;
using System.Collections.Generic;

namespace Modele
{
    public class ThemeMusical
    {
        private HashSet<Titre> titres;
        // Champs
        public bool Leitmotiv { get; set; }
        public ISet<Titre> Titres { get; }

        // Méthodes
        public ThemeMusical(bool leitmotiv)
        {
            Leitmotiv = leitmotiv;
            Titres = new HashSet<Titre>();
        }

        /// <summary>
        /// Ajoute un titre au thème.
        /// Cette méthode ne peut être utilisée que si Leitmotiv est true.
        /// </summary>
        /// <param name="nom">Le nom du titre</param>
        /// <returns>true si le titre a été ajouté, false sinon</returns>
        public bool AjouterTitre(string nom)
		{
            if (Leitmotiv)
			{
                return Titres.Add(new Titre(nom));
			}
            return false; // N'est pas censé arriver
		}

        /// <summary>
        /// Ajoute un titre au thème.
        /// Cette méthode ne peut être utilisée que si Leitmotiv est true.
        /// </summary>
        /// <param name="nom">Le nom du titre</param>
        /// <param name="lien">Un lien internet pour écouter le titre</param>
        /// <returns>true si le titre a été ajouté, false sinon</returns>
        public bool AjouterTitre(string nom, string lien)
		{
            if (Leitmotiv)
			{
                return Titres.Add(new Titre(nom, lien));
			}
            return false; // N'est pas censé arriver
		}

        /// <summary>
        /// Supprime un titre.
        /// </summary>
        /// <param name="titre">Le titre à supprimer</param>
        /// <returns>true si le titre a été supprimé, false s'il n'existait pas.</returns>
        public bool SupprimerTitre(Titre titre)
		{
            return Titres.Remove(titre);
		}
    }
}