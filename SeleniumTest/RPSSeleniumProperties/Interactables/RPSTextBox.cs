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
       

        

        public string Read()
        {
            throw new NotImplementedException();
        }

        public T Write(string text)
        {
           
                var driver = this.WebDriver;
                this.Write(text, driver);
            return this.View;
            
        }
        public T Write(string text, IWebDriver driver)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                var element = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.Id(this.ID)));
                element.SendKeys(text);
            }
            else
            {
                var element = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector(this.CSSSelector)));
                element.SendKeys(text);
            }
            return this.View;
        }

    }
}
