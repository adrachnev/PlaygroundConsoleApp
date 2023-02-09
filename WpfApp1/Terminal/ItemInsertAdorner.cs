using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using GongSolutions.Wpf.DragDrop;
using GongSolutions.Wpf.DragDrop.Utilities;
using DragDrop = GongSolutions.Wpf.DragDrop.DragDrop;

namespace WpfApp1
{
    public class ItemInsertAdorner : DropTargetHighlightAdorner
    {

        public ItemInsertAdorner(UIElement adornedElement, DropInfo dropInfo) : base(adornedElement, dropInfo) { }

        protected override void OnRender(DrawingContext drawingContext)
        {
            var result = Application.Current.TryFindResource("FestoColors.HighlightBrush") as Brush;

            if (result != null)
            {
                Pen.Brush = result;
            }
            else
            {
                Pen.Brush = new SolidColorBrush(Colors.Red);
            }

            var dropInfo = DropInfo;

            Module target = dropInfo.TargetItem as Module;
            if (target == null)
            {
                return;
            }

            var ui = (dropInfo.TargetItem as Module).DeviceImage as FrameworkElement;
            Point top, bottom;
            switch (target.PositionOnDrag)
            {
                case MousePositionWithinModule.Left:
                    top = ui.TranslatePoint(new Point(0, 0), dropInfo.VisualTarget);
                    bottom = ui.TranslatePoint(new Point(0, ui.ActualHeight), dropInfo.VisualTarget);
                    break;
                case MousePositionWithinModule.Right:
                    top = ui.TranslatePoint(new Point(ui.ActualWidth, 0), dropInfo.VisualTarget);
                    bottom = ui.TranslatePoint(new Point(ui.ActualWidth, ui.ActualHeight), dropInfo.VisualTarget);
                    break;
                default:
                    return;
            }

            drawingContext?.DrawLine(Pen, top, bottom);


        }
    }
}