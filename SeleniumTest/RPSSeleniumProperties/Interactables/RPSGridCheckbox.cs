﻿using OpenQA.Selenium;
using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.Interactables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSSeleniumProperties.Interactables
{
    public class RPSGridCheckbox<T> : SeleniumInteractable<T>, IRPSGridCheckbox<T> where T : class, IView
    {
        public string OriginalCssSelector { get; set; }
        

        public T Check(int row,IWebDriver driver)
        {
            CalculateCssSelector(row);
            var element = GetElement(driver, "label[class='rps-checkbox-label style-checkbox']");
            string content = GetPseudoElement(driver, "label[class='rps-checkbox-label style-checkbox']", ":before");
            if (string.IsNullOrEmpty(content) || content == "\"\"")
            {
                element.Click();
            }

            return this.View;
        }
        public T Check(int row)
        {
            var driver = this.WebDriver;
            return Check(row,driver);
            
        }

        public T Click(int row)
        {
            var driver = this.WebDriver;
            return Click(row,driver);
            
        }
        public T Click(int row,IWebDriver driver)
        {
            CalculateCssSelector(row);
            var element = GetElement(driver, "label[class='rps-checkbox-label style-checkbox']");
            element.Click();

            return this.View;
        }

        public bool IsChecked(int row,IWebDriver driver)
        {
            CalculateCssSelector(row);
            var element = GetElement(driver, "label[class='rps-checkbox-label style-checkbox']");
            string content = GetPseudoElement(driver, "label[class='rps-checkbox-label style-checkbox']", ":before");
            return !string.IsNullOrEmpty(content);
        }

        public T Uncheck(int row,IWebDriver driver)
        {
            CalculateCssSelector(row);
            var element = GetElement(driver, "label[class='rps-checkbox-label style-checkbox']");
            string content = GetPseudoElement(driver, "label[class='rps-checkbox-label style-checkbox']", ":before");
            if ((!string.IsNullOrEmpty(content) || content == "\"\""))
            {
                element.Click();
            }

            return this.View;

        }
        public bool IsChecked(int row)
        {
            var driver = this.WebDriver;
            return IsChecked(row,driver);

        }

        public T Uncheck(int row)
        {
            var driver = this.WebDriver;
            return Uncheck(row,driver);
        }
        public T Exists(int row, IWebDriver driver)
        {
            CalculateCssSelector(row);
            var elements = this.GetElement(driver, "label[class='rps-checkbox-label style-checkbox']");
            return this.View;
        }

        public T Exists(int row)
        {
            var driver = this.WebDriver;
            return Exists(row, driver);
        }
        public void CalculateCssSelector(int row)
        {
            this.CSSSelector = OriginalCssSelector.Replace($".ag-row[role='row']", $".ag-row[role='row'][row-index='{row}']");
        }
       


    }
}
