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
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Terminal.xaml
    /// </summary>
    public partial class Terminal : UserControl
    {

        PasteMode _pasteMode = PasteMode.None;
        int _copiedItemIndex = -1;
        
        public Terminal()
        {           
            InitializeComponent();
            ctxMenu.DataContext = this;

            IsItemCopiedToClipboard = false;
        }



        internal bool IsItemCopiedToClipboard
        {
            get { return (bool)GetValue(IsItemCopiedProperty); }
            set { SetValue(IsItemCopiedProperty, value); }
        }

        public static readonly DependencyProperty IsItemCopiedProperty =
            DependencyProperty.Register("IsItemCopied", typeof(bool), typeof(Terminal), new FrameworkPropertyMetadata(null));


        public ObservableCollection<Module> Modules
        {
            get { return (ObservableCollection<Module>)GetValue(ModulesProperty); }
            set { SetValue(ModulesProperty, value); }
        }
        public static readonly DependencyProperty ModulesProperty = DependencyProperty.Register("Modules", typeof(ObservableCollection<Module>), typeof(Terminal), new FrameworkPropertyMetadata(null));

        public Module SelectedModule 
        { 
            get { return (Module)GetValue(SelectedModuleProperty); } 
            set { SetValue(SelectedModuleProperty, value); } 
        }
        public static readonly DependencyProperty SelectedModuleProperty = DependencyProperty.Register("SelectedModule", typeof(Module), typeof(Terminal), new FrameworkPropertyMetadata(null));

        public ICommand DoubleClickCommand
        {
            get { return (ICommand)GetValue(DoubleClickCommandProperty); }
            set { SetValue(DoubleClickCommandProperty, value); }
        }

        public static readonly DependencyProperty DoubleClickCommandProperty =
            DependencyProperty.Register("DoubleClickCommand", typeof(ICommand), typeof(Terminal), new FrameworkPropertyMetadata(null));

        public ICommand PasteCommand
        {
            get { return (ICommand)GetValue(PasteCommandProperty); }
            set { SetValue(PasteCommandProperty, value); }
        }
        public static readonly DependencyProperty PasteCommandProperty =
            DependencyProperty.Register("PasteCommand", typeof(ICommand), typeof(Terminal), new FrameworkPropertyMetadata(null));



        private void listboxItem_PreviewMouseMoveEvent(object sender, MouseEventArgs e)
        {
            if (sender is ListBoxItem && e.LeftButton == MouseButtonState.Pressed)
            {
                ListBoxItem draggedItem = sender as ListBoxItem;
                DragDrop.DoDragDrop(draggedItem, draggedItem.DataContext, DragDropEffects.All);
                draggedItem.IsSelected = true;
            }
        }
        private void listboxItem_Drop(object sender, DragEventArgs e)
        {
            ResetClipboard();

            if (sender is ListBoxItem)
            {
                Module droppedModule = e.Data.GetData(typeof(Module)) as Module;
                CatalogItem droppedCatalogItem = e.Data.GetData(typeof(CatalogItem)) as CatalogItem;
                
                // reorder items within terminal
                if (droppedModule != null)
                {
                    Module target = ((ListBoxItem)(sender)).DataContext as Module;

                    int removedIdx = listbox.Items.IndexOf(droppedModule);
                    int targetIdx = listbox.Items.IndexOf(target);

                    if (removedIdx < targetIdx)
                    {
                        Modules.Move(removedIdx, targetIdx);
                    }
                    else
                    {
                        int remIdx = removedIdx + 1;
                        if (Modules.Count + 1 > remIdx)
                        {
                            Modules.Move(removedIdx, targetIdx);
                        }
                    }
                }
                // insert new item into terminal from other UI control
                if (droppedCatalogItem != null)
                {
                    var droppedDataConverted = new Module(null) { OrderCode = droppedCatalogItem.OrderCode };
                    Module target = ((ListBoxItem)(sender)).DataContext as Module;
                    int targetIdx = listbox.Items.IndexOf(target);
                    Modules.Insert(targetIdx, droppedDataConverted);
                }
            }
            
        }

        private void listboxItem_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (e.Effects == DragDropEffects.Move)
            {
                e.UseDefaultCursors = false;
                Mouse.SetCursor(Cursors.Hand);
            }
            else
                e.UseDefaultCursors = true;

            e.Handled = true;
        }

        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedModule = listbox.SelectedItem as Module;
        }
        
        private void listbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete )
                delete(null, null);

            if ((Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.X))
                cut(null, null);

            if ((Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.C))
                copy(null, null);
            
            if ((Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.V))
                paste(null, null);
        }
        private void listBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ResetClipboard();

            var module = (sender as ListBoxItem).DataContext as Module;

            DoubleClickCommand?.Execute(Modules.IndexOf(module));
        }

        private void open(object sender, RoutedEventArgs e)
        {
            if (SelectedModule == null)
                return;
            ResetClipboard();
            DoubleClickCommand?.Execute(Modules.IndexOf(SelectedModule));
        }

        private void delete(object sender, RoutedEventArgs e)
        {
            if (SelectedModule == null)
                return;

            ResetClipboard();         
          
            Modules.Remove(SelectedModule);
        }

        private void shiftRight(object sender, RoutedEventArgs e)
        {
            if (SelectedModule == null)
                return;

            ResetClipboard();

            var index = Modules.IndexOf(SelectedModule);
            var newIndex = index + 1;
            if (newIndex < Modules.Count)
                Modules.Move(index, newIndex);


        }

        private void shiftLeft(object sender, RoutedEventArgs e)
        {
            if (SelectedModule == null)
                return;

            ResetClipboard();
         
            var index = Modules.IndexOf(SelectedModule);
            var newIndex = index - 1;
            if (newIndex >= 0)
                Modules.Move(index, newIndex);


        }

        

        private void cut(object sender, RoutedEventArgs e)
        {
            if (SelectedModule == null)
                return;
            
            _copiedItemIndex = Modules.IndexOf(SelectedModule);
            _pasteMode = PasteMode.Cut;
            IsItemCopiedToClipboard = true;
        }

        private void copy(object sender, RoutedEventArgs e)
        {
            if (SelectedModule == null)
                return;
            
            _copiedItemIndex = Modules.IndexOf(SelectedModule);
            _pasteMode = PasteMode.Copy;
            IsItemCopiedToClipboard = true;
        }

        private void paste(object sender, RoutedEventArgs e)
        {
            if (!IsItemCopiedToClipboard)
                return;



            var args = new PasteCommandArgs
            {
                Mode = _pasteMode,
                InsertToIndex = SelectedModule != null ? Modules.IndexOf(SelectedModule) + 1 : Modules.Count,
                OriginItemIndex = _copiedItemIndex
            };
            

            var copy = new Module(Modules[args.OriginItemIndex].XamlMarkup)
            {
                OrderCode = Modules[args.OriginItemIndex].OrderCode,
            };

            Modules.Insert(args.InsertToIndex, copy);

            if (args.Mode == PasteMode.Cut)
            {
                Modules.RemoveAt(args.OriginItemIndex);
                args.InsertToIndex = args.InsertToIndex - 1;
            }
              


            PasteCommand?.Execute(args);

            listbox.SelectedItem = null;
            SelectedModule = null;

            ResetClipboard();
        }

        private void ResetClipboard()
        {
            _pasteMode = PasteMode.None;
            _copiedItemIndex = -1;
            IsItemCopiedToClipboard = false;
        }
    }
    public class PasteCommandArgs 
    {
        public PasteMode Mode { get; set; }
        public int OriginItemIndex { get; set; }
        public int InsertToIndex { get; set; }
    }
    public enum PasteMode 
    {
        None,
        Cut,
        Copy
    }
}
