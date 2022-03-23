using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for TerminalGrid.xaml
    /// </summary>
    public partial class TerminalGrid : UserControl
    {
        public TerminalGrid()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ModulesProperty = DependencyProperty.Register("Modules", typeof(ObservableCollection<Module>), typeof(TerminalGrid), new FrameworkPropertyMetadata(null));
        public ObservableCollection<Module> Modules
        {
            get { return (ObservableCollection<Module>)GetValue(ModulesProperty); }
            set { SetValue(ModulesProperty, value); }
        }

        public static readonly DependencyProperty ModuleNameEditEndingCommandProperty = DependencyProperty.Register("ModuleNameEditEndingCommand", typeof(ICommand), typeof(TerminalGrid), new UIPropertyMetadata(null));

        public ICommand ModuleNameEditEndingCommand
        {
            get
            {
                return (ICommand)GetValue(ModuleNameEditEndingCommandProperty);
            }
            set
            {
                SetValue(ModuleNameEditEndingCommandProperty, value);
            }
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            if (e.EditAction == DataGridEditAction.Commit && e.Column.SortMemberPath == nameof(Module.Name))
            {
                if ((e.EditingElement.DataContext as Module).Name != e.EditingElement.GetValue(TextBox.TextProperty) as string)
                {
                    Console.WriteLine(e.EditingElement.GetValue(TextBox.TextProperty));
                    
                    ModuleNameEditEndingCommand?.Execute(new Tuple<Module, string>(
                        e.EditingElement.DataContext as Module,
                        e.EditingElement.GetValue(TextBox.TextProperty) as string));
                }                
            }
        }
    }
}
