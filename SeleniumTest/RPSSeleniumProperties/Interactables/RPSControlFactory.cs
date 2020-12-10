using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.Interactables;
using RPSSeleniumProperties.viewmodels;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

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
        public static IRPSGridTextBox<T> CreateRPSGridTextBox<T>(string id, string cssSelector, string xpath, bool required, T view) where T : class, IView
        {
            RPSGridTextBox<T> control = new RPSGridTextBox<T>();
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
        public static IRPSCheckbox<T> CreateRPSCheckBox<T>(string id, string cssSelector, string xpath, bool required, T view) where T : class, IView
        {
            RPSCheckbox<T> control = new RPSCheckbox<T>();
            control.ID = id;
            control.CSSSelector = cssSelector;
            control.XPathSelector = xpath;
            control.View = view;
            control.WebDriver = view.WebDriver;
            var property = new ViewModelProperty { Type = Interfaces.viewmodels.ViewModelPropertyType.Boolean, Required = required };
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
                "rps-breadcrumb a:last-of-type","",
                view,
               newView);
        }
        public static IRPSButton<T> RPSDeleteButton<T>(T view) where T : class, IView
        {
            return RPSControlFactory.CreateRPSButton<T>("", "[id='kendoToolbar'] a[title='Eliminar']","", view);
            
        }
        ////div[contains(@class, 'rps-window rps-flex-container k-window-content k-content')]//rps-text-button/div[text()='Si']
        public static IRPSButton<T,N> RPSConfirmDeleteButton<T,N>(T view,N newView) where T : class, IView where N : class, IView
        {
            return RPSControlFactory.CreateRPSButtonToView<T,N>("", "", "//div[contains(@class,'rps-window rps-flex-container k-window-content k-content')]//rps-text-button/div[text()='Si']", view,newView);

        }
        public static IRPSButton<T> RPSConsultButton<T>(T view) where T : class, IView
        {
            return RPSControlFactory.CreateRPSButton<T>("", "", "//rps-text-with-icon-button/div[text()[normalize-space()='Consultar']]", view);

        }
        public static IRPSSaveButton<T> RPSSaveButton<T>(T view) where T : class, IView
        {
            RPSSaveButton<T> button = new RPSSaveButton<T>();
            button.ID = "";
            button.CSSSelector = "[id = 'kendoToolbar'] a[title = 'Guardar']";
            button.XPathSelector = "";
            button.View = view;
            
            button.WebDriver = view.WebDriver;
            var prop = new ViewModelProperty { Type = Interfaces.viewmodels.ViewModelPropertyType.Command };
            button.ViewModelProperty = prop;

            prop.ViewModel = view.ViewModel;
            view.ViewModel.Properties.Add(prop);
            return button;            

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
        public static C RPSCreateCollectionWithGrid<C,T, N>(CollectionInit parameters, T view, N newView) where T : class, IView where N : class, IView where C:class, IRPSCollectionEditor<T,N>
        {
            Type myclass = typeof(C);
            ConstructorInfo cinfo = myclass.GetConstructor(new Type[] { });
            RPSCollectionEditor<T, N> container = (RPSCollectionEditor<T, N>)cinfo.Invoke(new object[] { });
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
            var grid = myclass.GetProperties( BindingFlags.Public).Where(p=>p.PropertyType is RPSGridView<T,N>).FirstOrDefault();
            if (grid != null)
            {
                ConstructorInfo ginfo = grid.GetType().GetConstructor(new Type[] { });
                var gridInstance = ginfo.Invoke(new object[] { });
                /*inicializamos el grid*/
                grid.SetValue(container, gridInstance);
            }
            return container as C;
        }

        public static C RPSCreateCollectionWithGrid<C, T>(CollectionInit parameters, T view) where T : class, IView where C : class, IRPSCollectionEditor<T>
        {
            Type myclass = typeof(C);
            ConstructorInfo cinfo = myclass.GetConstructor(new Type[] { });
            RPSCollectionEditor<T> container = (RPSCollectionEditor<T>)cinfo.Invoke(new object[] { });
            container.View = view;
           
            container.WebDriver = view.WebDriver;
            
            var grid = myclass.GetProperties(BindingFlags.Public).Where(p => p.PropertyType is RPSGridView<T>).FirstOrDefault();
            if (grid != null)
            {
                ConstructorInfo ginfo = grid.GetType().GetConstructor(new Type[] { });
                var gridInstance = ginfo.Invoke(new object[] { });
                /*inicializamos el grid*/
                grid.SetValue(container, gridInstance);
            }
            return container as C;
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
