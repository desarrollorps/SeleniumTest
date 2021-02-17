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
            var elements = this.GetElements(driver, "div:first-child")[row];
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
            value = element.GetValueOnInput();
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
            var inpt = BrowserElements.GetElement(driver,input.Element);
            inpt.Click();
            inpt.ClearOnInput();//SendKeys(Keys.Control + "a");
            inpt.WriteAndTabOnInput(text);//.SendKeys(text + Keys.Tab);
            return this.View;
        }
    }
    public class RPSGridEmailTextBox<T> : RPSTextBox<T>, IRPSTextBox<T> where T : class, IView
    {




        public T Read(out string value)
        {
            var driver = this.WebDriver;
            return Read(driver, out value);

        }
        public T Read(IWebDriver driver, out string value)
        {
            var element = this.GetElement(driver, new string[] { "a" });
            value = element.GetAttributeOnElemen("href");
            return this.View;

        }

        public T Write(string text)
        {

            var driver = this.WebDriver;
            this.Write(text, driver);
            return this.View;

        }
        public T Write(string text, IWebDriver driver)
        {
            var element = this.GetElement(driver, new string[] { "rps-editor div" });
            //new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"[id='{this.ID}'] input")));
            element.Click();
            var elementInput = this.GetElement(driver, new string[] { "input" });
            elementInput.ClearOnInput();//.SendKeys(Keys.Control + "a");
            elementInput.WriteAndTabOnInput(text);
            //BrowserElements.GetElementXPATH(driver, "//body").Click();
            return this.View;
        }

        public T Exists(int row, IWebDriver driver)
        {
            var elements = this.GetElements(driver, "rps-editor div")[row];
            return this.View;
        }
        public T Exists(int row)
        {
            var driver = this.WebDriver;
            return this.Exists(row, driver);
        }

    }


}
