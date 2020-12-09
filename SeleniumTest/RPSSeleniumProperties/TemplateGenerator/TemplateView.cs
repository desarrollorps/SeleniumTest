using RPSSeleniumProperties.TemplateGenerator.templates;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.TemplateGenerator
{
    public class TemplateView
    {
        public ITemplateGenerator Template { get; set; }
        public string ViewType { get; set; }

        public string ObjectName { get; set; }      
        public virtual string GenerateObjectDefinition() { return $"public {ViewType} {ObjectName} {{get; set; }}"; }
        public virtual string GenerateObjectInitialization() { return $"{ObjectName}  = new {ViewType}(this);"; }
        public virtual string GenerateObjectInitializeInternals() { return $"{ObjectName}.InitializeControls();"; }
        public virtual string GenerateFullClassDefinition() { return Template.TransformText(); }
            
    }
}
