using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSSeleniumProperties.Interfaces.Interactables
{
    public interface IRPSGridComboBox<T> where T : class, IView
    {
        T Write(int row,string text);
        T Write(int row, string text, IWebDriver driver);
        T Clear(int row);
        /// <summary>
        /// Selects the index elemento from the li
        /// </summary>
        /// <param name="index">0 based index item</param>
        /// <returns></returns>
        T Select(int row, int index);

        string GetSelected(int row);
        bool HasSelectedItem(int row);
        T Exists(int row, IWebDriver driver);
        T Exists(int row);
    }
}
