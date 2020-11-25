using OpenQA.Selenium;
using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.Interactables;
using RPSSeleniumProperties.Interfaces.viewmodels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interactables
{
    public class RPSCheckbox<T> : SeleniumInteractable<T>,IRPSCheckbox<T> where T:class,IView
    {
      
      

        public T Check(IWebDriver driver)
        {
            var element = GetElement(driver, "label[class='rps-checkbox-label style-checkbox']");
            string content = GetPseudoElement(driver, "label[class='rps-checkbox-label style-checkbox']", ":before");
            if (string.IsNullOrEmpty(content) || content == "\"\"")
            {
                element.Click();
            }

            return this.View;
        }
        public T Check()
        {
            var driver = this.WebDriver;
            Check(driver);
            return this.View;
        }

        public T Click()
        {
            var driver = this.WebDriver;
            Click(driver);
            return this.View;
        }
        public T Click(IWebDriver driver)
        {

            var element = GetElement(driver, "label[class='rps-checkbox-label style-checkbox']");
            element.Click();

            return this.View;
        }

        public bool IsChecked(IWebDriver driver)
        {
            var element = GetElement(driver, "label[class='rps-checkbox-label style-checkbox']");
            string content = GetPseudoElement(driver, "label[class='rps-checkbox-label style-checkbox']", ":before");
            return !string.IsNullOrEmpty(content);
        }

        public T Uncheck(IWebDriver driver)
        {
            var element = GetElement(driver, "label[class='rps-checkbox-label style-checkbox']");
            string content = GetPseudoElement(driver, "label[class='rps-checkbox-label style-checkbox']", ":before");
            if ((!string.IsNullOrEmpty(content) || content == "\"\""))
            {
                element.Click();
            }

            return this.View;

        }
        public bool IsChecked()
        {
            var driver = this.WebDriver;
            return IsChecked(driver);
            
        }

        public T Uncheck()
        {
            var driver = this.WebDriver;
            return Uncheck(driver);
        }
        public T Exists(IWebDriver driver)
        {
            return this.Exists(driver, "label[class='rps-checkbox-label style-checkbox']");
        }
        public T Exists()
        {
            var driver = this.WebDriver;
            return this.Exists(driver);
        }
    }
}
