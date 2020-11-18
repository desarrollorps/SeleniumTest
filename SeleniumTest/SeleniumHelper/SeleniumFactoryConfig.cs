using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumHelper
{
   
    public static class SeleniumFactoryConfig
    {
        static SeleniumFactoryConfig()
        {
            DefaultBrowser = DriverType.Chrome;
        }
        public static DriverType DefaultBrowser
        {
            get;set;
        }
        public static string ChromeDriverPath { get; set; }
        public static string EdgeDriverPath { get; set; }
    }
}
