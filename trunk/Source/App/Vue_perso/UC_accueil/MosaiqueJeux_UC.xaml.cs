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

namespace Vue_perso
{
    /// <summary>
    /// Logique d'interaction pour MosaiqueJeux_UC.xaml
    /// </summary>
    public partial class MosaiqueJeux_UC : UserControl
    {
        public Manager Mgr => (App.Current as App).MonManager;

        public MosaiqueJeux_UC()
        {
            InitializeComponent();
            DataContext = Mgr;
        }

        private void SerieSelectionnee(object sender, SelectionChangedEventArgs e)
        {
            var mainWindow = new MainWindow(((sender as ListBox).SelectedItem as Serie));
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }
    }
}
