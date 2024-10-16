
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
            Assembly newtonAssembly = typeof(JsonConverter).Assembly;

            Assembly uiAssembly = typeof(Festo.Tool.UI.WPF.ApplicationDispatcher).Assembly;


            return new PluginUserControl()
            {
                DataContext = new DataContext
                {
                    Text = "Old Plugin uses" +
                            Environment.NewLine + uiAssembly.FullName +
                            Environment.NewLine + newtonAssembly.FullName
                }
            };
        }
    }

}
