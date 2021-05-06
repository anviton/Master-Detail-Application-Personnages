using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Donnees
    {
        public ISet<Serie> Series { get; }
        public IDictionary<string, HashSet<Personnage>> Groupes { get; }

        public Donnees()
        {
            Series = new HashSet<Serie>();
            Groupes = new Dictionary<string, HashSet<Personnage>>();
        }

        /// <summary>
        /// Permet d'ajouter un personnage à un groupe.
        /// </summary>
        /// <param name="nomGroupe">Le nom du groupe</param>
        /// <param name="personnage">Le personnage à ajouter</param>
        /// <exception cref="ArgumentException">Lancé si le groupe n'existe pas, ou si le personnage est déjà dans le groupe</exception>
        public void AjouterPersoAGroupe(string nomGroupe, Personnage personnage)
		{
            // On teste si nomGroupe n'est pas une clé de Groupes :
            // autrement dit, si le groupe en question n'existe pas
            if (! Groupes.ContainsKey(nomGroupe))
			{
                throw new ArgumentException($"Le groupe \"{nomGroupe}\" n'existe pas.");
			}

            // On teste si le personnage est déjà dans le groupe :
            if (Groupes[nomGroupe].Contains(personnage))
			{
                throw new ArgumentException($"Le personnage \"{personnage.Nom}\" est déjà dans le groupe \"{nomGroupe}\".");
			}

            // Si aucun test n'a lancé d'exception, on peut ajouter le personnage dans le groupe.
            Groupes[nomGroupe].Add(personnage);
		}

        /// <summary>
        /// Retire un personnage d'un groupe.
        /// </summary>
        /// <param name="nomGroupe">Le nom du groupe</param>
        /// <param name="personnage">Le personnage à retirer</param>
        /// <exception cref="ArgumentException">Lancé si le groupe n'existe pas, ou si le personnage n'est pas dans le groupe</exception>
        public void RetirerPersoDeGroupe(string nomGroupe, Personnage personnage)
		{
            // On teste si nomGroupe n'est pas une clé de Groupes :
            // autrement dit, si le groupe en question n'existe pas
            if (! Groupes.ContainsKey(nomGroupe))
			{
                throw new ArgumentException($"Le groupe \"{nomGroupe}\" n'existe pas.");
			}

            // On teste si le personnage n'est pas dans le groupe :
            if (! Groupes[nomGroupe].Contains(personnage))
			{
                throw new ArgumentException($"Le personnage \"{personnage.Nom}\" n'est pas dans le groupe \"{nomGroupe}\".");
            }

            // Si aucun test n'a lancé d'exception, on peut retirer le personnage du groupe.
            Groupes[nomGroupe].Remove(personnage);
		}
        
        /// <summary>
        /// Ajoute une nouvelle série de jeux vidéo.
        /// </summary>
        /// <param name="nom">Le nom de la nouvelle série.</param>
        /// <exception cref="ArgumentException">Lancé si la série existe déjà.</exception>
        public void AjouterSerie(string nom)
		{
            // On instancie une nouvelle série.
            Serie serie = new Serie(nom);

            // On fait un test pour savoir si la série existe déjà.
            // Si c'est le cas, on lance une exception.
            if (Series.Contains(serie))
			{
                throw new ArgumentException($"La série \"{nom}\" existe déjà.");
			}

            // La série n'existe pas : on peut l'ajouter.
            Series.Add(serie);
		}
        
        /// <summary>
        /// Supprime une série de jeux
        /// </summary>
        /// <param name="serie">La série à supprimer</param>
        public void SupprimerSerie(Serie serie)
		{
            throw new NotImplementedException();
            // On fait un test vérifiant la non-existance de serie.
            // Si la série n'existe pas, on lance une exception.
            if (! Series.Contains(serie))
			{
                throw new ArgumentException($"La série \"{serie.Nom}\" n'existe pas.");
			}

            // On vérifie si la série contient des personnages : si c'est le cas, on supprime les personnages.
            if (serie.Personnages.Count == 0)
			{
                foreach (Personnage personnage in serie.Personnages)
                {
                    ;
				}
			}

            // La série existe : on peut la supprimer.
            Series.Remove(serie);
		}
    }
}
