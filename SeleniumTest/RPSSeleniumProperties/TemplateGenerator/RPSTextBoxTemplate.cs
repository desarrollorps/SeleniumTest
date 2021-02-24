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

    public class RPSEmailTextBoxTemplate : TemplateObject
    {
        public RPSEmailTextBoxTemplate() : base()
        {

        }
        public override string GenerateObjectDefinition()
        {
            return $"public IRPSTextBox<{ViewType}> {this.ObjectName} {{ get; set; }}";

        }
        public override List<string> GenerateObjectInitialization()
        {
            return new List<string> { $"{this.ObjectName} = RPSControlFactory.CreateRPSEmailTextBox<{ViewType}>(\"{ID}\",\"{CssSelector}\",\"{XpathSelector}\",{(Required ? "true" : "false")}, this);" };
        }
    }
    public class RPSGridEmailTextBoxTemplate : TemplateObject
    {
        public RPSGridEmailTextBoxTemplate() : base()
        {

        }
        public override string GenerateObjectDefinition()
        {
            return $"public IRPSGridTextBox<{ViewType}> {this.ObjectName} {{ get; set; }}";

        }
        public override List<string> GenerateObjectInitialization()
        {
            return new List<string> { $"{this.ObjectName} = RPSControlFactory.CreateRPSGridEmailTextBox<{ViewType}>(\"{ID}\",\"{CssSelector}\",\"{XpathSelector}\",{(Required ? "true" : "false")}, this.CurrentView);" };
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
            return new List<string> { $"{this.ObjectName} = RPSControlFactory.CreateRPSGridTextBox<{ViewType}>(\"{ID}\",\"{CssSelector}\",\"{XpathSelector}\",{(Required ? "true" : "false")}, this.CurrentView);" };
        }
    }
    public class RPSGridMemoTextBoxTemplate : TemplateObject
    {
        public RPSGridMemoTextBoxTemplate() : base()
        {

        }
        public override string GenerateObjectDefinition()
        {
            return $"public IRPSGridTextBox<{ViewType}> {this.ObjectName} {{ get; set; }}";

        }
        public override List<string> GenerateObjectInitialization()
        {
            return new List<string> { $"{this.ObjectName} = RPSControlFactory.CreateRPSGridMemoTextBox<{ViewType}>(\"{ID}\",\"{CssSelector}\",\"{XpathSelector}\",{(Required ? "true" : "false")}, this.CurrentView);" };
        }
    }
    public class RPSFormattedTextBoxTemplate : TemplateObject
    {
        public RPSFormattedTextBoxTemplate() : base()
        {

        }
        public override string GenerateObjectDefinition()
        {
            return $"public IRPSTextBox<{ViewType}> {this.ObjectName} {{ get; set; }}";

        }
        public override List<string> GenerateObjectInitialization()
        {
            return new List<string> { $"{this.ObjectName} = RPSControlFactory.CreateRPSFormattedTextBox<{ViewType}>(\"{ID}\",\"{CssSelector}\",\"{XpathSelector}\",{(Required ? "true" : "false")}, this);" };
        }
    }
    public class RPSGridFormattedTextBoxTemplate : TemplateObject
    {
        public RPSGridFormattedTextBoxTemplate() : base()
        {

        }
        public override string GenerateObjectDefinition()
        {
            return $"public IRPSGridTextBox<{ViewType}> {this.ObjectName} {{ get; set; }}";

        }
        public override List<string> GenerateObjectInitialization()
        {
            return new List<string> { $"{this.ObjectName} = RPSControlFactory.CreateRPSGridFormattedTextBox<{ViewType}>(\"{ID}\",\"{CssSelector}\",\"{XpathSelector}\",{(Required ? "true" : "false")}, this.CurrentView);" };
        }
    }

    public class RPSDurationTextBoxTemplate : TemplateObject
    {
        public RPSDurationTextBoxTemplate() : base()
        {

        }
        public override string GenerateObjectDefinition()
        {
            return $"public IRPSDurationTextBox<{ViewType}> {this.ObjectName} {{ get; set; }}";

        }
        public override List<string> GenerateObjectInitialization()
        {
            return new List<string> { $"{this.ObjectName} = RPSControlFactory.CreateRPSDurationTextBox<{ViewType}>(\"{ID}\",\"{CssSelector}\",\"{XpathSelector}\",{(Required ? "true" : "false")}, this);" };
        }
    }
    public class RPSGridDurationTextBoxTemplate : TemplateObject
    {
        public RPSGridDurationTextBoxTemplate() : base()
        {

        }
        public override string GenerateObjectDefinition()
        {
            return $"public IRPSGridDurationTextBox<{ViewType}> {this.ObjectName} {{ get; set; }}";

        }
        public override List<string> GenerateObjectInitialization()
        {
            return new List<string> { $"{this.ObjectName} = RPSControlFactory.CreateRPSGridDurationTextBox<{ViewType}>(\"{ID}\",\"{CssSelector}\",\"{XpathSelector}\",{(Required ? "true" : "false")}, this.CurrentView);" };
        }
    }

}
