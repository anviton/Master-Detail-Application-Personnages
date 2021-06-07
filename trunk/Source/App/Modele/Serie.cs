using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Modele
{
    [DataContract(Name = "serie")]
    public class Serie : Nommable, INotifyPropertyChanged
    {
        //Propriétés
        [DataMember(Name = "listePersonnages")]
        public ObservableCollection<Personnage> Personnages { get; set; }
        public Personnage PersonnageSelectionne {
            get
            {
                return personnageSelectionne;
            }
            set
            {
                personnageSelectionne = value;
                OnPropertyChanged(nameof(PersonnageSelectionne));
            }
        }
        public static string Couleur => "#FF98CBF7";

        private Personnage personnageSelectionne;
        public Serie(string nom) : base(nom)
        {
            Personnages = new ObservableCollection<Personnage>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string PropertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        //Méthodes

        /// <summary>
        /// Ajoute un personnage à la série
        /// </summary>
        /// <param name="nom">Le nom du personnage a ajouter</param>
        /// <param name="nouveauPerso">Le personnage nouvellement créé.</param>
        /// <returns>true si le personnage a été ajouté, false sinon.</returns>
        internal bool AjouterUnPersonnage(string nom, out Personnage nouveauPerso)
        {
            // On instancie le personnage
            nouveauPerso = new Personnage(nom, this.Nom);

            // L'exception n'a pas été levée : on peut l'ajouter à la série.
            if (!Personnages.Contains(nouveauPerso))
            {
                Personnages.Add(nouveauPerso);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Permet d'ajouter un peronnage importé à sa serie
        /// </summary>
        /// <param name="perosnnageImporte">le personnage importé</param>
        /// <returns></returns>
        internal bool AjouterUnPersonnage(Personnage perosnnageImporte)
        {
            if (!Personnages.Contains(perosnnageImporte))
            {
                Personnages.Add(perosnnageImporte);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Supprime un personnage de la série.
        /// </summary>
        /// <param name="personnage">Le personnage à supprimer</param>
        internal void SupprimerUnPersonnage(Personnage personnage)
		{
            Personnages.Remove(personnage);
		}

        public override string ToString()
        {
            return Nom;
        }
    }
}
