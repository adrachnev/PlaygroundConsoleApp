﻿using System;
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
        }

        public IList<Module> Modules
        {
            get { return (IList<Module>)GetValue(ModulesProperty); }
            set { SetValue(ModulesProperty, value); }
        }
        public IList<Module> SelectedModules 
        { 
            get { return (IList<Module>)GetValue(SelectedModulesProperty); } 
            set { SetValue(SelectedModulesProperty, value); } 
        }
        public static readonly DependencyProperty ModulesProperty = DependencyProperty.Register("Modules", typeof(IList<Module>), typeof(Terminal), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty SelectedModulesProperty = DependencyProperty.Register("SelectedModules", typeof(IList<Module>), typeof(Terminal), new FrameworkPropertyMetadata(null));

        
        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedModules = listbox.SelectedItems.Cast<Module>().ToList();
        }
        private void listbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                if (SelectedModules != null)
                {
                    foreach (var m in SelectedModules)
                        Modules.Remove(m);
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
                        Modules.Insert(targetIdx + 1, droppedModule);
                        Modules.RemoveAt(removedIdx);
                    }
                    else
                    {
                        int remIdx = removedIdx + 1;
                        if (Modules.Count + 1 > remIdx)
                        {
                            Modules.Insert(targetIdx, droppedModule);
                            Modules.RemoveAt(remIdx);
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
    }
}
