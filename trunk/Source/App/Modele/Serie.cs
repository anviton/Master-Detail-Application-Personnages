using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public class Serie : Nommable
    {
        //Propriétés
        public IList<Personnage> Personnages { get; set; }
        public Serie(string nom) : base(nom.ToLower())
        {
            Personnages = new List<Personnage>();
            
        }

        //Méthodes

        /// <summary>
        /// Ajoute Un personnage à la série
        /// </summary>
        /// <param name="personnage">personnage a ajouté</param>
        public void AjouterUnPersonnage(Personnage personnage)
        {
            if(!(Personnages.Contains(personnage)))
                Personnages.Add(personnage);
        }

        /// <summary>
        /// Permet de retrouverUnPersonnage
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        public Personnage RechercherUnPersonnage(string nom)
        {
            return Personnages[Personnages.IndexOf(new Personnage("nom"))];
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}
