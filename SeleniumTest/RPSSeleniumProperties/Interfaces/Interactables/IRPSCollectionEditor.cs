using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interfaces.Interactables
{
    public interface IRPSCollectionEditor<T,N> where T : class, IView where N : class, IView
    {
        IRPSDescriptorView<T, N> DescriptorView { get; set; }
        T Exists(IWebDriver driver);
        T Exists();
    }
    public interface IRPSCollectionEditor<T>  where T : class, IView
    {        
        T Exists(IWebDriver driver);
        T Exists();
    }
}
