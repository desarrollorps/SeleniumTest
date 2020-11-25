﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.viewmodels;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RPSSeleniumProperties
{

    public class SeleniumInteractable<T> : ISeleniumInteractable<T> where T:class,IView
    {
        public string ID { get; set; }
        

        public IViewModelProperty ViewModelProperty { get; set; }
        public T View { get; set; }
        public IWebDriver WebDriver
        {
            get;set;
        }

        public string CSSSelector { get; set; }
        public string XPathSelector { get; set; }
        public virtual IWebElement GetElement( string afterelement)
        {
            var driver = this.WebDriver;
            return GetElement(driver, afterelement);
        }
        public virtual IWebElement GetElement(IWebDriver driver,string afterelement)
        {
            if (!string.IsNullOrEmpty(this.ID))
            {
                return BrowserElements.GetElementCSS(driver,$"[id = '{this.ID}'] {afterelement}".Trim());
            }else if (!string.IsNullOrEmpty(this.CSSSelector))
            {
                return BrowserElements.GetElementCSS(driver, $"{this.CSSSelector} {afterelement}".Trim());
            }
            else if (!string.IsNullOrEmpty(this.XPathSelector))
            {
                return BrowserElements.GetElementXPATH(driver, $"{this.XPathSelector} {afterelement}".Trim());
            }
            else
            {
                return null;
            }
        }
        public T Exists(string afterelement)
        {
            var driver = this.WebDriver;
            return Exists(driver, afterelement);
        }
        public T Exists(IWebDriver driver, string afterelement)
        {
            IWebElement element;
            if (!string.IsNullOrEmpty(this.ID))
            {
                 element = BrowserElements.GetExistElementCSS(driver, $"[id = '{this.ID}'] {afterelement}".Trim());
            }
            else if (!string.IsNullOrEmpty(this.CSSSelector))
            {
                element = BrowserElements.GetExistElementCSS(driver, $"{this.CSSSelector} {afterelement}".Trim());
            }
            else if (!string.IsNullOrEmpty(this.XPathSelector))
            {
                element =  BrowserElements.GetExistElementXPATH(driver, $"{this.XPathSelector} {afterelement}".Trim());
            }
            else
            {
                return null;
            }
            return this.View;

        }
        public virtual ReadOnlyCollection<IWebElement> GetElements(IWebDriver driver, string afterelement)
        {
            if (!string.IsNullOrEmpty(this.ID))
            {
                return BrowserElements.GetElementsCSS(driver, $"[id = '{this.ID}'] {afterelement}".Trim());
            }
            else if (!string.IsNullOrEmpty(this.CSSSelector))
            {
                return BrowserElements.GetElementsCSS(driver, $"{this.CSSSelector} {afterelement}".Trim());
            }
            else if (!string.IsNullOrEmpty(this.XPathSelector))
            {
                return BrowserElements.GetElementsXPATH(driver, $"{this.XPathSelector} {afterelement}".Trim());
            }
            else
            {
                return null;
            }
        }
        public virtual IWebElement GetElement(IWebDriver driver, string[] afterelements)
        {
            List<string> selectors = new List<string>();
            if (!string.IsNullOrEmpty(this.ID))
            {
                foreach(var s in afterelements)
                {
                    selectors.Add($"[id = '{this.ID}'] {s}".Trim());
                }
                return BrowserElements.GetElementCSS(driver,  string.Join(" ,", selectors));
            }
            else if (!string.IsNullOrEmpty(this.CSSSelector))
            {
                foreach (var s in afterelements)
                {
                    selectors.Add($"{this.CSSSelector} {s}".Trim());
                }
                return BrowserElements.GetElementCSS(driver, string.Join(" ,", selectors));
            }
            else if (!string.IsNullOrEmpty(this.XPathSelector))
            {
                foreach (var s in afterelements)
                {
                    selectors.Add($"{this.XPathSelector} {s}".Trim());
                }
                return BrowserElements.GetElementXPATH(driver, string.Join(" ,", selectors));
            }
            else
            {
                return null;
            }
        }

        public virtual ReadOnlyCollection<IWebElement> GetElements(IWebDriver driver, string[] afterelements)
        {
            List<string> selectors = new List<string>();
            if (!string.IsNullOrEmpty(this.ID))
            {
                foreach (var s in afterelements)
                {
                    selectors.Add($"[id = '{this.ID}'] {s}".Trim());
                }
                return BrowserElements.GetElementsCSS(driver, string.Join(" ,", selectors));
            }
            else if (!string.IsNullOrEmpty(this.CSSSelector))
            {
                foreach (var s in afterelements)
                {
                    selectors.Add($"{this.CSSSelector} {s}".Trim());
                }
                return BrowserElements.GetElementsCSS(driver, string.Join(" ,", selectors));
            }
            else if (!string.IsNullOrEmpty(this.XPathSelector))
            {
                foreach (var s in afterelements)
                {
                    selectors.Add($"{this.XPathSelector} {s}".Trim());
                }
                return BrowserElements.GetElementsXPATH(driver, string.Join(" ,", selectors));
            }
            else
            {
                return null;
            }
        }
        public virtual string GetPseudoElement(IWebDriver driver, string afterelement,string pseudoelement)
        {
            if(!string.IsNullOrEmpty(this.ID))
            {
                return BrowserElements.GetPseudoElementContent(driver, $"[id = '{this.ID}'] {afterelement}".Trim(), pseudoelement);
            }
            else if (!string.IsNullOrEmpty(this.CSSSelector))
            {
                return BrowserElements.GetPseudoElementContent(driver, $"{this.CSSSelector} {afterelement}".Trim(), pseudoelement);
            }
            else if (!string.IsNullOrEmpty(this.XPathSelector))
            {
                return BrowserElements.GetPseudoElementContent(driver, $"{this.XPathSelector} {afterelement}".Trim(), pseudoelement);
            }
            else
            {
                return null;
            }
        }
    }
    public static class BrowserElements
    {
        

        public static IWebElement GetElementCSS(IWebDriver driver,string cssselector)
        {
            return new WebDriverWait(driver,
                new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).
                Until(
                ExpectedConditions.ElementToBeClickable(By.CssSelector(cssselector)));
                //drv => drv.FindElement(By.CssSelector(cssselector)));
        }
        public static IWebElement GetElementXPATH(IWebDriver driver, string xpath)
        {
            return new WebDriverWait(driver,
                new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).
                Until(
                ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
                //drv => drv.FindElement(By.XPath(xpath)));
        }
        public static IWebElement GetExistElementCSS(IWebDriver driver, string cssselector)
        {
            return new WebDriverWait(driver,
                new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).
                Until(
                ExpectedConditions.ElementExists(By.CssSelector(cssselector)));
            //drv => drv.FindElement(By.CssSelector(cssselector)));
        }
        public static IWebElement GetExistElementXPATH(IWebDriver driver, string xpath)
        {
            return new WebDriverWait(driver,
                new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).
                Until(
                ExpectedConditions.ElementExists(By.XPath(xpath)));
            //drv => drv.FindElement(By.XPath(xpath)));
        }
        public static ReadOnlyCollection<IWebElement> GetElementsCSS(IWebDriver driver, string cssselector)
        {
            return new WebDriverWait(driver,
                new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).
                Until(
                ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector(cssselector))
                /*drv =>
                {
                    
                    var elements = drv.FindElements(By.CssSelector(cssselector));
                    if (elements.Count > 0)
                    {
                        return elements;
                    }
                    else
                    {
                        return null;
                    }
                }*/);
        }
        public static ReadOnlyCollection<IWebElement> GetElementsXPATH(IWebDriver driver, string xpath)
        {
            return new WebDriverWait(driver,
                new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).
                Until(
                ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(xpath))
                /*drv =>
                {

                    var elements = drv.FindElements(By.XPath(xpath));
                    if (elements.Count > 0)
                    {
                        return elements;
                    }
                    else
                    {
                        return null;
                    }
                }
                */);
                
        }
        public static string GetPseudoElementContent(IWebDriver driver, string cssSelector,string pseudoElement)
        {
            String script = $"return window.getComputedStyle(document.querySelector(\"{cssSelector}\"), '{pseudoElement}').getPropertyValue('content')";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            String contentValue = (String)js.ExecuteScript(script);
            return contentValue;
        }
    }
}
