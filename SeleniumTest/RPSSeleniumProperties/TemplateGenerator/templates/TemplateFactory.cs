using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.TemplateGenerator.templates
{
    public class TemplateFactory
    {
        public static EntityMaintenance.EntityMaintenanceScreen CreateEntityMaintenanceScreen()
        {
            var en = new EntityMaintenance.EntityMaintenanceScreen();
            en.Model = new EntityMaintenance.EntityMaintenanceScreenVM();
            return en;
        }
    }
    public enum ScreenType
    {
        EntityMaintenace = 0,
        QueryScreen = 1
    }
}
