﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.TemplateGenerator
{
    public class RPSCheckboxTemplate : TemplateObject
    {
        public RPSCheckboxTemplate() : base()
        {

        }
        public override string GenerateObjectDefinition()
        {
            return $"public IRPSCheckbox<{ViewType}> {this.ObjectName} {{ get; set; }}";

        }
        public override List<string> GenerateObjectInitialization()
        {
            return new List<string> { $"{this.ObjectName} = RPSControlFactory.CreateRPSCheckBox<{ViewType}>(\"{ID}\",\"{CssSelector}\",\"{XpathSelector}\",{(Required ? "true" : "false")}, this);" };
        }
    }
    public class RPSGridCheckboxTemplate : TemplateObject
    {
        public RPSGridCheckboxTemplate() : base()
        {

        }
        public override string GenerateObjectDefinition()
        {
            return $"public IRPSGridCheckbox<{ViewType}> {this.ObjectName} {{ get; set; }}";

        }
        public override List<string> GenerateObjectInitialization()
        {
            return new List<string> { $"{this.ObjectName} = RPSControlFactory.CreateRPSGridCheckBox<{ViewType}>(\"{ID}\",\"{CssSelector}\",\"{XpathSelector}\",{(Required ? "true" : "false")}, this.CurrentView);" };
        }
    }
}
