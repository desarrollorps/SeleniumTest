using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interfaces.Interactables
{
    public interface IRPSGridView<T, N> where T : class, IView where N : class, IView
    {

    }
    public interface IRPSGridView<T> where T : class,IView
    {        
       
    }

}
