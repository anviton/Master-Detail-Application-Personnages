using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Modele
{
    public class SeriesTheque
    {
        public SeriesTheque()
        {
            Series = new ObservableCollection<Serie>();
        }

        public ObservableCollection<Serie> Series { get; }

        
    }
}
