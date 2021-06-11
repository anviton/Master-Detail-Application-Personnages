using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Modele;

namespace Vue_perso.Dialogs
{
	/// <summary>
	/// Logique d'interaction pour NouvelleRelationDialog.xaml
	/// </summary>
	public partial class NouvelleRelationDialog : Window
	{
		public Manager Mgr => (App.Current as App).MonManager;
		public Personnage PersoRec { get; set; }
		public string NomPersoNonRec { get; set; }
		public string Type { get; set; }

		public NouvelleRelationDialog()
		{
			InitializeComponent();
			DataContext = this;
		}

		private void OKButtonPressed(object sender, RoutedEventArgs e)
		{
			this.DialogResult = true;
		}

		private void CancelButtonPressed(object sender, RoutedEventArgs e)
		{
			this.DialogResult = false;
		}

		private void ResetTextBox(object sender, SelectionChangedEventArgs e)
		{
			AlternateToComboBox.Clear();
		}

		private void ResetComboBox(object sender, TextChangedEventArgs e)
		{
			MandatoryComboBox.SelectedIndex = -1;
		}
	}
}
