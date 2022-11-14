using Infrastructure.Client;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace TextFinderClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new FinderViewModel();
            this.DataContext = _viewModel;
            listView.ItemsSource = _viewModel.Data;
        } 
        private readonly RestAPIClient _client = new RestAPIClient();
        private FinderViewModel _viewModel;

        private async void Find_Click(object sender, RoutedEventArgs e)
        {
            await _viewModel.FindText();
        }

        private void TextToFind_GotFocus(object sender, RoutedEventArgs e)
        {
            this.TextToFind.Text = string.Empty;
        }

        private void SelectFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.ValidateNames = false;
            openFileDialog.CheckFileExists = false;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            // Always default to Folder Selection.
            //Note: Issue with Win32 version cuts the text in filename, so to be replaced with WinForms version.
            openFileDialog.FileName = "Folder Selection...";
            if (openFileDialog.ShowDialog() == true)
            {
                this.FileLocation.Text = Path.GetDirectoryName(openFileDialog.FileName);
            }    
        }
    }
}
