using GongSolutions.Wpf.DragDrop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Terminal.xaml
    /// </summary>
    public partial class Terminal : UserControl, IDropTarget
    {

        PasteMode _pasteMode = PasteMode.None;
        int _copiedItemIndex = -1;

        public Terminal()
        {
            InitializeComponent();
            ctxMenu.DataContext = this;

            IsItemCopiedToClipboard = false;

        }


        #region Dependency Properties

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
        public static readonly DependencyProperty SelectedModuleProperty = DependencyProperty.Register("SelectedModule", typeof(Module), typeof(Terminal), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(SelectedModuleChangedCallback)));

        private static void SelectedModuleChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as Terminal).SelectedModule = e.NewValue as Module;
            (d as Terminal).listbox.SelectedValue = e.NewValue;
        }

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



        public double MaximumZoomFactor
        {
            get { return (double)GetValue(MaximumZoomFactorProperty); }
            set { SetValue(MaximumZoomFactorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaximumZoomFactor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaximumZoomFactorProperty =
            DependencyProperty.Register("MaximumZoomFactor", typeof(double), typeof(Terminal), new PropertyMetadata(3.0));



        public double MinimumZoomFactor
        {
            get { return (double)GetValue(MinimumZoomFactorProperty); }
            set { SetValue(MinimumZoomFactorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinimumZoomFactor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinimumZoomFactorProperty =
            DependencyProperty.Register("MinimumZoomFactor", typeof(double), typeof(Terminal), new PropertyMetadata(0.3));



        public double ZoomFactor
        {
            get { return (double)GetValue(ZoomFactorProperty); }
            set { SetValue(ZoomFactorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ZoomFactor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ZoomFactorProperty =
            DependencyProperty.Register("ZoomFactor", typeof(double), typeof(Terminal), new PropertyMetadata(1.5));

        #endregion

        public DragHandler DragHandler => new DragHandler(listbox);



        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedModule = listbox.SelectedItem as Module;
        }

        #region Context Menu
        private void listbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                delete(null, null);

            if (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.X)
                cut(null, null);

            if (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.C)
                copy(null, null);

            if (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.V)
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

        #endregion


        #region DragDrop
        void IDropTarget.DragEnter(IDropInfo dropInfo)
        {
            //throw new NotImplementedException();

            DragHandler.SetDragDropEffects(dropInfo);
        }

        

        void IDropTarget.DragOver(IDropInfo dropInfo)
        {
            

            listbox.SelectedItem = null;

            Item sourceItem = dropInfo.Data as CatalogItem;
            if (sourceItem == null)
                sourceItem = dropInfo.Data as Module;

            Module targetItem = dropInfo.TargetItem as Module;
            
            if (sourceItem != null && targetItem != null)
            {

                DragHandler.SetDragDropEffects(dropInfo);

                var pos = GetMouseAlignmentRelativeToTarget(dropInfo);

                if (pos == HorizontalAlignment.Center)
                {
                    if (sourceItem is CatalogItem)
                        targetItem.SignalReplaceDrop = true;

                    dropInfo.DropTargetAdorner = null;
                }
                  

                if (pos == HorizontalAlignment.Left || pos == HorizontalAlignment.Right)
                {
                    foreach (var m in Modules)
                        m.SignalReplaceDrop = false;
                    
                    dropInfo.DropTargetAdorner = typeof(CustmDropTargetHighlightAdorner);
                }
                if (pos == HorizontalAlignment.Stretch)
                {
                    
                    foreach (var m in Modules)
                        m.SignalReplaceDrop = false;

                    dropInfo.DropTargetAdorner = null;
                }
            }
        }

        void IDropTarget.Drop(IDropInfo dropInfo)
        {
            ResetClipboard();

            Module targetItem = dropInfo.TargetItem as Module;
            Item sourceItem = dropInfo.Data as CatalogItem;
            if (sourceItem == null)
                sourceItem = dropInfo.Data as Module;

            // insert new item into terminal from other UI control
            if (sourceItem != null && targetItem != null)
            {
                var alignement = GetMouseAlignmentRelativeToTarget(dropInfo);


                var droppedDataConverted = new Module(sourceItem.   XamlMarkup) { OrderCode = sourceItem.OrderCode };

                int targetIndex = Modules.IndexOf(targetItem);

                if (sourceItem is CatalogItem)
                {
                    if (alignement == HorizontalAlignment.Left)
                        Modules.Insert(targetIndex, droppedDataConverted);
                    else if (alignement == HorizontalAlignment.Right)
                        Modules.Insert(targetIndex + 1, droppedDataConverted);

                    else if (alignement == HorizontalAlignment.Center)
                    {
                        Modules.Remove(targetItem);
                        Modules.Insert(targetIndex, droppedDataConverted);
                    }
                }
                else if (sourceItem is Module) 
                {
                    if (alignement == HorizontalAlignment.Left)
                        Modules.Move(Modules.IndexOf(sourceItem as Module), targetIndex);
                    else if (alignement == HorizontalAlignment.Right)
                    {
                        var targetIdx = targetIndex + 1 >= Modules.Count ? Modules.Count -1 : targetIndex;
                        Modules.Move(Modules.IndexOf(sourceItem as Module), targetIdx);
                    }
                        
                }
                 
            }


        }

        void IDropTarget.DragLeave(IDropInfo dropInfo)
        {
            dropInfo.Effects = DragDropEffects.None;
        }

        

        private HorizontalAlignment GetMouseAlignmentRelativeToTarget(IDropInfo dropInfo)
        {
            var targetItemUI = (dropInfo.TargetItem as Module).DeviceImage as FrameworkElement;

            var width = targetItemUI.ActualWidth;

            var p1 = targetItemUI.TranslatePoint(dropInfo.DropPosition, dropInfo.VisualTargetItem);
            var p2 = targetItemUI.TranslatePoint(new Point(), dropInfo.VisualTarget);
            var posWithinTarget = p1.X - p2.X;


            //Console.WriteLine(string.Format("OrderCode {0}", targetItem.OrderCode));
            //Console.WriteLine(string.Format("ActualWidth {0}", targetItemUI.ActualWidth));

            //Console.WriteLine(string.Format("Position within target item {0}", p1.X - p2.X));
            HorizontalAlignment result;

            if (posWithinTarget > width / 3 * 2 && posWithinTarget < width)
                result = HorizontalAlignment.Right;

            else if (posWithinTarget > width / 3 && posWithinTarget < width / 3 * 2)
                result = HorizontalAlignment.Center;

            else if (posWithinTarget > 0 && posWithinTarget < width / 3)
                result = HorizontalAlignment.Left;
            else
                result = HorizontalAlignment.Stretch;

            // Console.WriteLine(string.Format("result {0}", result));

            return result;
        }

        

      

        #endregion
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
