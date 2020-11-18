using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
namespace RPSSeleniumProperties.Interfaces
{
    public interface IScreen
    {
        string CodUser { get; set; }
        string Password { get; set; }
        string CodCompany { get; set; }
        string Name { get; }
        T NavigateToScreen<T>() where T : class, IView;
        IWebDriver WebDriver { get;  }
            
    }
}
