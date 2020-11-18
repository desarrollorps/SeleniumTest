using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumHelper;

namespace SeleniumTest
{
    class Program
    {
        static void Main(string[] args)
        {           
            SeleniumHelper.SeleniumFactoryConfig.ChromeDriverPath = $"U:\\Selenium\\";
            UTManager.ExecuteTests();           
        }
    }
}
