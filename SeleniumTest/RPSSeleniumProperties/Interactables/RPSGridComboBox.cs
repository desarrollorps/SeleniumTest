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


            var combo = GetElements(driver, "div.rps-editor-editor.rps-editor-viewer.rps-semantic-state")[row];
            combo.Click();

            var element = GetElement(driver, "input");
            element.Click();
            element.Clear();
            element.SendKeys(Keys.Tab);

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
        public T Select(int row,IWebDriver driver, int index)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                var combo = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"[id='{this.ID}'] div.rps-button-button.rps-editor-editor.k-button.k-button-icon")));
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
            {
                var combo = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"{this.CSSSelector} div.rps-button-button.rps-editor-editor.k-button.k-button-icon")));
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
            if (!string.IsNullOrEmpty(ID))
            {
                var combo = GetElements(driver, "div.rps-editor-editor.rps-editor-viewer.rps-semantic-state")[row];
                combo.Click();

                var element = GetElement(driver, "input");
                element.Click();
                element.Clear();
                element.SendKeys(Keys.Home + text + Keys.Tab);
            }
            else
            {
                var combo = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"{this.CSSSelector} div.rps-editor-editor.rps-editor-viewer.rps-semantic-state")));
                combo.Click();
                var element = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"{this.CSSSelector} input")));
                element.Click();
                element.Clear();
                element.SendKeys(Keys.Home + text + Keys.Tab);
            }
            return this.View;
        }
        public T Exists(int row, IWebDriver driver)
        {
            var combo = GetElements(driver, "div.rps-editor-editor.rps-editor-viewer.rps-semantic-state")[row];
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


            var combo = GetElements(driver, "span.rps-editor-editor.rps-semantic-state")[row];
            combo.Click();

            var element = GetElement(driver, "input");
            element.Click();
            element.Clear();
            element.SendKeys(Keys.Tab);

            return this.View;
        }


        public string GetSelected(int row)
        {
            var driver = this.WebDriver;
            return this.GetSelected(row,driver);
        }
        public string GetSelected(int row,IWebDriver driver)
        {

            var a = GetElements(driver, "input")[row];
            var str = a.GetProperty("value");
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
                var a = GetElements(driver, "input")[row];
                var str = a.GetProperty("value");
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
            if (!string.IsNullOrEmpty(ID))
            {
                var combo = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"[id='{this.ID}'] span.k-i-arrow-60-down")));
                combo.Click();
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

            }
            else
            {
                var combo = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"{this.CSSSelector} span.k-i-arrow-60-down")));
                combo.Click();
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
            }
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
            if (!string.IsNullOrEmpty(ID))
            {
                var combo = GetElements(driver, "span.rps-editor-editor.rps-semantic-state")[row];
                combo.Click();

                var element = GetElement(driver, "input");
                element.Click();
                element.Clear();
                element.SendKeys(Keys.Home + text + Keys.Tab);
            }
            else
            {
                var combo = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"{this.CSSSelector} span.rps-editor-editor.rps-semantic-state")));
                combo.Click();
                var element = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"{this.CSSSelector} input")));
                element.Click();
                element.Clear();
                element.SendKeys(Keys.Home + text + Keys.Tab);
            }
            return this.View;
        }
        public T Exists(int row,IWebDriver driver)
        {
            var combo = GetElements(driver, "span.rps-editor-editor.rps-semantic-state")[row];
            return this.View;
        }
        public T Exists(int row)
        {
            var driver = this.WebDriver;
            return this.Exists(row,driver);
        }
    }
}
