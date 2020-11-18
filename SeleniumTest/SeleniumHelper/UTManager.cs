using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace SeleniumHelper
{
    public static class UTManager
    {
        public static List<WebDriverUnitTest> UnitTests = new List<WebDriverUnitTest>();
        static UTManager()
        {
            

        }
        public static void ExecuteTests()
        {
            ExecuteTests(SeleniumFactoryConfig.DefaultBrowser);

        }
        public static void ExecuteTests(DriverType type)
        {
            UnitTests.Clear();
            var asm = Assembly.GetEntryAssembly();
            var classes = asm.GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(WebDriverUnitTest)));
            var driver = SeleniumFactory.CreateDriver(type);
            foreach (var c in classes)
            {
                var unittest = (WebDriverUnitTest)Activator.CreateInstance(c, new object[] { driver });
                UnitTests.Add(unittest);
                unittest.Execute();
            }
        }
    }
}
