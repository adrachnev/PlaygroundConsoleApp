using Festo.Suite.Design.AttachedProperties;
using GongSolutions.Wpf.DragDrop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using DragDrop = GongSolutions.Wpf.DragDrop.DragDrop;

namespace WpfApp1
{

    public enum MousePositionWithinModule
    {
        NONE,
        Left,
        Right,
        Center,
        Placeholder,
        SlotIn,
        
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

            IsItemCutOrCopied = false;

        }


        #region Dependency Properties

        internal bool IsItemCutOrCopied
        {
            get { return (bool)GetValue(IsItemCutOrCopiedProperty); }
            set { SetValue(IsItemCutOrCopiedProperty, value); }
        }

        public static readonly DependencyProperty IsItemCutOrCopiedProperty =
            DependencyProperty.Register(nameof(IsItemCutOrCopied), typeof(bool), typeof(Terminal), new FrameworkPropertyMetadata(null));


        public ObservableCollection<Module> Modules
        {
            get { return (ObservableCollection<Module>)GetValue(ModulesProperty); }
            set { SetValue(ModulesProperty, value); }
        }
        public static readonly DependencyProperty ModulesProperty = DependencyProperty.Register(nameof(Modules), typeof(ObservableCollection<Module>), typeof(Terminal), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(ModulesChangedCallback)));

        private static void ModulesChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        public Module SelectedModule
        {
            get { return (Module)GetValue(SelectedModuleProperty); }
            set { SetValue(SelectedModuleProperty, value); }
        }
        public static readonly DependencyProperty SelectedModuleProperty = DependencyProperty.Register(nameof(SelectedModule), typeof(Module), typeof(Terminal), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(SelectedModuleChangedCallback)));

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
            DependencyProperty.Register(nameof(DoubleClickCommand), typeof(ICommand), typeof(Terminal), new FrameworkPropertyMetadata(null));

        public ICommand PasteCommand
        {
            get { return (ICommand)GetValue(PasteCommandProperty); }
            set { SetValue(PasteCommandProperty, value); }
        }
        public static readonly DependencyProperty PasteCommandProperty =
            DependencyProperty.Register(nameof(PasteCommand), typeof(ICommand), typeof(Terminal), new FrameworkPropertyMetadata(null));



        public double MaximumZoomFactor
        {
            get { return (double)GetValue(MaximumZoomFactorProperty); }
            set { SetValue(MaximumZoomFactorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaximumZoomFactor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaximumZoomFactorProperty =
            DependencyProperty.Register(nameof(MaximumZoomFactor), typeof(double), typeof(Terminal), new PropertyMetadata(3.0));



        public double MinimumZoomFactor
        {
            get { return (double)GetValue(MinimumZoomFactorProperty); }
            set { SetValue(MinimumZoomFactorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinimumZoomFactor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinimumZoomFactorProperty =
            DependencyProperty.Register(nameof(MinimumZoomFactor), typeof(double), typeof(Terminal), new PropertyMetadata(0.3));



        public double ZoomFactor
        {
            get { return (double)GetValue(ZoomFactorProperty); }
            set { SetValue(ZoomFactorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ZoomFactor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ZoomFactorProperty =
            DependencyProperty.Register(nameof(ZoomFactor), typeof(double), typeof(Terminal), new PropertyMetadata(1.5));

        #endregion

        public DragHandler DragHandler => new DragHandler(listbox);



        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedModule = listbox.SelectedItem as Module;
            if (SelectedModule == null)
            {
                ResetSignalReplace();
                return;
            }
               
            if (SelectedModule.IsSlotIn)
            {
                DisplaySlotInSelection(Modules.First(x => x.SlotIn == SelectedModule), true);
                
            }
            else
                ResetSignalReplace();
        }

        /// <summary>
        /// Handle slot-in selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var m = (sender as ListBoxItem).DataContext as Module;

            if (m.SlotIn == null)
                return;
            bool selectSlotIn = IsMouseOverPlaceholder(e, m.Placeholder);

            DisplaySlotInSelection(m, selectSlotIn);
            if (selectSlotIn)
                e.Handled = true;

        }

        private static bool IsMouseOverPlaceholder(MouseButtonEventArgs e, FrameworkElement placeholder)
        {
            var pos = e.GetPosition(placeholder);

            var selectSlotIn = (pos.X > 0 && pos.Y > 0 &&
                pos.X < placeholder.ActualWidth && pos.Y < placeholder.ActualHeight);

            return selectSlotIn;
        }

        private void DisplaySlotInSelection(Module placeholder, bool isSelected) 
        {
            Debug.Assert(placeholder.Placeholder != null);
            Debug.Assert(placeholder.SlotIn != null);
            Debug.Assert(placeholder.SlotIn.IsSlotIn == true);
            if (isSelected)
            {
                // select slot-in

                listbox.SelectionChanged -= listbox_SelectionChanged;
                listbox.SelectedItem = null;                
                SelectedModule = placeholder.SlotIn;
                listbox.SelectionChanged += listbox_SelectionChanged;
                placeholder.IsMouseOverPlaceholder = true;
                
                

                placeholder.SignalReplaceDrop = true;

            }
            else
            {
                placeholder.IsMouseOverPlaceholder = false;
                placeholder.SignalReplaceDrop = false;
            }
        }

        

        #region Context Menu
        private void listbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                Delete(null, null);

            if (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.X)
                Cut(null, null);

            if (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.C)
                Copy(null, null);

            if (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.V)
                Paste(null, null);

            if (Keyboard.IsKeyDown(Key.Escape))
            {
                ResetClipboard();
                ResetSignalReplace();
                listbox.SelectedItem = null;
            }
             
        }
        private void listBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ResetClipboard();

            var moduleToSelect = (sender as ListBoxItem).DataContext as Module;

            if (moduleToSelect.SlotIn != null)
            {
                if (IsMouseOverPlaceholder(e, moduleToSelect.Placeholder))
                    moduleToSelect = moduleToSelect.SlotIn;
            }

            DoubleClickCommand?.Execute(Modules.IndexOf(moduleToSelect));
        }

        private void Open(object sender, RoutedEventArgs e)
        {
            if (SelectedModule == null)
                return;
            ResetClipboard();
            DoubleClickCommand?.Execute(Modules.IndexOf(SelectedModule));
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (SelectedModule == null)
                return;

            ResetClipboard();

            if (SelectedModule.IsSlotIn) 
            {
                var placeholder = Modules.Single(x=>x.SlotIn == SelectedModule);
                placeholder.SlotIn = null;
                TestDataContext.FillPlaceholder(placeholder, null);
            }
            if (SelectedModule.SlotIn != null)
                Modules.Remove(SelectedModule.SlotIn);

            Modules.Remove(SelectedModule);
        }

        private void ShiftRight(object sender, RoutedEventArgs e)
        {
            if (SelectedModule == null)
                return;

            ResetClipboard();

            var index = Modules.IndexOf(SelectedModule);
            var newIndex = index + 1;
            if (newIndex < Modules.Count)
            {
                Shift(index, newIndex);
            }



        }

        private void Shift(int index, int newIndex)
        {
            foreach (var m in Modules)
            {
                m.PositionOnDrag = MousePositionWithinModule.NONE;
                if (m.Placeholder != null)
                    m.IsMouseOverPlaceholder = false;
            }
            if (Modules[index].SlotIn != null)
            {
                if (newIndex < index)
                   newIndex--;

                newIndex = newIndex < 0 ? 0 : newIndex;
            }

            AssertIndex();
            MoveTerminalItem(Modules[newIndex], Modules[index]);
            AssertIndex();
        }

        private void ShiftLeft(object sender, RoutedEventArgs e)
        {
            if (SelectedModule == null)
                return;

            ResetClipboard();

            var index = Modules.IndexOf(SelectedModule);
            var newIndex = index - 1;
            if (newIndex >= 0)
            {
                Shift(index, newIndex);
            }
              


        }



        private void Cut(object sender, RoutedEventArgs e)
        {
            if (SelectedModule == null)
                return;

            _copiedItemIndex = Modules.IndexOf(SelectedModule);
            _pasteMode = PasteMode.Cut;
            SelectedModule.IsCut = true;
            IsItemCutOrCopied = true;
        }

        private void Copy(object sender, RoutedEventArgs e)
        {
            if (SelectedModule == null)
                return;

            ResetCutModule();

            _copiedItemIndex = Modules.IndexOf(SelectedModule);
            _pasteMode = PasteMode.Copy;
            IsItemCutOrCopied = true;
        }

        private void Paste(object sender, RoutedEventArgs e)
        {
            Debug.Assert(IsItemCutOrCopied);
            Debug.Assert(_copiedItemIndex != -1);



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
            ResetCutModule();
            _pasteMode = PasteMode.None;
            _copiedItemIndex = -1;
            IsItemCutOrCopied = false;
        }

        private void ResetCutModule()
        {
            foreach (var m in Modules)
            {
                if (m.IsCut)
                    m.IsCut = false;
            }
        }

        #endregion


        #region DragDrop
        void IDropTarget.DragEnter(IDropInfo dropInfo)
        {
            //throw new NotImplementedException();

            var source = dropInfo.Data as Module;
            if (source != null)
            {
                if (source.SlotIn != null)
                {
                    if (source.IsMouseOverPlaceholder)
                        DragDrop.SetDragAdornerTemplate(listbox, (DataTemplate)FindResource("SlotInDragAdorner"));
                    else
                        DragDrop.SetDragAdornerTemplate(listbox, (DataTemplate)FindResource("PlaceholderDragAdorner"));
                }
                else
                    DragDrop.SetDragAdornerTemplate(listbox, (DataTemplate)FindResource("ItemDragAdorner"));
            }

            DragHandler.SetDragDropEffects(dropInfo);
        }


        
        void IDropTarget.DragOver(IDropInfo dropInfo)
        {
            //listbox.SelectedItem = null;

            IModule sourceItem = dropInfo.Data as CatalogModuleProductViewModel;
            if (sourceItem == null)
                sourceItem = dropInfo.Data as Module;

            Module targetItem = dropInfo.TargetItem as Module;

            if (targetItem == null || sourceItem == null)
                return;

            // mouse cursor
            DragHandler.SetDragDropEffects(dropInfo);

            var currentDropPosition = GetMouseAlignmentRelativeToTarget(dropInfo);
            targetItem.PositionOnDrag = currentDropPosition;

            switch (currentDropPosition)
            {
                // display replace adorner
                case MousePositionWithinModule.Center:
                case MousePositionWithinModule.Placeholder:
                case MousePositionWithinModule.SlotIn:
                    targetItem.SignalReplaceDrop = false;

                    if (sourceItem is CatalogModuleProductViewModel)
                    {
                        targetItem.IsMouseOverPlaceholder = currentDropPosition == MousePositionWithinModule.SlotIn;
                        targetItem.SignalReplaceDrop = true;
                    }
                    else if
                        (sourceItem is Module && ((Module)sourceItem).Placeholder == null 
                        && currentDropPosition == MousePositionWithinModule.SlotIn)
                    {
                       
                        targetItem.IsMouseOverPlaceholder = currentDropPosition == MousePositionWithinModule.SlotIn;
                        targetItem.SignalReplaceDrop = true;
                    }

                    break;

                // display insert adorner
                case MousePositionWithinModule.Right:
                case MousePositionWithinModule.Left:

                    ResetSignalReplace();
                    dropInfo.DropTargetAdorner = typeof(ItemInsertAdorner);

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
            if (sourceItem == null || targetItem == null)
                return;
            if (sourceItem == targetItem && !targetItem.IsMouseOverPlaceholder)
                return;


            //var alignement = GetMouseAlignmentRelativeToTarget(dropInfo);
            

            // drop item from catalog
            if (sourceItem is CatalogModuleProductViewModel)
            {
                DropCatalogItem(targetItem, sourceItem);
            }
            // drop item from terminal itself
            else if (sourceItem is Module)
            {
                DropTerminalItem(targetItem, sourceItem);
            }

            //ResetSignalReplace();

        }

        private void DropTerminalItem(Module targetItem, IModule sourceItem)
        {
            AssertIndex();

            if (targetItem.PositionOnDrag == MousePositionWithinModule.Left
                || targetItem.PositionOnDrag == MousePositionWithinModule.Right)
            {
                
                MoveTerminalItem(targetItem, sourceItem as Module);
            }

            else if (targetItem.PositionOnDrag == MousePositionWithinModule.SlotIn)
            {
                InsertOrReplaceSlotIn(targetItem, sourceItem as Module);
            }

            AssertIndex();
        }

        private void InsertOrReplaceSlotIn(Module targetItem, Module newSlotIn)
        {
            /* 
             * if a placeholder is empty - insert
               if slot-in module exists - change positions of modules
             */

            if (targetItem == newSlotIn) return;

            if (targetItem.SlotIn != null)
            {

                // move old slot-in
                var newIndex = Modules.IndexOf(targetItem.SlotIn) > Modules.IndexOf(newSlotIn) ? Modules.IndexOf(newSlotIn) : Modules.IndexOf(newSlotIn) - 1;
                newIndex = newIndex < 0 ? 0 : newIndex;   
                
                Modules.Move(Modules.IndexOf(targetItem.SlotIn), newIndex);
                targetItem.SlotIn.IsSlotIn = false;

            }
            if (Modules.IndexOf(newSlotIn) + 1 != Modules.IndexOf(targetItem))
            {
                // move new slot-in module
                var newIndex = Modules.IndexOf(newSlotIn) > Modules.IndexOf(targetItem) ? Modules.IndexOf(targetItem): Modules.IndexOf(targetItem) - 1;
                newIndex = newIndex < 0 ? 0 : newIndex;
                
                Modules.Move(Modules.IndexOf(newSlotIn), newIndex);
            }

            TestDataContext.FillPlaceholder(targetItem, newSlotIn);
        }

        private void MoveTerminalItem(Module targetItem, Module sourceItem)
        {

            int oldIndex = Modules.IndexOf(sourceItem);
            int newIndex = Modules.IndexOf(targetItem);

            // move operation for module or placeholder without slot-in module
            if (sourceItem.SlotIn == null)
            {
                Modules.Move(oldIndex, GetMoveNewIndex(sourceItem, targetItem));
            }
            // slotin or placeholder with slot-in
            else
            {
                // move operation for slot-in
                if (sourceItem.IsMouseOverPlaceholder)
                {
                    
                    Modules.Move(Modules.IndexOf(sourceItem.SlotIn), GetMoveNewIndex(sourceItem.SlotIn, targetItem));

                    sourceItem.SlotIn.DeviceImage = Module.CreateImageObject(sourceItem.SlotIn.XamlMarkup, DeviceImageType.XamlMarkup);
                    sourceItem.SlotIn.IsSlotIn = false;
                    TestDataContext.FillPlaceholder(sourceItem, null);

                }
                // move operation for placeholder with slot-in
                else
                
                {
                    // first placeholder 
                    Modules.Move(oldIndex, GetMoveNewIndex(sourceItem,targetItem));


                    // second slot-in if needed (don't adapt new index for slot-in)
                    if (Modules.IndexOf(sourceItem.SlotIn) + 1 != Modules.IndexOf(sourceItem))
                    {
                        newIndex = Modules.IndexOf(sourceItem);
                        Modules.Move(Modules.IndexOf(sourceItem.SlotIn), Modules.IndexOf(sourceItem.SlotIn) > newIndex ? newIndex : newIndex - 1);
                    }
                }
            }
        }

        private void AssertIndex()
        {
            Modules.SingleOrDefault(x => x.IsSlotIn);
            

            foreach (var item in Modules)
            {
                if (item.SlotIn != null)
                {
                    Debug.Assert(item.SlotIn == Modules[Modules.IndexOf(item) - 1]);
                }
            }
        }

        /// <summary>
        /// Adopts new index depending on
        /// - drop position (left/right of target module)
        /// - direction of move operation <see cref="ObservableCollection{T}.Move(int, int)"/>
        /// </summary>        
        private int GetMoveNewIndex(Module source , Module target )
        {
            // if shift context
            if (target.PositionOnDrag == MousePositionWithinModule.NONE)
            {
                if (target.IsSlotIn == false)
                    return StepOverSlotIn(Modules.IndexOf(source), Modules.IndexOf(target), Modules.IndexOf(target));
                else
                    return StepOverSlotIn(Modules.IndexOf(source), Modules.IndexOf(target) + 1, Modules.IndexOf(target) + 1);
            }

            if (target.IsSlotIn)
                throw new InvalidOperationException("Index is calculated only for non sloted modules");

            int oldIndex = Modules.IndexOf(source);
            int newIndex = Modules.IndexOf(target);

            MousePositionWithinModule positionOnDrag;
            if (target.IsSlotIn)
            {
                var placeholder = Modules.First(x => x.SlotIn == target);
                positionOnDrag = placeholder.PositionOnDrag;
            }
            else
                positionOnDrag = target.PositionOnDrag;


            // consider the move direction (if moving to right decrease)
            int result = oldIndex > newIndex ? newIndex : newIndex - 1;


            switch (positionOnDrag)
            {
                case MousePositionWithinModule.Left:
                case MousePositionWithinModule.SlotIn:
                    break;
                case MousePositionWithinModule.Right:
                    result++;
                    break;
                default:
                    throw new InvalidOperationException("internal implementation fault");
            }

            result = StepOverSlotIn(oldIndex, newIndex, result);

            return result;
        }

        

        private int StepOverSlotIn(int oldIndex, int newIndex, int result)
        {
            /*
                         * moving to left -> jump over slot-in if needed
                         * moving to right -> nothing to do, 'cause slot-in module is collapsed within terminal view
                         */
            if (oldIndex > newIndex)
            {
                if (Modules[result].SlotIn != null)
                    result--;
            }

            result = (result < 0) ? 0 : result;
            result = (result >= Modules.Count) ? Modules.Count - 1 : result;
            return result;
        }

        private void DropCatalogItem(Module targetItem, IModule sourceItem)
        {
            int targetIndex = Modules.IndexOf(targetItem);

            var droppedDataConverted = new Module(sourceItem.XamlMarkup) { OrderCode = sourceItem.OrderCode };

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
                if (targetItem.SlotIn != null)
                    Modules.Remove(targetItem.SlotIn);
                var index = Modules.IndexOf(targetItem);
                Modules.Remove(targetItem);
                Modules.Insert(index == 0 ? 0 : index--, droppedDataConverted);
            }
            else if (targetItem.PositionOnDrag == MousePositionWithinModule.SlotIn)
            {
                /* 
                 * if a placeholder is empty - insert
                 * if slot-in module exists - replace
                */
                if (targetItem.SlotIn != null)
                    Modules.Remove(targetItem.SlotIn);

                TestDataContext.FillPlaceholder(targetItem, droppedDataConverted);
                Modules.Insert(Modules.IndexOf(targetItem as Module), droppedDataConverted);


                Debug.Assert(Modules.IndexOf(targetItem) == Modules.IndexOf(targetItem.SlotIn) + 1);
            }
        }

        void IDropTarget.DragLeave(IDropInfo dropInfo)
        {
            dropInfo.Effects = DragDropEffects.None;
        }



        private const int MODULE_INSERT_EDGE_DISTANCE_PIXEL = 10;

        private MousePositionWithinModule GetMouseAlignmentRelativeToTarget(IDropInfo dropInfo)
        {
            MousePositionWithinModule result = MousePositionWithinModule.NONE;


            var targetItemUI = (dropInfo.TargetItem as Module).DeviceImage as FrameworkElement;

            var targetWidth = targetItemUI.ActualWidth;

            var p1 = targetItemUI.TranslatePoint(dropInfo.DropPosition, dropInfo.VisualTargetItem);
            var p2 = targetItemUI.TranslatePoint(new Point(), dropInfo.VisualTarget);
            var posWithinTarget = p1.X - p2.X;



            //Console.WriteLine(string.Format("OrderCode {0}", targetItem.OrderCode));
            //Console.WriteLine(string.Format("ActualWidth {0}", targetItemUI.ActualWidth));

            //Console.WriteLine(string.Format("Position within target item {0}", p1.X - p2.X));





            if ((dropInfo.TargetItem as Module).Placeholder != null)
            {
                var placeholderLeft = SuiteProps.GetTranslateTransformX((dropInfo.TargetItem as Module).Placeholder);
                var placeholderRight = placeholderLeft + (dropInfo.TargetItem as Module).Placeholder.ActualWidth;

                //var yUp = SuiteProps.GetTranslateTransformY((dropInfo.TargetItem as Module).Placeholder);
                //var yDown = yUp + (dropInfo.TargetItem as Module).Placeholder.ActualHeight;

                if (posWithinTarget > placeholderLeft && posWithinTarget < placeholderRight)
                    result = MousePositionWithinModule.SlotIn;
                else
                {
                    result = CalculateAlignment(targetWidth, posWithinTarget);
                }
            }
            else 
            {
                result = CalculateAlignment(targetWidth, posWithinTarget, true);
            }

            


            

             Console.WriteLine(result);
            return result;
        }

        private static MousePositionWithinModule CalculateAlignment(double width, double posWithinTarget, bool isPlaceholder = false)
        {
            MousePositionWithinModule result;
            if (posWithinTarget > 0 && posWithinTarget < MODULE_INSERT_EDGE_DISTANCE_PIXEL)
                result = MousePositionWithinModule.Left;
            else if (posWithinTarget > width - MODULE_INSERT_EDGE_DISTANCE_PIXEL && posWithinTarget < width)
                result = MousePositionWithinModule.Right;
            else
                result = isPlaceholder ? MousePositionWithinModule.Center : MousePositionWithinModule.Placeholder;
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
