using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.TemplateGenerator
{
    public class RPSComboBoxTemplate : TemplateObject
    {
        public RPSComboBoxTemplate() : base()
        {

        }
        public override string GenerateObjectDefinition()
        {
            return $"public IRPSComboBox<{ViewType}> {this.ObjectName} {{ get; set; }}";

        }
        public override List<string> GenerateObjectInitialization()
        {
            return new List<string> { $"{this.ObjectName} = RPSControlFactory.CreateRPSComboBox<{ViewType}>(\"{ID}\",\"{CssSelector}\",\"{XpathSelector}\",{(Required ? "true" : "false")}, this);" };
        }
    }
    public class RPSCollectionComboBoxTemplate : TemplateObject
    {
        public RPSCollectionComboBoxTemplate() : base()
        {

        }
        public override string GenerateObjectDefinition()
        {
            return $"public IRPSCollectionComboBox<{ViewType}> {this.ObjectName} {{ get; set; }}";

        }
        public override List<string> GenerateObjectInitialization()
        {
            return new List<string> { $"{this.ObjectName} = RPSControlFactory.CreateRPSCollectionComboBox<{ViewType}>(\"{ID}\",\"{CssSelector}\",\"{XpathSelector}\",{(Required ? "true" : "false")}, this);" };
        }
    }
    public class RPSEnumComboBoxTemplate : TemplateObject
    {
        public RPSEnumComboBoxTemplate() : base()
        {

        }
        public override string GenerateObjectDefinition()
        {
            return $"public IRPSComboBox<{ViewType}> {this.ObjectName} {{ get; set; }}";

        }
        public override List<string> GenerateObjectInitialization()
        {
            return new List<string> { $"{this.ObjectName} = RPSControlFactory.CreateRPSEnumComboBox<{ViewType}>(\"{ID}\",\"{CssSelector}\",\"{XpathSelector}\",{(Required ? "true" : "false")}, this);" };
        }
    }

    public class RPSGridComboBoxTemplate : TemplateObject
    {
        public RPSGridComboBoxTemplate() : base()
        {

        }
        public override string GenerateObjectDefinition()
        {
            return $"public IRPSGridComboBox<{ViewType}> {this.ObjectName} {{ get; set; }}";

        }
        public override List<string> GenerateObjectInitialization()
        {
            return new List<string> { $"{this.ObjectName} = RPSControlFactory.CreateRPSGridComboBox<{ViewType}>(\"{ID}\",\"{CssSelector}\",\"{XpathSelector}\",{(Required ? "true" : "false")}, this.CurrentView);" };
        }
    }
    public class RPSGridEnumComboBoxTemplate : TemplateObject
    {
        public RPSGridEnumComboBoxTemplate() : base()
        {

        }
        public override string GenerateObjectDefinition()
        {
            return $"public IRPSGridComboBox<{ViewType}> {this.ObjectName} {{ get; set; }}";

        }
        public override List<string> GenerateObjectInitialization()
        {
            return new List<string> { $"{this.ObjectName} = RPSControlFactory.CreateRPSGridEnumComboBox<{ViewType}>(\"{ID}\",\"{CssSelector}\",\"{XpathSelector}\",{(Required ? "true" : "false")}, this.CurrentView);" };
        }
    }
}
