using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
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

    }
}
