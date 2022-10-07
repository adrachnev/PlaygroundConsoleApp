
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PlaygroundConsoleApp.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

[assembly:InternalsVisibleTo("Tests")]
namespace PlaygroundConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            VariantOERegex();
            DllVersion();

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
