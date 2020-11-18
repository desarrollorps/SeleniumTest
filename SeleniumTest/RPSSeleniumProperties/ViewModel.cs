using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.viewmodels;
using RPSSeleniumProperties.viewmodels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties
{
    public class ViewModel : IViewModel
    { 
       public ViewModel()
       {
            Properties = new List<IViewModelProperty>(); 
       }
       public IView View { get; set; }
        

        public List<IViewModelProperty> Properties { get; set; }
    }
}
