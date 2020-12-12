using System.Drawing;
using Vintasoft.Barcode;

namespace BarcodeScannerApp.Models.Readers
{
    public static class VintasoftReader
    {
        public static void SetUp()
        {
           BarcodeGlobalSettings.Register("Mate Iszlai", "iszimate@gmail.com", "2021-01-04", "tPs4Q6WfEquFReJy+unImRQ8tl0BeRx1nkqU4QU9Sf3toYTHvEm17rOVOt3xXcYMLTwZmgub0YYjWMQgvSbj9xsgY1lsniW3+MsQX8RdfHdXGtuQYNY/KOH8f+gRc+FSbBiCbcnw/VFPcTaPSabbhGupL9nZtVB3VAhCF+5D/lQ");
        }

        public static string DecodeBarcode(string path)
        {
            var type = "Vintasoft: ";
            using BarcodeReader reader = new BarcodeReader();
            reader.Settings.ScanDirection = ScanDirection.LeftToRight;
            reader.Settings.ExpectedBarcodes = 1;
            reader.Settings.ScanInterval = 5;
            reader.Settings.ScanBarcodeTypes = BarcodeType.Code11 | BarcodeType.Code128 | BarcodeType.Codabar | BarcodeType.Code16K | BarcodeType.Code39 | BarcodeType.Code93 | BarcodeType.Standard2of5;
            reader.Settings.AutomaticRecognition = true;
            var results = reader.ReadBarcodes(path);
            if (results.Length > 0)
            {
                var number = results[0].Value;
                if (number.Length > 10)
                    return type + number.Substring(0, 10);
                return type + number;
            }
            return type + "No barcode found";
        }

    }
}
