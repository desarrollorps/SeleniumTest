﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interfaces.Interactables
{
    public interface IRPSDescriptorView<T,N>: ISeleniumInteractable<T> where T:class,IView where N:class,IView
    {
       
        N NewView { get; }
        N Click(string text);
        N Click(IWebDriver driver, string text);
        N Click(int index);
        N Click(IWebDriver driver, int index);
        T Exists(IWebDriver driver);
        T Exists();
    }
}
