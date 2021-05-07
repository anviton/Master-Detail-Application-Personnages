using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    /// <summary>
    /// Classe JeuVideo
    /// </summary>
    public class JeuVideo : Nommable
    {
        public DateTime Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nom">nom du jeux </param>
        /// <param name="serie">nom de la série de jeu</param>
        public JeuVideo(string nom, DateTime date) : base(nom)
        {
            Date = date;
        }

        public JeuVideo(string nom) : base(nom)
        {
            
        }

        public override string ToString()
        {
            return $"{Nom} ({Date})";
        }
    }
}
