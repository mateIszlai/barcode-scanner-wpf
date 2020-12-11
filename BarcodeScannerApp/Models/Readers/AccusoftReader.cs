using Accusoft.BarcodeXpressSdk;
using System.Drawing;

namespace BarcodeScannerApp.Models.Readers
{
    public static class AccusoftReader
    {
        public static string DecodeBarcode(string path)
        {
            var type = "Accusoft: ";
            using BarcodeXpress barcodeXpress = new BarcodeXpress();
            using Bitmap image = new Bitmap(path);
            var results = barcodeXpress.reader.Analyze(image);
            if (results.Length > 0)
                return type + results[0].BarcodeValue;
            return type + "No barcode found";
        }

    }
}
