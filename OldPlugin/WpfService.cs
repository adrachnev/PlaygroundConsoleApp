
using Newtonsoft.Json;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace OldPlugin
{
    public class WpfService : Contract.IWpfService
    {
        public FrameworkElement GetElement()
        {
            Assembly assembly = typeof(JsonConverter).Assembly;


            return new Button { Content = assembly.FullName };
        }
    }

}
