using BarcodeScannerApp.Models.Readers;
using Leadtools;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BarcodeScannerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HashSet<string> _libraries = new HashSet<string>();
        private readonly ObservableCollection<string> _results = new ObservableCollection<string>();
        private string _imagePath;

        public MainWindow()
        {
            InitializeComponent();
            resultList.ItemsSource = _results;
            var licfileCorrect = false;
            try
            {
                RasterSupport.SetLicense("eval-license-files.lic", "x8wVXpNT1ZaRbXTDSNFAk5KRXsAXLgAI5d3u3qtp7DM=");
                licfileCorrect = true;
            }
            catch (RasterException)
            {
                MessageBox.Show("Please open the leadtools licence file");
                while (!licfileCorrect)
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    if (openFileDialog.ShowDialog() == true)
                    {
                        try
                        {
                            RasterSupport.SetLicense(openFileDialog.FileName, "x8wVXpNT1ZaRbXTDSNFAk5KRXsAXLgAI5d3u3qtp7DM=");
                            licfileCorrect = true;
                        }
                        catch (RasterException)
                        {
                            continue;
                        }
                    }
                }
            }

            
            VintasoftReader.SetUp();
        }

        private void addImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                var uri = new Uri(openFileDialog.FileName);
                _imagePath = openFileDialog.FileName;
                var picture = new BitmapImage(uri);
                image.Source = picture;
                decodeBtn.IsEnabled = true;
            }
        }

        private void decodeBtn_Click(object sender, RoutedEventArgs e)
        {
            _results.Clear();
            foreach (var name in _libraries)
            {
                switch (name)
                {
                    case "Aspose":
                        _results.Add(AsposeReader.DecodeBarcode(_imagePath));
                        break;
                    case "Spire":
                        _results.Add(SpireReader.DecodeBarcode(_imagePath));
                        break;
                    case "ByteScout":
                        _results.Add(ByteScoutReader.DecodeBarcode(_imagePath));
                        break;
                    case "ZXing":
                        _results.Add(ZXingReader.DecodeBarcode(_imagePath));
                        break;
                    case "Leadtools":
                        _results.Add(LeadtoolsReader.DecodeBarcode(_imagePath));
                        break;
                    case "Dynamsoft":
                        _results.Add(DynamsoftReader.DecodeBarcode(_imagePath));
                        break;
                    case "Vintasoft":
                        _results.Add(VintasoftReader.DecodeBarcode(_imagePath));
                        break;
                    case "Accusoft":
                        _results.Add(AccusoftReader.DecodeBarcode(_imagePath));
                        break;
                    default:
                        break;
                }
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            _libraries.Add(((TextBlock)((CheckBox)sender).Content).Text);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            _libraries.Remove(((TextBlock)((CheckBox)sender).Content).Text);
        }
    }
}
