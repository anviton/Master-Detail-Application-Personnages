using System;

namespace Classes
{
    public abstract class Nommable
    {
        // Attributs
        public readonly string nom;

        // Constructeur
        public Nommable(string nom)
        {
            this.nom = nom;
        }
    }
}
