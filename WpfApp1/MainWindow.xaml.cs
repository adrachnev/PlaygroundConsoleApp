using Festo.ComponentData.Contract;
using Festo.ComponentData.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DragDrop = GongSolutions.Wpf.DragDrop.DragDrop;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CatalogData2 _deviceCatalog;

        public MainWindow()
        {
             


            InitializeComponent();

            var context = listViewCatalogItems.DataContext as TestDataContext;
            if (context != null) 
            {   
                DragDrop.SetDragHandler(listViewCatalogItems, new DragHandler(listViewCatalogItems));
            }


            Func<CatalogData2> getCatalog = () => DeviceCatalog;
            Action resetCatalog = () => DeviceCatalog = null;



            var item = getCatalog().CatalogItems.First();



            resetCatalog();


            item = getCatalog().CatalogItems.First();

        }

        

        public CatalogData2 DeviceCatalog
        {
            get
            {
                if (_deviceCatalog == null)
                {
                    var manifestAssembly = Assembly.GetExecutingAssembly();
                    var catalogFile = "WpfApp1.catalog.json";

                    using (var reader = new StreamReader(manifestAssembly.GetManifestResourceStream(catalogFile), System.Text.Encoding.UTF8))
                    {
                        var catalogJson = reader.ReadToEnd();
                        _deviceCatalog = JsonConvert.DeserializeObject<CatalogData2>(catalogJson, ComponentDataJsonSettings.Default);
                    }
                }

                return _deviceCatalog;
            }
            private set { _deviceCatalog = value; }
        }

        private void JogLeftButton_OnClick(object sender, RoutedEventArgs e)
        {
            ((TestDataContext)DataContext).JogLeftCommand.Execute(null);
        }
    }
}
