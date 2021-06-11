﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Modele;
using StubP;

namespace Vue_perso
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //public Manager MonManager { get; private set; } = new Manager(new StubP.Stub());
        public Manager MonManager { get; private set; } = new Manager(new DataContractPersistance.DataContractPers());

        public App()
        {
            //Chargeur chargeur = new Stub("");
            MonManager.ChargeDonnees();
        }
    }
}
