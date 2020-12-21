using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.Interactables;
using RPSSeleniumProperties.Interfaces.viewmodels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interactables
{
    public class RPSTextBox<T> :SeleniumInteractable<T>, IRPSTextBox<T> where T:class,IView
    {
       

        

        public T Read(out string value)
        {
            var driver = this.WebDriver;
            return Read(driver, out value);
            
        }
        public T Read(IWebDriver driver,out string value)
        {
            var element = this.GetElement(driver, new string[] { "input","textarea" });
            value = element.GetAttribute("value");
            return this.View;

        }

        public T Write(string text)
        {
           
                var driver = this.WebDriver;
                this.Write(text, driver);
            return this.View;
            
        }
        public T Write(string text, IWebDriver driver)
        {
            var element = this.GetElement(driver, new string[] { "input", "textarea" });
            //new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"[id='{this.ID}'] input")));
            element.Click();
            
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(text+Keys.Tab);
            //BrowserElements.GetElementXPATH(driver, "//body").Click();
            return this.View;
        }

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

    public class RPSFormattedTextBox<T> : RPSTextBox<T>, IRPSTextBox<T> where T : class, IView
    {
        public T Read(out string value)
        {
            var driver = this.WebDriver;
            return Read(driver, out value);

        }
        public T Read(IWebDriver driver, out string value)
        {
            var element = this.GetElement(driver, new string[] { "input" });
            value = element.GetAttribute("value");
            return this.View;

        }

        public T Write(string text)
        {

            var driver = this.WebDriver;
            this.Write(text, driver);
            return this.View;

        }
        public T Write(string text, IWebDriver driver)
        {
            var element = this.GetElements(driver, new string[] { "input" });
            var style = element[0].GetAttribute("style");
            //new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"[id='{this.ID}'] input")));
            if (string.IsNullOrEmpty(style))
            {
                element[0].Click();
            }
            var element2 = this.GetElement(driver, new string[] { "input:nth-of-type(2)" });
            //element2.Clear();
            element2.SendKeys(Keys.Control + "a");
            element2.SendKeys(text+Keys.Tab);
            
            return this.View;
        }

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

    public class RPSTimeTextBox<T> : RPSFormattedTextBox<T>, IRPSTimeTextBox<T> where T : class, IView
    {
        public T Read(out string value)
        {
            var driver = this.WebDriver;
            return Read(driver, out value);

        }
        public T Read(IWebDriver driver, out string value)
        {
            var element = this.GetElement(driver, new string[] { "input" });
            value = element.GetAttribute("value");
            return this.View;

        }

        public T Write(string text)
        {

            var driver = this.WebDriver;
            this.Write(text, driver);
            return this.View;

        }
        public T Write(string text, IWebDriver driver)
        {
            var element = this.GetElements(driver, new string[] { "input" });
            var style = element[0].GetAttribute("style");
            //new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"[id='{this.ID}'] input")));
            if (string.IsNullOrEmpty(style))
            {
                element[0].Click();
            }
            var element2 = this.GetElement(driver, new string[] { "input:nth-of-type(2)" });
            //element2.Clear();
            element2.SendKeys(Keys.Control + "a");
            element2.SendKeys(text + Keys.Tab);

            return this.View;
        }

        public T Exists(IWebDriver driver)
        {
            return this.Exists(driver, "");
        }
        public T Exists()
        {
            var driver = this.WebDriver;
            return this.Exists(driver);
        }

        public T SelectTimeType(IWebDriver driver, int index)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                var combo = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"[id='{this.ID}'] span.k-i-arrow-60-down")));
                combo.Click();
                var main = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).
                Until(drv =>
                {
                    var elements = drv.FindElements(By.CssSelector($"div.k-list-container.k-popup.k-group ul li"));
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
                var combo = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"{this.CSSSelector} span.k-i-arrow-60-down")));
                combo.Click();
                var main = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).
                Until(drv =>
                {
                    var elements = drv.FindElements(By.CssSelector($"div.k-list-container.k-popup.k-group ul li"));
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

        public T SelectTimeType(int index)
        {
            var driver = this.WebDriver;
            return SelectTimeType(driver, index);
        }
    }
}
