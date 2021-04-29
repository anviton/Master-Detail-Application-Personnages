using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    class Liste : Nommable
    {
        private IList<Personnage> liste;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nom"></param>
        public Liste (string nom) : base(nom)
        {

        }

    }
}
