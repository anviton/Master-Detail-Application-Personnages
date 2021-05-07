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
    }
}
