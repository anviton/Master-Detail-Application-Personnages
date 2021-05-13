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
        private void SupprimerSerie(Serie serie)
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
        /// <param name="serie">La série du nouveau personnage.</param>
        /// <param name="nouveauPerso">Le personnage nouvellement créé.</param>
        /// <returns>true si le personnage est enregistré, false s'il existe déjà (utilise la valeur de retour de Serie.AjouterUnPersonnage)</returns>
        public bool EnregistrerPersonnage(string nomPerso, Serie serie, out Personnage nouveauPerso)
        {
            return serie.AjouterUnPersonnage(nomPerso, out nouveauPerso);
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
            foreach (Relation relation in perso.EstMentionneDans) // On parcours les personnages ayant une relation avec le personnage à supprimer
            {
                relation.ModifierRelation(perso.Nom);
            }

            serie.SupprimerUnPersonnage(perso);

            if (serie.Personnages.Count == 0)
			{
                SupprimerSerie(serie);
			}
		}

        /// <summary>
        /// Permet de créer un nouveau groupe de personnages (série ou groupe).
        /// </summary>
        /// <param name="nom">Le nom du nouveau groupe.</param>
        /// <returns>true si le groupe a été ajouté, false s'il existait déjà.</returns>
        public bool AjouterGroupe(string nom)
        {
            // On fait un test pour savoir si le regroupement existe.
            // S'il existe, on renvoie false.
            if (Groupes.ContainsKey(nom))
            {
                return false;
            }

            // Le groupe n'existe pas : on l'ajoute et renvoie true.
            Groupes.Add(nom, new HashSet<Personnage>());
            return true;
        }

        /// <summary>
        /// Permet de supprimer un groupe de personnages.
        /// </summary>
        /// <param name="nom">Le nom du groupe à supprimer.</param>
        public void SupprimerGroupe(string nom)
        {
            Groupes.Remove(nom);
        }

        /// <summary>
        /// Permet d'ajouter un personnage à un groupe.
        /// </summary>
        /// <param name="nomGroupe">Le nom du groupe</param>
        /// <param name="personnage">Le personnage à ajouter</param>
        /// <returns>true si le personnage a été ajouté au groupe, false s'il existait déjà.</returns>
        public bool AjouterPersoAGroupe(string nomGroupe, Personnage personnage)
		{
            return Groupes[nomGroupe].Add(personnage);
		}

        /// <summary>
        /// Retire un personnage d'un groupe.
        /// </summary>
        /// <param name="nomGroupe">Le nom du groupe</param>
        /// <param name="personnage">Le personnage à retirer</param>
        public void RetirerPersoDeGroupe(string nomGroupe, Personnage personnage)
		{
            Groupes[nomGroupe].Remove(personnage);
		}
    }
}
