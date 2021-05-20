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
    /// Logique d'interaction pour MosaiquePersonnages_UC.xaml
    /// </summary>
    public partial class MosaiquePersonnages_UC : UserControl
    {
        public Manager Mgr => (App.Current as App).MonManager;

        public MosaiquePersonnages_UC()
        {
            InitializeComponent();
            DataContext = Mgr;
        }

        private void PersonnageSelectionne(object sender, SelectionChangedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }
    }
}
