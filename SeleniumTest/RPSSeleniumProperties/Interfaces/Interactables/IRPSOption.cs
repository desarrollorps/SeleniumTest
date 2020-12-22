using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interfaces.Interactables
{
    public interface IRPSOption<T>  where T : class, IView
    {
        T Click();
        T Click(IWebDriver driver);
        T Exists(IWebDriver driver);
        T Exists();
    }
}
