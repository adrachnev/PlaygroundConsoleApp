using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public enum DeviceImageType
    {
        None = 0,
        XamlMarkup
    }
    public class Module
    {
        public Module(string xamlMarkup) 
        {
            DeviceImage = CreateImageObject(xamlMarkup, DeviceImageType.XamlMarkup);
        }
        public string Value { get; set; }
        public DependencyObject DeviceImage { get; }

        private DependencyObject CreateImageObject(string xamlMarkup, DeviceImageType imageType)
        {
            if (imageType == DeviceImageType.XamlMarkup)
            {
                FrameworkElement markupElement;
                try 
                { 
                    markupElement = XamlReader.Parse(xamlMarkup) as FrameworkElement; 
                }
                catch 
                {
                    Uri resourceUri = new Uri(@"\Terminal\Images\faultXAML.png", UriKind.Relative);

                    Image dynamicImage = new Image() 
                    { 
                        Stretch = System.Windows.Media.Stretch.UniformToFill,
                        Source = new BitmapImage(resourceUri),
                        MaxHeight = 100,
                        MaxWidth = 100
                    };
                    
                    markupElement = dynamicImage;
                }
                

                return markupElement;
            }

            throw new Exception($"Image type: {imageType} is not supported");
        }

    }
}
