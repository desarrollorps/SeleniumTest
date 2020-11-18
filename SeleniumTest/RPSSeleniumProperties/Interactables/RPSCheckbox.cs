using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.Interactables;
using RPSSeleniumProperties.Interfaces.viewmodels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interactables
{
    public class RPSCheckbox<T> : SeleniumInteractable<T>,IRPSCheckbox<T> where T:class,IView
    {
      
      

        public T Check()
        {
            throw new NotImplementedException();
        }

        public T Click()
        {
            throw new NotImplementedException();
        }

        public bool IsChecked()
        {
            throw new NotImplementedException();
        }

        public T Uncheck()
        {
            throw new NotImplementedException();
        }
    }
}
