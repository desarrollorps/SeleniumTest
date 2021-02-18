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
        public virtual SeleniumWebElement GetElement( string afterelement, string beforeelement = "")
        {
            var driver = this.WebDriver;
            return GetElement(driver, afterelement,beforeelement);
        }
        public virtual SeleniumWebElement GetElement(IWebDriver driver,string afterelement, string beforeelement ="")
        {
            if (!string.IsNullOrEmpty(this.ID))
            {
                return BrowserElements.GetElementCSS(driver,$"{beforeelement} [id = '{this.ID}'] {afterelement}".Trim());
            }else if (!string.IsNullOrEmpty(this.CSSSelector))
            {
                return BrowserElements.GetElementCSS(driver, $"{beforeelement} {this.CSSSelector} {afterelement}".Trim());
            }
            else if (!string.IsNullOrEmpty(this.XPathSelector))
            {
                return BrowserElements.GetElementXPATH(driver, $"{beforeelement} {this.XPathSelector} {afterelement}".Trim());
            }
            else
            {
                return null;
            }
        }
        public T Exists(string afterelement, string beforeelement = "")
        {
            var driver = this.WebDriver;
            return Exists(driver, afterelement, beforeelement);
        }
        public T Exists(IWebDriver driver, string afterelement,string beforeelement = "")
        {
            SeleniumWebElement element;
            if (!string.IsNullOrEmpty(this.ID))
            {
                 element = BrowserElements.GetExistElementCSS(driver, $"{beforeelement} [id = '{this.ID}'] {afterelement}".Trim());
            }
            else if (!string.IsNullOrEmpty(this.CSSSelector))
            {
                element = BrowserElements.GetExistElementCSS(driver, $"{beforeelement} {this.CSSSelector} {afterelement}".Trim());
            }
            else if (!string.IsNullOrEmpty(this.XPathSelector))
            {
                element =  BrowserElements.GetExistElementXPATH(driver, $"{beforeelement} {this.XPathSelector} {afterelement}".Trim());
            }
            else
            {
                return null;
            }
            return this.View;

        }
        public virtual ReadOnlyCollection<SeleniumWebElement> GetElements(IWebDriver driver, string afterelement, string beforeelement = "")
        {
            if (!string.IsNullOrEmpty(this.ID))
            {
                return BrowserElements.GetElementsCSS(driver, $"{beforeelement} [id = '{this.ID}'] {afterelement}".Trim());
            }
            else if (!string.IsNullOrEmpty(this.CSSSelector))
            {
                return BrowserElements.GetElementsCSS(driver, $"{beforeelement} {this.CSSSelector} {afterelement}".Trim());
            }
            else if (!string.IsNullOrEmpty(this.XPathSelector))
            {
                return BrowserElements.GetElementsXPATH(driver, $"{beforeelement} {this.XPathSelector} {afterelement}".Trim());
            }
            else
            {
                return null;
            }
        }
        public virtual SeleniumWebElement GetElement(IWebDriver driver, string[] afterelements)
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

        public virtual ReadOnlyCollection<SeleniumWebElement> GetElements(IWebDriver driver, string[] afterelements)
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
        public virtual string GetPseudoElement(IWebDriver driver, string afterelement,string pseudoelement, string beforeelement = "")
        {
            if(!string.IsNullOrEmpty(this.ID))
            {
                return BrowserElements.GetPseudoElementContent(driver, $"{beforeelement} [id = '{this.ID}'] {afterelement}".Trim(), pseudoelement);
            }
            else if (!string.IsNullOrEmpty(this.CSSSelector))
            {
                return BrowserElements.GetPseudoElementContent(driver, $"{beforeelement} {this.CSSSelector} {afterelement}".Trim(), pseudoelement);
            }
            else if (!string.IsNullOrEmpty(this.XPathSelector))
            {
                return BrowserElements.GetPseudoElementContent(driver, $"{beforeelement} {this.XPathSelector} {afterelement}".Trim(), pseudoelement);
            }
            else
            {
                return null;
            }
        }
        public virtual List<string> GetPseudoElements(IWebDriver driver, string afterelement, string pseudoelement, string beforeelement = "")
        {
            if (!string.IsNullOrEmpty(this.ID))
            {
                return BrowserElements.GetPseudoElementsContent(driver, $"{beforeelement} [id = '{this.ID}'] {afterelement}".Trim(), pseudoelement);
            }
            else if (!string.IsNullOrEmpty(this.CSSSelector))
            {
                return BrowserElements.GetPseudoElementsContent(driver, $"{beforeelement} {this.CSSSelector} {afterelement}".Trim(), pseudoelement);
            }
            else if (!string.IsNullOrEmpty(this.XPathSelector))
            {
                return BrowserElements.GetPseudoElementsContent(driver, $"{beforeelement} {this.XPathSelector} {afterelement}".Trim(), pseudoelement);
            }
            else
            {
                return null;
            }
        }
    }
    public static class BrowserElements
    {
        
        public static SeleniumWebElement GetElement(IWebDriver driver, IWebElement element)
        {
            var w = new WebDriverWait(driver,
                new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).//IgnoreExceptionTypes(typeof(ElementClickInterceptedException)).        
                Until(
                ExpectedConditions.ElementToBeClickable(element));
            return new SeleniumWebElement(w);
        }
        public static SeleniumWebElement GetElementCSS(IWebDriver driver,string cssselector)
        {
           
            var w= new WebDriverWait(driver,
                new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).
                Until(
                ExpectedConditions.ElementToBeClickable(By.CssSelector(cssselector)));
            //drv => drv.FindElement(By.CssSelector(cssselector)));
            return new SeleniumWebElement(w);
        }
        public static SeleniumWebElement GetElementXPATH(IWebDriver driver, string xpath)
        {
            var w = new WebDriverWait(driver,
                new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).
                Until(
                ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            //drv => drv.FindElement(By.XPath(xpath)));
            return new SeleniumWebElement(w);
        }
        public static SeleniumWebElement GetExistElementCSS(IWebDriver driver, string cssselector)
        {
            var w = new WebDriverWait(driver,
                new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).
                Until(
                ExpectedConditions.ElementExists(By.CssSelector(cssselector)));
            //drv => drv.FindElement(By.CssSelector(cssselector)));
            return new SeleniumWebElement(w);
        }
        public static SeleniumWebElement GetExistElementXPATH(IWebDriver driver, string xpath)
        {
            var w = new WebDriverWait(driver,
                new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).
                Until(
                ExpectedConditions.ElementExists(By.XPath(xpath)));
            //drv => drv.FindElement(By.XPath(xpath)));
            return new SeleniumWebElement(w);
        }
        public static ReadOnlyCollection<SeleniumWebElement> GetElementsCSS(IWebDriver driver, string cssselector)
        {
            var col = new WebDriverWait(driver,
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
            List<SeleniumWebElement> we = new List<SeleniumWebElement>();
            foreach(var c in col)
            {
                we.Add(new SeleniumWebElement(c));
            }
            ReadOnlyCollection<SeleniumWebElement> sel = new ReadOnlyCollection<SeleniumWebElement>(we);
            return sel;
        }
        public static ReadOnlyCollection<SeleniumWebElement> GetElementsXPATH(IWebDriver driver, string xpath)
        {
            var col = new WebDriverWait(driver,
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
            List<SeleniumWebElement> we = new List<SeleniumWebElement>();
            foreach (var c in col)
            {
                we.Add(new SeleniumWebElement(c));
            }
            ReadOnlyCollection<SeleniumWebElement> sel = new ReadOnlyCollection<SeleniumWebElement>(we);
            return sel;

        }
        public static string GetPseudoElementContent(IWebDriver driver, string cssSelector,string pseudoElement)
        {
            String script = $"return window.getComputedStyle(document.querySelector(\"{cssSelector}\"), '{pseudoElement}').getPropertyValue('content')";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            String contentValue = (String)js.ExecuteScript(script);
            return contentValue;
        }
        public static IWebElement GetParent(IWebDriver driver, IWebElement element)
        {
            return (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript(
                                   "return arguments[0].parentNode;", element);
        }
        public static List<string> GetPseudoElementsContent(IWebDriver driver, string cssSelector, string pseudoElement)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"var elements = document.querySelectorAll(\"{ cssSelector}\");");
            sb.AppendLine($"var results = [];");
            sb.AppendLine($"for(var i = 0; i<elements.length;i++){{");
            sb.AppendLine($"results.push(window.getComputedStyle(elements[i],'{pseudoElement}').getPropertyValue('content'));");
            
            sb.AppendLine($"}}");
            sb.AppendLine($"return results;");


          
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            var contentValues = (System.Collections.ObjectModel.ReadOnlyCollection<object>)js.ExecuteScript(sb.ToString());
            List<string> values = new List<string>();
            foreach(var val in contentValues)
            {
                values.Add(val.ToString());
            }
            return values;
        }
        public static List<string> GetPseudoElementzContent(IWebDriver driver, string cssSelector, string pseudoElement)
        {

            String script = @"var elements = document.querySelectorAll("""+cssSelector+@""");
                              var result = []
                              for (var i = 0; i < elements.length; i++)
                                {
                                    var el = elements[i];
                                    result.push(window.getComputedStyle(el, """+pseudoElement+@""").getPropertyValue('content'));
                                }";            
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            List<string> contentValue = (List<string>)js.ExecuteScript(script);
            return contentValue;
        }
    }
}
