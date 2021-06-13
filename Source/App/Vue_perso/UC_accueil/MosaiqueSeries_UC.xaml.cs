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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Modele;

namespace Vue_perso.UC_accueil
{
    /// <summary>
    /// Logique d'interaction pour MosaiqueJeux_UC.xaml
    /// </summary>
    public partial class MosaiqueJeux_UC : UserControl
    {
        public Manager Mgr => (App.Current as App).MonManager;

		public double MosaicWidth
		{
			get { return (double)GetValue(MosaicWidthProperty); }
			set { SetValue(MosaicWidthProperty, value); }
		}

		// Using a DependencyProperty as the backing store for MosaicWidth.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MosaicWidthProperty =
			DependencyProperty.Register("MosaicWidth", typeof(double), typeof(MosaiqueJeux_UC), new PropertyMetadata(0.0));

		public MosaiqueJeux_UC()
        {
            InitializeComponent();
            DataContext = Mgr;
        }

        private void SerieSelectionnee(object sender, SelectionChangedEventArgs e)
        {
            //var mainWindow = new MainWindow(((sender as ListBox).SelectedItem as Serie));
            if((sender as ListBox).SelectedItem != null) 
            {
                Mgr.SerieSelectionnee = (sender as ListBox).SelectedItem as Serie;
                var mainWindow = new MainWindow();
                Window.GetWindow(this).Close();
                mainWindow.ShowDialog();
            }
            
        }
    }
}
