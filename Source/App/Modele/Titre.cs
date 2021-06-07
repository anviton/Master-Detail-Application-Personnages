using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Modele
{
    [DataContract(Name = "titre")]
    public class Titre : Nommable
    {
        // Champs
        [DataMember(EmitDefaultValue = false, Name = "lien")]
        public string Lien { get; set; }

        // Méthodes
        public Titre(string nom) : base (nom)
        {

        }

        public Titre(string nom, string lien) : this(nom)
		{
            Lien = lien;
		}

        public override string ToString()
        {
            if (Lien == null)
                return $"{Nom}";
            else
                return $"{Nom}  ({Lien})";
        }
    }
}
