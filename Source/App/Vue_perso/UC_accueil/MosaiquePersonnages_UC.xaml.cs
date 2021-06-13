using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;
using Modele;

namespace Vue_perso.UC_accueil
{
    /// <summary>
    /// Logique d'interaction pour MosaiquePersonnages_UC.xaml
    /// </summary>
    public partial class MosaiquePersonnages_UC : UserControl
    {
        public Manager Mgr => (App.Current as App).MonManager;

		public double MosaicWidth
		{
			get { return (double)GetValue(MosaicWidthProperty); }
			set { SetValue(MosaicWidthProperty, value); }
		}

		// Using a DependencyProperty as the backing store for MosaicWidth.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MosaicWidthProperty =
			DependencyProperty.Register("MosaicWidth", typeof(double), typeof(MosaiquePersonnages_UC), new PropertyMetadata(0.0));



		public MosaiquePersonnages_UC()
        {
            InitializeComponent();
            DataContext = Mgr;
        }
        
        private void PersonnageSelectionne(object sender, MouseButtonEventArgs e)
        {
            // On gère ainsi le cas dans lequel l'utilisateur clique dans la ListBox mais pas sur un personnage
            if ((sender as ListBox).SelectedItem != null)
            {
                Mgr.PersonnageSelectionne = (sender as ListBox).SelectedItem as Personnage;
                MainWindow mainWindow = new MainWindow();
                Window.GetWindow(this).Close(); 
                mainWindow.Show();
            }
        }
    }
}
