using System;

namespace Classes
{
    public abstract class Nommable
    {
        // Attributs


        public readonly string nom; //ATTENTION cet attribut ne peut pas rester en public

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
