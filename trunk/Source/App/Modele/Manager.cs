using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modele
{
    public class Manager
    {
        public SortedSet<Serie> Series { get; }
        // Format : string = nom, SortedSet = personnages appartenant au groupe
        public IDictionary<string, SortedSet<Personnage>> Groupes { get; }
        public IEnumerable<Personnage> Personnages => Series.SelectMany(serie => serie.Personnages).Distinct();

        public Manager()
        {
            Series = new SortedSet< Serie >(); 
            Groupes = new SortedList<string, SortedSet<Personnage>>();
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

            return Series.Add(serie);
        }

        /// <summary>
        /// Supprime une série. Cette méthode est appelée si une série n'a plus de personnages.
        /// </summary>
        /// <param name="serie">La série à supprimer</param>
        private void SupprimerSerie(Serie serie)
        {

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
            foreach (KeyValuePair<string, SortedSet<Personnage>> groupe in Groupes) {
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
            Groupes.Add(nom, new SortedSet<Personnage>());
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

        /// <summary>
        /// Permet de rechercher un personnage parmis tous les personnages de l'application
        /// En saisissant son nom et sa série
        /// </summary>
        /// <param name="nom">nom du personnage à rechercher</param>
        /// <param name="serie">série du personnage à rechercher</param>
        /// <param name="personnage">Contient le personnage trouvé</param>
        /// <returns>true si le perso est trouvé / fals s'il n'est pas trouvé</returns>
        public bool RechercherUnPersonnage(string nom, string serie, out Personnage personnage)
        {
            Dictionary<string, Personnage> tousLesPersos = Personnages.ToDictionary(p => p.Nom + p.SerieDuPerso);

            return tousLesPersos.TryGetValue(nom+serie, out personnage);
        }

        /// <summary>
        /// Recherhce une série parmis les séries de l'application
        /// </summary>
        /// <param name="nom">nom de la série recherchée</param>
        /// <param name="serie"></param>
        /// <returns>true si la série est trouvée / false si la série n'est pas trouvée</returns>
        public bool RechercherUneSerie(string nom, out Serie serie)
        {
            return Series.TryGetValue(new Serie(nom), out serie);
        }


    }
}
