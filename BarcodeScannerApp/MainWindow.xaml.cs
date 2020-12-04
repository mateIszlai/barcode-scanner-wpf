using Aspose.BarCode.BarCodeRecognition;
using Microsoft.Win32;
using Spire.Barcode;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
//using ZXing;

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
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                var uri = new Uri(openFileDialog.FileName);
                var picture = new BitmapImage(uri);
                image.Source = picture;


                /* ZXing.Net - opensource, nem sikerült működésre bírnom, a result mindig null, mintha nem ismerne fel egy barcodeot sem

                BarcodeReader barcodeReader = new BarcodeReader();
                var zxingResult = barcodeReader.Decode(picture);
                */

                //Aspose Barcode reader - Fizetős, de jól működött nálam, az evaluation verziót próbáltam

                using (BarCodeReader reader = new BarCodeReader(openFileDialog.FileName))
                {
                    var asposeResult = reader.ReadBarCodes();
                    if (asposeResult.Length > 0)
                    {
                        var number = asposeResult[0].CodeText;
                        if (number.Length > 10)
                            asposeNumberText.Text = number.Substring(0, 10);
                        else
                            asposeNumberText.Text = number;

                    }
                        
                    else
                        asposeNumberText.Text = "No barcode found";
                }


                //Spire Barcode - Elérhető ingyenes verzió is belőle, de nem tudom, hogy ez e az, szóval lehet, hogy ingyenes. Az aspose egy helyen jobban teljesített nálam, meg gyorsabb is volt. 

                var spireResult = BarcodeScanner.ScanOne(openFileDialog.FileName);
                if (spireResult.Length > 0)
                    spireNumberText.Text = spireResult;
                else
                    spireNumberText.Text = "No barcode found";
                
            }
        }
    }
}
