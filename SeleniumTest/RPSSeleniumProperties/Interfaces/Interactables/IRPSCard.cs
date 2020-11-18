using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interfaces.Interactables
{
    public interface IRPSCard<T,N>:IRPSButton<T,N> where T:class,IView where N:class,IView
    {
        string DescriptorText { get; set; }
    }
}
