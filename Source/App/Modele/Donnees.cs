using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public class Donnees
    {
        public HashSet<Serie> Series { get; } // Un HashSet n'est Pas utilisable car on doit pouvoir récupéré les séries
        // Format : string = nom, HashSet = personnages appartenant au groupe
        public IDictionary<string, HashSet<Personnage>> Groupes { get; }

        public Donnees()
        {
            Series = new HashSet< Serie >(); 
            Groupes = new Dictionary<string, HashSet<Personnage>>();
        }

        /// <summary>
        /// Ajoute une nouvelle série de jeux vidéo.
        /// </summary>
        /// <param name="nom">Le nom de la nouvelle série.</param>
        /// <param name="serie">La série nouvellement créée.</param>
        /// <returns>true si la série est ajoutée, false si la série existe déjà.</returns>
        public bool AjouterSerie(string nom, out Serie serie)
        {
            // On instancie une nouvelle série.
            serie = new Serie(nom);

            // On fait un test pour savoir si la série existe déjà.
            // Si c'est le cas, on lance une exception.
            if (Series.Contains(serie))
            {
                return false;
            }

            // La série n'existe pas : on peut l'ajouter.
            Series.Add(serie);
            return true;
        }

        /// <summary>
        /// Supprime une série. Cette méthode est appelée si une série n'a plus de personnages.
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

            // On peut supprimer la série
            Series.Remove(serie);
        }

        /// <summary>
        /// Enregistre un nouveau personnage.
        /// </summary>
        /// <param name="nomPerso">Le nom du nouveau personnage.</param>
        /// <param name="nomSerie">Le nom de la série du nouveau personnage.</param>
        /// <param name="nouveauPerso">Le personnage nouvellement créé.</param>
        /// <exception cref="ArgumentException">Levée si la série n'existe pas.</exception>
        /// <returns>true si le personnage est enregistré, false s'il existe déjà (utilise la valeur de retour de Serie.AjouterUnPersonnage)</returns>
        public bool EnregistrerPersonnage(string nomPerso, string nomSerie, out Personnage nouveauPerso)
        {
            if (Series.TryGetValue(new Serie(nomSerie), out Serie serie))
                // Si la série existe
                return serie.AjouterUnPersonnage(nomPerso, out nouveauPerso);
            else
            {
                // On lève une exception si elle n'existe pas
                nouveauPerso = null;
                throw new ArgumentException($"La série \"{nomSerie}\" n'existe pas.");
            }
        }

        /// <summary>
        /// Supprime un personnage d'une série et de tous les groupes dans lesquels il pourrait se trouver.
        /// Transforme aussi les relations ayant une référence à ce personnage en une relation avec personnage non enregistré.
        /// S'il s'agit du dernier personnage d'une série, supprime la série.
        /// </summary>
        /// <param name="perso">Le personnage à supprimer.</param>
        public void SupprimerPersonnage(Personnage perso)
		{
            // Obtention de la série
            Series.TryGetValue(new Serie(perso.SerieDuPerso), out Serie serie);

            // Suppression du personnage de tous les groupes
            foreach (KeyValuePair<string, HashSet<Personnage>> groupe in Groupes) {
                groupe.Value.Remove(perso);
			}

            // Transformation des relations des autres personnages
            foreach (Personnage personnage in perso.ARelationAvec) // On parcours les personnages ayant une relation avec le personnage à supprimer
            {
                // TODO
            }

            serie.SupprimerUnPersonnage(perso);
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
