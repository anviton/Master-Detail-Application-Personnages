using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Modele
{
    public class Personnage : Nommable, IEquatable<Personnage>, IComparable<Personnage>
    {
        public ISet<string> Citations { get; }
        public static Random indexRandomizer = new Random();
        public string CitationAleatoire
		{
            get
			{
                if (Citations.Count > 0) {
                    int index = indexRandomizer.Next(Citations.Count);
                    string[] arr_citations = new string[Citations.Count];
                    Citations.CopyTo(arr_citations, 0);
                    return arr_citations[index];
                } else return "";
			}
		}
        private string image;
        public string Image
		{
            get
			{
                if (image == null) return "/Bibliothèques_Images;Component/Images_Personnages/mario.jpeg"; // On renvoie l'image par défaut
                else return image;
            }
            set { image = value; }
   		}
        public ISet<JeuVideo> JeuxVideo { get; }
        public ThemeMusical Theme { get; set; }
        public HashSet<Relation> Relations { get; }
        public string SerieDuPerso { get; }
        public ISet<Relation> EstMentionneDans { get; }
        public string Description { get; set; }

        public EventHandler<NotificationRelationEvent> NotificationRelation;
        protected virtual void OnNotificationRelation(NotificationRelationEvent args)
            => NotificationRelation?.Invoke(this, args);

        // Méthodes
        public Personnage(string nom, string serie) : base(nom)
        {
            SerieDuPerso = serie;
            Citations = new HashSet<string>();
            JeuxVideo = new HashSet<JeuVideo>();
            Relations = new HashSet<Relation>();
            EstMentionneDans = new HashSet<Relation>();
            NotificationRelation += AjouterAEstMentionneDans;
        }

        //Protocole d'égalité
        public override bool Equals(object obj)
        {
            if (!(obj is Personnage))
            {
                return false;
            }

            return Equals((Personnage)obj);
        }

        public bool Equals(Personnage other)
        {
            return (base.Equals(other) && this.SerieDuPerso.Equals(other.SerieDuPerso));
        }

        public int CompareTo(Personnage other)
        {
            int resultat = (this as Nommable).CompareTo((other as Nommable)); // Cette syntaxe pour appeler le CompareTo de Nommable
            if (resultat != 0) return resultat;

            resultat = this.SerieDuPerso.CompareTo(other.SerieDuPerso);
            if (resultat != 0) return resultat;

            return 0;
        }

        public override int CompareTo(object obj)
        {
            if (!(obj is Personnage))
            {
                throw new ArgumentException("Argument is not a Personnage", "obj");
            }
            return this.CompareTo((obj as Personnage));
        }

        public static bool operator<(Personnage left, Personnage right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator<=(Personnage left, Personnage right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator>(Personnage left, Personnage right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator>=(Personnage left, Personnage right)
        {
            return left.CompareTo(right) >= 0;
        }

        /// <summary>
        /// Retourne un hashcode pour utiliser cete classe dans une table de hashage
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {

            return base.GetHashCode() + SerieDuPerso.GetHashCode();
        }

        /// <summary>
        /// Ajoute une citation du personnage.
        /// </summary>
        /// <param name="citation">La citation à ajouter.</param>
        /// <returns>true si la citation a été ajoutée, false sinon.</returns>
        public bool AjouterCitation(string citation)
		{
            return Citations.Add(citation);
		}

        /// <summary>
        /// Supprime une citation du personnage.
        /// </summary>
        /// <param name="citation">La citation à supprimer.</param>
        public void SupprimerCitation(string citation)
		{
            Citations.Remove(citation);
		}

        /// <summary>
        /// Ajouter une relation avec un personnage enregistré
        /// </summary>
        /// <param name="type">Le type de la relation exemple : "ennemi, "équipier"</param>
        /// <param name="perso">Personnage avec lequel la relation est réalisée</param>
        /// <returns>true si la relation a été ajoutée, false si elle existait déjà</returns>
        public bool AjouterRelation(string type, Personnage perso)
        {
            Relation relation = new Relation(type, perso);
            if (Relations.Add(relation))
			{
                OnNotificationRelation(new NotificationRelationEvent(perso, relation));
                return true;
			}
            return false;
        }

        /// <summary>
        /// Ajouter une relation avec un personnage non enregistré
        /// </summary>
        /// <param name="type">Le type de la relation exemple : "ennemi, "équipier"</param>
        /// <param name="nomPerso">Nom du Personnage avec lequel la relation est réalisée</param>
        /// <returns>true si la relation a été ajoutée, false si elle existait déjà</returns>
        public bool AjouterRelation(string type, string nomPerso)
        {
            return Relations.Add(new Relation(type, nomPerso));
        }

        /// <summary>
        /// Permet de supprimer une relatiuon de la liste des relations
        /// </summary>
        /// <param name="relation">relation à supprimer</param>
       public void SupprimerUneRelation(Relation relation)
        {
            if (relation.PersoRec != null)
			{
                relation.PersoRec.EstMentionneDans.Remove(relation);
			}
            Relations.Remove(relation);
        }

        /// <summary>
        /// Ajoute à la liste de relation EetMentionneDans la relation dans laquel le personnage apparait
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void AjouterAEstMentionneDans(Object sender, NotificationRelationEvent args)
        {
            args.LePersonnage.EstMentionneDans.Add(args.LaRelation);
        }

        /// <summary>
        /// Permet d'ajouter un jeu à la liste des jeux vidéo du perso
        /// </summary>
        /// <param name="nom">Le nom du jeu à ajouter</param>
        /// <returns>true si le jeu a été ajouté, false s'il y était déjà</returns>
        public bool AjouterUnJeu(string nom)
        {
            return JeuxVideo.Add(new JeuVideo(nom));
        }

        /// <summary>
        /// Permet d'ajouter un jeu à la liste des jeux vidéo du perso
        /// </summary>
        /// <param name="nom">Le nom du jeu à ajouter</param>
        /// <param name="annee">L'année de sortie du jeu</param>
        /// <returns>true si le jeu a pu être ajouté, false sinon</returns>
        public bool AjouterUnJeu(string nom, int annee)
		{
            return JeuxVideo.Add(new JeuVideo(nom, annee));
		}

        /// <summary>
        /// Permet de supprimer un jeu 
        /// </summary>
        /// <param name="jeu"></param>
        public void SupprimerUnJeu(JeuVideo jeu)
        {
            JeuxVideo.Remove(jeu);
        }

        /// <summary>
        /// Retourne le Personnage sous forme de string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Nom}";
        }



    }
}
