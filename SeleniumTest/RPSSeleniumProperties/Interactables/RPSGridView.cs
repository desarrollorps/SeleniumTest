using OpenQA.Selenium;
using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.Interactables;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interactables
{
    public class RPSGridView<T, N> : SeleniumInteractable<T>, IRPSGridView<T, N> where T : class, IView where N : class, IView
    {
        public N NewView { get; set; }

        public T CurrentView { get; set; }
        public T AddInlineRow(IWebDriver driver)
        {
            var element = this.GetElement(".ag-pinned-left-header .fa-plus-circle");
            element.Click();
            return CurrentView;
        }
        public T AddInlineRow()
        {
            var driver = this.WebDriver;
            return AddInlineRow(driver);
        }
      
    }

    public class RPSGridView<T> : SeleniumInteractable<T>, IRPSGridView<T> where T : class, IView
    {    
        public T CurrentView { get; set; }
        public T AddInlineRow(IWebDriver driver)
        {
            var element = this.GetElement(".ag-pinned-left-header .fa-plus-circle");
            element.Click();
            return CurrentView;
        }
        public T AddInlineRow()
        {
            var driver = this.WebDriver;
            return AddInlineRow(driver);
        }

    }

}
