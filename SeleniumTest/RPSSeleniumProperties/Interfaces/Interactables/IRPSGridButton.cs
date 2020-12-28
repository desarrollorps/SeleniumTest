using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSSeleniumProperties.Interfaces.Interactables
{
    public interface IRPSGridButton<T> where T : class, IView
    {
        T Click(int row);
        T Click(int row, IWebDriver driver);
        T Exists(int row, IWebDriver driver);
        T Exists(int row);
    }
    public interface IRPSGridButton<T, N> : IRPSGridButton<T> where T : class, IView where N : class, IView
    {
        N NewView { get; }
        new N Click(int row);
        new N Click(int row,IWebDriver driver);
    }
}
