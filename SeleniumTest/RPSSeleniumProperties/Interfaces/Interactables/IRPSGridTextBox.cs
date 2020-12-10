using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interfaces.Interactables
{
    public interface IRPSGridTextBox<T>:IRPSTextBox<T> where T : class, IView
    {
        T Write(int row,string text);
        T Write(int row,string text, IWebDriver driver);
        T Read(int row,out string value);
        T Read(int row,IWebDriver driver, out string value);
        T Exists(int row,IWebDriver driver);
        T Exists(int row);
    }
}
