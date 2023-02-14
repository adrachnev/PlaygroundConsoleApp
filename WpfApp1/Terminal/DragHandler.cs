using GongSolutions.Wpf.DragDrop;
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

            SetDragDropEffects(dragInfo);


        }

        private void PositionDragAdorner(IDragInfo dragInfo)
        {
            double height, width;
            DependencyObject image = null;
            if (dragInfo.Data is Module)
            {
                var source = (Module)dragInfo.Data;
                if (source.SlotIn != null && source.IsMouseOverPlaceholder)
                {

                    image = source.SlotIn.DeviceImage;

                }
                else
                    image = source.DeviceImage;
            }
            else if (dragInfo.Data is CatalogModuleProductViewModel)
            {
                image = Module.CreateImageObject((dragInfo.Data as CatalogModuleProductViewModel).XamlMarkup, DeviceImageType.XamlMarkup);
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


        public static void SetDragDropEffects(IDragInfo info)
        {

            if (info.Data is Module)
                info.Effects = DragDropEffects.Move;
            else if (info.Data is CatalogModuleProductViewModel)
                info.Effects = DragDropEffects.Copy;
            else
                info.Effects = DragDropEffects.None;
        }
        public static void SetDragDropEffects(IDropInfo info)
        {

            if (info.Data is Module)
                info.Effects = DragDropEffects.Move;
            else if (info.Data is CatalogModuleProductViewModel)
                info.Effects = DragDropEffects.Copy;
            else
                info.Effects = DragDropEffects.None;
        }

        
    }
}
