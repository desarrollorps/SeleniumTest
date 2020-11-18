using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumHelper
{
    public enum DriverType
    {
        Chrome,
        Edge
    }
    public static class SeleniumFactory
    {
        public static IWebDriver CreateDriver(DriverType type)
        {
            if (type == DriverType.Chrome)
            {
                return new ChromeDriver(SeleniumFactoryConfig.ChromeDriverPath);
            }
            return null;
        }
        public static IWebDriver CreateDefault()
        {
            return CreateDriver(SeleniumFactoryConfig.DefaultBrowser);
        }
    }
}
