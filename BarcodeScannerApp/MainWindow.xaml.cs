using BarcodeScannerWPF.Model;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace BarcodeScannerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BarcodeData _barcodeData = new BarcodeData { SerialNumber = 0000000000 };
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _barcodeData;
            image.Source = new BitmapImage(new Uri(@"/input/gazora.jpg", UriKind.Relative));
        }

        private void addImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                var uri = new Uri(openFileDialog.FileName);
                image.Source = new BitmapImage(uri);
            }
        }
    }
}
