using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interfaces.Interactables
{
    public interface IRPSButton<T>: ISeleniumInteractable<T> where T : class, IView
    {      
        T Click();
        T Click(IWebDriver driver);
    }
    public interface IRPSButton<T, N>: IRPSButton<T> where T:class,IView where N:class,IView
    {
        N NewView { get; }
        new N Click();
        new N Click(IWebDriver driver);
    }
}
