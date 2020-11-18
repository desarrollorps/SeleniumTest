using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.Interactables;
using RPSSeleniumProperties.Interfaces.viewmodels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interactables
{
    public class RPSComboBox<T> : SeleniumInteractable<T>,IRPSComboBox<T> where T:class,IView
    {
      

        

        public T Clear()
        {
            throw new NotImplementedException();
        }

        public string GetSelected()
        {
            throw new NotImplementedException();
        }

        public bool HasSelectedItem()
        {
            throw new NotImplementedException();
        }

        public T Select(int index)
        {
            throw new NotImplementedException();
        }

        public T Write()
        {
            throw new NotImplementedException();
        }
    }
}
