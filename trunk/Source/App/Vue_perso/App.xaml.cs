using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Data;
using Modele;

namespace Vue_perso
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Manager MonManager { get; private set; }

        public App()
        {
            Chargeur chargeur = new Stub("");
            MonManager = chargeur.Charger();
        }
    }
}
