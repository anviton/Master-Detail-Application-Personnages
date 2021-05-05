using System;

namespace Classes
{
    public abstract class Nommable
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
    }
}
