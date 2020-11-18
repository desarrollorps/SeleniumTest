using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.TemplateGenerator.templates.EntityMaintenance
{
    public partial class EntityMaintenanceScreen: ITemplateGenerator
    {

        public EntityMaintenanceScreenVM Model { get; set; }
    }
    public class EntityMaintenanceScreenVM
    {
        public EntityMaintenanceScreenVM()
        {
            Views = new List<TemplateView>();
        }
        /// <summary>
        /// The name of the uimodel
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// For example general.Sites
        /// </summary>
        public string FullType { get; set; }
        //List with the views of the screen, the right side of the screen in the editor
        public List<TemplateView> Views { get; set; }
        public string Service { get; set; }
        public string Package { get; set; }
        public string Customer { get; set; }
        public string Version { get; set; }
    }
}
