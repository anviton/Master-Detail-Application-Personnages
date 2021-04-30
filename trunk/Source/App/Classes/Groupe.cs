using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Groupe : Nommable
    {
        public IList<Personnage> Personnages { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nom"></param>
        public Groupe (string nom) : base(nom)
        {
            IList<Personnage> Personnages = new List<Personnage>();
        }

    }
}
