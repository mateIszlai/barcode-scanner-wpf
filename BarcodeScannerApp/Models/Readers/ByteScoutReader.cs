using Bytescout.BarCodeReader;

namespace BarcodeScannerApp.Models.Readers
{
    public static class ByteScoutReader
    {
        public static string DecodeBarcode(string path)
        {
            using Reader reader = new Reader
            {
                RegistrationName = "demo",
                RegistrationKey = "demo"
            };
            var type = "ByteScout : ";
            reader.BarcodeTypesToFind.All1D = true;
            reader.ReadFromFile(path);
            if (reader.FoundBarcodes.Length > 0)
            {
                var number = reader.FoundBarcodes[0].Value;
                if (number.Length > 10)
                    return type + number.Substring(0, 10);
                return type + number;
            }
            return type +  "No barcode found";
        }
    }
}
