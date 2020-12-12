using System.Collections.Generic;
using System.Drawing;
using ZXing;

namespace BarcodeScannerApp.Models.Readers
{
    public static class ZXingReader
    {
        private static readonly BarcodeReader _reader = new BarcodeReader();
        public static string DecodeBarcode(string path)
        {
            var type = "ZXing: ";
            _reader.Options.TryHarder = true;
            _reader.Options.PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.All_1D };
            var result = _reader.Decode((Bitmap)Image.FromFile(path));
            if(result != null)
            {
                if (result.Text.Length > 10)
                    return type + result.Text.Substring(0, 10);
                return type + result.Text;
            }
            return type + "No barcode found";
        }
              
    }
}
