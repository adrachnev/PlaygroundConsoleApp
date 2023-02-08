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
    public class CustomDropTargetHighlightAdorner : DropTargetHighlightAdorner
    {
        
        public CustomDropTargetHighlightAdorner(UIElement adornedElement, DropInfo dropInfo) : base(adornedElement, dropInfo) { }

        protected override void OnRender(DrawingContext drawingContext)
        {
            var result = Application.Current.TryFindResource("FestoColors.HighlightBrush") as Brush;

            if (result != null)
            {
                Pen.Brush = result;
            }
            else {
                Pen.Brush = new SolidColorBrush(Colors.Red);
            }

            var dropInfo = DropInfo;
            var itemsControl = dropInfo.VisualTarget as ItemsControl;

            if (itemsControl != null)
            {
                ItemsControl itemParent;

                var visualTargetItem = dropInfo.VisualTargetItem;

                if (visualTargetItem != null)
                {
                    itemParent = ItemsControl.ItemsControlFromItemContainer(visualTargetItem);
                }
                else
                {
                    itemParent = itemsControl;
                }

                if (itemParent == null)
                {
                    return;
                }

                var itemsCount = itemParent.Items.Count;
                var index = Math.Min(dropInfo.InsertIndex, itemsCount - 1);

                var lastItemInGroup = false;
                var targetGroup = dropInfo.TargetGroup;

                if (targetGroup != null && targetGroup.IsBottomLevel && dropInfo.InsertPosition.HasFlag(RelativeInsertPosition.AfterTargetItem))
                {
                    var indexOf = targetGroup.Items.IndexOf(dropInfo.TargetItem);
                    lastItemInGroup = indexOf == targetGroup.ItemCount - 1;

                    if (lastItemInGroup && dropInfo.InsertIndex != itemsCount)
                    {
                        index--;
                    }
                }

                var itemContainer = (UIElement)itemParent.ItemContainerGenerator.ContainerFromIndex(index);

                var showAlwaysDropTargetAdorner = itemContainer == null && DragDrop.GetShowAlwaysDropTargetAdorner(itemParent);

                if (showAlwaysDropTargetAdorner)
                {
                    itemContainer = itemParent;
                }

                if (itemContainer != null)
                {
                    var itemRect = new Rect(itemContainer.TranslatePoint(new Point(), AdornedElement), itemContainer.RenderSize);

                    Point point1,
                          point2;

                    if (dropInfo.VisualTargetOrientation == Orientation.Vertical)
                    {
                        if (dropInfo.InsertIndex == itemsCount || lastItemInGroup)
                        {
                            if (itemsCount > 0)
                            {
                                itemRect.Y += itemContainer.RenderSize.Height;
                            }
                            else
                            {
                                if ((itemsControl as ListView)?.View is GridView)
                                {
                                    var header = itemsControl.GetVisualDescendent<GridViewHeaderRowPresenter>();

                                    if (header != null)
                                    {
                                        itemRect.Y += header.RenderSize.Height;
                                    }
                                }
                                else if (itemsControl is DataGrid)
                                {
                                    var header = itemsControl.GetVisualDescendent<DataGridColumnHeadersPresenter>();

                                    if (header != null)
                                    {
                                        itemRect.Y += header.RenderSize.Height;
                                    }
                                }

                                itemRect.Y += Pen.Thickness;
                            }
                        }

                        var itemRectRight = itemRect.Right; //Math.Min(itemRect.Right, viewportWidth);
                        var itemRectLeft = itemRect.X < 0 ? 0 : itemRect.X;
                        point1 = new Point(itemRectLeft, itemRect.Y);
                        point2 = new Point(itemRectRight, itemRect.Y);
                    }
                    else
                    {
                        if (dropInfo.VisualTargetFlowDirection == FlowDirection.LeftToRight && dropInfo.InsertIndex == itemsCount)
                        {
                            if (itemsCount > 0)
                            {
                                itemRect.X += itemContainer.RenderSize.Width;
                            }
                            else
                            {
                                itemRect.X += Pen.Thickness;
                            }
                        }
                        else if (dropInfo.VisualTargetFlowDirection == FlowDirection.RightToLeft && dropInfo.InsertIndex != itemsCount)
                        {
                            if (itemsCount > 0)
                            {
                                itemRect.X += itemContainer.RenderSize.Width;
                            }
                            else
                            {
                                itemRect.X += Pen.Thickness;
                            }
                        }

                        var itemRectTop = itemRect.Y < 0 ? 0 : itemRect.Y;
                        var itemRectBottom = itemRect.Bottom; //Math.Min(itemRect.Bottom, viewportHeight);

                        point1 = new Point(itemRect.X, itemRectTop);
                        point2 = new Point(itemRect.X, itemRectBottom);
                    }

                    drawingContext?.DrawLine(Pen, point1, point2);
                }
            }
        }
    }
}