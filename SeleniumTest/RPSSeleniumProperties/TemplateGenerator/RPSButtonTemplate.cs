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

        public override string GenerateObjectInitialization()
        {
            if (string.IsNullOrEmpty(NewViewType))
            {
                return $"{this.ObjectName} = RPSControlFactory.CreateRPSButton<{ViewType}>( \"{this.ID}\",\"{CssSelector}\",this);";
            }
            else
            {
                return $"{this.ObjectName} = RPSControlFactory.CreateRPSButtonToView<{ViewType},{NewViewType}>(\"{this.ID}\",\"{CssSelector}\", this,{Constants.ScreenProperty}.{NewViewProperty});";
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
        public override string GenerateObjectInitialization()
        {
            return $"{this.ObjectName} = RPSControlFactory.RPSNewButton<{ViewType},{NewViewType}>( this,{Constants.ScreenProperty}.{NewViewProperty});";
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
        public override string GenerateObjectInitialization()
        {
            return $"{this.ObjectName} = RPSControlFactory.RPSDeleteButton<{ViewType}>( this);";
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
            return $"public IRPSButton<{ViewType}> {this.ObjectName} {{ get; set; }}";
           
        }

        public override string GenerateObjectInitialization()
        {
            return $"{this.ObjectName} = RPSControlFactory.RPSSaveButton<{ViewType}>( this);";
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
        public override string GenerateObjectInitialization()
        {
            return $"{this.ObjectName} = RPSControlFactory.RPSBackButton<{ViewType},{NewViewType}>( this,{Constants.ScreenProperty}.{NewViewProperty});";
        }
    }

}
