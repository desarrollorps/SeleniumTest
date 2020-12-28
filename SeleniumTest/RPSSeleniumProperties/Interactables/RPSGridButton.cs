using OpenQA.Selenium;
using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.Interactables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSSeleniumProperties.Interactables
{
    public class RPSGridButton<T> : SeleniumInteractable<T>, IRPSGridButton<T> where T : class, IView
    {


        public T Click(int row)
        {
            var driver = this.WebDriver;
            Click(row, driver);
            return this.View;
        }
        public T Click(int row, IWebDriver driver)
        {

            var element = GetElements(driver, "div:first-child rps-button div.rps-button-button")[row];
            element.Click();

            return this.View;
        }
        public T Exists(int row, IWebDriver driver)
        {
            var element = GetElements(driver, "div:first-child rps-button div.rps-button-button")[row];
            return this.View;
            
        }
        public T Exists(int row)
        {
            var driver = this.WebDriver;
            return this.Exists(row, driver);
        }
    }
    public class RPSGridButton<T, N> : RPSGridButton<T>, IRPSGridButton<T, N> where T : class, IView where N : class, IView
    {
        public N NewView { get; set; }
        public new N Click(int row)
        {
            base.Click(row);

            return NewView as N;
        }

        public new N Click(int row,IWebDriver driver)
        {
            base.Click(row,driver);
            return NewView as N;
        }
    }
}
