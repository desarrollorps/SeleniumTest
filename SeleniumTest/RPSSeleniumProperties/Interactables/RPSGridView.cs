using OpenQA.Selenium;
using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.Interactables;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interactables
{
    public class RPSGridView<T, N> : SeleniumInteractable<T>, IRPSGridView<T, N> where T : class, IView where N : class, IView
    {
        public N NewView { get; set; }

        public T CurrentView { get; set; }
      
    }
    
}
