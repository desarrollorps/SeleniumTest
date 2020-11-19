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

            var element = GetElement(driver, "");
            element.Click();

            return this.View;
        }
    }
    public class RPSButton<T,N> : RPSButton<T>, IRPSButton<T,N> where T : class, IView where N:class,IView
    {
       public N NewView { get; set; }
        public new  N Click()
        {
            base.Click();
            
            return NewView as N;
        }

        public new  N Click(IWebDriver driver) 
        {
            base.Click(driver);
            return NewView as N;
        }
    }
}
