using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSSeleniumProperties
{
    public class SeleniumWebElement
    {
        public SeleniumWebElement(IWebElement element)
        {
            Element = element;
        }
        public SeleniumWebElement()
        {

        }
        public IWebElement Element { get; set; }
        protected int maxtime = RPSEnvironment.DefaultWaitSeconds;
        protected int poolseconds = 5;
        public void Click()
        {
            if (Element != null)
            {
                Retry.Execute(() => { Element.Click(); }, new TimeSpan(0, 0, maxtime), new TimeSpan(0, 0, poolseconds));
            }
        }
        public string Text { get { return Element.Text; } }
        public void TabOnInput()
        {
            Element.SendKeys(Keys.Tab);
        }
        public void WriteAndTabOnInput(string text)
        {
            Element.SendKeys(Keys.Home + text + Keys.Tab);
        }
        public void WriteOnInput(string text)
        {
            Element.SendKeys(Keys.Home + text);
        }
        public void ClearOnInput()
        {
            Element.Clear();
        }
        public string GetValueOnInput()
        {
            return Element.GetProperty("value");
        }
        public string GetAttributeOnElemen(string name)
        {
            return Element.GetAttribute(name);
        }
    }
}
