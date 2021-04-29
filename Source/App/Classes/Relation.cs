/*
 * Constructeur : comment le faire ???
 * Soit on définit AvecPersoRec en fonction du constructeur appelé
 * (si il a pour argument persoRec ou NomPersoNonRec), soit c'est un argument du constructeur.
 * À mon avis, c'est mieux la première solution mais je sais pas si c'est exploitable
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Relation
    {
        // Champs
        public string Type { get; set; }
        public string NomPersoNonRec { get; set; }
        public Personnage PersoRec { get; set; }
        public bool AvecPersoRec { get; set; }

        // Méthodes
    }
}
