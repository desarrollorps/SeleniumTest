using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interfaces
{
    public interface IView
    {
        string Name { get; }
        IWebDriver WebDriver { get; }
        IViewModel ViewModel { get; }
        IScreen Screen { get; }
        
}
}
