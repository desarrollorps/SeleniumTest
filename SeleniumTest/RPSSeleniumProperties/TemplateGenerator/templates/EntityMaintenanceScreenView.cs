using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.TemplateGenerator.templates.EntityMaintenance
{
    public partial class EntityMaintenanceScreenView: ITemplateGenerator
    {
        public EntityMaintenanceScreenViewVM Model { get; set; }

    }
    public class EntityMaintenanceScreenViewVM
    {
        public EntityMaintenanceScreenViewVM()
        {
            Controls = new List<TemplateObject>();
        }
        public string ViewType { get; set; }
        public string ScreenName { get; set; }
        public List<TemplateObject> Controls { get; set; }
        public string Service { get; set; }
        public string Package { get; set; }
        public string Customer { get; set; }
        public string Version { get; set; }
    }

}
