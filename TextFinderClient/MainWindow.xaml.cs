﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TextFinderClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            var t = this.TextToFind.Text;
            MessageBox.Show("To be implemented...");
        }

        private void TextToFind_GotFocus(object sender, RoutedEventArgs e)
        {
            this.TextToFind.Text = string.Empty;
        }
    }
}
