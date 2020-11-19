using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interfaces.Interactables
{
    public interface IRPSCollectionEditor<T,N>: ISeleniumInteractable<T> where T : class, IView where N : class, IView
    {
        IRPSDescriptorView<T, N> DescriptorView { get; set; }
    }
}
