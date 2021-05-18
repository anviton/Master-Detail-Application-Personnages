﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    /// <summary>
    /// Classe JeuVideo
    /// </summary>
    public class JeuVideo : Nommable
    {
        public int AnneeDeCreation { get; set; }

        /// <summary>
        /// Constructeur de la classe JeuVideo
        /// </summary>
        /// <param name="nom">nom du jeux </param>
        public JeuVideo(string nom, int annee) : base(nom)
        {
            AnneeDeCreation = annee;
        }

        public JeuVideo(string nom) : base(nom)
        {
            
        }


        public override string ToString()
        {
            if (AnneeDeCreation == 0)
            {
                return $"{Nom}";
            }
            return $"{Nom} ({AnneeDeCreation})";
        }
    }
}