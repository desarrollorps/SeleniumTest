using RPSSeleniumProperties.Interactables;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace RPSSeleniumProperties.TemplateGenerator
{
    public class RPSColletionEditorTemplate:TemplateObject
    {
        private string _objecttype;
        public string ObjectType { get { return String.Concat(_objecttype.Where(c => !Char.IsWhiteSpace(c))); } set { _objecttype = value; } }

        private string _newviewtype;
        public string NewViewType { get { return String.Concat(_newviewtype.Where(c => !Char.IsWhiteSpace(c))); } set { _newviewtype = value; } }

        private string newviewproperty;
        public string NewViewProperty { get { return String.Concat(newviewproperty.Where(c => !Char.IsWhiteSpace(c))); } set { newviewproperty = value; } }
        public CollectionInit Parameters { get; set; }
        public override string GenerateObjectDefinition()
        {
            if (string.IsNullOrEmpty(Parameters.IDGrid) && string.IsNullOrEmpty(Parameters.CSSSelectorGrid) && string.IsNullOrEmpty(Parameters.XPathGrid))
            {
                if (string.IsNullOrEmpty(this.NewViewType))
                {
                    return $"public IRPSCollectionEditor<{ViewType}> {this.ObjectName} {{ get; set; }}";
                }
                else
                {
                    return $"public IRPSCollectionEditor<{ViewType},{NewViewType}> {this.ObjectName} {{ get; set; }}";
                }
            }
            else
            {
                if (string.IsNullOrEmpty(this.NewViewType))
                {
                    return $"public {this.ObjectType}CollectionEditor<{ViewType}> {this.ObjectName} {{ get; set; }}";
                }
                else
                {
                    return $"public {this.ObjectType}CollectionEditor<{ViewType},{NewViewType}> {this.ObjectName} {{ get; set; }}";
                }
            }
            
        }

        public override List<string> GenerateObjectInitialization()
        {
            if (string.IsNullOrEmpty(Parameters.IDGrid) && string.IsNullOrEmpty(Parameters.CSSSelectorGrid) && string.IsNullOrEmpty(Parameters.XPathGrid))
            {
                if (string.IsNullOrEmpty(this.NewViewType))
                {
                    List<string> definition = new List<string>();
                    definition.Add($"CollectionInit params_{this.ObjectName} = new CollectionInit(){{IDDescriptor = \"{Parameters.IDDescriptor}\",CSSSelectorDescriptor = \"{Parameters.CSSSelectorDescriptor}\",XPathDescriptor = \"{Parameters.XPathDescriptor}\"}};");
                    definition.Add($"{this.ObjectName} = RPSControlFactory.RPSCreateCollection<{ViewType}>( params_{this.ObjectName},this);");
                    return definition;
                }
                else
                {
                    List<string> definition = new List<string>();
                    definition.Add($"CollectionInit params_{this.ObjectName} = new CollectionInit(){{IDDescriptor = \"{Parameters.IDDescriptor}\",CSSSelectorDescriptor = \"{Parameters.CSSSelectorDescriptor}\",XPathDescriptor = \"{Parameters.XPathDescriptor}\"}};");
                    definition.Add($"{this.ObjectName} = RPSControlFactory.RPSCreateCollection<{ViewType},{NewViewType}>( params_{this.ObjectName},this,{Constants.ScreenProperty}.{NewViewProperty});");
                    return definition;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(this.NewViewType))
                {
                    List<string> definition = new List<string>();
                    definition.Add($"CollectionInit params_{this.ObjectName} = new CollectionInit(){{IDDescriptor = \"{Parameters.IDDescriptor}\",CSSSelectorDescriptor = \"{Parameters.CSSSelectorDescriptor}\",XPathDescriptor = \"{Parameters.XPathDescriptor}\",IDGrid=\"{Parameters.IDGrid}\",CSSSelectorGrid=\"{Parameters.CSSSelectorGrid}\",XPathGrid=\"{Parameters.XPathGrid}\"}};");
                    definition.Add($"{this.ObjectName} = RPSControlFactory.RPSCreateCollectionWithGrid<{this.ObjectType}CollectionEditor<{ViewType}>,{ViewType}>( params_{this.ObjectName},this);");
                    return definition;
                }
                else
                {
                    List<string> definition = new List<string>();
                    definition.Add($"CollectionInit params_{this.ObjectName} = new CollectionInit(){{IDDescriptor = \"{Parameters.IDDescriptor}\",CSSSelectorDescriptor = \"{Parameters.CSSSelectorDescriptor}\",XPathDescriptor = \"{Parameters.XPathDescriptor}\",IDGrid=\"{Parameters.IDGrid}\",CSSSelectorGrid=\"{Parameters.CSSSelectorGrid}\",XPathGrid=\"{Parameters.XPathGrid}\"}};");
                    definition.Add($"{this.ObjectName} = RPSControlFactory.RPSCreateCollectionWithGrid<{this.ObjectType}CollectionEditor<{ViewType},{NewViewType}>,{ViewType},{NewViewType}>( params_{this.ObjectName},this,{Constants.ScreenProperty}.{NewViewProperty});");
                    return definition;
                }
            }
            
        }
    }
}
