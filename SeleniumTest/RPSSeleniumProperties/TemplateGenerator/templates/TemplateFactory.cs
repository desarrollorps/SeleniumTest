using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.TemplateGenerator.templates
{
    public class TemplateFactory
    {
        public static EntityMaintenance.Screen CreateEntityMaintenanceScreen()
        {
            var en = new EntityMaintenance.Screen();
            en.Model = new EntityMaintenance.ScreenVM();
            return en;
        }
    }
    public enum ScreenType
    {
        EntityMaintenace = 0,
        QueryScreen = 1
    }
}
