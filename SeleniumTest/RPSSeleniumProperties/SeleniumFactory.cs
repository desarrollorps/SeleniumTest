using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
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
                var options = new ChromeOptions();
                if (!RPSSeleniumProperties.RPSEnvironment.Visible)
                {
                    options.AddArgument("--headless");
                }
                options.AddArgument("--no-sandbox");
                options.AddArgument("--disable-dev-shm-usage");
                options.AddArgument("--whitelisted-ips=''");
                // options.AddArgument("--no-sandbox");
                if (!string.IsNullOrEmpty(SeleniumFactoryConfig.ChromeDriverPath))
                {
                    return new ChromeDriver(SeleniumFactoryConfig.ChromeDriverPath, options);
                }
                else
                {
                    return new ChromeDriver(options);
                }
            }else if (type == DriverType.Edge)
            {
                var options = new EdgeOptions();
                options.UseChromium = true;
                if (!RPSSeleniumProperties.RPSEnvironment.Visible)
                {
                    options.AddArgument("headless");
                }
                return new EdgeDriver(options);
            }
            return null;
        }
        public static IWebDriver CreateDefault()
        {
            return CreateDriver(SeleniumFactoryConfig.DefaultBrowser);
        }
    }
}
