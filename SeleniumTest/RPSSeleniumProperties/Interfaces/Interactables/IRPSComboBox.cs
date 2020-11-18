using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interfaces.Interactables
{
    public interface IRPSComboBox<T>:ISeleniumInteractable<T> where T:class,IView
    {
        T Write();
        T Clear();
        T Select(int index);
        
        string GetSelected();
        bool HasSelectedItem();
    }
}
