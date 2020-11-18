using RPSSeleniumProperties.Interactables;
using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.viewmodels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.viewmodels
{
    public class ViewModelProperty : IViewModelProperty
    {
        public bool Required { get; set; }

        public ViewModelPropertyType Type { get; set; }

      

        public IViewModel ViewModel { get; set; }
       

        
    }
}
