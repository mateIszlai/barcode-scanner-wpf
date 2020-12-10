using Dynamsoft.Barcode;
using System;

namespace BarcodeScannerApp.Models.Readers
{
    public static class DynamsoftReader
    {
        private static BarcodeReader _barcodeReader = new BarcodeReader("t0068NQAAAEZQ+6k6nQlw7e0kS27TpLG9kboWzxAC5NkqExsTUZODN+BD06FtgippZn2Enx6Xtoe+eSMuCvdb9pxUt8zg0Xg=");
        public static string DecodeBarcode(string path)
        {
            var type = "Dynamsoft: ";
            try
            {
                var results = _barcodeReader.DecodeFile(path, "");
                if (results.Length > 0)
                {
                    var number = results[0].BarcodeText;
                    if(number.Length > 10)
                        return type + number.Substring(0, 10);

                    return type + number;
                }
            }
            catch (BarcodeReaderException exp)
            {
                Console.WriteLine(exp.Message);
            }
            return type + "No barcode found";
        }

    }
}
