using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interfaces.Interactables
{
    public interface IRPSGridCell<T>  where T : class, IView
    {

        T Exists(IWebDriver driver);
        T Exists();

    }
}
