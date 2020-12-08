using BarcodeScannerApp.Models.Readers;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
//using ZXing;

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

                /* ZXing.Net - opensource, nem sikerült működésre bírnom, a result mindig null, mintha nem ismerne fel egy barcodeot sem

                BarcodeReader barcodeReader = new BarcodeReader();
                var zxingResult = barcodeReader.Decode(picture);
                */
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
                    case "BarCode":
                        _results.Add(IronReader.DecodeBarcode(_imagePath));
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
