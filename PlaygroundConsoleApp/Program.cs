
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
            CheckUnderscoreRegex();
            GetCategories();
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
