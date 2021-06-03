using System;
using Modele;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.IO;

namespace DataContractPersistance
{
    public class DataContractPers : IPersistance
    {
        public string FilePath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "..//XML");
        public string FileName { get; set; } = "AppPersonnages.xml";
        public (SeriesTheque series, IDictionary<string, ObservableCollection<Personnage>> groupes) Charger()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sauvagarde les series de Personnage et les groupes.
        /// </summary>
        /// <param name="series"></param>
        /// <param name="Groupes"></param>
        public void Sauvegarder (SeriesTheque series, IDictionary<string, ObservableCollection<Personnage>> Groupes)
        {
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
            var serializer = new DataContractSerializer(typeof(SeriesTheque));
            using (Stream s = File.Create(FileName))
            {
                serializer.WriteObject(s, series);
            }

        }
    }
}
