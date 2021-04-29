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
        public string Serie { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nom">nom du jeux </param>
        /// <param name="serie">nom de la série de jeu</param>
        public JeuVideo(string nom, string serie) : base(nom)
        {
            Serie = serie;
        }


    }
}
