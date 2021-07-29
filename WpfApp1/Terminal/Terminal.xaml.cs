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
        public Terminal()
        {           
            InitializeComponent();
            ctxMenu.DataContext = this;
        
        }







        private bool IsItemSelected
        {
            get { return (bool)GetValue(IsItemSelectedProperty); }
            set { SetValue(IsItemSelectedProperty, value); }
        }

        private static readonly DependencyProperty IsItemSelectedProperty =
            DependencyProperty.Register("IsItemSelected", typeof(bool), typeof(Terminal), new FrameworkPropertyMetadata(null));



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



        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedModule = listbox.SelectedItem as Module;

            if (SelectedModule!= null) 
            {
                IsItemSelected = true;
            }
            else 
            {
                IsItemSelected = false;
            }
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

        private void deleteModule(object sender, RoutedEventArgs e)
        {
            if (IsItemSelected)

            {
                Modules.Remove(SelectedModule);
                //PasteCommand?.Execute(Modules.IndexOf(SelectedModule.First()));
            }
                
        }

        private void shiftRight(object sender, RoutedEventArgs e)
        {
            if (IsItemSelected)
            {
                var index = Modules.IndexOf(SelectedModule);
                var newIndex = index + 1;
                if (newIndex  < Modules.Count)
                    Modules.Move(index, newIndex);
            }
              
        }

        private void shiftLeft(object sender, RoutedEventArgs e)
        {
            if (IsItemSelected)
            {
                var index = Modules.IndexOf(SelectedModule);
                var newIndex = index - 1;
                if (newIndex >= 0)
                    Modules.Move(index, newIndex);
            }
            

        }

        private void listBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var module = (sender as ListBoxItem).DataContext as Module;
            
            DoubleClickCommand?.Execute( Modules.IndexOf(module));
        }
    }
}
