using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Modele
{
    [DataContract(Name = "jeuVideo")]
    /// <summary>
    /// Classe JeuVideo
    /// </summary>
    public class JeuVideo : Nommable
    {
        [DataMember(EmitDefaultValue = false, Name = "annee")]
        public int? AnneeDeCreation { get; set; }

        /// <summary>
        /// Constructeur de la classe JeuVideo
        /// </summary>
        /// <param name="nom">nom du jeux </param>
        public JeuVideo(string nom, int? annee) : base(nom)
        {
            AnneeDeCreation = annee;
        }


        public override string ToString()
        {
            if (AnneeDeCreation == null)
            {
                return $"{Nom}";
            }
            return $"{Nom} ({AnneeDeCreation})";
        }
    }
}
