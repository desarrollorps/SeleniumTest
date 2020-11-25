using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.Interactables;
using RPSSeleniumProperties.Interfaces.viewmodels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interactables
{
    public class RPSTextBox<T> :SeleniumInteractable<T>, IRPSTextBox<T> where T:class,IView
    {
       

        

        public T Read(out string value)
        {
            var driver = this.WebDriver;
            return Read(driver, out value);
            
        }
        public T Read(IWebDriver driver,out string value)
        {
            var element = this.GetElement(driver, new string[] { "input","textarea" });
            value = element.GetAttribute("value");
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
            var element = this.GetElement(driver, new string[] { "input", "textarea" });
            //new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"[id='{this.ID}'] input")));
            element.Click();
            element.Clear();
            element.SendKeys(Keys.Home + text + Keys.Tab);
            return this.View;
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
