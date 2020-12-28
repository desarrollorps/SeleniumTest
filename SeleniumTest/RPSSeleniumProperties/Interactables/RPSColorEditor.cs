using OpenQA.Selenium;
using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.Interactables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSSeleniumProperties.Interactables
{
    public class RPSColorEditor<T> : SeleniumInteractable<T>, IRPSColorEditor<T> where T : class, IView
    {
        public T Exists(IWebDriver driver)
        {
            return this.Exists(driver, "");
        }
        public T Exists()
        {
            var driver = this.WebDriver;
            return this.Exists(driver);
        }
        /// <summary>
        /// Sets a color in format #FFFFFF
        /// </summary>
        /// <param name="driver">Selenium driver</param>
        /// <param name="color">Color in format #FFFFFF</param>
        /// <returns></returns>
        public T SetColor(IWebDriver driver, string color)
        {
            var dropdown = this.GetElement("span.k-icon.k-i-arrow-60-down");
            dropdown.Click();
            var popupinput = BrowserElements.GetElementCSS(driver,"div.k-flatcolorpicker[style*='display: block'] input.k-color-value");
            popupinput.SendKeys(Keys.Control + "a");
            popupinput.SendKeys(color);
            var btnaplicar = BrowserElements.GetElementCSS(driver, "div.k-flatcolorpicker[style*='display: block'] div.k-controls button.apply");
            btnaplicar.Click();
            return this.View;
        }
        public T SetColor(string color)
        {
            var driver = this.WebDriver;
            return SetColor(driver, color);
        }
    }
}
