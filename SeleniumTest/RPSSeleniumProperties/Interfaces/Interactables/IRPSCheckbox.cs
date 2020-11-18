using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interfaces.Interactables
{
    public interface IRPSCheckbox<T>:ISeleniumInteractable<T> where T:class,IView
    {
        T Click();
        T Check();
        T Uncheck();
        bool IsChecked();
    }
}
