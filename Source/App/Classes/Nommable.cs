using System;

namespace Classes
{
    public abstract class Nommable
    {
        // Attributs
        public readonly string nom;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nom"></param>
        public Nommable(string nom)
        {
            this.nom = nom;
        }
    }
}
