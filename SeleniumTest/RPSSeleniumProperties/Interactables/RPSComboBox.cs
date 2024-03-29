﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.Interactables;
using RPSSeleniumProperties.Interfaces.viewmodels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interactables
{
    public class RPSComboBox<T> : SeleniumInteractable<T>,IRPSComboBox<T> where T:class,IView
    {
      

        

        public T Clear()
        {
            var driver = this.WebDriver;
            this.Clear(driver);
            return this.View;
        }
        public T Clear(IWebDriver driver)
        {
            
            
                var combo = GetElement(driver, "div.rps-editor-editor.rps-editor-viewer.rps-semantic-state");
                combo.Click();
            
                var element = GetElement(driver, "input");
                element.Click();
                element.ClearOnInput();
                element.TabOnInput();
            
            return this.View;
        }


        public string GetSelected()
        {
            var driver = this.WebDriver;
            return this.GetSelected(driver);
        }
        public string GetSelected(IWebDriver driver)
        {

            var a = GetElement(driver, "a");
            var str = a.Text;
            return str;
                
              
        }
        public bool HasSelectedItem()
        {
            var driver = this.WebDriver;
            return HasSelectedItem(driver);
        }
        public bool HasSelectedItem(IWebDriver driver)
        {
            try{
                var a = GetElement(driver, "a");
                if (a != null)
                {
                    return true;
                }else{
                    return false;
                }
            }catch
            {
                return false;
            }
        }

        public T Select(int index)
        {
            var driver = this.WebDriver;
            return Select(driver, index);
        }
        public T Select(IWebDriver driver, int index)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                var combo = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"[id='{this.ID}'] div.rps-button-button.rps-editor-editor.k-button.k-button-icon, [id='{this.ID}'] span.k-icon.k-i-arrow-60-down")));
                var el = new SeleniumWebElement(combo);
                el.Click();
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
                var it = main[index];
                var seleniumit = new SeleniumWebElement(it);
                seleniumit.Click();

            }
            else
            {
                var combo = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"{this.CSSSelector} div.rps-button-button.rps-editor-editor.k-button.k-button-icon, {this.CSSSelector} span.k-icon.k-i-arrow-60-down")));
                var el = new SeleniumWebElement(combo);
                el.Click();
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
                var it = main[index];
                var seleniumit = new SeleniumWebElement(it);
                seleniumit.Click();
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
            if (!string.IsNullOrEmpty(ID))
            {
                var combo = GetElement(driver, "div.rps-editor-editor.rps-editor-viewer.rps-semantic-state");
                combo.Click();

                var element = GetElement(driver, "input");
                element.Click();
                element.ClearOnInput();
                element.WriteAndTabOnInput(text);
            }
            else
            {
                var combo = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"{this.CSSSelector} div.rps-editor-editor.rps-editor-viewer.rps-semantic-state")));
                combo.Click();
                var element = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"{this.CSSSelector} input")));
                var el = new SeleniumWebElement(element);
                el.Click();
                el.ClearOnInput();
                el.WriteAndTabOnInput(text);
            }
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

    public class RPSEnumComboBox<T> : SeleniumInteractable<T>, IRPSComboBox<T> where T : class, IView
    {




        public T Clear()
        {
            var driver = this.WebDriver;
            this.Clear(driver);
            return this.View;
        }
        public T Clear(IWebDriver driver)
        {


            var combo = GetElement(driver, "span.rps-editor-editor.rps-semantic-state");
            combo.Click();

            var element = GetElement(driver, "input");
            element.Click();
            element.ClearOnInput();
            element.TabOnInput();

            return this.View;
        }


        public string GetSelected()
        {
            var driver = this.WebDriver;
            return this.GetSelected(driver);
        }
        public string GetSelected(IWebDriver driver)
        {

            var a = GetElement(driver, "input");
            var str = a.GetValueOnInput();
            return str;


        }
        public bool HasSelectedItem()
        {
            var driver = this.WebDriver;
            return HasSelectedItem(driver);
        }
        public bool HasSelectedItem(IWebDriver driver)
        {
            try
            {
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

        public T Select(int index)
        {
            var driver = this.WebDriver;
            return Select(driver, index);
        }
        public T Select(IWebDriver driver, int index)
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
                var clickable = BrowserElements.GetElement(driver,main[index]);
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

        public T Write(string text)
        {

            var driver = this.WebDriver;
            this.Write(text, driver);
            return this.View;

        }
        public T Write(string text, IWebDriver driver)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                var combo = GetElement(driver, "span.rps-editor-editor.rps-semantic-state");
                combo.Click();

                var element = GetElement(driver, "input");
                element.Click();
                element.ClearOnInput();
                element.WriteAndTabOnInput(text);
            }
            else
            {
                var combo = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"{this.CSSSelector} span.rps-editor-editor.rps-semantic-state")));
                combo.Click();
                var element = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"{this.CSSSelector} input")));
                var el = new SeleniumWebElement(element);
                el.Click();
                el.ClearOnInput();
                el.WriteAndTabOnInput(text);
            }
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
}
