using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interfaces.Interactables
{
    public interface IRPSTextBox<T>:ISeleniumInteractable<T> where T:class,IView
    {
        T Write(string text);
        T Write(string text, IWebDriver driver);
        T Read(out string value);
        T Exists(IWebDriver driver);
        T Exists();
    }
    public interface IRPSDurationTextBox<T> : IRPSTextBox<T> where T : class, IView
    {
        T SelectTimeType(IWebDriver driver, int index);
        T SelectTimeType(int index);
    }
}
