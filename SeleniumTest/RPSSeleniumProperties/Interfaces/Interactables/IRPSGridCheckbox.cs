using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSSeleniumProperties.Interfaces.Interactables
{
    public interface IRPSGridCheckbox<T> where T : class, IView
    {
        T Click(int row);
        T Click(int row, IWebDriver driver);
        T Check(int row, IWebDriver driver);
        T Uncheck(int row, IWebDriver driver);
        bool IsChecked(int row, IWebDriver driver);
        T Check(int row);
        T Uncheck(int row);
        bool IsChecked(int row);
        T Exists(int row, IWebDriver driver);
        T Exists(int row);
    }
}
