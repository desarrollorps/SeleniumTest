using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.TemplateGenerator
{
    public class TemplateObject
    {
        public TemplateObject()
        {
            ObjectName = "";
            ID = "";
            CssSelector = "";
            ViewType = "";
        }
        public string ViewType { get; set; }
     
        public string ObjectName { get; set; }
        public string ID { get; set; }
        public string CssSelector { get; set; }
        public string XpathSelector { get; set; }
        public bool Required { get; set; }
        public virtual string GenerateObjectDefinition() { return ""; }
        public virtual List<string> GenerateObjectInitialization() { return new List<string> { "" }; }
        
    }
}
