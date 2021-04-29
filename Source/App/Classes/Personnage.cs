﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Personnage : Nommable
    {
        // Champs
        public List<string> Citations { get; set; }
        public string Image { get; set; }
        public List<JeuVideo> JeuxVideo { get; set; }
        public ThemeMusical Theme { get; set; }
        public List<Relation> Relations { get; set; }

        // Méthodes
        public Personnage(string nom) : base(nom)
        {
            List<Relation> Relations = new List<Relation>();
            // INITIALISER LES LISTES ?
        }

        public void AjouterRelationAvecPersoEnr (string type, Personnage perso)
        {
            Relations.Add(new Relation(type, perso));
        }
    }
}
