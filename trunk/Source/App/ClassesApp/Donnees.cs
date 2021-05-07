using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Donnees
    {
        public List<Serie> Series { get; }
        // Format : string = nom, HashSet = personnages appartenant au groupe
        public IDictionary<string, HashSet<Personnage>> Groupes { get; }

        public Donnees()
        {
            Series = new List<Serie>();
            Groupes = new Dictionary<string, HashSet<Personnage>>();
        }

        /// <summary>
        /// Ajoute une nouvelle série de jeux vidéo.
        /// </summary>
        /// <param name="nom">Le nom de la nouvelle série.</param>
        /// <exception cref="ArgumentException">Levée si la série existe déjà.</exception>
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
        /// Supprime une série et tous ses personnages.
        /// Si un personnage est présent dans des groupes, ils seront supprimés de ces groupes.
        /// </summary>
        /// <param name="serie">La série à supprimer</param>
        /// <exception cref="ArgumentException">Levée si la série n'existe pas.</exception>
        public void SupprimerSerie(Serie serie)
        {
            // On fait un test pour vérifier la non-existance de la série.
            // Si la série n'existe pas, on lève une exception.
            if (!Series.Contains(serie))
            {
                throw new ArgumentException("La série n'existe pas.");
            }

            // Si l'exception n'est pas levée, on peut supprimer des groupes les personnage de la série.

            // On parcours le HashSet de la série correspondante
            foreach (Personnage perso in serie.Personnages)
            {
                // On parcours tous les groupes
                foreach (KeyValuePair<string, HashSet<Personnage>> groupe in Groupes)
                {
                    // On supprime le perso du groupe actuellement parcouru
                    groupe.Value.Remove(perso);
                }
            }

            // On peut supprimer la série
            Series.Remove(serie);
        }

        /// <summary>
        /// Permet de créer un nouveau groupe de personnages (série ou groupe).
        /// </summary>
        /// <param name="nom">Le nom du nouveau groupe.</param>
        /// <exception cref="ArgumentException">Levée si le groupe existe déjà.</exception>
        public void AjouterGroupe(string nom)
        {
            // On fait un test pour savoir si le regroupement existe.
            // S'il existe, on lève une exception.
            if (Groupes.ContainsKey(nom))
            {
                throw new ArgumentException("Le groupe existe déjà.");
            }

            // L'exception n'a pas été levée : on peut ajouter un nouveau regroupement de personnages.
            Groupes.Add(nom, new HashSet<Personnage>());
        }

        /// <summary>
        /// Permet de supprimer un groupe de personnages.
        /// </summary>
        /// <param name="nom">Le nom du groupe à supprimer.</param>
        /// <exception cref="ArgumentException">Levée si le groupe n'existe pas.</exception>
        public void SupprimerGroupe(string nom)
        {
            // On fait un test pour vérifier la non-existance du groupe.
            // Si le groupe n'existe pas, on lève une exception.
            if (! Groupes.ContainsKey(nom))
            {
                throw new ArgumentException("Le groupe n'existe pas.");
            }

            // On peut supprimer le groupe.
            Groupes.Remove(nom);
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
    }
}
