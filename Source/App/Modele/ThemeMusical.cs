/*
 * NOTES
 * Deux constructeurs : en vrai, on en supprimera un des deux
 * en fonction de celui qui est concrètement utilisé
 */
using System;
using System.Collections.Generic;

namespace Modele
{
    public class ThemeMusical
    {
        private HashSet<Titre> titres;
        // Champs
        public bool Leitmotiv { get; set; }
        public HashSet<Titre> Titres
        { 
            get { return titres; }
            set
            {
                if (value.Count > 1 && !Leitmotiv)
                {
                    throw new InvalidOperationException("Le thème musical n'est pas un leitmotiv, un seul titre est accepté");
                }
                titres = value;
            }
        }

        // Méthodes
        public ThemeMusical(bool leitmotiv)
        {
            Leitmotiv = leitmotiv;
        }
    }
}