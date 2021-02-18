using RPSSeleniumProperties.TemplateGenerator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RPSSeleniumProperties.TemplateGenerator.templates;
using RPSUIModelParser;
using RPSSeleniumProperties.TemplateGenerator.templates.EntityMaintenance;
using RPSSeleniumProperties.Interactables;
using RPSSeleniumProperties.TemplateGenerator.templates.UnitTest;
using System.IO;
using System.Threading.Tasks;

namespace RPSSeleniumClassGenerator
{
    public class UIModelToString:IDisposable
       
    {
        RPSUIModelParser.UIModel currentmodel = null;
        public  string GenerateCS(RPSUIModelParser.UIModel model)
        {
            /*if (model.UIComponents.Any(d => d.type.Contains("RPS.UI.Model.MainEntityViewDefinition")))
            {*/
                currentmodel = model;
                var screen = RPSSeleniumProperties.TemplateGenerator.templates.TemplateFactory.CreateEntityMaintenanceScreen();
                screen.Model.FullType = model.FullName;
                screen.Model.Name = model.Name;
                screen.Model.Service = model.Service;
                screen.Model.Package = model.Package;
                screen.Model.Version = model.Version;
                screen.Model.Customer = model.Customer;
                foreach (var view in model.UIComponents)
                {
                    view.Name = screen.Model.GetViewName(view.Name);   
                    var generator = CreateGenerator(view,model.ScreenName,model.Service,model.Package,model.Version,model.Customer);
                    if (generator != null)
                    {
                        TemplateView v = new TemplateView() { ViewType = view.Name, ObjectName =  view.Name, Template = generator };
                        screen.Model.Views.Add(v);
                    }
                 
                }
                return screen.TransformText();           
            /*}
            else
            {
                return "";
            }*/
        }
        public  async Task GenerateUnitTestCS(RPSUIModelParser.UIModel model, string destfolder)
        {
            if (model.UIComponents.Any(d => d.VMs.Any(v => v.MainModel != null)))
            {
                DirectoryInfo d = new DirectoryInfo(destfolder);
                string fullpath = Path.Combine(destfolder, "UnitTest", model.Customer, model.Package, model.Service, $"{model.Name }.cs");
                if (!File.Exists(fullpath))
                {
                    DirectoryInfo d1 = new DirectoryInfo(Path.GetDirectoryName(fullpath));
                    if (!d1.Exists)
                    {
                        d1.Create();
                    }
                    Console.WriteLine($"Generating {fullpath}");
                    /*if (model.UIComponents.Any(d => d.type.Contains("RPS.UI.Model.MainEntityViewDefinition")))
                    {*/
                    CRUDUnitTestVM vm = new CRUDUnitTestVM();
                    vm.FileNameNoExtension = model.Name;
                    vm.UsingToSeleniumGeneratedClasses = $"SeleniumGeneratedClasses.{model.Customer}.{model.Package}.Services.{model.Service}";
                    vm.Namespace = $"UnitTest.{model.Customer}.{model.Package}.Services.{model.Service}";
                    vm.SeleniumConfigNamespace = d.Name;


                    CRUDUnitTest UT = new CRUDUnitTest();
                    UT.Model = vm;
                    string test = UT.TransformText();
                    await File.WriteAllTextAsync(fullpath, test);
                }
                else
                {
                    Console.WriteLine($"Skipped {fullpath} it already exists");
                }
                /*}
                else
                {
                    return "";
                }*/
            }
        }
        public  TemplateObject SectionToTemplate(Sections section, ComunicatorView view, ViewVM model)
        {
            var sectioneditor = new RPSSectionTemplate { CssSelector =$"ul li[rpsid='{section.ID}']", ObjectName = model.GetControlName(section.Name), ViewType = view.Name };
            return sectioneditor;
        }
        public  TemplateObject CollectionToTemplate(CollectionEditor col, ComunicatorView view, ViewVM model)
        {
            var childview = view.VMs[0].Children.Where(d => d.View != null).Select(d => d.View).FirstOrDefault();
            if (childview != null)
            {
                CollectionInit param = new CollectionInit();
             
                var desc = col.DescriptorViews.FirstOrDefault();
                if (desc != null)
                {
                    param.IDDescriptor = desc.ID;
                }
                var grid = col.GridViews.FirstOrDefault();
                if (grid != null)
                {
                    param.IDGrid = grid.ID;
                   
                   
                }
                var editor = new RPSColletionEditorTemplate
                {
                    ViewType = view.Name,
                    ObjectName = model.GetControlName(col.Name),
                    ObjectType = col.Name,
                    NewViewType = childview.Name,
                    NewViewProperty = childview.Name,
                    Parameters = param
                };
                return editor;
            }
            else
            {
                CollectionInit param = new CollectionInit();

                var desc = col.DescriptorViews.FirstOrDefault();
                if (desc != null)
                {
                    param.IDDescriptor = desc.ID;
                }
                var grid = col.GridViews.FirstOrDefault();
                if (grid != null)
                {
                    param.IDGrid = grid.ID;


                }
                var editor = new RPSColletionEditorTemplate
                {
                    ViewType = view.Name,
                    ObjectName = model.GetControlName(col.Name),
                    ObjectType = col.Name,
                    NewViewType = "",
                    NewViewProperty = "",
                    Parameters = param
                };
                return editor;
            }
        }
        public  TemplateObject ViewEditorToTemplate(ViewEditor ed, ComunicatorView view)
        {
            if (view.VMs[0].Children.Count > 0)
            {

                var main = view.VMs[0].MainModel;
                if (main != null && main.View != null)
                {
                    CollectionInit param = new CollectionInit();
                    param.IDDescriptor = ed.ID;
                    var editor = new RPSColletionEditorTemplate
                    {
                        ViewType = view.Name,
                        ObjectName = "MainConsult",
                        NewViewType = main.View.Name,
                        NewViewProperty = main.View.Name,
                        Parameters = param
                    };
                    return editor;
                }
                else
                {
                    var relatedView = view.VMs[0].View;
                    if (relatedView != null)
                    {
                        CollectionInit param = new CollectionInit();
                        param.IDDescriptor = ed.ID;
                        var editor = new RPSColletionEditorTemplate
                        {
                            ViewType = view.Name,
                            ObjectName = "MainConsult",
                            NewViewType = relatedView.Name,
                            NewViewProperty = relatedView.Name,
                            Parameters = param
                        };
                        return editor;
                    }
                    else
                    {
                        return null;
                    }
                }                                                                
            }
            else
            {
                return null;
            }
        }
        public  TemplateObject EditorToTemplate(PropertyEditor property,ComunicatorView view, ViewVM model)
        {
            bool required = false;
            if (property.vmProperty != null)
            {
                required = property.vmProperty.IsRequired;
            }
            switch(property.type)
            {
                case "RPS.UI.Model.EmailEditor, RPSUIModel":
                    return new RPSEmailTextBoxTemplate { ID = property.id, ViewType = view.Name, ObjectName = model.GetControlName(property.Name), Required = required };
                case "RPS.UI.Model.DecimalEditor, RPSUIModel":
                case "RPS.UI.Model.AmountEditor, RPSUIModel":
                case "RPS.UI.Model.PriceEditor, RPSUIModel":
                case "RPS.UI.Model.QuantityEditor, RPSUIModel":               
                case "RPS.UI.Model.PercentageEditor, RPSUIModel":
                case "RPS.UI.Model.IntegerEditor, RPSUIModel":
                    return new RPSFormattedTextBoxTemplate { ID = property.id, ViewType = view.Name, ObjectName = model.GetControlName(property.Name), Required = required };
                case "RPS.UI.Model.TextEditor, RPSUIModel":                                             
                case "RPS.UI.Model.DateTimeEditor, RPSUIModel":
                case "RPS.UI.Model.PasswordEditor, RPSUIModel":
                case "RPS.UI.Model.LongEditor, RPSUIModel":
                case "RPS.UI.Model.TimeEditor, RPSUIModel":
                    return new RPSTextBoxTemplate { ID = property.id, ViewType = view.Name, ObjectName = model.GetControlName(property.Name), Required = required };                    
                case "RPS.UI.Model.Button, RPSUIModel":
                    {
                        if (property.vmProperty  == null || property.vmProperty.VMToNavigate == null)
                        {
                            return new RPSButtonTemplate { ID = property.id, ViewType = view.Name, ObjectName = model.GetControlName(property.Name) };
                        }
                        else
                        {
                            return new RPSButtonTemplate { ID = property.id, ViewType = view.Name, ObjectName = model.GetControlName(property.Name), NewViewProperty = property.vmProperty.VMToNavigate.View.Name, NewViewType = property.vmProperty.VMToNavigate.View.Name };
                        }
                    }
                case "RPS.UI.Model.ColorEditor, RPSUIModel":
                    return new RPSColorEditorTemplate { ID = property.id, ViewType = view.Name, ObjectName = model.GetControlName(property.Name) };
                case "RPS.UI.Model.LookupEditor, RPSUIModel":
                    return new RPSComboBoxTemplate { ID = property.id, ViewType = view.Name, ObjectName = model.GetControlName(property.Name), Required = required };
                case "RPS.UI.Model.MultiLookupEditor, RPSUIModel":
                    return new RPSCollectionComboBoxTemplate { ID = property.id, ViewType = view.Name, ObjectName = model.GetControlName(property.Name), Required = required };
                case "RPS.UI.Model.EnumEditor, RPSUIModel":
                case "RPS.UI.Model.OptionEditor, RPSUIModel":
                case "RPS.UI.Model.TextComboEditor, RPSUIModel":
                    return new RPSEnumComboBoxTemplate { ID = property.id, ViewType = view.Name, ObjectName = model.GetControlName(property.Name), Required = required };
                case "RPS.UI.Model.CheckBoxEditor, RPSUIModel":
                    return new RPSCheckboxTemplate { ID = property.id, ViewType = view.Name, ObjectName = model.GetControlName(property.Name), Required = required };
                case "RPS.UI.Model.OptionValueEditor, RPSUIModel":
                    return new RPSOptionTemplate { ID = property.id, ViewType = view.Name, ObjectName = model.GetControlName(property.Name), Required = required };
                case "RPS.UI.Model.DurationEditor, RPSUIModel":
                    return new RPSDurationTextBoxTemplate { ID = property.id, ViewType = view.Name, ObjectName = model.GetControlName(property.Name), Required = required };

                case "RPS.UI.Model.EntityDescriptor, RPSUIModel":
                case "RPS.UI.Model.Label, RPSUIModel":
                case "RPS.UI.Model.FormattedNumber, RPSUIModel":
                case "RPS.UI.Model.IconEditor, RPSUIModel":
                case "RPS.UI.Model.LookupDescriptor, RPSUIModel":
                case "RPS.UI.Model.ImageEditor, RPSUIModel":
                    return new IgnoredObjectTemplate();
                
                default: 
                    return null;
            }
        }
        public  TemplateObject EditorToGridTemplate(string gridID,PropertyEditor property, ComunicatorView view, RPSSeleniumProperties.TemplateGenerator.templates.Grids.CollectionEditorVM model)
        {
            string selector = "#" + gridID + " .ag-row[role='row'] [col-id='c" + property.vmProperty.Name + "']";
            switch (property.type)
            {
                case "RPS.UI.Model.EmailEditor, RPSUIModel":
                    return new RPSGridEmailTextBoxTemplate { CssSelector = selector, ViewType = view.Name, ObjectName = model.GetControlName(property.Name), Required = property.vmProperty.IsRequired };
                case "RPS.UI.Model.DecimalEditor, RPSUIModel":
                case "RPS.UI.Model.AmountEditor, RPSUIModel":
                case "RPS.UI.Model.PriceEditor, RPSUIModel":
                case "RPS.UI.Model.QuantityEditor, RPSUIModel":
                case "RPS.UI.Model.PercentageEditor, RPSUIModel":
                case "RPS.UI.Model.IntegerEditor, RPSUIModel":
                    return new RPSGridFormattedTextBoxTemplate { CssSelector = selector, ViewType = view.Name, ObjectName = model.GetControlName(property.Name), Required = property.vmProperty.IsRequired };
                case "RPS.UI.Model.TextEditor, RPSUIModel":
                case "RPS.UI.Model.DateTimeEditor, RPSUIModel":
                case "RPS.UI.Model.PasswordEditor, RPSUIModel":
                case "RPS.UI.Model.LongEditor, RPSUIModel":
                case "RPS.UI.Model.TimeEditor, RPSUIModel":
                    
                    return new RPSGridTextBoxTemplate { CssSelector = selector, ViewType = view.Name, ObjectName = model.GetControlName(property.Name), Required = property.vmProperty.IsRequired };
                case "RPS.UI.Model.Button, RPSUIModel":
                    {
                        if (property.vmProperty == null || property.vmProperty.VMToNavigate == null)
                        {
                            return new RPSGridButtonTemplate { CssSelector = selector, ViewType = view.Name, ObjectName = model.GetControlName(property.Name) };
                        }
                        else
                        {
                            return new RPSGridButtonTemplate { CssSelector = selector, ViewType = view.Name, ObjectName = model.GetControlName(property.Name), NewViewProperty = property.vmProperty.VMToNavigate.View.Name, NewViewType = property.vmProperty.VMToNavigate.View.Name };
                        }
                    }
                case "RPS.UI.Model.LookupEditor, RPSUIModel":
                    return new RPSGridComboBoxTemplate { CssSelector =selector, ViewType = view.Name, ObjectName = property.Name, Required = property.vmProperty.IsRequired };
                case "RPS.UI.Model.EnumEditor, RPSUIModel":
                case "RPS.UI.Model.OptionEditor, RPSUIModel":
                case "RPS.UI.Model.TextComboEditor, RPSUIModel":
                    return new RPSGridEnumComboBoxTemplate { CssSelector = selector, ViewType = view.Name, ObjectName = property.Name, Required = property.vmProperty.IsRequired };
                case "RPS.UI.Model.CheckBoxEditor, RPSUIModel":
                   
                 return new RPSGridCheckboxTemplate { CssSelector = selector, ViewType = view.Name, ObjectName = property.Name, Required = property.vmProperty.IsRequired };
                case "RPS.UI.Model.DurationEditor, RPSUIModel":
                    return new RPSGridDurationTextBoxTemplate { CssSelector = selector, ViewType = view.Name, ObjectName = model.GetControlName(property.Name), Required = property.vmProperty.IsRequired };
                case "RPS.UI.Model.EntityDescriptor, RPSUIModel":
                case "RPS.UI.Model.Label, RPSUIModel":
                case "RPS.UI.Model.FormattedNumber, RPSUIModel":
                case "RPS.UI.Model.IconEditor, RPSUIModel":
                case "RPS.UI.Model.LookupDescriptor, RPSUIModel":
                case "RPS.UI.Model.ImageEditor, RPSUIModel":
                case "RPS.UI.Model.EntityStateEditor, RPSUIModel":
                    return new IgnoredObjectTemplate();
                default:
                    return null;
            }
        }
        public  List<TemplateObject> AddDefaultTemplateControls(ComunicatorView view)
        {
            string viewtype = view.type;
            if (viewtype == "RPS.UI.Model.QueryViewDefinition, RPSUIModel")
            {
                var list = new List<TemplateObject>();
                //Esta tendra el control de nuevo
                if (view.VMs[0].Children.Count > 0)
                {

                    var main = view.VMs[0].MainModel;
                    if (main != null && main.View != null)
                    {
                        
                        list.Add(new RPSNewButtonTemplate() { ViewType = view.Name, NewViewType = main.View.Name, NewViewProperty = main.View.Name });
                        list.Add(new RPSConsultButtonTemplate() { ViewType = view.Name, NewViewType = main.View.Name, NewViewProperty = main.View.Name });

                        /*if (view.VMs[0].type == "RPS.UI.Model.CrudScreenVMDefinition, RPSUIModel")
                        {
                            CollectionInit param = new CollectionInit();
                            param.CSSSelectorDescriptor = "rps-descriptor-view";
                            list.Add(new RPSColletionEditorTemplate() { 
                                ViewType = view.Name, 
                                NewViewType = main.View.Name, 
                                NewViewProperty = main.View.Name, 
                                ObjectName = "MainConsult",
                                Parameters = param });
                        }*/
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
            else if (viewtype == "RPS.UI.Model.CrudViewDefinition, RPSUIModel")
            {
                var list = new List<TemplateObject>();
                //Esta tendra el control de nuevo
                if (view.VMs[0].Children.Count > 0)
                {

                    var main = view.VMs[0].MainModel;
                    if (main != null)
                    {

                        list.Add(new RPSNewButtonTemplate() { ViewType = view.Name, NewViewType = main.View.Name, NewViewProperty = main.View.Name });
                        //list.Add(new RPSConsultButtonTemplate() { ViewType = view.Name, NewViewType = main.View.Name, NewViewProperty = main.View.Name });
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
                if (view.VMs[0].Parent != null && view.VMs[0].Parent.View != null)
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
                if (view.VMs[0].Parent != null && view.VMs[0].Parent.View != null)
                {
                    list.Add(new RPSDeleteButtonTemplate() { ViewType = view.Name, NewViewType = view.VMs[0].Parent.View.Name, NewViewProperty = view.VMs[0].Parent.View.Name });
                    list.Add(new RPSConfirmButtonTemplate() { ViewType = view.Name, NewViewType = view.VMs[0].Parent.View.Name, NewViewProperty = view.VMs[0].Parent.View.Name });
                    list.Add(new RPSBackButtonTemplate() { ViewType = view.Name, NewViewType = view.VMs[0].Parent.View.Name, NewViewProperty = view.VMs[0].Parent.View.Name });

                    list.Add(new RPSAcceptButtonTemplate() { ViewType = view.Name, NewViewType = view.VMs[0].Parent.View.Name, NewViewProperty = view.VMs[0].Parent.View.Name });                
                }
                return list;
            }
            else
            {
                return new List<TemplateObject> { };
            }
        }
        public  ITemplateGenerator CreateGenerator(ComunicatorView view,string screenname, string Service, string Package, string Version, string Customer)
        {
            string viewtype = view.type;
           /* if  (viewtype == "RPS.UI.Model.QueryViewDefinition, RPSUIModel")
            {*/
                var te = new View();
                te.Model = new ViewVM();
                te.Model.Service = Service;
                te.Model.Package = Package;
                te.Model.Version = Version;
                te.Model.Customer = Customer;
                te.Model.ScreenName = screenname;
                te.Model.ViewType = view.Name;
                te.Model.Controls.AddRange(AddDefaultTemplateControls(view));
                foreach(var c in view.PropertyEditors)
                {
                    var ctr = EditorToTemplate(c,view,te.Model);
                    if (ctr != null)
                    {
                        if (ctr is IgnoredObjectTemplate)
                        {
                            ErrorManagement.AddError(new Error
                            {
                                FileName = this.currentmodel.FullName,
                                EType = ErrorType.IgnoredControl,
                                ViewName = view.Name,
                                EditorId = c.id,
                                EditorType = c.type,
                                Message =
                            $"Ignoring generating control {c.id}-{c.type}"
                            });
                        }
                        else
                        {
                            te.Model.Controls.Add(ctr);
                        }
                    }
                    else
                    {
                        ErrorManagement.AddError(new Error
                        {
                            FileName = this.currentmodel.FullName,
                            EType = ErrorType.ControlNotGenerated,
                            ViewName = view.Name,
                            EditorId = c.id,
                            EditorType = c.type,
                            Message =
                            $"Error generating control {c.id}-{c.type}"
                        });                        
                    }
                }
                foreach(var col in view.Collections)
                {
                    var collection = CollectionToTemplate(col, view,te.Model);
                    if (collection != null)
                    {
                        te.Model.Controls.Add(collection);
                        foreach(var gv in col.GridViews)
                        {
                            if (!te.Model.CollectionClasses.Any(d => d is RPSSeleniumProperties.TemplateGenerator.templates.Grids.CollectionEditor &&
                            (d as RPSSeleniumProperties.TemplateGenerator.templates.Grids.CollectionEditor).Model.CollectionName == col.Name &&
                            (d as RPSSeleniumProperties.TemplateGenerator.templates.Grids.CollectionEditor).Model.GridName == gv.Name &&
                            (d as RPSSeleniumProperties.TemplateGenerator.templates.Grids.CollectionEditor).Model.ViewType == (collection as RPSColletionEditorTemplate).ViewType
                            ))
                            {
                                RPSSeleniumProperties.TemplateGenerator.templates.Grids.CollectionEditor coltemplate = new RPSSeleniumProperties.TemplateGenerator.templates.Grids.CollectionEditor();
                                coltemplate.Model = new RPSSeleniumProperties.TemplateGenerator.templates.Grids.CollectionEditorVM();
                                coltemplate.Model.CollectionName = col.Name;
                                coltemplate.Model.Customer = te.Model.Customer;

                                coltemplate.Model.GridName = gv.Name;
                                coltemplate.Model.NewVieType = (collection as RPSColletionEditorTemplate).NewViewType;
                                coltemplate.Model.Package = te.Model.Package;
                                coltemplate.Model.ScreenName = te.Model.ScreenName;
                                coltemplate.Model.Service = te.Model.Service;
                                coltemplate.Model.Version = te.Model.Version;
                                coltemplate.Model.ViewType = (collection as RPSColletionEditorTemplate).ViewType;
                                foreach (var editor in gv.PropertyEditors)
                                {
                                    var ctr = EditorToGridTemplate(gv.ID, editor, view,coltemplate.Model);
                                    if (ctr != null)
                                    {
                                        if (ctr is IgnoredObjectTemplate)
                                        {
                                            ErrorManagement.AddError(new Error
                                            {
                                                FileName = this.currentmodel.FullName,
                                                EType = ErrorType.IgnoredControlInGrid,
                                                ViewName = view.Name,
                                                EditorType = editor.type,
                                                EditorId = editor.id,
                                                GridID = gv.ID,
                                                CollectionName = col.Name,
                                                Message =
                                                $"There is an ignored control { editor.id }-{ editor.type } in grid { gv.ID } of collection { col.Name }"
                                            });
                                        }
                                        else
                                        {
                                            coltemplate.Model.Controls.Add(ctr);
                                        }
                                        
                                    }
                                    else
                                    {
                                        ErrorManagement.AddError(new Error
                                        {
                                            FileName = this.currentmodel.FullName,
                                            EType = ErrorType.ControlNotGeneratedInGrid,
                                            ViewName = view.Name,
                                            EditorType = editor.type,
                                            EditorId = editor.id,
                                            GridID = gv.ID,
                                            CollectionName = col.Name,
                                            Message =
                                            $"There is a null control { editor.id }-{ editor.type } in grid { gv.ID } of collection { col.Name }"
                                        });


                                        //Console.WriteLine($"There is a null control {editor.id}-{editor.type} in grid {gv.ID} of collection {col.Name}");
                                    }
                                }
                                te.Model.CollectionClasses.Add(coltemplate);
                            }
                        }                        
                    }
                    else {
                        ErrorManagement.AddError(new Error
                        {
                            FileName = this.currentmodel.FullName,
                            EType = ErrorType.CollectionNotGenerated,
                            ViewName = view.Name,                            
                            EditorType = col.type,
                            EditorId = col.ID,
                            CollectionName = col.Name,
                            Message =
                            $"There is a null collection {col.ID}-{col.type}"
                        });
                    
                    }
                }
                foreach(var sec in view.Sections)
                {
                    
                    var section = SectionToTemplate(sec,view, te.Model);
                    if (section != null)
                    {
                        te.Model.Controls.Add(section);
                    }
                    else {
                        ErrorManagement.AddError(new Error
                        {
                            FileName = this.currentmodel.FullName,
                            EType = ErrorType.SectionNotGenerated,
                            ViewName = view.Name,
                            EditorId = sec.ID,
                            EditorType = "Section",
                            Message =
                           $"There is a null section {sec.ID}"
                        });
                    
                    }
                }
                foreach(var ed in view.ViewEditor)
                {
                    var editor = ViewEditorToTemplate(ed, view); 
                    if (editor != null)
                    {
                        te.Model.Controls.Add(editor);
                    }
                    else
                    {
                        ErrorManagement.AddError(new Error
                        {
                            FileName = this.currentmodel.FullName,
                            EType = ErrorType.SectionNotGenerated,
                            ViewName = view.Name,
                            EditorId = ed.ID,
                            EditorType = "ViewEditor",
                                Message =
                           $"There is a null vieweditor {ed.ID}"
                        });
                    
                    }

                }
                return te;
           /* }
            else if (viewtype == "RPS.UI.Model.MainEntityViewDefinition, RPSUIModel")
            {
                var te = new View();
                te.Model = new ViewVM();
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
                var te = new View();
                te.Model = new ViewVM();
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
            }*/
        }

        public void Dispose()
        {
            
        }
    }
}
