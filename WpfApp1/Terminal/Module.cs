﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
            XamlMarkup = xamlMarkup;
            DeviceImage = CreateImageObject(xamlMarkup, DeviceImageType.XamlMarkup);

        }

        public string OrderCode
        {
            get => orderCode;
            set => orderCode = value;
        }

        public DependencyObject DeviceImage
        {
            get => deviceImage;
            set
            {
                
                deviceImage = value;
                placeholder = TestDataContext.FindChildByTag(deviceImage, "ModulePlaceHolder") as FrameworkElement;
            }
        }

        public bool IsSlotIn
        {
            get => isSlotIn; set
            {
                isSlotIn = value;
                if (isSlotIn)
                {
                    Debug.Assert(SlotIn == null);
                    Debug.Assert(Placeholder == null);
                }
                OnPropertyChanged();
            }
        }

        public bool IsCut
        {
            get => isCut;
            set
            {
                isCut = value;
                OnPropertyChanged();
            }
        }

        public Module SlotIn
        {
            get => slotIn;
            set
            {
                slotIn = value;
                if (slotIn != null)
                {
                    Debug.Assert(Placeholder != null);
                    Debug.Assert(!IsSlotIn);
                }
            }
        }
        public FrameworkElement Placeholder => placeholder;          
        
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

        public string Name
        {
            get => name;
            set => name = value;
        }

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

        private bool signalReplaceDrop;
        private int address;
        private bool isSlotIn;
        private Module slotIn;
        private bool isMouseOverPlaceholder;
        private DependencyObject deviceImage;
        private FrameworkElement placeholder;
        private string orderCode;
        private bool isCut;
        private string name;
        private MousePositionWithinModule positionOnDrag;
        private bool displayModuleDescription;
        private string xamlMarkup;

        public bool SignalReplaceDrop
        {
            get { return signalReplaceDrop; }
            set
            {
                if (signalReplaceDrop == value)
                    return;

                signalReplaceDrop = value;

                OnPropertyChanged();
            }
        }

        public MousePositionWithinModule PositionOnDrag
        {
            get => positionOnDrag;
            set => positionOnDrag = value;
        }

        public bool IsMouseOverPlaceholder
        {
            get => isMouseOverPlaceholder;
            set
            {
                if (isSlotIn)
                    throw new InvalidOperationException("This field is to be set only for placeholder modules");
                isMouseOverPlaceholder = value;
            }
        }

        public bool DisplayModuleDescription
        {
            get => displayModuleDescription;
            set => displayModuleDescription = value;
        }

        public string Message => "message";
        public bool HasWarning => false;

        public bool HasError => false;

        public bool DisplayDiagnosis => HasWarning || HasError || HasInfo;


        public bool HasInfo => false;

        public string XamlMarkup
        {
            get => xamlMarkup;
            set => xamlMarkup = value;
        }
    }
}
