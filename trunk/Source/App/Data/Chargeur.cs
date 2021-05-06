using System;
using Classes;
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

        public abstract Donnees Charger(string chemin);
    }
}
