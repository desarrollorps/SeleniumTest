using OpenQA.Selenium;
using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.Interactables;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interactables
{
    public class RPSOption<T> : SeleniumInteractable<T>, IRPSOption<T> where T : class, IView
    {


        public T Click()
        {
            var driver = this.WebDriver;
            Click(driver);
            return this.View;
        }
        public T Click(IWebDriver driver)
        {

            var element = GetElement(driver, "input");
            element.Click();

            return this.View;
        }
        public T Exists(IWebDriver driver)
        {
            return this.Exists(driver, "input");
        }
        public T Exists()
        {
            var driver = this.WebDriver;
            return this.Exists(driver);
        }
    }
}
