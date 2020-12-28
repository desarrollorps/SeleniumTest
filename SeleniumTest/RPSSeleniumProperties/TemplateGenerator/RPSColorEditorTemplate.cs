using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSSeleniumProperties.TemplateGenerator
{
    public class RPSColorEditorTemplate : TemplateObject
    {
        public RPSColorEditorTemplate() : base()
        {

        }

        public string NewViewType { get; set; }
        public string NewViewProperty { get; set; }

        public override string GenerateObjectDefinition()
        {
           
                return $"public IRPSColorEditor<{ViewType}> {this.ObjectName} {{ get; set; }}";
           
        }

        public override List<string> GenerateObjectInitialization()
        {

            return new List<string> { $"{this.ObjectName} = RPSControlFactory.CreateRPSColorEditor<{ViewType}>( \"{this.ID}\",\"{CssSelector}\",\"{XpathSelector}\",this);" };

        }       
    }
}
