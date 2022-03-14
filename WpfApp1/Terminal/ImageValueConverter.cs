using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public class ImageValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            try
            {
                using (Stream streamOut = new MemoryStream())
                {
                    var converter = new XamlToPngConverter();
                    converter.Convert(value as string, 0, 0, 0, 0, ScaleTO.OriginalSize, streamOut);

                    var image = InitBitmap(streamOut);

                    streamOut.Close();

                    return image;
                }
            }
            catch 
            {
                return DependencyProperty.UnsetValue;
            }
        }
        private BitmapImage InitBitmap(Stream streamOut)
        {
            var result = new BitmapImage();
            result.BeginInit();
            result.StreamSource = streamOut;
            result.CacheOption = BitmapCacheOption.OnLoad;
            result.EndInit();
            result.Freeze();

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
