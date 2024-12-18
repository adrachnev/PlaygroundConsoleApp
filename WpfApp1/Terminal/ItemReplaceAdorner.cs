﻿using Festo.Suite.Design.AttachedProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;

namespace WpfApp1
{
    public class ItemReplaceAdorner : Adorner
    {
        #region fields

        private readonly ContentPresenter _presenter;

        #endregion

        #region ctors

        public ItemReplaceAdorner(FrameworkElement adornedElement)
            : base(adornedElement)
        {
            _presenter = new ContentPresenter();
            var dataContextBinding = new Binding("DataContext") { Source = adornedElement };
            BindingOperations.SetBinding(_presenter, ContentPresenter.ContentProperty, dataContextBinding);
            Template = GetTemplate(adornedElement);
            TemplateSelector = GetTemplateSelector(adornedElement);
            AddVisualChild(_presenter);
            AddLogicalChild(_presenter);
        }

        #endregion

        #region properties

        public DataTemplate Template
        {
            get { return _presenter.ContentTemplate; }
            set { _presenter.ContentTemplate = value; }
        }

        public DataTemplateSelector TemplateSelector
        {
            get { return _presenter.ContentTemplateSelector; }
            set { _presenter.ContentTemplateSelector = value; }
        }

        #endregion

        #region attached/dependency properties

        private static ItemReplaceAdorner GetAdorner(DependencyObject obj)
        {
            return (ItemReplaceAdorner)obj.GetValue(AdornerProperty);
        }

        private static void SetAdorner(DependencyObject obj, ItemReplaceAdorner value)
        {
            obj.SetValue(AdornerProperty, value);
        }

        private static readonly DependencyProperty AdornerProperty =
            DependencyProperty.RegisterAttached("Adorner", typeof(ItemReplaceAdorner), typeof(ItemReplaceAdorner), new PropertyMetadata(null));

        public static DataTemplate GetTemplate(DependencyObject obj)
        {
            return (DataTemplate)obj.GetValue(TemplateProperty);
        }

        public static void SetTemplate(DependencyObject obj, DataTemplate value)
        {
            obj.SetValue(TemplateProperty, value);
        }

        public static readonly DependencyProperty TemplateProperty =
            DependencyProperty.RegisterAttached("Template", typeof(DataTemplate), typeof(ItemReplaceAdorner), new PropertyMetadata(null, OnTemplateChanged));

        public static DataTemplateSelector GetTemplateSelector(DependencyObject obj)
        {
            return (DataTemplateSelector)obj.GetValue(TemplateSelectorProperty);
        }

        public static void SetTemplateSelector(DependencyObject obj, DataTemplateSelector value)
        {
            obj.SetValue(TemplateSelectorProperty, value);
        }

        // Using a DependencyProperty as the backing store for TemplateSelector.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TemplateSelectorProperty =
            DependencyProperty.RegisterAttached("TemplateSelector", typeof(DataTemplateSelector), typeof(ItemReplaceAdorner), new PropertyMetadata(null, OnTemplateSelectorChanged));

        public static bool GetVisible(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsVisibleProperty);
        }

        public static void SetVisible(DependencyObject obj, bool value)
        {
            obj.SetValue(VisibleProperty, value);
        }

        public static readonly DependencyProperty VisibleProperty =
            DependencyProperty.RegisterAttached("Visible", typeof(bool), typeof(ItemReplaceAdorner), new PropertyMetadata(false, OnVisibleChanged));


        public static readonly DependencyProperty AutoSizeProperty = DependencyProperty.RegisterAttached(
            "AutoSize", typeof(bool), typeof(ItemReplaceAdorner), new PropertyMetadata(default(bool), OnAutoSizeChanged));





        public static void SetAutoSize(DependencyObject element, bool value)
        {
            element.SetValue(AutoSizeProperty, value);
        }

        public static bool GetAutoSize(DependencyObject element)
        {
            return (bool)element.GetValue(AutoSizeProperty);
        }

        #endregion

        #region methods

        private static void OnAutoSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var adorner = GetAdorner(d);
            if (adorner != null)
                adorner.InvalidateMeasure();
        }

        private static void OnTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ItemReplaceAdorner adorner = GetAdorner(d);
            if (adorner != null)
            {
                adorner.Template = (DataTemplate)e.NewValue;
            }
        }

        private static void OnTemplateSelectorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ItemReplaceAdorner adorner = GetAdorner(d);
            if (adorner != null)
            {
                adorner.TemplateSelector = (DataTemplateSelector)e.NewValue;
            }
        }

        

        private static void OnVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
            FrameworkElement adornedElement = d as FrameworkElement;
            ItemReplaceAdorner adorner = GetAdorner(adornedElement);

            
            
            
            if (adornedElement == null) throw new InvalidOperationException("Adorners can only be applied to elements deriving from FrameworkElement");
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(adornedElement);
            if (layer == null) throw new InvalidOperationException("Cannot show adorner since no adorner layer was found in the visual tree");

            
            
            bool isVisible = (bool)e.NewValue;

            if (isVisible && adorner == null)
            {
                

                adorner = new ItemReplaceAdorner(adornedElement);
                
                var placeholder = TestDataContext.FindChildByTag(adornedElement, "ModulePlaceHolder") as FrameworkElement;
                var markplacholder = (adornedElement.DataContext as Module).IsMouseOverPlaceholder;
                if (placeholder != null && markplacholder)
                {
                    adorner.Width = placeholder.Width;
                    adorner.Height = placeholder.Height;
                    adorner.Margin = new Thickness(SuiteProps.GetTranslateTransformX(placeholder), SuiteProps.GetTranslateTransformY(placeholder), 0, 0);

                }
                else 
                {
                    adorner.Width = adornedElement.ActualWidth;
                    adorner.Height = adornedElement.ActualHeight;

                }

                SetAdorner(adornedElement, adorner);
                layer.Add(adorner);               
            }
            else if (!isVisible && adorner != null)
            {
                layer.Remove(adorner);
                SetAdorner(d, null);
            }
        }

        #endregion

        #region Adorner overrides

        protected override int VisualChildrenCount
        {
            get
            {
                return 1;
            }
        }

        protected override System.Windows.Media.Visual GetVisualChild(int index)
        {
            if (index == 0) return _presenter;
            throw new ArgumentOutOfRangeException("index");
        }

        protected override Size MeasureOverride(Size constraint)
        {
            if (GetAutoSize(AdornedElement))
            {
                var result = base.MeasureOverride(constraint);
                _presenter.Measure(constraint);
                InvalidateVisual();
                return result;
            }

            _presenter.Measure(constraint);
            return _presenter.DesiredSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            _presenter.Arrange(new Rect(new Point(0, 0), finalSize));
            return finalSize;
        }

        #endregion
    }
}
