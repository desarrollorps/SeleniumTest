using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interfaces.Interactables
{
    public interface IRPSGridView<T, N> : ISeleniumInteractable<T> where T : class, IView where N : class, IView
    {
        N NewView { get; }

        T CurrentView { get; }
    }

    public interface IRPSGridView<T> : ISeleniumInteractable<T> where T : class,IView
    {        
        T CurrentView { get; }
    }

}
