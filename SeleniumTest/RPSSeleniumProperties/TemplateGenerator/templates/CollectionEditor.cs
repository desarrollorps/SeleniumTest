using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.TemplateGenerator.templates.Grids
{
    public partial class CollectionEditor : ITemplateGenerator
    {
        public CollectionEditorVM Model { get; set; }
    }
    public class CollectionEditorVM
    {
        public CollectionEditorVM()
        {
            Controls = new List<TemplateObject>();
        }
        public string ViewType { get; set; }
        public string NewVieType { get; set; }
        public string GridName { get; set; }
        public string CollectionName { get; set; }
        public string ScreenName { get; set; }
        public List<TemplateObject> Controls { get; set; }
        public string Service { get; set; }
        public string Version { get; set; }
        public string Package { get; set; }
        public string Customer { get; set; }
    }
}
