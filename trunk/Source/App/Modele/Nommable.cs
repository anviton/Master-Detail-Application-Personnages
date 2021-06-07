using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Modele
{
    [DataContract]
    public abstract class Nommable : IEquatable<Nommable>, IComparable<Nommable>, IComparable
    {
        // Attributs

        
        public string Nom { get => nom; }
        [DataMember (Order = 0, Name = "nom")]
        private string nom;
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nom"></param>
        public Nommable(string nom)
        {
            this.nom = nom;
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

        public int CompareTo(Nommable other)
		{
            return this.Nom.CompareTo(other.Nom);
		}

        public virtual int CompareTo(object obj)
		{
            if (!(obj is Nommable))
			{
                throw new ArgumentException("Argument is not a Nommable", "obj");
			}
            return this.CompareTo((obj as Nommable));
		}

        public static bool operator<(Nommable left, Nommable right)
		{
            return left.CompareTo(right) < 0;
		}

        public static bool operator<=(Nommable left, Nommable right)
		{
            return left.CompareTo(right) <= 0;
		}

        public static bool operator>(Nommable left, Nommable right)
		{
            return left.CompareTo(right) > 0;
		}

        public static bool operator>=(Nommable left, Nommable right)
		{
            return left.CompareTo(right) >= 0;
		}
        
    }
}
