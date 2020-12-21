using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RPSSeleniumProperties.TemplateGenerator
{
    public class IgnoredObjectTemplate:TemplateObject
    {

    }
    public class TemplateObject
    {
        public TemplateObject()
        {
            ObjectName = "";
            ID = "";
            CssSelector = "";
            ViewType = "";
        }
        private string _viewtype;
        public string ViewType { get { return String.Concat(_viewtype.Where(c => !Char.IsWhiteSpace(c))); } set { _viewtype = value; } }

        private string _objectname;
        public string ObjectName { get { return String.Concat(_objectname.Where(c => !Char.IsWhiteSpace(c))); } set { _objectname = value; } }
        public string ID { get; set; }
        public string CssSelector { get; set; }
        public string XpathSelector { get; set; }
        public bool Required { get; set; }
        public virtual string GenerateObjectDefinition() { return ""; }
        public virtual List<string> GenerateObjectInitialization() { return new List<string> { "" }; }
        
    }
}
