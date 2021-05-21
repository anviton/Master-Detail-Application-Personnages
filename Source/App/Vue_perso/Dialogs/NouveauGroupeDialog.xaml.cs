﻿using System;
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

namespace Vue_perso.Dialogs
{
    /// <summary>
    /// Logique d'interaction pour NouveauGroupeDialog.xaml
    /// </summary>
    public partial class NouveauGroupeDialog : Window
    {
        public string groupName { get; set; }
        public NouveauGroupeDialog()
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
    }
}
