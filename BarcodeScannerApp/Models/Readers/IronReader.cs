using IronBarCode;

namespace BarcodeScannerApp.Models.Readers
{
    public static class IronReader
    {
        public static string DecodeBarcode(string path)
        {
            var type = "BarCode : ";
            var result = BarcodeReader.ReadASingleBarcode(path, ImageCorrection: BarcodeReader.BarcodeImageCorrection.DeepCleanPixels);
            if (result != null)
                return type + result.Text;
            return type + "No barcode found";
        }
    }
}
