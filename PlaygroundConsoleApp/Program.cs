
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PlaygroundConsoleApp.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;

[assembly:InternalsVisibleTo("Tests")]
namespace PlaygroundConsoleApp
{
    public class Program
    {
        private static string topology =
            @"{
            ""Description"":{ ""GeneratedBy"":""automated"", ""TopologySchemaVersion"":2, ""FileVersion"":1,
            ""FileVersionDate"":""2020-07-10"" }, ""NumberOfApAsics"":3, ""ApAsicList"":[{""KoKaID"":2, ""ManKaID"":1, ""PU0_ID"":1,
            ""PU1_ID"":4, ""ModuleCode"":8196, ""PartNo"":8086601, ""ProductKey"":""3S7PNQJ0LZ5"", ""Connectors"":[{""Role"":""In"",
            ""Type"":""Socket"", ""TargetKoKaID"":1, ""CableLength"":476},
            { ""Role"":""Out"", ""Type"":""Socket"", ""TargetKoKaID"":3, ""CableLength"":348 }]},
            {
                ""KoKaID"":3, ""ManKaID"":2, ""PU0_ID"":2, ""PU1_ID"":3, ""ModuleCode"":8201, ""PartNo"":8086604,
                ""ProductKey"":""3s7pnyq55f9"", ""Connectors"":[{ ""Role"":""In"", ""Type"":""Socket"", ""TargetKoKaID"":2,
                ""CableLength"":348}, { ""Role"":""Out"", ""Type"":""Socket"", ""TargetKoKaID"":-1, ""CableLength"":-1 }]
            },
            {
                ""KoKaID"":1, ""ManKaID"":0, ""PU0_ID"":0, ""PU1_ID"":5, ""ModuleCode"":8323, ""PartNo"":8086610,
                ""ProductKey"":""DX2TJB8Y5LB"", ""Connectors"":[{ ""Role"":""Out"", ""Type"":""Socket"", ""TargetKoKaID"":-1,
                ""CableLength"":-1}, { ""Role"":""Out"", ""Type"":""Socket"", ""TargetKoKaID"":2, ""CableLength"":476 }]
            }]
        }";

        [STAThread]
        static void Main(string[] args)
        {
            ZipArchive();
        }

       
        private static string SetSlotInIdForPlaceholder(string iconMarkup, string Guid) 
        {
            string placeholderProperty = "ModulePlaceHolder=\"";

            var placeHolderPropertyIndex = iconMarkup.IndexOf(placeholderProperty);
            if (placeHolderPropertyIndex == -1)
                return iconMarkup;

            var firstQuoteIndex = placeHolderPropertyIndex + placeholderProperty.Length;
            var secondQuoteIndex = iconMarkup.IndexOf("\"", firstQuoteIndex);


            var result = iconMarkup.Remove(firstQuoteIndex, secondQuoteIndex - firstQuoteIndex);

            if (string.IsNullOrEmpty(Guid)) 
            {
                return result;
            }
            else 
            {
                return result.Insert(firstQuoteIndex, Guid);
            }
        }

        private static AutoResetEvent event_1 = new AutoResetEvent(false);

        private static void ParseModulePlaceholder()
        {

            Task.Run(() =>
            {

                string iconMarkup = "<?xml version='1.0' encoding='UTF-8'?><Canvas Tag=\"VABA-S6-1-X5\" Width=\"142\" Height=\"145\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:attachedProperties=\"clr-namespace:Festo.Suite.Design.AttachedProperties;assembly=Festo.Suite.Design\" VerticalAlignment=\"Top\"><Canvas Tag=\"Spacer\" IsHitTestVisible=\"False\"><Rectangle Tag=\"Spacer-2\" Width=\"2\" Height=\"140\" Canvas.Left=\"140\" Canvas.Top=\"0\" /></Canvas><Canvas Tag=\"Valves\" IsHitTestVisible=\"False\"><Canvas Tag=\"Valve\"><Rectangle Tag=\"Fitting\" Width=\"10\" Height=\"5\" Fill=\"#FFB6BEC6\" Canvas.Left=\"76\" Canvas.Top=\"140\" /><Rectangle Tag=\"Bottom\" Width=\"16\" Height=\"84\" Fill=\"#FFD8DCE1\" Canvas.Left=\"73\" Canvas.Top=\"56\" /><Rectangle Tag=\"Top\" Width=\"16\" Height=\"56\" Fill=\"#FFB6BEC6\" Canvas.Left=\"73\" Canvas.Top=\"0\" /></Canvas><Canvas Tag=\"Valve\"><Rectangle Tag=\"Fitting-2\" Width=\"10\" Height=\"5\" Fill=\"#FFB6BEC6\" Canvas.Left=\"93\" Canvas.Top=\"140\" /><Rectangle Tag=\"Bottom-2\" Width=\"16\" Height=\"84\" Fill=\"#FFD8DCE1\" Canvas.Left=\"90\" Canvas.Top=\"56\" /><Rectangle Tag=\"Top-2\" Width=\"16\" Height=\"56\" Fill=\"#FFB6BEC6\" Canvas.Left=\"90\" Canvas.Top=\"0\" /></Canvas><Canvas Tag=\"Valve\"><Rectangle Tag=\"Fitting-3\" Width=\"10\" Height=\"5\" Fill=\"#FFB6BEC6\" Canvas.Left=\"110\" Canvas.Top=\"140\" /><Rectangle Tag=\"Bottom-3\" Width=\"16\" Height=\"84\" Fill=\"#FFD8DCE1\" Canvas.Left=\"107\" Canvas.Top=\"56\" /><Rectangle Tag=\"Top-3\" Width=\"16\" Height=\"56\" Fill=\"#FFB6BEC6\" Canvas.Left=\"107\" Canvas.Top=\"0\" /></Canvas><Canvas Tag=\"Valve\"><Rectangle Tag=\"Fitting-4\" Width=\"10\" Height=\"5\" Fill=\"#FFB6BEC6\" Canvas.Left=\"127\" Canvas.Top=\"140\" /><Rectangle Tag=\"Bottom-4\" Width=\"16\" Height=\"84\" Fill=\"#FFD8DCE1\" Canvas.Left=\"124\" Canvas.Top=\"56\" /><Rectangle Tag=\"Top-4\" Width=\"16\" Height=\"56\" Fill=\"#FFB6BEC6\" Canvas.Left=\"124\" Canvas.Top=\"0\" /></Canvas><Canvas Tag=\"Cut out\"><Path Tag=\"Middle\" Stroke=\"#FFF2F3F5\" StrokeThickness=\"7\" Canvas.Left=\"-208.10799999999995\" Canvas.Top=\"-2124.145\"><Path.Data><PathGeometry Figures=\"M316 2124.145c0 8.778-3.677 23.243-3.6 40.569.076 16.549 4.413 38.436 4.413 50.938 0 28.261-3.363 34.1-3.363 48.493\" /></Path.Data></Path><Path Tag=\"Right\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"1\" Canvas.Left=\"-204.10799999999995\" Canvas.Top=\"-2124.145\"><Path.Data><PathGeometry Figures=\"M316 2124.145c0 8.778-3.677 23.243-3.6 40.569.076 16.549 4.413 38.436 4.413 50.938 0 28.261-3.363 34.1-3.363 48.493\" /></Path.Data></Path><Path Tag=\"Left\" Stroke=\"#FFB6BEC6\" StrokeThickness=\"1\" Canvas.Left=\"-212.10799999999995\" Canvas.Top=\"-2124.145\"><Path.Data><PathGeometry Figures=\"M316 2124.145c0 8.778-3.677 23.243-3.6 40.569.076 16.549 4.413 38.436 4.413 50.938 0 28.261-3.363 34.1-3.363 48.493\" /></Path.Data></Path></Canvas></Canvas><Rectangle Tag=\"Body\" Width=\"72\" Height=\"140\" Fill=\"#FFE5E8EB\" Canvas.Left=\"0\" Canvas.Top=\"0\" IsHitTestVisible=\"False\" /><Canvas Tag=\"Screws\" IsHitTestVisible=\"False\"><Ellipse Tag=\"Screw\" Width=\"7.0\" Height=\"7.0\" Fill=\"#FFB6BEC6\" Canvas.Left=\"2\" Canvas.Top=\"114\" /><Ellipse Tag=\"Screw-2\" Width=\"7.0\" Height=\"7.0\" Fill=\"#FFB6BEC6\" Canvas.Left=\"2\" Canvas.Top=\"126\" /><Ellipse Tag=\"Screw-3\" Width=\"7.0\" Height=\"7.0\" Fill=\"#FFB6BEC6\" Canvas.Left=\"63\" Canvas.Top=\"114\" /><Ellipse Tag=\"Screw-4\" Width=\"7.0\" Height=\"7.0\" Fill=\"#FFB6BEC6\" Canvas.Left=\"63\" Canvas.Top=\"19\" /><Ellipse Tag=\"Screw-5\" Width=\"7.0\" Height=\"7.0\" Fill=\"#FFB6BEC6\" Canvas.Left=\"2\" Canvas.Top=\"3\" /><Ellipse Tag=\"Screw-6\" Width=\"7.0\" Height=\"7.0\" Fill=\"#FFB6BEC6\" Canvas.Left=\"22\" Canvas.Top=\"7\" /></Canvas><Canvas Tag=\"LEDs\" IsHitTestVisible=\"False\"><Rectangle Tag=\"LED_PL\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"46\" Canvas.Top=\"10\" /><Rectangle Tag=\"LED_MD\" Width=\"6\" Height=\"2\" Fill=\"#FFB6BEC6\" Canvas.Left=\"38\" Canvas.Top=\"10\" /></Canvas><Canvas Tag=\"Slot\" IsHitTestVisible=\"False\"><Path Tag=\"Right_Notch\" Fill=\"#FFD8DCE1\" Canvas.Left=\"68.999\" Canvas.Top=\"110.084\"><Path.Data><PathGeometry Figures=\"M0 6.085v49c0 3.793 7 11.093 7 11.093V0S0 1.823 0 6.085Z\" /></Path.Data><Path.RenderTransform><RotateTransform CenterX=\"0\" CenterY=\"0\" Angle=\"180\" /></Path.RenderTransform></Path><Path Tag=\"Left_Notch\" Fill=\"#FFD8DCE1\" Canvas.Left=\"-11813\" Canvas.Top=\"-14960.092\"><Path.Data><PathGeometry Figures=\"M11816 15064.091v-49c0-3.793 7-11.093 7-11.093v66.176S11816 15068.353 11816 15064.091Z\" /></Path.Data></Path><Canvas Tag=\"Frame\"><Rectangle Width=\"53.0\" Height=\"110.0\" StrokeThickness=\"1\" Canvas.Left=\"9.5\" Canvas.Top=\"15.5\" /><Rectangle Width=\"52.0\" Height=\"109.0\" Stroke=\"#FFD8DCE1\" StrokeThickness=\"1\" Canvas.Left=\"9.5\" Canvas.Top=\"15.5\" /></Canvas></Canvas><Rectangle Tag=\"ModulePlaceHolder\" Width=\"50\" Height=\"107\" Canvas.Left=\"11\" Canvas.Top=\"17\" IsHitTestVisible=\"False\" attachedProperties:SuiteProps.TranslateTransformX=\"11\" attachedProperties:SuiteProps.TranslateTransformY=\"17\" attachedProperties:SuiteProps.ModulePlaceHolder=\"\" /><Canvas Tag=\"ApAddressPlaceHolder\" IsHitTestVisible=\"False\" attachedProperties:SuiteProps.TranslateTransformX=\"118\" attachedProperties:SuiteProps.TranslateTransformY=\"128\" attachedProperties:SuiteProps.IsApAddressPlaceHolder=\"True\"><Rectangle Tag=\"ApAddressPlaceHolder-2\" Width=\"20\" Height=\"8\" Fill=\"#FFFFFFFF\" Canvas.Left=\"118\" Canvas.Top=\"128\" /></Canvas></Canvas>";

                var res = SetSlotInIdForPlaceholder(iconMarkup, Guid.NewGuid().ToString());
                res = SetSlotInIdForPlaceholder(res, null);

                res = SetSlotInIdForPlaceholder(res, null);
                event_1.Set();
            });
            event_1.WaitOne();
        }


        private class Option
        {
            private readonly ushort id;
            private readonly ushort length;

            public Option(ushort id, ushort length)
            {
                this.id = id;
                this.length = length;
            }

            public byte[] GetBytes()
            {
                var result = new List<byte>();
                result.AddRange(BitConverter.GetBytes(id));
                result.AddRange(BitConverter.GetBytes(length));
                return result.ToArray();
            }
        }

        private static void ZipArchive()
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    var demoFile = archive.CreateEntry("topology.json");

                    using (var entryStream = demoFile.Open())
                    using (var streamWriter = new StreamWriter(entryStream))
                    {
                        streamWriter.Write(topology);
                    }

                    var analysEntry = archive.CreateEntry("system_analysis.aptl");

                    var evmOptBytes = new Option(4, 30).GetBytes();
                    var crcOptBytes = new Option(6, 39).GetBytes();

                    // format
                    var bytes = Encoding.UTF8.GetBytes("APTL").ToList();
                    // version
                    bytes.Add(1);
                    bytes.AddRange(Encoding.UTF8.GetBytes("OPTS"));
                    // opts length
                    bytes.AddRange(BitConverter.GetBytes((ushort) evmOptBytes.Count() + crcOptBytes.Count()));
                    bytes.AddRange(evmOptBytes);
                    bytes.AddRange(crcOptBytes);
                    bytes.AddRange(Encoding.UTF8.GetBytes("MSER"));

                    using (var entryStream = analysEntry.Open())
                    {
                        entryStream.Write(bytes.ToArray(), 0, bytes.Count());
                    }

                }


                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = "Archive"; // Default file name
                dlg.DefaultExt = ".aptez"; // Default file extension
                dlg.Filter = "Archive files (.aptez)|*.aptez"; // Filter files by extension

                // Show save file dialog box
                var result = dlg.ShowDialog();

                // Process save file dialog box results
                if (result == DialogResult.OK)
                {
                    // Save document
                    
                    using (var fileStream = new FileStream(dlg.FileName, FileMode.Create))
                    {
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        memoryStream.CopyTo(fileStream);
                    }
                }

                
            }
        }

        private static void DllVersion()
        {
            var path = @"C:\Workspace\repositories\569_festo_automation_suite_git\Deployment\FestoAutomationSuite.exe";
            var v = FileVersionInfo.GetVersionInfo(path).FileVersion;
        }

        private static void VariantOERegex()
        {
            Regex OeVariantRegex = new Regex("(^.*)OE$", RegexOptions.Compiled);
            string variantOE = "CPX-AP-A-4IOL-M12 Variant 4 OE";
            string variant = "CPX-AP-A-4IOL-M12 Variant 4";
            var r = OeVariantRegex.Match(variant);
        }

        private static void ReadFileAsResource()
        {
            var keys = new Dictionary<string, string>();
            var lines = Resources.NavigationAndHelpKeys.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                string[] columns = line.Split(';');
                Debug.Assert(columns.Count() == 2);
                keys.Add(columns[0], columns[1]);
            }
        }

        private static void ReplaceUnderscoreWithinUri ()
        {
            string pathParams = @"help:CPX_AP.chm?Diagnosis/Module_0.htm";
            pathParams = Regex.Replace(pathParams, @"Module_[\d]", "Module");
            Debug.Assert(pathParams == @"help:CPX_AP.chm?Diagnosis/Module.htm");
            pathParams = pathParams.Insert( pathParams.IndexOf(".htm"), @"/Parameters");
            Debug.Assert(pathParams == @"help:CPX_AP.chm?Diagnosis/Module/Parameters.htm");

            string pathState = @"help:CPX_AP.chm?Diagnosis/Module_0/DeviceState.htm";
            pathState = Regex.Replace(pathState, @"Module_[\d]", "Module");
            Debug.Assert(pathState == @"help:CPX_AP.chm?Diagnosis/Module/DeviceState.htm");
            pathState = Regex.Replace(pathState, @"Module/", string.Empty);
            Debug.Assert(pathState == @"help:CPX_AP.chm?Diagnosis/DeviceState.htm");

        }
        private static void ReplaceRegex()
        {
            string str = "local:Parameterization/Module_9/Parameters";
            var res = Regex.Replace(str, @"_[\d]", String.Empty, RegexOptions.None);
        }

        private static void GetCategories()
        {
            var list = new List<Product>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new Product
                {
                    Name = "Product " + i,
                    Category = i % 2 == 0 ? "1" : "2"
                });
            }

            var groups = list.GroupBy(x => x.Category);
            var res = new Dictionary<string, List<Product>>();
            foreach (var x in groups)
                res.Add(x.Key, x.ToList());
        }
        private class Product 
        {
            public string Category { get; set; }
            public string Name { get; set; }
        }
        
        private static void CheckUnderscoreRegex()
        {
            string str = "1D_0029BF5800000007";
            string str1 = "1D_0029BF5800000007_bitarr8";

            str = str.Substring(11, 8);
            str1 = str1.Substring(11, 8);

            var ipRegex = new Regex(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$");
            var result = ipRegex.IsMatch(@"1.2.3.4");



            var onlyLettersNumbersUnderscores = new Regex(@"[^\w\d]+");

            string input = @"4_!";
            result = onlyLettersNumbersUnderscores.IsMatch(input);


            var r = System.Text.RegularExpressions.Regex.Replace(input, onlyLettersNumbersUnderscores.ToString(), "_");

            var m = System.Text.RegularExpressions.Regex.IsMatch(input, @"^[\d]");
        }

        
    }





}
