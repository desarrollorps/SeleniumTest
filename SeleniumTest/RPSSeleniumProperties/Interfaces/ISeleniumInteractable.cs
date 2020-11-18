using OpenQA.Selenium;
using RPSSeleniumProperties.Interfaces.viewmodels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interfaces
{
    public interface ISeleniumInteractable<T> where T : class, IView
    {
        string ID { get; }
        string CSSSelector { get; }
        IViewModelProperty ViewModelProperty { get; }
        IWebDriver WebDriver { get; }
        T View { get; }
    }
    public enum ControlType
    {
        Button,
        Textbox,
        Checkbox,
        Combobox,
        CollectionCombobox
    }
}
