using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interfaces.Interactables
{
    public interface IRPSComboBox<T>:ISeleniumInteractable<T> where T:class,IView
    {
        T Write(string text);
        T Write(string text, IWebDriver driver);
        T Clear();
        /// <summary>
        /// Selects the index elemento from the li
        /// </summary>
        /// <param name="index">0 based index item</param>
        /// <returns></returns>
        T Select(int index);
        
        string GetSelected();
        bool HasSelectedItem();
        T Exists(IWebDriver driver);
        T Exists();
    }
}
