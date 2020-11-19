using OpenQA.Selenium;
using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.Interactables;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interactables
{
    public class RPSSection<T>: SeleniumInteractable<T>,IRPSSection<T> where T : class, IView
    {
        public T Click()
        {
            var driver = this.WebDriver;
            Click(driver);
            return this.View;
        }
        public T Click(IWebDriver driver)
        {

            var element = GetElement(driver, "");
            element.Click();

            return this.View;
        }
    }
}
