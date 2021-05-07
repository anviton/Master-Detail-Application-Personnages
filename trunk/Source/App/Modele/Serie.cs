using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public class Serie : Nommable
    {
        //Propriétés
        public HashSet<Personnage> Personnages { get; set; }
        public Serie(string nom) : base(nom.ToLower())
        {
            Personnages = new HashSet<Personnage>();
            
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

        public override string ToString()
        {
            return Nom;
        }
    }
}
