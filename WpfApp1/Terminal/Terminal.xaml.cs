using Festo.Suite.Design.AttachedProperties;
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

    public enum MousePositionWithinModule
    {
        NONE,
        Outside,
        Left,
        Right,
        Center,
        Module,
        Placeholder,
        
    }
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
        public static readonly DependencyProperty ModulesProperty = DependencyProperty.Register("Modules", typeof(ObservableCollection<Module>), typeof(Terminal), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(ModulesChangedCallback)));

        private static void ModulesChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

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

            IModule sourceItem = dropInfo.Data as CatalogModuleProductViewModel;
            if (sourceItem == null)
                sourceItem = dropInfo.Data as Module;

            Module targetItem = dropInfo.TargetItem as Module;

            if (targetItem == null || sourceItem == null)
                return;

            // mouse cursor
            DragHandler.SetDragDropEffects(dropInfo);

            var currentDragPosition = GetMouseAlignmentRelativeToTarget(dropInfo);
            targetItem.PositionOnDrag = currentDragPosition;

            switch (currentDragPosition)
            {
                // display replace adorner
                case MousePositionWithinModule.Center:
                case MousePositionWithinModule.Module:
                case MousePositionWithinModule.Placeholder:
                    targetItem.SignalReplaceDrop = false;

                    if (sourceItem is CatalogModuleProductViewModel || 
                        (sourceItem is Module && currentDragPosition == MousePositionWithinModule.Placeholder))
                    {                        
                        targetItem.IsMouseOverPlaceholder = currentDragPosition == MousePositionWithinModule.Placeholder;
                        targetItem.SignalReplaceDrop = true;
                    }
                    break;

                // display insert adorner
                case MousePositionWithinModule.Right:
                case MousePositionWithinModule.Left:

                    ResetSignalReplace();
                    dropInfo.DropTargetAdorner = typeof(ItemInsertAdorner);

                    break;

                case MousePositionWithinModule.Outside:

                    ResetSignalReplace();
                    dropInfo.DropTargetAdorner = null;

                    break;

            }
            

        }

        private void ResetSignalReplace()
        {
            foreach (var m in Modules)
                m.SignalReplaceDrop = false;
        }

        void IDropTarget.Drop(IDropInfo dropInfo)
        {
            ResetClipboard();

            Module targetItem = dropInfo.TargetItem as Module;
            IModule sourceItem = dropInfo.Data as CatalogModuleProductViewModel;
            if (sourceItem == null)
                sourceItem = dropInfo.Data as Module;

            // insert new item into terminal from other UI control
            if (sourceItem != null && targetItem != null)
            {
                //var alignement = GetMouseAlignmentRelativeToTarget(dropInfo);


                var droppedDataConverted = new Module(sourceItem.XamlMarkup) { OrderCode = sourceItem.OrderCode };

                int targetIndex = Modules.IndexOf(targetItem);

                // drop item from catalog
                if (sourceItem is CatalogModuleProductViewModel)
                {
                    if (targetItem.PositionOnDrag == MousePositionWithinModule.Left)
                        Modules.Insert(targetIndex, droppedDataConverted);
                    else if (targetItem.PositionOnDrag == MousePositionWithinModule.Right)
                        Modules.Insert(targetIndex + 1, droppedDataConverted);

                    else if (targetItem.PositionOnDrag == MousePositionWithinModule.Center)
                    {
                        Modules.Remove(targetItem);
                        Modules.Insert(targetIndex, droppedDataConverted);
                    }
                    else if (targetItem.PositionOnDrag == MousePositionWithinModule.Placeholder)
                    {
                        TestDataContext.ReplacePlaceholder(targetItem, droppedDataConverted);
                        Modules.Insert(targetIndex, droppedDataConverted);
                    }

                }
                // drop item from terminal itself
                else if (sourceItem is Module)
                {
                    if (!IsMoveOperationPossible(Modules.IndexOf(sourceItem as Module), targetIndex, targetItem.PositionOnDrag))
                        return;


                    if (targetItem.PositionOnDrag == MousePositionWithinModule.Left)
                        Modules.Move(Modules.IndexOf(sourceItem as Module), targetIndex);
                    else if (targetItem.PositionOnDrag == MousePositionWithinModule.Right)
                    {
                        var targetIdx = targetIndex + 1 >= Modules.Count ? Modules.Count - 1 : targetIndex;
                        Modules.Move(Modules.IndexOf(sourceItem as Module), targetIdx);
                    }
                    else if (targetItem.PositionOnDrag == MousePositionWithinModule.Placeholder)
                    {


                        Modules.Move(Modules.IndexOf(sourceItem as Module), targetIndex - 1);
                        targetItem.SignalReplaceDrop = false;
                        TestDataContext.ReplacePlaceholder(targetItem, (Module)sourceItem );
                        
                    }

                }

            }


        }

        private bool IsMoveOperationPossible(int sourcePosition, int targetPosition, MousePositionWithinModule alignement)
        {
            if (sourcePosition == targetPosition)
                return false;
            if (sourcePosition + 1 == targetPosition && alignement == MousePositionWithinModule.Left)
                return false;
            if (sourcePosition - 1 == targetPosition && alignement == MousePositionWithinModule.Right)
                return false;

            return true;
        }

        void IDropTarget.DragLeave(IDropInfo dropInfo)
        {
            dropInfo.Effects = DragDropEffects.None;
        }


        /// <summary>
        /// If PlaceholderModule - return Module/Placeholder/Outside
        /// If normal Module - return Center/Left/Right/Outside
        /// </summary>
        /// <param name="dropInfo"></param>
        /// <returns></returns>
        private MousePositionWithinModule GetMouseAlignmentRelativeToTarget(IDropInfo dropInfo)
        {
            MousePositionWithinModule result = MousePositionWithinModule.NONE;


            var targetItemUI = (dropInfo.TargetItem as Module).DeviceImage as FrameworkElement;

            var width = targetItemUI.ActualWidth;

            var p1 = targetItemUI.TranslatePoint(dropInfo.DropPosition, dropInfo.VisualTargetItem);
            var p2 = targetItemUI.TranslatePoint(new Point(), dropInfo.VisualTarget);
            var posWithinTarget = p1.X - p2.X;
            if ((dropInfo.TargetItem as Module).Placeholder == null)
            {

                //Console.WriteLine(string.Format("OrderCode {0}", targetItem.OrderCode));
                //Console.WriteLine(string.Format("ActualWidth {0}", targetItemUI.ActualWidth));

                //Console.WriteLine(string.Format("Position within target item {0}", p1.X - p2.X));


                if (posWithinTarget > width / 3 * 2 && posWithinTarget < width)
                    result = MousePositionWithinModule.Right;

                else if (posWithinTarget > width / 3 && posWithinTarget < width / 3 * 2)
                    result = MousePositionWithinModule.Center;

                else if (posWithinTarget > 0 && posWithinTarget < width / 3)
                    result = MousePositionWithinModule.Left;
                else
                    result = MousePositionWithinModule.Outside;

                // Console.WriteLine(string.Format("result {0}", result));


            }
            else
            {
                var xLeft = SuiteProps.GetTranslateTransformX((dropInfo.TargetItem as Module).Placeholder);
                var xRight = xLeft + (dropInfo.TargetItem as Module).Placeholder.ActualWidth;

                var yUp = SuiteProps.GetTranslateTransformY((dropInfo.TargetItem as Module).Placeholder);
                var yDown = yUp + (dropInfo.TargetItem as Module).Placeholder.ActualHeight;

                if (posWithinTarget > xLeft && posWithinTarget < xRight)
                    result = MousePositionWithinModule.Placeholder;
                else
                    result = MousePositionWithinModule.Module;


            }

             Console.WriteLine(string.Format("result {0}", result));
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
