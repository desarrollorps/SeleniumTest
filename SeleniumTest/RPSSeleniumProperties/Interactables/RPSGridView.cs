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
        public N AddItem(IWebDriver driver)
        {
            var element = this.GetElement(".rps-stack-panel-item span.fa-plus");
            element.Click();
            return NewView;
        }
        public T DeleteItem(IWebDriver driver, int index)
        {
            var elements = this.GetElements(driver,".ag-pinned-left-cols-container .rps-grid-remove-command");
            var element = elements[index];
            element.Click();
            return CurrentView;
        }
        public N NavigateToItem(IWebDriver driver, int index)
        {
            var elements = this.GetElements(driver,".ag-pinned-left-cols-container .rps-grid-navigate-command");
            var element = elements[index];
            element.Click();
            return NewView;
        }
        public T AddInlineRow()
        {
            var driver = this.WebDriver;
            return AddInlineRow(driver);
        }
        public N AddItem()
        {
            var driver = this.WebDriver;
            return AddItem(driver);
        }
        public T DeleteItem(int index)
        {
            var driver = this.WebDriver;
            return DeleteItem(driver, index);
        }
        public N NavigateToItem(int index)
        {
            var driver = this.WebDriver;
            return NavigateToItem(driver, index);
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
        public T DeleteItem(IWebDriver driver, int index)
        {
            var elements = this.GetElements(driver, ".ag-pinned-left-cols-container .rps-grid-remove-command");
            var element = elements[index];
            element.Click();
            return CurrentView;
        }
        public T DeleteItem(int index)
        {
            var driver = this.WebDriver;
            return DeleteItem(driver, index);
        }

    }

}
