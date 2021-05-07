/*
 * NOTES
 * Deux constructeurs : en vrai, on en supprimera un des deux
 * en fonction de celui qui est concrètement utilisé
 */
using System.Collections.Generic;

namespace Modele
{
    public class ThemeMusical
    {
        // Champs
        public IList<Titre> Titres { get; set; }
        public bool Leitmotiv { get; set; }

        // Méthodes
        public ThemeMusical(List<Titre> titres, bool leitmotiv)
        {
            Titres = titres;
            Leitmotiv = leitmotiv;
        }

        public ThemeMusical(bool leitmotiv)
        {
            IList<Titre> Titres = new List<Titre>();
            Leitmotiv = leitmotiv;
        }
    }
}