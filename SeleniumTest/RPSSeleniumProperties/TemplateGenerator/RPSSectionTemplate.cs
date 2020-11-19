using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.TemplateGenerator
{
    public class RPSSectionTemplate : TemplateObject
    {
        public override string GenerateObjectDefinition()
        {
          
                return $"public IRPSSection<{ViewType}> {this.ObjectName} {{ get; set; }}";
           
        }

        public override List<string> GenerateObjectInitialization()
        {
            
            return new List<string> { $"{this.ObjectName} = RPSControlFactory.CreateRPSSection<{ViewType}>( \"{this.ID}\",\"{CssSelector}\",\"{XpathSelector}\",this);" };
            
        }
    }
}
