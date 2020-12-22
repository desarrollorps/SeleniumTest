using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interfaces.Interactables
{
    public interface IRPSButton<T> where T : class, IView
    {      
        T Click();
        T Click(IWebDriver driver);
        T Exists(IWebDriver driver);
        T Exists();
    }
    public interface IRPSButton<T, N>: IRPSButton<T> where T:class,IView where N:class,IView
    {
        N NewView { get; }
        new N Click();
        new N Click(IWebDriver driver);
    }
    public interface IRPSAcceptButton<T,N>:IRPSButton<T,N> where T : class, IView where N : class, IView
    {

    }
    public interface IRPSSaveButton<T>: IRPSButton<T> where T : class, IView
    {

    }
}
