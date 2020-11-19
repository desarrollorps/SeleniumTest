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
        public static IRPSButton<T> CreateRPSButton<T>(string id, string cssSelector,string xpath, T view) where T : class, IView
        {
            RPSButton<T> button = new RPSButton<T>();
            button.ID = id;
            button.CSSSelector = cssSelector;
            button.XPathSelector = xpath;
            button.View = view;
          
            var prop = new ViewModelProperty {  Type = Interfaces.viewmodels.ViewModelPropertyType.Command};
            button.ViewModelProperty = prop;
            button.WebDriver = view.WebDriver;
            prop.ViewModel = view.ViewModel;
            view.ViewModel.Properties.Add(prop);
            return button;
        }
        public static IRPSButton<T,N> CreateRPSButtonToView<T,N>(string id, string cssSelector,string xpath, T view, N newView) where T : class, IView where N:class,IView
        {
            RPSButton<T,N> button = new RPSButton<T,N>();
            button.ID = id;
            button.CSSSelector = cssSelector;
            button.XPathSelector = xpath;
            button.View = view;
            button.NewView = newView;
            button.WebDriver = view.WebDriver;
            var prop = new ViewModelProperty{ Type = Interfaces.viewmodels.ViewModelPropertyType.Command };
            button.ViewModelProperty = prop;
           
            prop.ViewModel = view.ViewModel;
            view.ViewModel.Properties.Add(prop);
            return button;
        }
        public static IRPSTextBox<T> CreateRPSTextBox<T>(string id, string cssSelector,string xpath, bool required, T view) where T:class,IView
        {
            RPSTextBox<T>control = new RPSTextBox<T>();
            control.ID = id;
            control.CSSSelector = cssSelector;
            control.XPathSelector = xpath;
            control.View = view;
            control.WebDriver = view.WebDriver;
            var property = new ViewModelProperty{ Type = Interfaces.viewmodels.ViewModelPropertyType.String, Required = required };
            control.ViewModelProperty = property;
         
            property.ViewModel = view.ViewModel;
            view.ViewModel.Properties.Add(property);
            return control;
        }
        public static IRPSComboBox<T> CreateRPSComboBox<T>(string id, string cssSelector,string xpath, bool required, T view) where T : class, IView
        {
            RPSComboBox<T> control = new RPSComboBox<T>();
            control.ID = id;
            control.CSSSelector = cssSelector;
            control.XPathSelector = xpath;
            control.View = view;
            control.WebDriver = view.WebDriver;
            var property = new ViewModelProperty { Type = Interfaces.viewmodels.ViewModelPropertyType.String, Required = required };
            control.ViewModelProperty = property;

            property.ViewModel = view.ViewModel;
            view.ViewModel.Properties.Add(property);
            return control;
        }
        #region RPSButtons
        public static IRPSButton<T, N> RPSNewButton<T, N>(T view, N newView) where T : class, IView where N : class, IView
        {
            return RPSControlFactory.CreateRPSButtonToView<T, N>(
                "",
                "[id='kendoToolbar'] a[title='Nuevo']","",
                view,
               newView);
        }
        public static IRPSButton<T, N> RPSBackButton<T, N>(T view, N newView) where T : class, IView where N : class, IView
        {
            return RPSControlFactory.CreateRPSButtonToView<T, N>(
                "",
                "rps-breadcrumb a[href*='general.category']","",
                view,
               newView);
        }
        public static IRPSButton<T> RPSDeleteButton<T>(T view) where T : class, IView
        {
            return RPSControlFactory.CreateRPSButton<T>("", "[id='kendoToolbar'] a[title='Eliminar']","", view);
            
        }
        public static IRPSButton<T> RPSConsultButton<T>(T view) where T : class, IView
        {
            return RPSControlFactory.CreateRPSButton<T>("", "", "//rps-text-with-icon-button/div[text()[normalize-space()='Consultar']]", view);

        }
        public static IRPSButton<T> RPSSaveButton<T>(T view) where T : class, IView
        {
            return RPSControlFactory.CreateRPSButton<T>("", "[id='kendoToolbar'] a[title='Guardar']","", view);

        }
        #endregion
        #region Sections
        public static IRPSSection<T> CreateRPSSection<T>(string id, string cssSelector, string xpath, T view) where T : class, IView
        {
            RPSSection<T> button = new RPSSection<T>();
            button.ID = id;
            button.CSSSelector = cssSelector;
            button.XPathSelector = xpath;
            button.View = view;
            button.WebDriver = view.WebDriver;
            return button;
        }
        #endregion
        #region Collections
        public static IRPSCollectionEditor<T,N> RPSCreateCollection<T,N>(CollectionInit parameters,T view, N newView) where T : class, IView where N : class, IView
        {
            RPSCollectionEditor<T,N> container = new RPSCollectionEditor<T,N>();
            container.View = view;
            container.NewView = newView;
            container.WebDriver = view.WebDriver;
            
            if (!string.IsNullOrEmpty(parameters.IDDescriptor) || !string.IsNullOrEmpty(parameters.CSSSelectorDescriptor) || !string.IsNullOrEmpty(parameters.XPathDescriptor))
            {
                container.DescriptorView = new RPSDescriptorView<T, N>()
                {
                    ID = parameters.IDDescriptor,
                    CSSSelector = parameters.CSSSelectorDescriptor,
                    XPathSelector = parameters.XPathDescriptor,
                    View = view,
                    NewView = newView,
                    WebDriver = view.WebDriver
                };                
            }
            return container;
        }
        #endregion
    }
    public class CollectionInit
    {
        public string IDDescriptor { get; set; }
        public string CSSSelectorDescriptor { get; set; }
        public string XPathDescriptor { get; set; }
        public string IDGrid { get; set; }
        public string CSSSelectorGrid { get; set; }
        public string XPathGrid { get; set; }

    }
}
