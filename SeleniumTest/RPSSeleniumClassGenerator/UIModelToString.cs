using RPSSeleniumProperties.TemplateGenerator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RPSSeleniumProperties.TemplateGenerator.templates;
using RPSUIModelParser;
using RPSSeleniumProperties.TemplateGenerator.templates.EntityMaintenance;

namespace RPSSeleniumClassGenerator
{
    public class UIModelToString
    {
        public static string GenerateCS(RPSUIModelParser.UIModel model)
        {
            if (model.UIComponents.Any(d => d.type.Contains("RPS.UI.Model.MainEntityViewDefinition")))
            {
                var screen = RPSSeleniumProperties.TemplateGenerator.templates.TemplateFactory.CreateEntityMaintenanceScreen();
                screen.Model.FullType = model.FullName;
                screen.Model.Name = model.Name;
                screen.Model.Service = model.Service;
                screen.Model.Package = model.Package;
                screen.Model.Version = model.Version;
                screen.Model.Customer = model.Customer;
                foreach (var view in model.UIComponents)
                {
                    
                    var generator = CreateGenerator(view,model.Service,model.Package,model.Version,model.Customer);
                    if (generator != null)
                    {
                        TemplateView v = new TemplateView() { ViewType = view.Name, ObjectName = view.Name, Template = generator };
                        screen.Model.Views.Add(v);
                    }
                    
                }
                return screen.TransformText();
                
            }
            else
            {
                return "";
            }
        }
        public static TemplateObject EditorToTemplate(PropertyEditor property,ComunicatorView view)
        {
            switch(property.type)
            {
                case "RPS.UI.Model.TextEditor, RPSUIModel":
                case "RPS.UI.Model.AmountEditor, RPSUIModel":
                case "RPS.UI.Model.PriceEditor, RPSUIModel":
                case "RPS.UI.Model.DateTimeEditor":
                    return new RPSTextBoxTemplate { ID = property.id, ViewType = view.Name, ObjectName = property.vmProperty.Name };                    
                case "RPS.UI.Model.Button, RPSUIModel":
                    return new RPSButtonTemplate { ID = property.id, ViewType = view.Name, ObjectName = property.vmProperty.Name };
                default: 
                    return null;
            }
        }
        public static List<TemplateObject> AddDefaultTemplateControls(ComunicatorView view)
        {
            string viewtype = view.type;
            if (viewtype == "RPS.UI.Model.QueryViewDefinition, RPSUIModel")
            {
                //Esta tendra el control de nuevo
                if (view.VMs[0].Children.Count > 0)
                {
                    return new List<TemplateObject> { new RPSNewButtonTemplate() { ViewType = view.Name } };
                }
                else
                {
                    return new List<TemplateObject>();
                }
            }
            else if (viewtype == "RPS.UI.Model.MainEntityViewDefinition, RPSUIModel")
            {
                //Esta tendra el control de nuevo (si tiene alguno que dependa de el), guardar, borrar y atras
                var list = new List<TemplateObject> {
                    
                    new RPSSaveButtonTemplate(){ ViewType = view.Name}
                    
                    
                };
                if (view.VMs[0].Children.Count > 0)
                {
                    list.Add(new RPSNewButtonTemplate() { ViewType = view.Name, NewViewType = view.VMs[0].Children[0].View.Name });
                }
                if (view.VMs[0].Parent != null)
                {
                    list.Add(new RPSDeleteButtonTemplate() { ViewType = view.Name, NewViewType = view.VMs[0].Parent.View.Name });
                    list.Add(new RPSBackButtonTemplate() { ViewType = view.Name, NewViewType = view.VMs[0].Parent.View.Name });
                }
                return list;
            }
            else if (viewtype == "RPS.UI.Model.EntityViewDefinition, RPSUIModel")
            {
                //Esta tendra el control de nuevo si tiene alguno que dependa de el, guardar, borrar y atras
                var list = new List<TemplateObject> {

                    new RPSSaveButtonTemplate(){ ViewType = view.Name}


                };
                if (view.VMs[0].Children.Count > 0)
                {
                    list.Add(new RPSNewButtonTemplate() { ViewType = view.Name, NewViewType = view.VMs[0].Children[0].View.Name });
                }
                if (view.VMs[0].Parent != null)
                {
                    list.Add(new RPSDeleteButtonTemplate() { ViewType = view.Name, NewViewType = view.VMs[0].Parent.View.Name });
                    list.Add(new RPSBackButtonTemplate() { ViewType = view.Name, NewViewType = view.VMs[0].Parent.View.Name });
                }
                return list;
            }
            else
            {
                return new List<TemplateObject> { };
            }
        }
        public static ITemplateGenerator CreateGenerator(ComunicatorView view, string Service, string Package, string Version, string Customer)
        {
            string viewtype = view.type;
            if  (viewtype == "RPS.UI.Model.QueryViewDefinition, RPSUIModel")
            {
                var te = new EntityEditorView();
                te.Model = new EntityEditorViewVM();
                te.Model.Service = Service;
                te.Model.Package = Package;
                te.Model.Version = Version;
                te.Model.Customer = Customer;
                te.Model.ScreenName = view.Name;
                te.Model.ViewType = view.Name;
                te.Model.Controls.AddRange(AddDefaultTemplateControls(view));
                foreach(var c in view.PropertyEditors)
                {
                    var ctr = EditorToTemplate(c,view);
                    if (ctr != null)
                    {
                        te.Model.Controls.Add(ctr);
                    }
                }
                return te;
            }
            else if (viewtype == "RPS.UI.Model.MainEntityViewDefinition, RPSUIModel")
            {
                var te = new EntityEditorView();
                te.Model = new EntityEditorViewVM();
                te.Model.Service = Service;
                te.Model.Package = Package;
                te.Model.Version = Version;
                te.Model.Customer = Customer;
                te.Model.ScreenName = view.Name;
                te.Model.ViewType = view.Name;
                te.Model.ParentViewType = view.VMs[0].Parent.View.Name;
                te.Model.Controls.AddRange(AddDefaultTemplateControls(view));
                foreach (var c in view.PropertyEditors)
                {
                    var ctr = EditorToTemplate(c,view);
                    if (ctr != null)
                    {
                        te.Model.Controls.Add(ctr);
                    }
                }
                return te;
            }
            else if (viewtype == "RPS.UI.Model.EntityViewDefinition, RPSUIModel")
            {
                var te = new EntityEditorView();
                te.Model = new EntityEditorViewVM();
                te.Model.Service = Service;
                te.Model.Package = Package;
                te.Model.Version = Version;
                te.Model.Customer = Customer;
                te.Model.ScreenName = view.Name;
                te.Model.ViewType = view.Name;
                te.Model.ParentViewType = view.VMs[0].Parent.View.Name;
                te.Model.Controls.AddRange(AddDefaultTemplateControls(view));
                foreach (var c in view.PropertyEditors)
                {
                    var ctr = EditorToTemplate(c,view);
                    if (ctr != null)
                    {
                        te.Model.Controls.Add(ctr);
                    }
                }
                return te;
            }
            else
            {
                return null;
            }
        }
    }
}
