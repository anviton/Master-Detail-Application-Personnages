using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;
using Modele;

namespace DataContractPersistance
{
    [DataContract]
    class DataToPersist
    {
        [DataMember]
        public SeriesTheque Series { get; set; } = new SeriesTheque();
        [DataMember]
        public IDictionary<string, ObservableCollection<Personnage>> Groupes { get; set; } = new Dictionary<string, ObservableCollection<Personnage>>();

    }
}
