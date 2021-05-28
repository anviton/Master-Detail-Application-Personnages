using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Modele
{
    public class Manager : INotifyPropertyChanged
    {
        public ObservableCollection<Serie> Series { get; }
        // Format : string = nom, SortedSet = personnages appartenant au groupe
        public IDictionary<string, ObservableCollection<Personnage>> Groupes { get; }
        public ICollection<string> NomsGroupes { get { return new List<string>(Groupes.Keys); } }

        public IList<Personnage> Personnages
        {
            get
            {
                
                return new ObservableCollection<Personnage>(Series.SelectMany(serie => serie.Personnages).OrderBy(n => n.Nom));
            }
            set
            {
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Personnages)));
                //personnages = new ObservableCollection<Personnage>(Series.SelectMany(serie => serie.Personnages).OrderBy(n => n.Nom));
            }
        }

        public ObservableCollection<Personnage> personnages;
        public IList<Personnage> ListeDePersonnagesActive { get; set; }
        public Personnage PersonnageSelectionne {
            get => personnageSelectionne;
            set 
            {
                if(personnageSelectionne != value)
                {
                    personnageSelectionne = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PersonnageSelectionne)));
                }
            }
        }
        private Personnage personnageSelectionne;

        //serieSelectionnee
        public Serie SerieSelectionnee
        {
            get => serieSelectionnee;
            set
            {
                if (serieSelectionnee != value)
                {
                    serieSelectionnee = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SerieSelectionnee)));
                }
            }
        }
        private Serie serieSelectionnee;

        public string GroupeSelectionne
        {
            get => groupeSelectionne;
            set
            {
                if (groupeSelectionne != value)
                {
                    groupeSelectionne = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GroupeSelectionne)));
                }
            }
        }
        private string groupeSelectionne;

        public Manager()
        {
            Series = new ObservableCollection<Serie>(); 
            Groupes = new SortedList<string, ObservableCollection<Personnage>>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
            if (Series.Contains(serie))
                return false;
            else
            {
                Series.Add(serie);
                return true;
            }
                    
        }

        /// <summary>
        /// Supprime une série. Cette méthode est appelée si une série n'a plus de personnages.
        /// </summary>
        /// <param name="serie">La série à supprimer</param>
        private void SupprimerSerie(Serie serie)
        {
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
            
                bool ajout =serie.AjouterUnPersonnage(nomPerso, out nouveauPerso);
            if(ajout == true)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Personnages)));
                return ajout;
            }
            else
            {
                return ajout;
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
            RechercherUneSerie(perso.SerieDuPerso, out Serie serie);

            // Suppression du personnage de tous les groupes
            foreach (KeyValuePair<string, ObservableCollection<Personnage>> groupe in Groupes) {
                groupe.Value.Remove(perso);
			}

            // Transformation des relations des autres personnages
            foreach (Relation relation in perso.EstMentionneDans) // On parcours les personnages ayant une relation avec le personnage à supprimer
            {
                relation.ModifierRelation(perso.Nom);
            }

            serie.SupprimerUnPersonnage(perso);
            //Personnages.Remove(perso);

            if (serie.Personnages.Count == 0)
			{
                SupprimerSerie(serie);
			}
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Personnages)));
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ListeDePersonnagesActive)));
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
            Groupes.Add(nom, new ObservableCollection<Personnage>());
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NomsGroupes)));
            return true;
        }

        /// <summary>
        /// Permet de supprimer un groupe de personnages.
        /// </summary>
        /// <param name="nom">Le nom du groupe à supprimer.</param>
        public void SupprimerGroupe(string nom)
        {
            Groupes.Remove(nom);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NomsGroupes)));
        }

        /// <summary>
        /// Permet d'ajouter un personnage à un groupe.
        /// </summary>
        /// <param name="nomGroupe">Le nom du groupe</param>
        /// <param name="personnage">Le personnage à ajouter</param>
        /// <returns>true si le personnage a été ajouté au groupe, false s'il existait déjà.</returns>
        public bool AjouterPersoAGroupe(string nomGroupe, Personnage personnage)
		{
            if (!Groupes[nomGroupe].Contains(personnage))
            {
                Groupes[nomGroupe].Add(personnage);
                return true;
            }
            else
            {
                return false;
            }
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
            if(Series.Contains(new Serie(nom)))
            {
                serie = Series[Series.IndexOf(new Serie(nom))];
                return true;
            }
            else
            {
                serie = null;
                return false;
            }
        }
        
        /// <summary>
        /// Permet de lire un personnage dans un fichier xml
        /// </summary>
        /// <param name="chemin">chemin du fichier dans lequel le personnage est "stocké"</param>
        public void LireUnPersonnageEnXml(string chemin)
        {
            XDocument personnageFichier = XDocument.Load(chemin);
            var persos = personnageFichier.Descendants("personnage")
                          .Select(eltPersonnage => new Personnage(eltPersonnage.Attribute("nom").Value, eltPersonnage.Element("serieDuPerso").Value)
                          {
                              Description = eltPersonnage.Element("description").Value,
                              Image = eltPersonnage.Element("image").Value
                          });
            foreach (Personnage perso in persos)
            {
                var citationsElt = personnageFichier.Descendants("personnage")
                                             .Single(elt => elt.Attribute("nom").Value == perso.Nom)
                                             .Element("citations");

                //perso.AjouterCitation(citationsElt.Value.Split());

                bool serieExiste = RechercherUneSerie(perso.SerieDuPerso, out Serie serie);
                if (serieExiste)
                {
                    serie.AjouterUnPersonnage(perso);
                }
                else
                {
                    AjouterSerie(perso.SerieDuPerso, out serie);
                    serie.AjouterUnPersonnage(perso);
                }
            }
        }

        /// <summary>
        /// Permet d'exporter un personnage dans un fichier xml
        /// </summary>
        /// <param name="perso"></param>
        public void EcrireUnPersonnageEnXml(Personnage perso)
        {
            XDocument personnageFichier = new XDocument();

            var personnageE = Personnages.Where(p => p.Nom == perso.Nom).Select(personnage => new XElement("personnage",
                new XAttribute("nom", perso.Nom),
                new XElement("serieDuPerso", perso.SerieDuPerso),
                new XElement("description", perso.Description),
                new XElement("image", perso.Image),
                new XElement("citations", perso.Citations.Count() > 0 ? personnage.Citations.Aggregate((stringCitation, nextCitation) => $"{stringCitation} {nextCitation}") : "")
                ));

            personnageFichier.Add(new XElement(perso.Nom, personnageE));

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (TextWriter tw = File.CreateText($"{perso.Nom}.xml"))
            using (XmlWriter writer = XmlWriter.Create(tw, settings))
            {
                personnageFichier.Save(writer);
            }
        }

    }
}
