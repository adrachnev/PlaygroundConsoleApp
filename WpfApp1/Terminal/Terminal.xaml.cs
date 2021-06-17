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
            listbox.SelectionChanged += listbox_SelectionChanged;
        }

        

        public IList<Module> Modules
        {
            get { return (IList<Module>)GetValue(ModulesProperty); }
            set { SetValue(ModulesProperty, value); }
        }
        public Module SelectedModule 
        { 
            get { return (Module)GetValue(SelectedModuleProperty); } 
            set { SetValue(SelectedModuleProperty, value); } 
        }
        public static readonly DependencyProperty ModulesProperty = DependencyProperty.Register("Modules", typeof(IList<Module>), typeof(Terminal), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty SelectedModuleProperty = DependencyProperty.Register("SelectedModule", typeof(Module), typeof(Terminal), new FrameworkPropertyMetadata(null));

        
        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedModule = (Module)listbox.SelectedItem;
        }
        private void listbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete) 
            {
                if (SelectedModule != null) 
                {
                    Modules.Remove(SelectedModule);
                }
            }
        }
    }
}
