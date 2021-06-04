/*
 * NOTES
 * Deux constructeurs : en vrai, on en supprimera un des deux
 * en fonction de celui qui est concrètement utilisé
 */
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Modele
{
    [DataContract]
    public class ThemeMusical
    {
        // Champs
        [DataMember]
        public bool Leitmotiv { get; set; }
        //[DataMember]
        public ISet<Titre> Titres { get; set; }

        // Méthodes
        public ThemeMusical(bool leitmotiv)
        {
            Leitmotiv = leitmotiv;
            Titres = new HashSet<Titre>();
        }

        /// <summary>
        /// Ajoute un titre au thème.
        /// 
        /// </summary>
        /// <param name="nom">Le nom du titre</param>
        /// <returns>true si le titre a été ajouté, false sinon</returns>
        public bool AjouterTitre(string nom)
		{
            int i = Titres.Count;
            if (!Leitmotiv)
            {
                if (Titres.Count < 1)
                    return Titres.Add(new Titre(nom));
                else
                    return false;
            }
            else
            {
                return Titres.Add(new Titre(nom));
            }
		}

        /// <summary>
        /// Ajoute un titre au thème.
        /// 
        /// </summary>
        /// <param name="nom">Le nom du titre</param>
        /// <param name="lien">Un lien internet pour écouter le titre</param>
        /// <returns>true si le titre a été ajouté, false sinon</returns>
        public bool AjouterTitre(string nom, string lien)
		{
            if (!Leitmotiv)
            {
                if (Titres.Count < 1)
                    return Titres.Add(new Titre(nom, lien));
                else
                    return false;
            }
            else
            {
                return Titres.Add(new Titre(nom, lien));
            }
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

        public override string ToString()
        {
            string t = "";
            foreach( Titre titre in Titres)
            {
                t += $"\n" + titre.ToString();
            }
            return t;
        }
        
    }
}