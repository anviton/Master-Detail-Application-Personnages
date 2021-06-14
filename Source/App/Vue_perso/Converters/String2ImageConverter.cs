using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Data;

namespace Vue_perso.Converters
{
    class String2ImageConverter : IValueConverter
    {
        public static string ImagesPath { get; set; }
        static String2ImageConverter()
        {
            //ImagesPath = Path.Combine(Directory.GetCurrentDirectory(), "..\\Images"); //chemin utilisé pour le développement
            ImagesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Personnages", "Images"); //chemin utilisé pour le déploiement
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imageName = value as string;
            if (string.IsNullOrWhiteSpace(imageName)) return null;

            string imagePath = Path.Combine(ImagesPath, imageName);

            return new Uri(imagePath, UriKind.RelativeOrAbsolute);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
