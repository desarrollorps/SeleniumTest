using OpenQA.Selenium;
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
    }
}
