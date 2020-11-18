using OpenQA.Selenium;
using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.viewmodels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties
{

    public class SeleniumInteractable<T> : ISeleniumInteractable<T> where T:class,IView
    {
        public string ID { get; set; }

        public IViewModelProperty ViewModelProperty { get; set; }
        public T View { get; set; }
        public IWebDriver WebDriver
        {
            get;set;
        }

        public string CSSSelector { get; set; }
    }
}
