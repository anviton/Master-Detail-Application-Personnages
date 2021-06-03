using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Modele
{
    public interface IPersistance
    {
        (SeriesTheque lesSeries, IDictionary<string, ObservableCollection<Personnage>> groupes) Charger();

        void Sauvegarder(SeriesTheque lesSeries, IDictionary<string, ObservableCollection<Personnage>> groupes);
    }
}
