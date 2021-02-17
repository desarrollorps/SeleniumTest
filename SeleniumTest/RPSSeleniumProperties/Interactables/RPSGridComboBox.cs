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
    public class RPSGridComboBox<T> : SeleniumInteractable<T>, IRPSGridComboBox<T> where T : class, IView
    {




        public T Clear(int row)
        {
            var driver = this.WebDriver;
            this.Clear(row,driver);
            return this.View;
        }
        public T Clear(int row,IWebDriver driver)
        {



            var cell = this.GetElements(driver, "")[row];// new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"{this.CSSSelector}")));
            cell.Click();


            var element = this.GetElement(driver, new string[] { "input" });
            element.Click();
            element.ClearOnInput();
            element.TabOnInput(); ;

            return this.View;
        }


        public string GetSelected(int row)
        {
            var driver = this.WebDriver;
            return this.GetSelected(row,driver);
        }
        public string GetSelected(int row,IWebDriver driver)
        {

            var a = GetElements(driver, "a")[row];
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
                
                var a = GetElements(driver, "a")[row];
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
            /*
            if (!string.IsNullOrEmpty(ID))
            {
                var cell = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"[id='{this.ID}']")));
                cell.Click();
                var combo = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"[id='{this.ID}'] k-icon.k-i-arrow-60-down")));
                combo.Click();
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
                main[index].Click();

            }
            else
            {*/
            var cell = this.GetElements(driver, "")[row];// new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"{this.CSSSelector}")));
                cell.Click();
                //var combo = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"{this.CSSSelector} k-icon.k-i-arrow-60-down")));
                var comboarrow = this.GetElement(driver, " span.k-icon.k-i-arrow-60-down");
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
                main[index].Click();
                var elementInput = this.GetElement(driver, new string[] { "input" });
            elementInput.TabOnInput();
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

            var cell = this.GetElements(driver, "")[row];// new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"{this.CSSSelector}")));
            cell.Click();


                var element = this.GetElement(driver, new string[] { "input" });
                 element.Click();
                element.ClearOnInput();
                element.WriteAndTabOnInput(text);
            
            return this.View;
        }
        public T Exists(int row, IWebDriver driver)
        {
            var cell = this.GetElements(driver, "")[row];
            return this.View;
        }
        public T Exists(int row)
        {
            var driver = this.WebDriver;
            return this.Exists(row,driver);
        }
    }

    public class RPSGridEnumComboBox<T> : SeleniumInteractable<T>, IRPSGridComboBox<T> where T : class, IView
    {




        public T Clear(int row)
        {
            var driver = this.WebDriver;
            this.Clear(row,driver);
            return this.View;
        }
        public T Clear(int row,IWebDriver driver)
        {


            var cell = this.GetElements(driver, "")[row];// new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"{this.CSSSelector}")));
            cell.Click();


            var element = this.GetElement(driver, new string[] { "input" });
            element.Click();
            element.ClearOnInput();
            element.TabOnInput();

            

            return this.View;
        }


        public string GetSelected(int row)
        {
            var driver = this.WebDriver;
            return this.GetSelected(row,driver);
        }
        public string GetSelected(int row,IWebDriver driver)
        {
            var cell = this.GetElements(driver, "")[row];
            cell.Click();
            var a = GetElement(driver, "input");
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
                var cell = this.GetElements(driver, "")[row];
                cell.Click();
                var a = GetElement(driver, "input");
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
            var cell = this.GetElements(driver, "")[row];// new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"{this.CSSSelector}")));
            
            //cell.Click();
            cell.Click();
            //var combo = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"{this.CSSSelector} k-icon.k-i-arrow-60-down")));
            var comboarrow = this.GetElement(driver, " span.k-icon.k-i-arrow-60-down");
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
            main[index].Click();
            var elementInput = this.GetElement(driver, new string[] { "input" });
            elementInput.TabOnInput();
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
            var cell = this.GetElements(driver, "")[row];// new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"{this.CSSSelector}")));
            cell.Click();


            var element = this.GetElement(driver, new string[] { "input" });
            element.Click();
            element.ClearOnInput();
            element.WriteAndTabOnInput(text);

            return this.View;
        }
        public T Exists(int row,IWebDriver driver)
        {
            var cell = this.GetElements(driver, "")[row];
            return this.View;
        }
        public T Exists(int row)
        {
            var driver = this.WebDriver;
            return this.Exists(row,driver);
        }
    }
}
