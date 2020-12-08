using Aspose.BarCode.BarCodeRecognition;

namespace BarcodeScannerApp.Models.Readers
{
    public static class AsposeReader
    {
        public static string DecodeBarcode(string path)
        {
            using BarCodeReader reader = new BarCodeReader(path);
            var asposeResult = reader.ReadBarCodes();
            var result = "Aspose : ";

            if (asposeResult.Length > 0)
            {
                var number = asposeResult[0].CodeText;
                if (number.Length > 10)
                    return result + number.Substring(0, 10);

                return result + number;
            }

            return result + "No barcode found";
        }
    }
}
