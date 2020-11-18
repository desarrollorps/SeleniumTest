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
        public override string GenerateObjectInitialization()
        {
            return $"{this.ObjectName} = RPSControlFactory.CreateRPSTextBox<{ViewType}>(\"{ID}\",\"{CssSelector}\", this);";
        }
    }
}
