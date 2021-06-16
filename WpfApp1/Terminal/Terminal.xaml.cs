using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Terminal.xaml
    /// </summary>
    public partial class Terminal : UserControl
    {
        public Terminal()
        {
           
            InitializeComponent();
        }


        public IList<Module> Modules {
            get
            {
                return (IList<Module>)GetValue(ModulesProperty);
            }
            set 
            {
                SetValue(ModulesProperty, value);
            } 
        }
        public static readonly DependencyProperty ModulesProperty = DependencyProperty.Register("Modules", typeof(IList<Module>), typeof(Terminal), new FrameworkPropertyMetadata(null)); 
    }
}
