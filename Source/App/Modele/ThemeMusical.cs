using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace Modele
{
    [DataContract(Name = "themeMusical")]
    public class ThemeMusical : INotifyPropertyChanged
    {
        // Champs
        [DataMember(Name = "isLeitmotiv")]
        private bool leitmotiv;

        public bool Leitmotiv
        {
            get { return leitmotiv; }
            set
            {
                if (leitmotiv != value)
                {
                    Titres.Clear();
                    leitmotiv = value;
                    if (!leitmotiv)
					{
                        Titres.Add(new Titre(""));
					}
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(leitmotiv)));
                }
            }
        }

        
        public ObservableCollection<Titre> Titres { get => titres; }
        [DataMember(Name = "listeTitres")]
        private readonly ObservableCollection<Titre> titres;

		public event PropertyChangedEventHandler PropertyChanged;

        // Méthodes
        public ThemeMusical(bool leitmotiv)
        {
            Leitmotiv = leitmotiv;
            titres = new ObservableCollection<Titre>();
            if (!leitmotiv)
			{
                Titres.Add(new Titre(""));
			}
        }

        public ThemeMusical() : this(false) { }

        /// <summary>
        /// Ajoute un titre au thème.
        /// </summary>
        /// <param name="nom">Le nom du titre</param>
        /// <returns>true si le titre a été ajouté, false sinon</returns>
        public bool AjouterTitre(string nom)
		{
            Titre titre = new Titre(nom);
            if (Leitmotiv)
            {
                if (!Titres.Contains(titre))
                {
                    Titres.Add(titre);
                    return true;
                }
                else return false;
            } else
            {
                Titres[0] = titre;
                return true;
            }
		}

        /// <summary>
        /// Ajoute un titre au thème.
        /// </summary>
        /// <param name="nom">Le nom du titre</param>
        /// <param name="lien">Un lien internet pour écouter le titre</param>
        /// <returns>true si le titre a été ajouté, false sinon</returns>
        public bool AjouterTitre(string nom, string lien)
		{
            Titre titre = new Titre(nom, lien);
            if (Leitmotiv) { 
                if (!Titres.Contains(titre))
                {
                    Titres.Add(new Titre(nom, lien));
                    return true;
                }
                else return false;
            } else
            {
                Titres[0] = titre;
                return true;
            }
        }

        /// <summary>
        /// Supprime un titre.
        /// </summary>
        /// <param name="titre">Le titre à supprimer</param>
        /// <returns>true si le titre a été supprimé, false s'il n'existait pas.</returns>
        public bool SupprimerTitre(Titre titre)
		{
            if (Leitmotiv)
            {
                Titres.Remove(titre);
                return true;
            }
            return false;
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