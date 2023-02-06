using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for TerminalEntry.xaml
    /// </summary>
    public partial class TerminalEntry : UserControl
    {


        public bool Signal
        {
            get { return (bool)GetValue(SignalProperty); }
            set { SetValue(SignalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Signal.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SignalProperty =
            DependencyProperty.Register("Signal", typeof(bool), typeof(TerminalEntry), new PropertyMetadata(false, new PropertyChangedCallback(SignalChangedCallback)));

        private static void SignalChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Debug.WriteLine(e.NewValue);
            
        }

        public TerminalEntry()
        {
            InitializeComponent();
            
        }

      
    }
}
