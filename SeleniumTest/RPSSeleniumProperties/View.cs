using OpenQA.Selenium;
using RPSSeleniumProperties.Interactables;
using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.viewmodels;
using RPSSeleniumProperties.viewmodels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RPSSeleniumProperties
{
    public class View : IView
    {
        public View()
        {
            ViewModel = new ViewModel();
            
        }
      
        public IWebDriver WebDriver { get; set; }        
        public IViewModel ViewModel { get; set; }

        public string Name { get; set; }

        

    }

}
