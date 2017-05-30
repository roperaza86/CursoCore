using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirtsAppVS17
{
    public class MyAppSettings
    {
        public string Title { get; set; }
        public AppOptions Options  { get; set; }
    }


          public class AppOptions
    {

        public string StringOption { get; set; }
        public bool BoolOption { get; set; }
        public int IntegerOption { get; set; }

    }
}
