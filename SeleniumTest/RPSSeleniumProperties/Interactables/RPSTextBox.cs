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
            var element = this.GetElement(driver, new string[] { "input", "textarea", "div.rps-long-text-box-input" });
            if (element.Element.TagName.ToUpper() == "DIV")
            {
                var p = this.GetElement("div.rps-long-text-box-input p");
                value = p.Text;
            }
            else
            {
                value = element.GetValueOnInput();
            }
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
            var element = this.GetElement(driver, new string[] { "input", "textarea", "div.rps-long-text-box-input" });
            //new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"[id='{this.ID}'] input")));
            element.Click();
            if (element.Element.TagName.ToUpper() == "DIV")
            {
                element.SelectTextOnInput();
                element.WriteOnInput(text);
                SeleniumWebElement.ClickOnBlankPage(driver);
            }
            else
            {
                element.SelectTextOnInput();//.SendKeys(Keys.Control + "a");
                element.WriteAndTabOnInput(text);//.SendKeys(text+Keys.Tab);
            }
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

    public class RPSEmailTextBox<T> : RPSTextBox<T>, IRPSTextBox<T> where T : class, IView
    {




        public T Read(out string value)
        {
            var driver = this.WebDriver;
            return Read(driver, out value);

        }
        public T Read(IWebDriver driver, out string value)
        {
            var element = this.GetElement(driver, new string[] { "a" });
            value = element.GetAttributeOnElemen("href");
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
            var element = this.GetElement(driver, new string[] { "rps-editor div" });
            //new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"[id='{this.ID}'] input")));
            element.Click();
            var elementInput = this.GetElement(driver, new string[] { "input" });
            elementInput.SelectTextOnInput();//SendKeys(Keys.Control + "a");
            elementInput.WriteAndTabOnInput(text);
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
            value = element.GetValueOnInput();
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
            var style = element[0].GetAttributeOnElemen("style");
            //new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"[id='{this.ID}'] input")));
            if (string.IsNullOrEmpty(style))
            {
                element[0].Click();
            }
            var element2 = this.GetElement(driver, new string[] { "input:nth-of-type(2)" });
            //element2.Clear();
            element2.SelectTextOnInput();//Keys.Control + "a");
            element2.WriteAndTabOnInput(text);
            
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

    public class RPSDurationTextBox<T> : RPSFormattedTextBox<T>, IRPSDurationTextBox<T> where T : class, IView
    {
        public T Read(out string value)
        {
            var driver = this.WebDriver;
            return Read(driver, out value);

        }
        public T Read(IWebDriver driver, out string value)
        {
            var element = this.GetElement(driver, new string[] { "input" });
            value = element.GetValueOnInput();
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
            var style = element[0].GetAttributeOnElemen("style");
            //new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"[id='{this.ID}'] input")));
            if (string.IsNullOrEmpty(style))
            {
                element[0].Click();
            }
            var element2 = this.GetElement(driver, new string[] { "input:nth-of-type(2)" });
            //element2.Clear();
            element2.ClearOnInput();
            element2.WriteAndTabOnInput(text);

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

        public T SelectTimeType(int index)
        {
            var driver = this.WebDriver;
            return SelectTimeType(driver, index);
        }
    }
}
