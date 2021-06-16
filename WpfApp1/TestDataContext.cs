using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class TestDataContext
    {
        public TestDataContext() 
        {
            Modules = new List<Module> { new Module { Value = "hallo" }, new Module { Value = "hallo" } };
        }


        public bool IsVisible
        {
            get
            {
                return true;
            }
        }

        public List<Module> Modules { get; private set; }
    }
}
