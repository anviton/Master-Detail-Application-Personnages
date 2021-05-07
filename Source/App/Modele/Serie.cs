using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public class Serie : Nommable
    {
        //Propriétés
        public HashSet<Personnage> Personnages { get; set; }
        public Serie(string nom) : base(nom)
        {
            Personnages = new HashSet<Personnage>();
        }

        //Méthodes

        /// <summary>
        /// Ajoute un personnage à la série
        /// </summary>
        /// <param name="nom">Le nom du personnage a ajouter</param>
        /// <exception cref="ArgumentException">Levée si le personnage est déjà enregistré dans la série.</exception>
        /// <returns>Le personnage créé.</returns>
        internal Personnage AjouterUnPersonnage(string nom)
        {
            // On instancie le personnage
            Personnage personnage = new Personnage(nom, this.Nom);

            // On fait un test pour savoir si le personnage est déjà enregistré dans cette série.
            // Si c'est le cas, on lève une exception.
            if (Personnages.Contains(personnage))
			{
                throw new ArgumentException($"Le personnage \"{nom}\" est déjà enregistré dans la série \"{this.Nom}\".");
			}

            // L'exception n'a pas été levée : on peut l'ajouter à la série.
            Personnages.Add(personnage);
            return personnage;
        }

        internal void SupprimerUnPersonnage(Personnage personnage)
		{
            // On fait un test pour savoir si le personnage n'est pas dans la série.
            // Si c'est le cas, on lève une exception.
            if (! Personnages.Contains(personnage))
			{
                throw new ArgumentException($"Le personnage \"{personnage.Nom}\" n'est pas dans la série.");
			}

            // L'exception n'a pas été levée : on peut supprimer le personnage de la série.
            Personnages.Remove(personnage);
		}

        public override string ToString()
        {
            return Nom;
        }
    }
}
