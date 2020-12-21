using OpenQA.Selenium;
using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.Interactables;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interactables
{
    public class RPSGridTextBox<T> : RPSTextBox<T>, IRPSGridTextBox<T> where T : class, IView
    {
        public T Exists(int row, IWebDriver driver)
        {
            var elements = this.GetElements(driver, "")[row];
            return this.View;
        }

        public T Exists(int row)
        {
            var driver = this.WebDriver;
            return Exists(row, driver);
        }

        public T Read(int row, out string value)
        {
            var driver = this.WebDriver;
            return Read(row, driver, out value);
        }
        public T Read(int row,IWebDriver driver, out string value)
        {
            var element = this.GetElements(driver, new string[] { "input", "textarea" })[row];
            value = element.GetAttribute("value");
            return this.View;
        }

        public T Write(int row, string text)
        {
            var driver = this.WebDriver;
            return Write(row, text, driver);
        }

        public T Write(int row, string text, IWebDriver driver)
        {
            var element = this.GetElements(driver, "div:first-child")[row];
            
            element.Click();
            var input = this.GetElements(driver, new string[] { "input"})[row];            
            var inpt = BrowserElements.GetElement(driver,input);
            inpt.Click();
            inpt.Clear();
            inpt.SendKeys(Keys.Home + text + Keys.Tab);
            return this.View;
        }
    }

   
}
