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
            {
                var number = results[0].BarcodeValue;
                if (number.Length > 10)
                    return type + number.Substring(0, 10);
                return type + number;
            }
            return type + "No barcode found";
        }

    }
}
