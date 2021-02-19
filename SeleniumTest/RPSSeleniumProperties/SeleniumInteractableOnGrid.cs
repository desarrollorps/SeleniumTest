using OpenQA.Selenium;
using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.viewmodels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSSeleniumProperties
{
    public class SeleniumInteractableOnGridConstants
    {
        public const string RowIndexPatter = "@ROWINDEX";
    }
    public class SeleniumInteractableOnGrid<T> : ISeleniumInteractableOnGrid<T> where T : class, IView
    {
        
        protected string GetRowIndexText(int row)
        {
            return $"[row-index='{row}']";
        }
        public string ID { get; set; }


        public IViewModelProperty ViewModelProperty { get; set; }
        public T View { get; set; }
        public IWebDriver WebDriver
        {
            get; set;
        }

        public string CSSSelector { get; set; }
        public string XPathSelector { get; set; }

        public virtual SeleniumWebElement GetElement(int row, string afterelement, string beforeelement = "")
        {
            var driver = this.WebDriver;
            return GetElement(driver,row, afterelement, beforeelement);
        }
        public virtual SeleniumWebElement GetElement(IWebDriver driver,int row, string afterelement, string beforeelement = "")
        {
            if (!string.IsNullOrEmpty(this.ID))
            {
                return BrowserElements.GetElementCSS(driver, $"{beforeelement} [id = '{this.ID}'] {afterelement}".Trim());
            }
            else if (!string.IsNullOrEmpty(this.CSSSelector))
            {
                return BrowserElements.GetElementCSS(driver, $"{beforeelement} {this.CSSSelector.Replace(SeleniumInteractableOnGridConstants.RowIndexPatter, GetRowIndexText(row))} {afterelement}".Trim());
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
        public T Exists(int row, string afterelement, string beforeelement = "")
        {
            var driver = this.WebDriver;
            return Exists(driver, row, afterelement, beforeelement);
        }
        public T Exists(IWebDriver driver,int row, string afterelement, string beforeelement = "")
        {
            SeleniumWebElement element;
            if (!string.IsNullOrEmpty(this.ID))
            {
                element = BrowserElements.GetExistElementCSS(driver, $"{beforeelement} [id = '{this.ID}'] {afterelement}".Trim());
            }
            else if (!string.IsNullOrEmpty(this.CSSSelector))
            {
                element = BrowserElements.GetExistElementCSS(driver, $"{beforeelement} {this.CSSSelector.Replace(SeleniumInteractableOnGridConstants.RowIndexPatter, GetRowIndexText(row))} {afterelement}".Trim());
            }
            else if (!string.IsNullOrEmpty(this.XPathSelector))
            {
                element = BrowserElements.GetExistElementXPATH(driver, $"{beforeelement} {this.XPathSelector} {afterelement}".Trim());
            }
            else
            {
                return null;
            }
            return this.View;

        }
        public virtual ReadOnlyCollection<SeleniumWebElement> GetElements(IWebDriver driver,int row, string afterelement, string beforeelement = "")
        {
            if (!string.IsNullOrEmpty(this.ID))
            {
                return BrowserElements.GetElementsCSS(driver, $"{beforeelement} [id = '{this.ID}'] {afterelement}".Trim());
            }
            else if (!string.IsNullOrEmpty(this.CSSSelector))
            {
                return BrowserElements.GetElementsCSS(driver, $"{beforeelement} {this.CSSSelector.Replace(SeleniumInteractableOnGridConstants.RowIndexPatter, GetRowIndexText(row))} {afterelement}".Trim());
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
        public virtual SeleniumWebElement GetElement(IWebDriver driver,int row, string[] afterelements)
        {
            List<string> selectors = new List<string>();
            if (!string.IsNullOrEmpty(this.ID))
            {
                foreach (var s in afterelements)
                {
                    selectors.Add($"[id = '{this.ID}'] {s}".Trim());
                }
                return BrowserElements.GetElementCSS(driver, string.Join(" ,", selectors));
            }
            else if (!string.IsNullOrEmpty(this.CSSSelector))
            {
                foreach (var s in afterelements)
                {
                    selectors.Add($"{this.CSSSelector.Replace(SeleniumInteractableOnGridConstants.RowIndexPatter, GetRowIndexText(row))} {s}".Trim());
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

        public virtual ReadOnlyCollection<SeleniumWebElement> GetElements(IWebDriver driver,int row, string[] afterelements)
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
                    selectors.Add($"{this.CSSSelector.Replace(SeleniumInteractableOnGridConstants.RowIndexPatter, GetRowIndexText(row))} {s}".Trim());
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
        public virtual string GetPseudoElement(IWebDriver driver,int row, string afterelement, string pseudoelement, string beforeelement = "")
        {
            if (!string.IsNullOrEmpty(this.ID))
            {
                return BrowserElements.GetPseudoElementContent(driver, $"{beforeelement} [id = '{this.ID}'] {afterelement}".Trim(), pseudoelement);
            }
            else if (!string.IsNullOrEmpty(this.CSSSelector))
            {
                return BrowserElements.GetPseudoElementContent(driver, $"{beforeelement} {this.CSSSelector.Replace(SeleniumInteractableOnGridConstants.RowIndexPatter, GetRowIndexText(row))} {afterelement}".Trim(), pseudoelement);
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
        public virtual List<string> GetPseudoElements(IWebDriver driver,int row, string afterelement, string pseudoelement, string beforeelement = "")
        {
            if (!string.IsNullOrEmpty(this.ID))
            {
                return BrowserElements.GetPseudoElementsContent(driver, $"{beforeelement} [id = '{this.ID}'] {afterelement}".Trim(), pseudoelement);
            }
            else if (!string.IsNullOrEmpty(this.CSSSelector))
            {
                return BrowserElements.GetPseudoElementsContent(driver, $"{beforeelement} {this.CSSSelector.Replace(SeleniumInteractableOnGridConstants.RowIndexPatter, GetRowIndexText(row))} {afterelement}".Trim(), pseudoelement);
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

}
