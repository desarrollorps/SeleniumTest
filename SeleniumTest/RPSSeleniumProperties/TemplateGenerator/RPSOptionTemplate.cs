using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.TemplateGenerator
{
    public class RPSOptionTemplate : TemplateObject
    {
        public RPSOptionTemplate() : base()
        {

        }
      

        public override string GenerateObjectDefinition()
        {
            
                return $"public IRPSOption<{ViewType}> {this.ObjectName} {{ get; set; }}";            
        }

        public override List<string> GenerateObjectInitialization()
        {
            
                return new List<string> { $"{this.ObjectName} = RPSControlFactory.CreateRPSOption<{ViewType}>( \"{this.ID}\",\"{CssSelector}\",\"{XpathSelector}\",this);" };
            
        }
    }
}
