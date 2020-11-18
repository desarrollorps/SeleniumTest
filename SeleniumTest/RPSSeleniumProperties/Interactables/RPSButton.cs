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
    public class RPSButton<T> : SeleniumInteractable<T>,IRPSButton<T> where T : class, IView
    {
              
      
        public T Click()
        {
            var driver = this.WebDriver;
            Click(driver);
            return this.View;
        }
        public T Click(IWebDriver driver)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                var element = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.Id(this.ID)));
                element.Click();
            }
            else
            {
                var element = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector(this.CSSSelector)));
                element.Click();
            }
            return this.View;
        }
    }
    public class RPSButton<T,N> : RPSButton<T>, IRPSButton<T,N> where T : class, IView where N:class,IView
    {
       public N NewView { get; set; }
        public  N Click()
        {
            base.Click();
            
            return NewView as N;
        }

        public  N Click(IWebDriver driver) 
        {
            base.Click(driver);
            return NewView as N;
        }
    }
}
