using System.Drawing;
using ZXing;

namespace BarcodeScannerApp.Models.Readers
{
    public static class ZXingReader
    {
        private static BarcodeReader _reader = new BarcodeReader();
        public static string DecodeBarcode(string path)
        {
            var type = "ZXing: ";
            var result = _reader.Decode((Bitmap)Image.FromFile(path));
            if(result != null)
            {
                return type + result.Text;
            }
            return type + "No barcode found";
        }
              
    }
}
