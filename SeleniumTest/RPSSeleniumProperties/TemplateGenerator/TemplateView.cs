using RPSSeleniumProperties.TemplateGenerator.templates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace RPSSeleniumProperties.TemplateGenerator
{
    public class TemplateView
    {
        public ITemplateGenerator Template { get; set; }
        private string _viewtype;
        public string ViewType { get { return String.Concat(_viewtype.Where(c => !Char.IsWhiteSpace(c))); } set { _viewtype = value; } }

        private string _objectname;
        public string ObjectName { get { return String.Concat(_objectname.Where(c => !Char.IsWhiteSpace(c))); } set { _objectname = value; } }
        public virtual string GenerateObjectDefinition() { return $"public {ViewType} {ObjectName} {{get; set; }}"; }
        public virtual string GenerateObjectInitialization() { return $"{ObjectName}  = new {ViewType}(this);"; }
        public virtual string GenerateObjectInitializeInternals() { return $"{ObjectName}.InitializeControls();"; }
        public virtual string GenerateFullClassDefinition() { return Template.TransformText(); }
            
    }
}
