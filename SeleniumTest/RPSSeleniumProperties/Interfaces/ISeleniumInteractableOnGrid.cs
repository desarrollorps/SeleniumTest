using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSSeleniumProperties.Interfaces
{
    public interface ISeleniumInteractableOnGrid<T>:ISeleniumInteractable<T> where T : class, IView
    {
    }
}
