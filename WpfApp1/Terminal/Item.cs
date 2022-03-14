using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public interface Item
    {
        string XamlMarkup { get; set; }
        string OrderCode { get; set; }
    }
}
