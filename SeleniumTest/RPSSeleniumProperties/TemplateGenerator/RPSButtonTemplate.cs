using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.TemplateGenerator
{
    public class RPSButtonTemplate : TemplateObject
    {
        public RPSButtonTemplate():base()
        {

        }
      
        public string NewViewType { get; set; }
        public string NewViewProperty { get; set; }
       
        public override string GenerateObjectDefinition()
        {
           if (string.IsNullOrEmpty(NewViewType))
            {
                return $"public IRPSButton<{ViewType}> {this.ObjectName} {{ get; set; }}";
            }
            else
            {
                return $"public IRPSButton<{ViewType},{NewViewType}> {this.ObjectName} {{ get; set; }}";
            }
        }

        public override List<string> GenerateObjectInitialization()
        {
            if (string.IsNullOrEmpty(NewViewType))
            {
                return new List<string> { $"{this.ObjectName} = RPSControlFactory.CreateRPSButton<{ViewType}>( \"{this.ID}\",\"{CssSelector}\",\"{XpathSelector}\",this);" };
            }
            else
            {
                return new List<string> { $"{this.ObjectName} = RPSControlFactory.CreateRPSButtonToView<{ViewType},{NewViewType}>(\"{this.ID}\",\"{CssSelector}\",\"{XpathSelector}\", this,{Constants.ScreenProperty}.{NewViewProperty});" };
            }
        }
    }
    public class RPSGridButtonTemplate : TemplateObject
    {
        public RPSGridButtonTemplate() : base()
        {

        }

        public string NewViewType { get; set; }
        public string NewViewProperty { get; set; }

        public override string GenerateObjectDefinition()
        {
            if (string.IsNullOrEmpty(NewViewType))
            {
                return $"public IRPSGridButton<{ViewType}> {this.ObjectName} {{ get; set; }}";
            }
            else
            {
                return $"public IRPSGridButton<{ViewType},{NewViewType}> {this.ObjectName} {{ get; set; }}";
            }
        }

        public override List<string> GenerateObjectInitialization()
        {
            if (string.IsNullOrEmpty(NewViewType))
            {
                return new List<string> { $"{this.ObjectName} = RPSControlFactory.CreateRPSGridButton<{ViewType}>( \"{this.ID}\",\"{CssSelector}\",\"{XpathSelector}\",this);" };
            }
            else
            {
                return new List<string> { $"{this.ObjectName} = RPSControlFactory.CreateRPSGridButtonToView<{ViewType},{NewViewType}>(\"{this.ID}\",\"{CssSelector}\",\"{XpathSelector}\", this,{Constants.ScreenProperty}.{NewViewProperty});" };
            }
        }
    }
    public class RPSNewButtonTemplate:RPSButtonTemplate
    {
        public RPSNewButtonTemplate():base()
        {
            this.ObjectName = "NewButton";
        }
        public override string GenerateObjectDefinition()
        {
            return $"public IRPSButton<{ViewType},{NewViewType}> {this.ObjectName} {{ get; set; }}";

        }
        public override List<string> GenerateObjectInitialization()
        {
            return new List<string> { $"{this.ObjectName} = RPSControlFactory.RPSNewButton<{ViewType},{NewViewType}>( this,{Constants.ScreenProperty}.{NewViewProperty});" };
        }
    }
    public class RPSDeleteButtonTemplate : RPSButtonTemplate
    {
        public RPSDeleteButtonTemplate():base()
        {
            this.ObjectName = "DeleteButton";
        }
        public override string GenerateObjectDefinition()
        {
            return $"public IRPSButton<{ViewType}> {this.ObjectName} {{ get; set; }}";

        }
        public override List<string> GenerateObjectInitialization()
        {
            return new List<string> { $"{this.ObjectName} = RPSControlFactory.RPSDeleteButton<{ViewType}>( this);" };
        }
    }
    public class RPSConfirmButtonTemplate : RPSButtonTemplate
    {
        public RPSConfirmButtonTemplate() : base()
        {
            this.ObjectName = "ConfirmDeleteButton";
        }
        public override string GenerateObjectDefinition()
        {
            return $"public IRPSButton<{ViewType},{NewViewType}> {this.ObjectName} {{ get; set; }}";

        }
        public override List<string> GenerateObjectInitialization()
        {
            return new List<string> { $"{this.ObjectName} = RPSControlFactory.RPSConfirmDeleteButton<{ViewType},{NewViewType}>( this,{Constants.ScreenProperty}.{NewViewProperty});" };
        }
    }
    public class RPSSaveButtonTemplate : RPSButtonTemplate
    {
        public RPSSaveButtonTemplate():base()
        {
            this.ObjectName = "SaveButton";
        }
        public override string GenerateObjectDefinition()
        {
            return $"public IRPSSaveButton<{ViewType}> {this.ObjectName} {{ get; set; }}";
           
        }

        public override List<string> GenerateObjectInitialization()
        {
            return new List<string> { $"{this.ObjectName} = RPSControlFactory.RPSSaveButton<{ViewType}>( this);" };
        }
    }
    public class RPSAcceptButtonTemplate : RPSButtonTemplate
    {
        public RPSAcceptButtonTemplate() : base()
        {
            this.ObjectName = "AcceptButton";
        }
        public override string GenerateObjectDefinition()
        {
            return $"public IRPSAcceptButton<{ViewType},{NewViewType}> {this.ObjectName} {{ get; set; }}";

        }

        public override List<string> GenerateObjectInitialization()
        {
            return new List<string> { $"{this.ObjectName} = RPSControlFactory.RPSAcceptButton<{ViewType},{NewViewType}>( this,{Constants.ScreenProperty}.{NewViewProperty});" };
        }
    }
    public class RPSBackButtonTemplate : RPSButtonTemplate
    {
        public RPSBackButtonTemplate():base()
        {
            this.ObjectName = "BackButton";
        }
        public override string GenerateObjectDefinition()
        {
            return $"public IRPSButton<{ViewType},{NewViewType}> {this.ObjectName} {{ get; set; }}";

        }
        public override List<string> GenerateObjectInitialization()
        {
            return new List<string> { $"{this.ObjectName} = RPSControlFactory.RPSBackButton<{ViewType},{NewViewType}>( this,{Constants.ScreenProperty}.{NewViewProperty});" };
        }
    }

    public class RPSConsultButtonTemplate : RPSButtonTemplate
    {
        public RPSConsultButtonTemplate() : base()
        {
            this.ObjectName = "ConsultButton";
        }
        public override string GenerateObjectDefinition()
        {
            return $"public IRPSButton<{ViewType}> {this.ObjectName} {{ get; set; }}";

        }
        public override List<string> GenerateObjectInitialization()
        {
            return new List<string> { $"{this.ObjectName} = RPSControlFactory.RPSConsultButton<{ViewType}>( this);" };
        }
    }

}
