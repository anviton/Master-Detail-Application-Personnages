using System;
using Modele;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;

namespace DataContractPersistance
{
    public class DataContractPers : IPersistance
    {
        //public string FilePath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "..//XML"); //chemin utilisé pour le développment
        public string FilePath { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Personnages", "XML"); //chemin utilisé pour le déploiement
        public string FileName { get; set; } = "AppPersonnages.xml";
        public (SeriesTheque lesSeries, IDictionary<string, ObservableCollection<Personnage>> groupes) Charger()
        {
            if(!File.Exists(Path.Combine(FilePath, FileName)))
            {
                throw new FileNotFoundException("Fichier de Persistance non trouvé");

            }
            DataToPersist data;
            var serializer = new DataContractSerializer(typeof(DataToPersist));
            using (Stream s = File.OpenRead(Path.Combine(FilePath, FileName)))
            {
                    data = serializer.ReadObject(s) as DataToPersist;
            }
            return (data.Series, data.Groupes);
        }
        /// <summary>
        /// Sauvagarde les series de Personnage et les groupes.
        /// </summary>
        /// <param name="series"></param>
        /// <param name="Groupes"></param>
        public void Sauvegarder (SeriesTheque series, IDictionary<string, ObservableCollection<Personnage>> groupes)
        {
            var serializer = new DataContractSerializer(typeof(DataToPersist),
                                                    new DataContractSerializerSettings()
                                                    {
                                                        PreserveObjectReferences = true
                                                    }) ;
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
            var settings = new XmlWriterSettings() { Indent = true };
            DataToPersist data = new DataToPersist();
            data.Groupes = groupes;
            data.Series = series;
            using (TextWriter tw = File.CreateText(Path.Combine(FilePath, FileName)))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, settings))
                {
                    serializer.WriteObject(writer, data);
                }
            }

        }
    }
}
