using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interfaces.Interactables
{
    public interface IRPSCheckbox<T> where T:class,IView
    {
        T Click();
        T Click(IWebDriver driver);
        T Check(IWebDriver driver);
        T Uncheck(IWebDriver driver);
        bool IsChecked(IWebDriver driver);
        T Check();
        T Uncheck();
        bool IsChecked();
        T Exists(IWebDriver driver);
        T Exists();
    }
}
