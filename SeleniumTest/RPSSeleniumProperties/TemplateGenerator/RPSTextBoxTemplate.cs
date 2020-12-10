using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.TemplateGenerator
{
    public class RPSTextBoxTemplate: TemplateObject
    {
        public RPSTextBoxTemplate():base()
        {

        }
        public override string GenerateObjectDefinition()
        {
            return $"public IRPSTextBox<{ViewType}> {this.ObjectName} {{ get; set; }}";

        }
        public override List<string> GenerateObjectInitialization()
        {
            return new List<string> { $"{this.ObjectName} = RPSControlFactory.CreateRPSTextBox<{ViewType}>(\"{ID}\",\"{CssSelector}\",\"{XpathSelector}\",{(Required ? "true" : "false")}, this);" };
        }
    }
    public class RPSGridTextBoxTemplate : TemplateObject
    {
        public RPSGridTextBoxTemplate() : base()
        {

        }
        public override string GenerateObjectDefinition()
        {
            return $"public IRPSGridTextBox<{ViewType}> {this.ObjectName} {{ get; set; }}";

        }
        public override List<string> GenerateObjectInitialization()
        {
            return new List<string> { $"{this.ObjectName} = RPSControlFactory.CreateRPSGridTextBox<{ViewType}>(\"{ID}\",\"{CssSelector}\",\"{XpathSelector}\",{(Required ? "true" : "false")}, this);" };
        }
    }
}
