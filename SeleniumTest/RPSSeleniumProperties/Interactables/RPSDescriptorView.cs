using RPSSeleniumProperties.Interfaces.Interactables;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RPSSeleniumProperties.Interfaces;

namespace RPSSeleniumProperties.Interactables
{
    public class RPSDescriptorView<T, N> : SeleniumInteractable<T>, IRPSDescriptorView<T, N> where T : class, IView where N : class, IView
    {
        public N NewView { get; set; }

        public N Click(string text)
        {
            var driver = this.WebDriver;
            return Click(driver, text);
        }

        public N Click(IWebDriver driver, string text)
        {
            var elements = GetElements(driver, "a h3,h4");
            foreach(var el in elements)
            {
                if(el.Text.ToUpper() == text)
                {
                    el.Click();
                    return this.NewView;
                }
            }
            return null;
            
        }

        public N Click(int index)
        {
            var driver = this.WebDriver;
            return Click(driver, index);
        }

        public N Click(IWebDriver driver, int index)
        {
            var element = GetElements(driver, "a");
            element[index].Click();

            return this.NewView;
        }
        public T Exists(IWebDriver driver)
        {
            return this.Exists(driver, "");
        }
        public T Exists()
        {
            var driver = this.WebDriver;
            return this.Exists(driver);
        }
    }
}
