using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.Interactables;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interactables
{
    public class RPSGridTextBox<T> : SeleniumInteractableOnGrid<T>, IRPSGridTextBox<T> where T : class, IView
    {
        
        public T Exists(int row, IWebDriver driver)
        {
            var elements = this.GetElement(driver,row, "div:first-child");
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
            var element = this.GetElement(driver,row, new string[] { "input", "textarea" });
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
            var element = this.GetElement(driver,row, "");

            element.Click();
            var input = this.GetElement(driver,row, new string[] { "input"});
            //var inpt = BrowserElements.GetElement(driver,input.Element);
            input.Click();
            input.SelectTextOnInput();//SendKeys(Keys.Control + "a");
            input.WriteOnInput(text);//.SendKeys(text + Keys.Tab);
            SeleniumWebElement.ClickOnBlankPage(driver);
            return this.View;
        }       
       
    }
    public class RPSGridEmailTextBox<T> : SeleniumInteractableOnGrid<T>, IRPSGridTextBox<T> where T : class, IView
    {        


        public T Read(int row,out string value)
        {
            var driver = this.WebDriver;
            return Read(row,driver, out value);

        }
        public T Read(int row,IWebDriver driver, out string value)
        {
            var element = this.GetElement(driver,row, new string[] { "a" });
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
            var element = this.GetElement(driver, row, "");

            element.Click();
            var elementInput = this.GetElement(driver,row, new string[] { "input" });
            elementInput.SelectTextOnInput();//.SendKeys(Keys.Control + "a");
            elementInput.WriteOnInput(text);
            SeleniumWebElement.ClickOnBlankPage(driver);
            //BrowserElements.GetElementXPATH(driver, "//body").Click();
            return this.View;
        }

        public T Exists(int row, IWebDriver driver)
        {
            var elements = this.GetElement(driver,row, "rps-editor div");
            return this.View;
        }
        public T Exists(int row)
        {
            var driver = this.WebDriver;
            return this.Exists(row, driver);
        }        

    }

    

    public class RPSGridFormattedTextBox<T> : SeleniumInteractableOnGrid<T>, IRPSGridTextBox<T> where T : class, IView
    {
        
        public T Read(int row,out string value)
        {
            var driver = this.WebDriver;
            return Read(row,driver, out value);

        }
        public T Read(int row, IWebDriver driver, out string value)
        {
            var element = this.GetElement(driver,row, new string[] { "input" });
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
            var element = this.GetElement(driver, row, "");
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
            var element2 = this.GetElement(driver,row, new string[] { "input[data-role]" });
            //element2.Clear();
            element2.SelectTextOnInput();//Keys.Control + "a");
            element2.WriteOnInput(text);
            SeleniumWebElement.ClickOnBlankPage(driver);
            return this.View;
        }

        public T Exists(int row, IWebDriver driver)
        {
            var element = this.GetElement(driver,row, new string[] { "input" });
            return this.View;
        }
        public T Exists(int row)
        {
            var driver = this.WebDriver;
            return this.Exists(row,driver);
        }     
    }

    public class RPSGridDurationTextBox<T> : SeleniumInteractableOnGrid<T>, IRPSGridDurationTextBox<T> where T : class, IView
    {
       
        public T Read(int row,out string value)
        {
            var driver = this.WebDriver;
            return Read(row,driver, out value);

        }
        public T Read(int row,IWebDriver driver, out string value)
        {
            var element = this.GetElement(driver,row, new string[] { "input" });
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

            var element = this.GetElement(driver, row, "");
            element.Click();
            var element2 = this.GetElement(driver,row, new string[] { "input:nth-of-type(2)" });
            //element2.Clear();
            element2.ClearOnInput();
            element2.WriteOnInput(text);
            SeleniumWebElement.ClickOnBlankPage(driver);

            return this.View;
        }

        public T Exists(int row, IWebDriver driver)
        {
            var element = this.GetElement(driver,row, new string[] { "input" });
            return this.View;
        }
        public T Exists(int row)
        {
            var driver = this.WebDriver;
            return this.Exists(row,driver);
        }

        public T SelectTimeType(int row,IWebDriver driver, int index)
        {
           
                var combo = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"{this.CSSSelector.Replace(SeleniumInteractableOnGridConstants.RowIndexPatter,this.GetRowIndexText(row))} span.k-i-arrow-60-down")));
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

    }

    public class RPSGridMemoTextBox<T> : SeleniumInteractableOnGrid<T>, IRPSGridTextBox<T> where T : class, IView
    {

        public T Read(int row, out string value)
        {
            var driver = this.WebDriver;
            return Read(row, driver, out value);

        }
        public T Read(int row, IWebDriver driver, out string value)
        {
            var element = this.GetElement(driver, row, new string[] { "div.rps-read-only-editor-container-in-grid" });
            value = element.Text;
            return this.View;

        }

        public T Write(int row, string text)
        {

            var driver = this.WebDriver;
            this.Write(row, text, driver);
            return this.View;

        }
        public T Write(int row, string text, IWebDriver driver)
        {
            var element = this.GetElement(driver, row, "div.rps-read-only-editor-container-in-grid");
            //var element = elements[row];
            element.Click();
            var button = this.GetElement(driver, row, "div.rps-grid-hover-button");
            button.Click();
            //el elemento tiene dos input pero solo uno visible
            /*var style = element.GetAttributeOnElemen("style");
            //new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"[id='{this.ID}'] input")));
            if (string.IsNullOrEmpty(style))
            {
                element.Click();
            }*/
            //cogemos el otro
            var element2 = BrowserElements.GetElementCSS(driver, "[id='read-only-editor-window'] div[contenteditable='true']");
            //element2.Clear();
            element2.Click();
            element2.SelectTextOnInput();//Keys.Control + "a");
            element2.WriteOnInput(text);
            var accept = BrowserElements.GetElementCSS(driver, "[id='read-only-editor-window'] div.rps-button-button.rps-editor-editor.k-button[type='button']");
            accept.Click();
            return this.View;
        }

        public T Exists(int row, IWebDriver driver)
        {
            var element = this.GetElement(driver, row, new string[] { "div.rps-read-only-editor-container-in-grid" });
            return this.View;
        }
        public T Exists(int row)
        {
            var driver = this.WebDriver;
            return this.Exists(row, driver);
        }
    }



}
