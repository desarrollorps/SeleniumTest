using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interfaces.Interactables
{
    public interface IRPSCollectionComboBox<T>:ISeleniumInteractable<T> where T:class,IView
    {
        T Write();
        T Clear();
        T Select(int index);
        T UnSelect(int index);
        bool IsSelected(int index);
        List<string> GetSelected();
        bool HasSelectedItems();
        T Exists(IWebDriver driver);
        T Exists();
    }
}
