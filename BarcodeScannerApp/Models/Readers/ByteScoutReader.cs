﻿using Bytescout.BarCodeReader;

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
            var result = "ByteScout : ";
            reader.BarcodeTypesToFind.All1D = true;
            reader.ReadFromFile(path);
            if (reader.FoundBarcodes.Length > 0)
                return result + reader.FoundBarcodes[0].Value;
            return result +  "No barcode found";
        }
    }
}
