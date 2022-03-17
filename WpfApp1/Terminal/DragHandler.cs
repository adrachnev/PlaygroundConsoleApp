﻿using GongSolutions.Wpf.DragDrop;
using GongSolutions.Wpf.DragDrop.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Models;
using DragDrop = GongSolutions.Wpf.DragDrop.DragDrop;

namespace WpfApp1
{
    public class DragHandler : IDragSource
    {
        private UIElement  dragSource;

        public DragHandler(UIElement dragSource)
        {
            this.dragSource = dragSource;
        }

        /// <inheritdoc />
        public virtual void StartDrag(IDragInfo dragInfo)
        {
            var items = TypeUtilities.CreateDynamicallyTypedList(dragInfo.SourceItems).Cast<object>().ToList();
            if (items.Count > 1)
            {
                dragInfo.Data = items;
            }
            else
            {
                // special case: if the single item is an enumerable then we can not drop it as single item
                var singleItem = items.FirstOrDefault();
                if (singleItem is IEnumerable && !(singleItem is string))
                {
                    dragInfo.Data = items;
                }
                else
                {
                    dragInfo.Data = singleItem;

                    PositionDragAdorner(dragInfo);

                }
            }

            dragInfo.Effects = dragInfo.Data != null ? DragDropEffects.Copy | DragDropEffects.Move : DragDropEffects.None;
            
        }

        private void PositionDragAdorner(IDragInfo dragInfo)
        {
            double height, width;
            DependencyObject image = null;
            if (dragInfo.Data is Module)
            {
                image = (dragInfo.Data as Module).DeviceImage;
            }
            else if (dragInfo.Data is CatalogItem)
            {
                image = Module.CreateImageObject((dragInfo.Data as CatalogItem).XamlMarkup, DeviceImageType.XamlMarkup);
            }
            else
                return;

            height = (double)image.GetValue(Image.HeightProperty);
            width = (double)image.GetValue(Image.WidthProperty);
            DragDrop.SetDragAdornerTranslation(dragSource, new Point(-width / 2, height));
        }

        /// <inheritdoc />
        public virtual bool CanStartDrag(IDragInfo dragInfo)
        {
            return true;
        }

        /// <inheritdoc />
        public virtual void Dropped(IDropInfo dropInfo)
        {
        }

        /// <inheritdoc />
        public virtual void DragDropOperationFinished(DragDropEffects operationResult, IDragInfo dragInfo)
        {
            // nothing here
        }

        /// <inheritdoc />
        public virtual void DragCancelled()
        {
        }

        /// <inheritdoc />
        public virtual bool TryCatchOccurredException(Exception exception)
        {
            return false;
        }
    }
}