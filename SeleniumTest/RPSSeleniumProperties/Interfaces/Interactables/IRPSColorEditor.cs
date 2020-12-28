using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSSeleniumProperties.Interfaces.Interactables
{
    public interface IRPSColorEditor<T> where T : class, IView
    {
        T Exists(IWebDriver driver);
        T Exists();
        T SetColor(IWebDriver driver, string color);
        T SetColor(string color);
        
    }
}
