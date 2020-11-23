using RPSSeleniumProperties.TemplateGenerator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RPSSeleniumProperties.TemplateGenerator.templates;
using RPSUIModelParser;
using RPSSeleniumProperties.TemplateGenerator.templates.EntityMaintenance;
using RPSSeleniumProperties.Interactables;

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
                    
                    var generator = CreateGenerator(view,model.ScreenName,model.Service,model.Package,model.Version,model.Customer);
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
        public static TemplateObject SectionToTemplate(Sections section, ComunicatorView view)
        {
            var sectioneditor = new RPSSectionTemplate { CssSelector =$"ul li[rpsid='{section.ID}']", ObjectName = section.Name, ViewType = view.Name };
            return sectioneditor;
        }
        public static TemplateObject CollectionToTemplate(CollectionEditor col, ComunicatorView view)
        {
            var childview = view.VMs[0].Children.Where(d => d.View != null).Select(d => d.View).FirstOrDefault();
            CollectionInit param = new CollectionInit();
            var desc = col.DescriptorViews.FirstOrDefault();
            if (desc!= null)
            {
                param.IDDescriptor = desc.ID;
            }
            var grid = col.GridViews.FirstOrDefault();
            if(grid != null)
            {
                param.IDGrid = grid.ID;
            }
            var editor = new RPSColletionEditorTemplate
            {
                ViewType = view.Name,
                ObjectName = col.Name,
                NewViewType = childview.Name,
                NewViewProperty = childview.Name, Parameters = param
            };
            return editor;
        }
        public static TemplateObject EditorToTemplate(PropertyEditor property,ComunicatorView view)
        {
            switch(property.type)
            {
                case "RPS.UI.Model.TextEditor, RPSUIModel":
                case "RPS.UI.Model.AmountEditor, RPSUIModel":
                case "RPS.UI.Model.PriceEditor, RPSUIModel":
                case "RPS.UI.Model.DateTimeEditor, RPSUIModel":
                    return new RPSTextBoxTemplate { ID = property.id, ViewType = view.Name, ObjectName = property.Name, Required = property.vmProperty.IsRequired };                    
                case "RPS.UI.Model.Button, RPSUIModel":
                    return new RPSButtonTemplate { ID = property.id, ViewType = view.Name, ObjectName = property.Name };
                case "RPS.UI.Model.LookupEditor, RPSUIModel":
                    return new RPSComboBoxTemplate { ID = property.id, ViewType = view.Name, ObjectName = property.Name, Required = property.vmProperty.IsRequired };
                default: 
                    return null;
            }
        }
        public static List<TemplateObject> AddDefaultTemplateControls(ComunicatorView view)
        {
            string viewtype = view.type;
            if (viewtype == "RPS.UI.Model.QueryViewDefinition, RPSUIModel")
            {
                var list = new List<TemplateObject>();
                //Esta tendra el control de nuevo
                if (view.VMs[0].Children.Count > 0)
                {

                    var main = view.VMs[0].MainModel;
                    if (main != null)
                    {
                        
                        list.Add(new RPSNewButtonTemplate() { ViewType = view.Name, NewViewType = main.View.Name, NewViewProperty = main.View.Name });
                        list.Add(new RPSConsultButtonTemplate() { ViewType = view.Name, NewViewType = main.View.Name, NewViewProperty = main.View.Name });
                    }
                    else
                    {

                    }
                    

                }
                else
                {
                   
                }
                return list;
            }
            else if (viewtype == "RPS.UI.Model.MainEntityViewDefinition, RPSUIModel")
            {
                //Esta tendra el control de nuevo (si tiene alguno que dependa de el), guardar, borrar y atras
                var list = new List<TemplateObject> {
                    
                    new RPSSaveButtonTemplate(){ ViewType = view.Name}
                    
                    
                };
                if (view.VMs[0].Children.Count > 0)
                {
                    var main = view.VMs[0].MainModel;
                    if (main != null)
                    {

                        list.Add(new RPSNewButtonTemplate() { ViewType = view.Name, NewViewType = main.View.Name, NewViewProperty = main.View.Name });
                        list.Add(new RPSConsultButtonTemplate() { ViewType = view.Name, NewViewType = main.View.Name, NewViewProperty = main.View.Name });
                    }
                    else
                    {

                    }
                }
                if (view.VMs[0].Parent != null)
                {
                    list.Add(new RPSDeleteButtonTemplate() { ViewType = view.Name, NewViewType = view.VMs[0].Parent.View.Name, NewViewProperty = view.VMs[0].Parent.View.Name });
                    list.Add(new RPSConfirmButtonTemplate() { ViewType = view.Name, NewViewType = view.VMs[0].Parent.View.Name, NewViewProperty = view.VMs[0].Parent.View.Name });
                    list.Add(new RPSBackButtonTemplate() { ViewType = view.Name, NewViewType = view.VMs[0].Parent.View.Name, NewViewProperty = view.VMs[0].Parent.View.Name });
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
                    var main = view.VMs[0].MainModel;
                    if (main != null)
                    {

                        list.Add(new RPSNewButtonTemplate() { ViewType = view.Name, NewViewType = main.View.Name, NewViewProperty = main.View.Name });
                        list.Add(new RPSConsultButtonTemplate() { ViewType = view.Name, NewViewType = main.View.Name, NewViewProperty = main.View.Name });
                    }
                    else
                    {

                    }
                }
                if (view.VMs[0].Parent != null)
                {
                    list.Add(new RPSDeleteButtonTemplate() { ViewType = view.Name, NewViewType = view.VMs[0].Parent.View.Name, NewViewProperty = view.VMs[0].Parent.View.Name });
                    list.Add(new RPSConfirmButtonTemplate() { ViewType = view.Name, NewViewType = view.VMs[0].Parent.View.Name, NewViewProperty = view.VMs[0].Parent.View.Name });
                    list.Add(new RPSBackButtonTemplate() { ViewType = view.Name, NewViewType = view.VMs[0].Parent.View.Name, NewViewProperty = view.VMs[0].Parent.View.Name });
                }
                return list;
            }
            else
            {
                return new List<TemplateObject> { };
            }
        }
        public static ITemplateGenerator CreateGenerator(ComunicatorView view,string screenname, string Service, string Package, string Version, string Customer)
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
                te.Model.ScreenName = screenname;
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
                foreach(var col in view.Collections)
                {
                    var collection = CollectionToTemplate(col, view);
                    te.Model.Controls.Add(collection);
                }
                foreach(var sec in view.Sections)
                {
                    var section = SectionToTemplate(sec,view);
                    te.Model.Controls.Add(section);
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
                te.Model.ScreenName = screenname;
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
                foreach (var col in view.Collections)
                {
                    var collection = CollectionToTemplate(col, view);
                    te.Model.Controls.Add(collection);
                }
                foreach (var sec in view.Sections)
                {
                    var section = SectionToTemplate(sec, view);
                    te.Model.Controls.Add(section);
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
                te.Model.ScreenName = screenname;
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
                foreach (var col in view.Collections)
                {
                    var collection = CollectionToTemplate(col, view);
                    te.Model.Controls.Add(collection);
                }
                foreach (var sec in view.Sections)
                {
                    var section = SectionToTemplate(sec, view);
                    te.Model.Controls.Add(section);
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
