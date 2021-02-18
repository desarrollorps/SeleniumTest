using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interfaces.Interactables
{
    public interface IRPSCollectionComboBox<T> where T:class,IView
    {
        T Write(string text);
        T Write(string text,IWebDriver driver);
        T Clear();
        T Clear(IWebDriver driver);
        T Select(int index);
        T Select(int index, IWebDriver driver);
        T UnSelect(int index);
        T UnSelect(int index, IWebDriver driver);
        bool IsSelected(int index);
        bool IsSelected(int index, IWebDriver driver);
        List<string> GetSelected();
        List<string> GetSelected(IWebDriver driver);
        bool HasSelectedItems();
        bool HasSelectedItems(IWebDriver driver);
        T Exists(IWebDriver driver);
        T Exists();
    }
}
