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
    public class RPSCollectionComboBox<T> : SeleniumInteractable<T>,IRPSCollectionComboBox<T> where T:class,IView
    {
      
      

        public T Clear()
        {
            var driver = this.WebDriver;
            this.Clear(driver);
            return this.View;
        }
        public T Clear(IWebDriver driver)
        {
            var combo = GetElement(driver, "div.rps-editor-editor.k-multiselect.rps-semantic-state");
            combo.Click();

            var element = GetElement(driver, "input");
            element.Click();
            element.ClearOnInput();
            element.TabOnInput();
            return this.View;
        }

        public List<string> GetSelected()
        {
            var driver = this.WebDriver;
            return this.GetSelected(driver);
        }
        public List<string> GetSelected(IWebDriver driver)
        {
            List<string> values = new List<string>();
            var items = GetElements(driver, "div.rps-editor-editor.k-multiselect.rps-semantic-state ul li div.rps-multi-lookup-popup-item-text");
            foreach(var it in items)
            {
                values.Add(it.Text);
            }
            return values;
        }

        public bool HasSelectedItems()
        {
            var driver = this.WebDriver;
            return HasSelectedItems(driver);
        }
        public bool HasSelectedItems(IWebDriver driver)
        {
            return GetSelected().Count > 0;
        }

        public bool IsSelected(int index)
        {
            var driver = this.WebDriver;
            return IsSelected(index,driver);
        }
        public bool IsSelected(int index, IWebDriver driver)
        {
            var items = GetSelected(driver);
            if (index > items.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public T Select(int index)
        {
            var driver = this.WebDriver;
            return Select(index,driver);
        }
        public T Select(int index, IWebDriver driver)
        {
           
                var combo = GetElement(driver, "div.rps-editor-editor.k-multiselect.rps-semantic-state");

                // new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector($"[id='{this.ID}'] div.rps-button-button.rps-editor-editor.k-button.k-button-icon")));
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

           
            return this.View;
        }

        public T UnSelect(int index)
        {
            var driver = this.WebDriver;
            return UnSelect(index, driver);
        }
        public T UnSelect(int index, IWebDriver driver)
        {
            var items = GetElements(driver, "div.rps-editor-editor.k-multiselect.rps-semantic-state ul li span.k-select");
            items[index].Click();
            return this.View;
        }

        public T Write(string text)
        {
            var driver = this.WebDriver;
            return Write(text, driver);
        }
        public T Write(string text, IWebDriver driver)
        {
            var combo = GetElement(driver, "div.rps-editor-editor.k-multiselect.rps-semantic-state");
            combo.Click();

            var element = GetElement(driver, "input");
            element.WriteOnInput(text);
            return this.View;
        }
        public T Exists(IWebDriver driver)
        {
            var combo = GetElement(driver, "");
            return this.View;
        }
        public T Exists()
        {
            var driver = this.WebDriver;
            return Exists(driver);
        }
    }
}
