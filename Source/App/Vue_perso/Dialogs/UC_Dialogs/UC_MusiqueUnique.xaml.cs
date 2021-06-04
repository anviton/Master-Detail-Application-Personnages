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

namespace Vue_perso.Dialogs.UC_Dialogs
{
    /// <summary>
    /// Logique d'interaction pour UC_MusiqueUnique.xaml
    /// </summary>
    public partial class UC_MusiqueUnique : UserControl
    {
        public Manager Mgr => (App.Current as App).MonManager;

        public ThemeMusical Theme
        {
            get { return (ThemeMusical)GetValue(ThemeProperty); }
            set { SetValue(ThemeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Theme.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ThemeProperty =
            DependencyProperty.Register("Theme", typeof(ThemeMusical), typeof(UC_MusiqueUnique), new PropertyMetadata(default(ThemeMusical)));

        public UC_MusiqueUnique()
        {
            InitializeComponent();
            DataContext = Mgr.PersonnageSelectionne.Theme;
        }
    }
}
