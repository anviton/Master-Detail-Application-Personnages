/*
 * NOTES
 * Deux constructeurs : en vrai, on en supprimera un des deux
 * en fonction de celui qui est concrètement utilisé
 */
using System.Collections.Generic;

namespace Classes
{
    public class ThemeMusical
    {
        // Champs
        public List<Titre> Titres { get; set; }
        public bool Leitmotiv { get; set; }

        // Méthodes
        public ThemeMusical(List<Titre> titres, bool leitmotiv)
        {
            Titres = titres;
            Leitmotiv = leitmotiv;
        }

        public ThemeMusical(bool leitmotiv)
        {
            // INITIALISER LISTE ???
            Leitmotiv = leitmotiv;
        }
    }
}