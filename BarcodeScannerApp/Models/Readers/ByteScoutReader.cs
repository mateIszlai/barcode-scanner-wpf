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
            reader.BarcodeTypesToFind.All1D = true;
            reader.ReadFromFile(path);
            if (reader.FoundBarcodes.Length > 0)
                return reader.FoundBarcodes[0].Value;
            return "No barcode found";
        }
    }
}
