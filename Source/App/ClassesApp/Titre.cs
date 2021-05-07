using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Titre : Nommable
    {
        // Champs
        public string Lien { get; set; }

        // Méthodes
        public Titre(string nom) : base(nom)
        {
            
        }
    }
}
