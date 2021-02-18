using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.Interactables;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interactables
{
    public class RPSGridTextBox<T> : RPSTextBox<T>, IRPSGridTextBox<T> where T : class, IView
    {
        public string OriginalCssSelector { get; set; }
        public T Exists(int row, IWebDriver driver)
        {
            var elements = this.GetElements(driver, "div:first-child")[row];
            return this.View;
        }

        public T Exists(int row)
        {
            var driver = this.WebDriver;
            return Exists(row, driver);
        }

        public T Read(int row, out string value)
        {
            var driver = this.WebDriver;
            return Read(row, driver, out value);
        }
        public T Read(int row,IWebDriver driver, out string value)
        {
            var element = this.GetElements(driver, new string[] { "input", "textarea" })[row];
            value = element.GetValueOnInput();
            return this.View;
        }

        public T Write(int row, string text)
        {
            var driver = this.WebDriver;
            return Write(row, text, driver);
        }

        public T Write(int row, string text, IWebDriver driver)
        {
            var element = GetCurrentCellElement(driver, row);

            element.Click();
            var input = this.GetElement(driver, new string[] { "input"});
            //var inpt = BrowserElements.GetElement(driver,input.Element);
            input.Click();
            input.SelectTextOnInput();//SendKeys(Keys.Control + "a");
            input.WriteOnInput(text);//.SendKeys(text + Keys.Tab);
            SeleniumWebElement.ClickOnBlankPage(driver);
            return this.View;
        }
        private SeleniumWebElement GetCurrentCellElement(IWebDriver driver, int row)
        {
            CalculateCssSelector(row);
            var element = this.GetElement(driver, "");


            return element;
        }
        public void CalculateCssSelector(int row)
        {
            this.CSSSelector = OriginalCssSelector.Replace($".ag-row[role='row']", $".ag-row[role='row'][row-index='{row}']");
        }
    }
    public class RPSGridEmailTextBox<T> : RPSTextBox<T>, IRPSGridTextBox<T> where T : class, IView
    {

        public string OriginalCssSelector { get; set; }


        public T Read(int row,out string value)
        {
            var driver = this.WebDriver;
            return Read(row,driver, out value);

        }
        public T Read(int row,IWebDriver driver, out string value)
        {
            var element = this.GetElements(driver, new string[] { "a" })[row];
            value = element.GetAttributeOnElemen("href");
            return this.View;

        }

        public T Write(int row,string text)
        {

            var driver = this.WebDriver;
            this.Write(row,text, driver);
            return this.View;

        }
        public T Write(int row,string text, IWebDriver driver)
        {
            // var element = this.GetElements(driver, new string[] { "rps-editor div" })[row];
            var element = GetCurrentCellElement(driver, row);

            element.Click();
            var elementInput = this.GetElement(driver, new string[] { "input" });
            elementInput.SelectTextOnInput();//.SendKeys(Keys.Control + "a");
            elementInput.WriteOnInput(text);
            SeleniumWebElement.ClickOnBlankPage(driver);
            //BrowserElements.GetElementXPATH(driver, "//body").Click();
            return this.View;
        }

        public T Exists(int row, IWebDriver driver)
        {
            var elements = this.GetElements(driver, "rps-editor div")[row];
            return this.View;
        }
        public T Exists(int row)
        {
            var driver = this.WebDriver;
            return this.Exists(row, driver);
        }
        private SeleniumWebElement GetCurrentCellElement(IWebDriver driver, int row)
        {
            CalculateCssSelector(row);
            var element = this.GetElement(driver, "");


            return element;
        }
        public void CalculateCssSelector(int row)
        {
            this.CSSSelector = OriginalCssSelector.Replace($".ag-row[role='row']", $".ag-row[role='row'][row-index='{row}']");
        }

    }

    

    public class RPSGridFormattedTextBox<T> : RPSTextBox<T>, IRPSGridTextBox<T> where T : class, IView
    {
        public string OriginalCssSelector { get; set; }
        public T Read(int row,out string value)
        {
            var driver = this.WebDriver;
            return Read(row,driver, out value);

        }
        public T Read(int row, IWebDriver driver, out string value)
        {
            var element = this.GetElements(driver, new string[] { "input" })[row];
            value = element.GetValueOnInput();
            return this.View;

        }

        public T Write(int row,string text)
        {

            var driver = this.WebDriver;
            this.Write(row,text, driver);
            return this.View;

        }
        public T Write(int row,string text, IWebDriver driver)
        {
            var element = GetCurrentCellElement(driver, row);
            //var element = elements[row];
            element.Click();
            //el elemento tiene dos input pero solo uno visible
            /*var style = element.GetAttributeOnElemen("style");
            //new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"[id='{this.ID}'] input")));
            if (string.IsNullOrEmpty(style))
            {
                element.Click();
            }*/
            //cogemos el otro
            var element2 = this.GetElement(driver, new string[] { "input[data-role]" });
            //element2.Clear();
            element2.SelectTextOnInput();//Keys.Control + "a");
            element2.WriteOnInput(text);
            SeleniumWebElement.ClickOnBlankPage(driver);
            return this.View;
        }

        public T Exists(int row, IWebDriver driver)
        {
            var element = this.GetElements(driver, new string[] { "input" })[row];
            return this.View;
        }
        public T Exists(int row)
        {
            var driver = this.WebDriver;
            return this.Exists(driver);
        }
        private SeleniumWebElement GetCurrentCellElement(IWebDriver driver, int row)
        {
            CalculateCssSelector(row);
            var element = this.GetElement(driver, "");


            return element;
        }
        public void CalculateCssSelector(int row)
        {
            this.CSSSelector = OriginalCssSelector.Replace($".ag-row[role='row']", $".ag-row[role='row'][row-index='{row}']");
        }
    }

    public class RPSGridDurationTextBox<T> : RPSFormattedTextBox<T>, IRPSGridDurationTextBox<T> where T : class, IView
    {
        public string OriginalCssSelector { get; set; }
        public T Read(int row,out string value)
        {
            var driver = this.WebDriver;
            return Read(row,driver, out value);

        }
        public T Read(int row,IWebDriver driver, out string value)
        {
            var element = this.GetElements(driver, new string[] { "input" })[row];
            value = element.GetValueOnInput();
            return this.View;

        }

        public T Write(int row,string text)
        {

            var driver = this.WebDriver;
            this.Write(row,text, driver);
            return this.View;

        }
        public T Write(int row,string text, IWebDriver driver)
        {

            var element = GetCurrentCellElement(driver, row);
            element.Click();
            var element2 = this.GetElement(driver, new string[] { "input:nth-of-type(2)" });
            //element2.Clear();
            element2.ClearOnInput();
            element2.WriteOnInput(text);
            SeleniumWebElement.ClickOnBlankPage(driver);

            return this.View;
        }

        public T Exists(int row, IWebDriver driver)
        {
            var element = this.GetElements(driver, new string[] { "input" })[row];
            return this.View;
        }
        public T Exists(int row)
        {
            var driver = this.WebDriver;
            return this.Exists(row,driver);
        }

        public T SelectTimeType(int row,IWebDriver driver, int index)
        {
           
                var combo = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElements(By.CssSelector($"{this.CSSSelector} span.k-i-arrow-60-down")))[row];
            var seleniumCombo = new SeleniumWebElement(combo);
            seleniumCombo.Click();
                var main = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).
                Until(drv =>
                {
                    var elements = drv.FindElements(By.CssSelector($"div[style*='display: block'].k-list-container.k-popup ul li"));
                    if (elements.Count > 0)
                    {
                        return elements;
                    }
                    else
                    {
                        return null;
                    }

                });
                var clickable = BrowserElements.GetElement(driver, main[index]);
                clickable.Click();
           
            return this.View;
        }

        public T SelectTimeType(int row,int index)
        {
            var driver = this.WebDriver;
            return SelectTimeType(row,driver, index);
        }
        private SeleniumWebElement GetCurrentCellElement(IWebDriver driver, int row)
        {
            CalculateCssSelector(row);
            var element = this.GetElement(driver, "");
            
            
            return element;
        }
        public void CalculateCssSelector(int row)
        {
            this.CSSSelector = OriginalCssSelector.Replace($".ag-row[role='row']", $".ag-row[role='row'][row-index='{row}']");
        }

    }
    


}
