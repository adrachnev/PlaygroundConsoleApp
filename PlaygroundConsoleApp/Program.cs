using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {




            Trigger();

            


            

            Console.ReadLine();

        }


        static async void Trigger()
        {
            await InvertAsync(true).ContinueWith(x =>
            {
                Console.WriteLine(x.Result);
            });

            var res = await InvertAsync(false);
            Console.WriteLine(res);
        }

        static async Task<bool> InvertAsync(bool value)
        {
            await Task.Run(() => value = !value);
            return value;
        }
    }
}
