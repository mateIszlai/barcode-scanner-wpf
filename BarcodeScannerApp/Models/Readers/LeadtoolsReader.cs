using Leadtools;
using Leadtools.Barcode;
using Leadtools.Codecs;

namespace BarcodeScannerApp.Models.Readers
{
    public static class LeadtoolsReader
    {
        private static BarcodeEngine _engine = new BarcodeEngine(); 
        public static string DecodeBarcode(string path)
        {
            using RasterCodecs codecs = new RasterCodecs();
            using RasterImage image = codecs.Load(path);
            var type = "Leadtools: ";
            var barcode = _engine.Reader.ReadBarcode(image, LeadRect.Empty, BarcodeSymbology.Unknown);
            if (barcode != null)
                return type + barcode;
            return type + "No barcode found";
        }
    }
}
