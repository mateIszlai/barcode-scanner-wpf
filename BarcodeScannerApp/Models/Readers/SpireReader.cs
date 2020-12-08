using Spire.Barcode;

namespace BarcodeScannerApp.Models.Readers
{
    public static class SpireReader
    {
        public static string DecodeBarcode(string path)
        {
            var result = "Spire : ";
            var spireResult = BarcodeScanner.ScanOne(path);

            if (spireResult.Length > 0)
                return result + spireResult;

            return result + "No barcode found";
        }
    }
}
