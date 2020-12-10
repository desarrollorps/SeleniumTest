using OpenQA.Selenium;
using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.Interactables;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interactables
{
    public class RPSCollectionEditor<T,N>:SeleniumInteractable<T>, IRPSCollectionEditor<T,N> where T : class, IView where N : class, IView
    {
        public N NewView;
        public IRPSDescriptorView<T,N> DescriptorView { get; set; }
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
    public class RPSCollectionEditor<T> : SeleniumInteractable<T>, IRPSCollectionEditor<T> where T : class, IView
    {
           
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
