using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.Interactables;
using RPSSeleniumProperties.Interfaces.viewmodels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interactables
{
    public class RPSCollectionComboBox<T> : SeleniumInteractable<T>,IRPSCollectionComboBox<T> where T:class,IView
    {
      
      

        public T Clear()
        {
            throw new NotImplementedException();
        }

        public List<string> GetSelected()
        {
            throw new NotImplementedException();
        }

        public bool HasSelectedItems()
        {
            throw new NotImplementedException();
        }

        public bool IsSelected(int index)
        {
            throw new NotImplementedException();
        }

        public T Select(int index)
        {
            throw new NotImplementedException();
        }

        public T UnSelect(int index)
        {
            throw new NotImplementedException();
        }

        public T Write()
        {
            throw new NotImplementedException();
        }
    }
}
