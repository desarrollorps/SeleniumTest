using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.Interactables;
using RPSSeleniumProperties.viewmodels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Interactables
{
    public class RPSControlFactory
    {
        public static IRPSButton<T> CreateRPSButton<T>(string id, string cssSelector, T view) where T : class, IView
        {
            RPSButton<T> button = new RPSButton<T>();
            button.ID = id;
            button.CSSSelector = cssSelector;
            button.View = view;
          
            var prop = new ViewModelProperty {  Type = Interfaces.viewmodels.ViewModelPropertyType.Command};
            button.ViewModelProperty = prop;
            button.WebDriver = view.WebDriver;
            prop.ViewModel = view.ViewModel;
            view.ViewModel.Properties.Add(prop);
            return button;
        }
        public static IRPSButton<T,N> CreateRPSButtonToView<T,N>(string id, string cssSelector, T view, N newView) where T : class, IView where N:class,IView
        {
            RPSButton<T,N> button = new RPSButton<T,N>();
            button.ID = id;
            button.CSSSelector = cssSelector;
            button.View = view;
            button.NewView = newView;
            button.WebDriver = view.WebDriver;
            var prop = new ViewModelProperty{ Type = Interfaces.viewmodels.ViewModelPropertyType.Command };
            button.ViewModelProperty = prop;
           
            prop.ViewModel = view.ViewModel;
            view.ViewModel.Properties.Add(prop);
            return button;
        }
        public static IRPSTextBox<T> CreateRPSTextBox<T>(string id, string cssSelector, bool required, T view) where T:class,IView
        {
            RPSTextBox<T>control = new RPSTextBox<T>();
            control.ID = id;
            control.CSSSelector = cssSelector;
            control.View = view;
            control.WebDriver = view.WebDriver;
            var property = new ViewModelProperty{ Type = Interfaces.viewmodels.ViewModelPropertyType.String, Required = required };
            control.ViewModelProperty = property;
         
            property.ViewModel = view.ViewModel;
            view.ViewModel.Properties.Add(property);
            return control;
        }
        public static IRPSButton<T, N> RPSNewButton<T, N>(T view, N newView) where T : class, IView where N : class, IView
        {
            return RPSControlFactory.CreateRPSButtonToView<T, N>(
                "",
                "[id='kendoToolbar'] a[title='Nuevo']",
                view,
               newView);
        }
        public static IRPSButton<T, N> RPSBackButton<T, N>(T view, N newView) where T : class, IView where N : class, IView
        {
            return RPSControlFactory.CreateRPSButtonToView<T, N>(
                "",
                "rps-breadcrumb a[href*='general.category']",
                view,
               newView);
        }
        public static IRPSButton<T> RPSDeleteButton<T>(T view) where T : class, IView
        {
            return RPSControlFactory.CreateRPSButton<T>("", "[id='kendoToolbar'] a[title='Eliminar']", view);
            
        }
        public static IRPSButton<T> RPSSaveButton<T>(T view) where T : class, IView
        {
            return RPSControlFactory.CreateRPSButton<T>("", "[id='kendoToolbar'] a[title='Guardar']", view);

        }
    }
}
