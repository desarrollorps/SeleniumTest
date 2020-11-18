using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.TemplateGenerator.templates.EntityMaintenance
{
    public partial class EntityEditorView: ITemplateGenerator
    {
        public EntityEditorViewVM Model { get; set; }
    }
    public class EntityEditorViewVM
    {
        public EntityEditorViewVM()
        {
            Controls = new List<TemplateObject>();
        }
        public string ViewType { get; set; }
        public string ParentViewType { get; set; }
        public string ScreenName { get; set; }
        public List<TemplateObject> Controls { get; set; }
        public string Service { get; set; }
        public string Version { get; set; }
        public string Package { get; set; }
        public string Customer { get; set; }
    }
}
