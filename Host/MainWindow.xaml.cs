using Contract;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Host
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            string[] pluginPaths = new string[]
            {
                    @"Plugin\bin\Debug\net8.0-windows\Plugin.dll",
                    @"OldPlugin\bin\Debug\net8.0-windows\OldPlugin.dll",

            };

            IEnumerable<Contract.IWpfService> services = pluginPaths.SelectMany(pluginPath =>
            {
                Assembly pluginAssembly = PluginHandler.LoadPlugin(pluginPath);
                return PluginHandler.CreateServices(pluginAssembly);
            }).ToList();


            if (services.Count() == 0)
            {
                MessageBox.Show("No services found.");
                return;
            }

            foreach (IWpfService s in services)
            {
                this.stackPanel.Children.Add(s.GetElement());
            }
        }
    }
}