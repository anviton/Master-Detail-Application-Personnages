using System;
using System.Collections.Generic;
using System.IO;
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
using Vue_perso.Converters;
using Vue_perso.Dialogs;

namespace Vue_perso
{
    /// <summary>
    /// Logique d'interaction pour ModifierPerso.xaml
    /// </summary>
    public partial class ModifierPerso : Window
    {
        public Manager Mgr => (App.Current as App).MonManager;
        public Personnage Perso => Mgr.PersonnageSelectionne;
        public ModifierPerso()
        {
            InitializeComponent();
            //Perso.Citations = Mgr.PersonnageSelectionne.Citations;
            DataContext = Perso;
        }

        private void RenseignerImage(object sender, RoutedEventArgs e)
		{
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.DefaultExt = ".jpg | .png | .gif | .jpeg";
            dialog.Filter = "Tous les fichiers image (*.jpg, *.png, *.gif, *.jpeg) | *.jpg; *.png; *.gif; *.jpeg";

            if (dialog.ShowDialog() == true)
			{
                FileInfo fi = new FileInfo(dialog.FileName);
                string fileName = dialog.FileName;
                int i = 0;
                while (File.Exists(System.IO.Path.Combine(String2ImageConverter.ImagesPath, fileName)))
                {
                    fileName = $"{fi.Name.Remove(fi.Name.LastIndexOf('.'))}_{i}.{fi.Extension}";
                    i++;
                }
                File.Copy(dialog.FileName, System.IO.Path.Combine(String2ImageConverter.ImagesPath, fileName));
                Perso.Image = fileName;
			}
		}

        private void RenseignerChamp(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;
            Window newWindow;
            /*
             * On regarde quel bouton a été cliqué.
             * Ensuite, on instancie un Window, contenant une référence vers une fenêtre demandée.
             */
            if (senderButton.Equals(CitationsButton))
            {
                newWindow = new CitationsDialog(Perso);
                newWindow.ShowDialog();
            }
            else if (senderButton.Equals(JVButton))
            {
                newWindow = new JeuxVideoDialog(Perso);
                newWindow.ShowDialog();
            }
            else if (senderButton.Equals(ThemeButton))
            {
                newWindow = new ThemeMusical();
                newWindow.ShowDialog();
            }
            else if (senderButton.Equals(RelationsButton))
            {
                newWindow = new RelationsDialog();
                newWindow.ShowDialog();
            }
        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{
            Close();
		}
	}
}
