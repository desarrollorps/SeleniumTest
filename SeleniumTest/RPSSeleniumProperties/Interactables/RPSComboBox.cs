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
                element.Clear();
                element.SendKeys(Keys.Tab);
            
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
