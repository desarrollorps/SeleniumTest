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
    public class RPSAcceptButton<T,N>:RPSButton<T,N>, IRPSAcceptButton<T,N> where T : class, IView where N:class,IView
    {
        public new N Click()
        {
            base.Click();

            return NewView as N;
        }

        public new N Click(IWebDriver driver)
        {
            base.Click(driver);
            return NewView as N;
        }
    }
    public class RPSSaveButton<T>:RPSButton<T>, IRPSSaveButton<T> where T : class, IView
    {
     
        public new T Click()
        {
            var driver = this.WebDriver;
            return Click(driver);
        }

        public new T Click(IWebDriver driver)
        {
            base.Click(driver);
            if(GetSaveResult(driver))
            {
                return this.View;
            }
            throw new Exception("There are errors saving the screen");
            
        }
        private bool GetSaveResult(IWebDriver driver)
        {
            string errorlist = "rps-error-details-viewer li div[class*='rps-error']";
            string savenotification = "div[class*='k-animation-container'] div[class*='k-notification-wrap'] span[title='success']";
            var elements = BrowserElements.GetElementsCSS(driver, $"{savenotification},{errorlist}");
            var attr = elements[0].GetAttributeOnElemen("title");
            if (attr == "success")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
