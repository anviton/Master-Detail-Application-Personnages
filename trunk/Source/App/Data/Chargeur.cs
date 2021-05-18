using Modele;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public abstract class Chargeur
    {
        private string cheminDAcces;
        public Chargeur(string chemin)
        {
            cheminDAcces = chemin;
        }

        public abstract Manager Charger();
    }
}
