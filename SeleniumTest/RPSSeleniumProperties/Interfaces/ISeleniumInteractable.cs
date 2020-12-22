using OpenQA.Selenium;
using RPSSeleniumProperties.Interfaces.viewmodels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interfaces
{
    public interface ISeleniumInteractable<T> where T : class, IView
    {
        public string ID { get; }
        public string CSSSelector { get; }
        public IViewModelProperty ViewModelProperty { get; }
        public IWebDriver WebDriver { get; }
        public T View { get; }
        
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
