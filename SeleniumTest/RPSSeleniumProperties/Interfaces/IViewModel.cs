using RPSSeleniumProperties.Interfaces.viewmodels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interfaces
{
    public interface IViewModel
    {
       IView View{ get; }      
        List<IViewModelProperty> Properties { get; }
    }
}
