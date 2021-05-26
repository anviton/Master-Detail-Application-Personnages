using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public class Titre : Nommable
    {
        // Champs
        public string Lien { get; set; }

        // Méthodes
        public Titre(string nom) : base(nom)
        {
            
        }

        public Titre(string nom, string lien) : this(nom)
		{
            Lien = lien;
		}

        public override string ToString()
        {
            if (Lien == null)
                return $"{Nom}";
            else
                return $"{Nom}  ({Lien})";
        }
    }
}
