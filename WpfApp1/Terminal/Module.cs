﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public enum DeviceImageType
    {
        None = 0,
        XamlMarkup
    }
    public class Module : ObservableBase, IModule
    {
        public Module(string xamlMarkup)
        {
            DeviceImage = CreateImageObject(xamlMarkup, DeviceImageType.XamlMarkup);
            XamlMarkup = xamlMarkup;
            Placeholder = TestDataContext.FindChildByTag(DeviceImage, "ModulePlaceHolder") as FrameworkElement;


        }
        public string OrderCode { get; set; }
        public DependencyObject DeviceImage { get; set; }

        public bool IsSlotIn { get; set; }
        public FrameworkElement Placeholder { get; }
        /// <summary>
        /// Slot number or somthing else (e.g. AP address) 
        /// </summary>
        public int Address
        {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged();
            }
        }

        public string Name { get; set; }

        public static DependencyObject CreateImageObject(string xamlMarkup, DeviceImageType imageType)
        {
            if (imageType == DeviceImageType.XamlMarkup)
            {
                FrameworkElement markupElement;
                try
                {
                    using (MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(xamlMarkup)))
                    {
                        markupElement = XamlReader.Load(memStream) as FrameworkElement;
                    }

                }
                catch
                {
                    Uri resourceUri = new Uri(@"\Terminal\Images\faultXAML.png", UriKind.Relative);

                    Image dynamicImage = new Image()
                    {
                        Stretch = System.Windows.Media.Stretch.UniformToFill,
                        Source = new BitmapImage(resourceUri),
                        MaxHeight = 100,
                        MaxWidth = 100
                    };

                    markupElement = dynamicImage;
                }


                return markupElement;
            }

            throw new Exception($"Image type: {imageType} is not supported");
        }

        private bool _signalReplaceDrop;
        private int address;
        private double replaceDropHeight;
        private double replaceDropWidth;
        private Thickness replaceDropMargin;

        public bool SignalReplaceDrop
        {
            get { return _signalReplaceDrop; }
            set
            {
                if (_signalReplaceDrop == value)
                    return;

                _signalReplaceDrop = value;

                OnPropertyChanged();
            }
        }

        public double ReplaceDropHeight { get => replaceDropHeight; set { replaceDropHeight = value; OnPropertyChanged(); } }
        public double ReplaceDropWidth { get => replaceDropWidth; set { replaceDropWidth = value; OnPropertyChanged(); } }
        public Thickness ReplaceDropMargin { get => replaceDropMargin; set { replaceDropMargin = value; OnPropertyChanged(); } }

        public bool DisplayModuleDescription { get; set; }

        public string Message => "message";
        public bool HasWarning => false;

        public bool HasError => false;

        public bool DisplayDiagnosis => HasWarning || HasError || HasInfo;


        public bool HasInfo => false;

        public string XamlMarkup { get; set; }
    }
}
