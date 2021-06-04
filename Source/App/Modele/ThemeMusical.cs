using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace Modele
{
    [DataContract]
    public class ThemeMusical
    {
        // Champs
        [DataMember]
        private bool leitmotiv { get; set; }

        public bool Leitmotiv
        {
            get { return leitmotiv; }
            set
            {
                if (leitmotiv != value)
                {
                    titres.Clear();
                    if (value == false)
                        titres.Add(new Titre(""));
                    leitmotiv = value;
                }
            }
        }

        [DataMember]
        private ObservableCollection<Titre> titres { get; set; }
        public ObservableCollection<Titre> Titres
        {
            get
            {
                return new ObservableCollection<Titre>(titres.Select(titre => titre).Where(n => n.Nom != ""));
            }
        }

        // Méthodes
        public ThemeMusical(bool leitmotiv)
        {
            Leitmotiv = leitmotiv;
            titres = new ObservableCollection<Titre>();
            if (!leitmotiv)
            {
                titres.Add(new Titre(""));
            }
        }

        public ThemeMusical() : this(false) { }

        /// <summary>
        /// Ajoute un titre au thème.
        /// </summary>
        /// <param name="nom">Le nom du titre</param>
        /// <returns>true si le titre a été ajouté, false sinon</returns>
        public void AjouterTitre(string nom)
		{
            Titre titre = new Titre(nom);
            if (Leitmotiv)
            {
                if (!titres.Contains(titre))
                {
                    titres.Add(titre);
                }
            } else
            {
                titres[0] = titre;
            }
		}

        /// <summary>
        /// Ajoute un titre au thème.
        /// 
        /// </summary>
        /// <param name="nom">Le nom du titre</param>
        /// <param name="lien">Un lien internet pour écouter le titre</param>
        /// <returns>true si le titre a été ajouté, false sinon</returns>
        public void AjouterTitre(string nom, string lien)
		{
            Titre titre = new Titre(nom, lien);
            if (Leitmotiv) { 
                if (!titres.Contains(titre))
                {
                    titres.Add(new Titre(nom, lien));
                }
            } else
            {
                titres[0] = titre;
            }
        }

        /// <summary>
        /// Supprime un titre.
        /// </summary>
        /// <param name="titre">Le titre à supprimer</param>
        /// <returns>true si le titre a été supprimé, false s'il n'existait pas.</returns>
        public void SupprimerTitre(Titre titre)
		{
            if (Leitmotiv)
            {
                Titres.Remove(titre);
            }
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