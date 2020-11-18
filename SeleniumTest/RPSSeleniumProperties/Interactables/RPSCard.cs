using RPSSeleniumProperties.Interfaces.Interactables;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RPSSeleniumProperties.Interfaces;

namespace RPSSeleniumProperties.Interactables
{ 
    public class RPSCard<T,N> : RPSButton<T,N>, IRPSCard<T,N> where T:class,IView where N:class,IView
    {
        public string DescriptorText { get; set; }
        public new N Click(IWebDriver driver)
        {
            if (!string.IsNullOrEmpty(this.DescriptorText))
            {
                var element = new WebDriverWait(driver, new TimeSpan(0, 0, RPSEnvironment.DefaultWaitSeconds)).Until(drv => drv.FindElement(By.CssSelector(this.CSSSelector)));
                element.Click();
            }
            else
            {
                base.Click(driver);
            }
            return this.NewView;
            
        }
    }
}
