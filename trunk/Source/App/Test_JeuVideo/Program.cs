using System;
using Modele;

namespace Test_JeuVideo
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager(new StubP.Stub());
            manager.ChargeDonnees();
            manager.Pers = new DataContractPersistance.DataContractPers();
            manager.SauvegaderDonnees();
        }
    }
}
