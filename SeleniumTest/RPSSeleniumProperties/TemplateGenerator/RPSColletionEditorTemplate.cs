using RPSSeleniumProperties.Interactables;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.TemplateGenerator
{
    public class RPSColletionEditorTemplate:TemplateObject
    {
        public string NewViewType { get; set; }
        public string NewViewProperty { get; set; }
        public CollectionInit Parameters { get; set; }
        public override string GenerateObjectDefinition()
        {
           
            return $"public IRPSCollectionEditor<{ViewType},{NewViewType}> {this.ObjectName} {{ get; set; }}";
            
        }

        public override List<string> GenerateObjectInitialization()
        {
            List<string> definition = new List<string>();
            definition.Add($"CollectionInit params_{this.ObjectName} = new CollectionInit(){{IDDescriptor = \"{Parameters.IDDescriptor}\",CSSSelectorDescriptor = \"{Parameters.CSSSelectorDescriptor}\",XPathDescriptor = \"{Parameters.XPathDescriptor}\"}};");
            definition.Add($"{this.ObjectName} = RPSControlFactory.RPSCreateCollection<{ViewType},{NewViewType}>( params_{this.ObjectName},this,{Constants.ScreenProperty}.{NewViewProperty});");
            return definition;
            
        }
    }
}
