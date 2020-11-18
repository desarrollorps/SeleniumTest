using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interfaces.viewmodels
{
    public interface IViewModelProperty
    {
        bool Required { get; }
        ViewModelPropertyType Type { get; }
       
        IViewModel ViewModel { get; }
     
    }
    public enum ViewModelPropertyType
    {
        String,
        Boolean,
        Decimal,
        Int,
        Enum,
        StringCollection,
        Lookup,
        Command,
    }
}
