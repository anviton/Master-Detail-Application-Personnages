using System;
using System.Collections.Generic;

namespace Modele
{
    public abstract class Nommable : IEquatable<Nommable>
    {
        // Attributs


        public string Nom {
            get { return nom; }
            protected set {
                if (string.IsNullOrWhiteSpace(value))
                {

                }
                else
                {
                    nom = value;
                }
            }
        }
        private string nom;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nom"></param>
        public Nommable(string nom)
        {
            Nom = nom;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Nommable))
            {
                return false;
            }
            return Equals((Nommable)obj);
        }

        public bool Equals(Nommable other)
        {
            return (this.Nom == other.Nom);
        }

        public override int GetHashCode()
        {

            return Nom.GetHashCode() % 31;
        }
    }
}
