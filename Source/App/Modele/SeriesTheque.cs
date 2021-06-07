using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;

namespace Modele
{
    [DataContract(Name = "serieTheque")]
    public class SeriesTheque
    {
        public SeriesTheque()
        {
            series = new ObservableCollection<Serie>();
        }
        public ObservableCollection<Serie> Series { get => series; }
        [DataMember(Name = "series")]
        private ObservableCollection<Serie> series;

        
    }
}
