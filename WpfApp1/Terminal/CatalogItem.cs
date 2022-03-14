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
            this.XamlMarkup = xamlMarkup;
        }

        

        public string OrderCode { get; set; }

        public string Tooltip { get { return OrderCode + Environment.NewLine + OrderCode; } }

        public string XamlMarkup { get; set; }

        

    }
}
