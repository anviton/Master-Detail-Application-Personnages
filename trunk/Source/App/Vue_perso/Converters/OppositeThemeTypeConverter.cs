using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace Vue_perso.Converters
{
	/// <summary>
	/// Classe permettant d'afficher le texte adéquat
	/// dans le bouton permettant de changer le type de thème musical d'un personnage
	/// (Leitmotiv ou Musique unique)
	/// </summary>
	class OppositeThemeTypeConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if ((bool)value == true) // S'il s'agit d'un Leitmotiv :
			{
				return "_Passer au mode \"Musique unique\""; // Le bouton doit proposer de passer au mode "non-leitmotiv"
			}
			else // S'il ne s'agit pas d'un Leitmotiv :
			{
				return "_Passer au mode \"Leitmotiv\""; // Le bouton doit proposer de passer au mode "leitmotiv"
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
