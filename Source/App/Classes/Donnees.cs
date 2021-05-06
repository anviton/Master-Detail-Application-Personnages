using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Donnees
    {
        public Donnees()
        {
            Series = new List<Serie>();
            Groupes = new Dictionary<string, HashSet<Personnage>>();
        }

        public IList<Serie> Series { get; set; }
        public Dictionary<string, HashSet<Personnage>> Groupes { get; }

 
    }
}
