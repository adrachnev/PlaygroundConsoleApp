using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;

namespace WpfApp1.Models
{
    public class CatalogItem
    {
        
        public CatalogItem(string xamlMarkup) 
        {

            using (Stream streamOut = new MemoryStream())
            {
                var converter = new XamlToPngConverter();
                converter.Convert(xamlMarkup, 0, 0, 0, 0, ScaleTO.OriginalSize, streamOut);
                
                InitBitmap(streamOut);

                streamOut.Close();
            }



        }

        private void InitBitmap(Stream streamOut)
        {
            Bitmap = new BitmapImage();
            Bitmap.BeginInit();
            Bitmap.StreamSource = streamOut;
            Bitmap.CacheOption = BitmapCacheOption.OnLoad;
            Bitmap.EndInit();
            Bitmap.Freeze();
        }

        public string OrderCode { get; set; }

        public string Tooltip { get { return OrderCode + Environment.NewLine + OrderCode; } }

        public BitmapImage Bitmap { get; set; }


     
    }
}
