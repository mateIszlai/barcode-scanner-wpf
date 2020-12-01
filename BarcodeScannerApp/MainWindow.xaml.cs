using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using Spire.Barcode;

namespace BarcodeScannerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                var uri = new Uri(openFileDialog.FileName);
                var picture = new BitmapImage(uri);
                image.Source = picture;
                var datas = BarcodeScanner.Scan(uri.AbsolutePath);
               serialNumberText.Text = datas[0];
            }
        }
    }
}
