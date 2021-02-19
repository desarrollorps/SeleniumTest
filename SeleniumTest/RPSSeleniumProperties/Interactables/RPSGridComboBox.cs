using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.Interactables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSSeleniumProperties.Interactables
{
    public class RPSGridComboBox<T> : SeleniumInteractableOnGrid<T>, IRPSGridComboBox<T> where T : class, IView
    {

        public string OriginalCssSelector { get; set; }


        public T Clear(int row)
        {
            var driver = this.WebDriver;
            this.Clear(row,driver);
            return this.View;
        }
        public T Clear(int row,IWebDriver driver)
        {


            var element = this.GetElement(driver,row, "");
            //var element = elements[row];
            element.Click();


            var elementi = this.GetElement(driver,row, new string[] { "input" });
            elementi.Click();
            elementi.ClearOnInput();
            elementi.TabOnInput(); ;

            return this.View;
        }


        public string GetSelected(int row)
        {
            var driver = this.WebDriver;
            return this.GetSelected(row,driver);
        }
        public string GetSelected(int row,IWebDriver driver)
        {

            var a = GetElement(driver,row, "a");
            var str = a.Text;
            return str;


        }
        public bool HasSelectedItem(int row)
        {
            var driver = this.WebDriver;
            return HasSelectedItem(row,driver);
        }
        public bool HasSelectedItem(int row,IWebDriver driver)
        {
            try
            {
                
                var a = GetElement(driver,row, "a");
                if (a != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public T Select(int row,int index)
        {
            var driver = this.WebDriver;
            return Select(row,driver, index);
        }
        public T Select(int row, IWebDriver driver, int index)
        {
            var element = this.GetElement(driver, row, "");
            //var element = elements[row];
            element.Click();
            //var combo = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"{this.CSSSelector} k-icon.k-i-arrow-60-down")));
            var comboarrow = this.GetElement(driver,row, " span.k-icon.k-i-arrow-60-down");
                comboarrow.Click();
                var main = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).
                Until(drv =>
                {
                    var elements = drv.FindElements(By.CssSelector($"div.rps-lookup-popup-item-text"));
                    if (elements.Count > 0)
                    {
                        return elements;
                    }
                    else
                    {
                        return null;
                    }

                });

            var el = main[index];
            var indexEl = new SeleniumWebElement(el);
            indexEl.Click();
            /*    var elementInput = this.GetElement(driver, new string[] { "input" });
            elementInput.TabOnInput();*/
            SeleniumWebElement.ClickOnBlankPage(driver);
            //main[index].SendKeys(Keys.Enter);
            //}
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

            var cell = this.GetElement(driver, row, "");
            cell.Click();


                var element = this.GetElement(driver,row, new string[] { "input" });
                 element.Click();
                element.ClearOnInput();
                element.WriteOnInput(text);
            SeleniumWebElement.ClickOnBlankPage(driver);

            return this.View;
        }
        public T Exists(int row, IWebDriver driver)
        {
            var cell = this.GetElement(driver,row, "");
            return this.View;
        }
        public T Exists(int row)
        {
            var driver = this.WebDriver;
            return this.Exists(row,driver);
        }
        
    }

    public class RPSGridEnumComboBox<T> : SeleniumInteractableOnGrid<T>, IRPSGridComboBox<T> where T : class, IView
    {

        public string OriginalCssSelector { get; set; }


        public T Clear(int row)
        {
            var driver = this.WebDriver;
            this.Clear(row,driver);
            return this.View;
        }
        public T Clear(int row,IWebDriver driver)
        {


            var element = this.GetElement(driver, row, "");
            //var element = elements[row];
            element.Click();


            var elementi = this.GetElement(driver,row, new string[] { "input" });
            elementi.Click();
            elementi.ClearOnInput();
            elementi.TabOnInput();

            

            return this.View;
        }


        public string GetSelected(int row)
        {
            var driver = this.WebDriver;
            return this.GetSelected(row,driver);
        }
        public string GetSelected(int row,IWebDriver driver)
        {
            var cell = this.GetElement(driver,row, "");
            cell.Click();
            var a = GetElement(driver,row, "input");
            var str = a.GetValueOnInput();
            return str;


        }
        public bool HasSelectedItem(int row)
        {
            var driver = this.WebDriver;
            return HasSelectedItem(row,driver);
        }
        public bool HasSelectedItem(int row,IWebDriver driver)
        {
            try
            {
                var cell = this.GetElement(driver,row, "");
                cell.Click();
                var a = GetElement(driver,row, "input");
                var str = a.GetValueOnInput();
                if (!string.IsNullOrEmpty(str))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public T Select(int row,int index)
        {
            var driver = this.WebDriver;
            return Select(row,driver, index);
        }
        public T Select(int row,IWebDriver driver, int index)
        {
            var element = this.GetElement(driver, row, "");
            //var element = elements[row];
            element.Click();
            //var combo = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"{this.CSSSelector} k-icon.k-i-arrow-60-down")));
            var comboarrow = this.GetElement(driver,row, " span.k-icon.k-i-arrow-60-down");
            comboarrow.Click();
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
            var el = main[index];
            var indexEl = new SeleniumWebElement(el);
            indexEl.Click();
            SeleniumWebElement.ClickOnBlankPage(driver);
            /*var elementInput = this.GetElement(driver, new string[] { "input" });
            elementInput.TabOnInput();*/
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
            var cell = this.GetElement(driver, row, "");
            cell.Click();


            var element = this.GetElement(driver,row, new string[] { "input" });
            element.Click();
            element.ClearOnInput();
            element.WriteOnInput(text);
            SeleniumWebElement.ClickOnBlankPage(driver);

            return this.View;
        }
        public T Exists(int row,IWebDriver driver)
        {
            var cell = this.GetElement(driver,row, "");
            return this.View;
        }
        public T Exists(int row)
        {
            var driver = this.WebDriver;
            return this.Exists(row,driver);
        }       

    }
}
