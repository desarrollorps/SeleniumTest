﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.TemplateGenerator.templates.EntityMaintenance
{
    public partial class View: ITemplateGenerator
    {
        public ViewVM Model { get; set; }
    }
    public class ViewVM
    {
        public ViewVM()
        {
            Controls = new List<TemplateObject>();
            CollectionClasses = new List<ITemplateGenerator>();
        }
        public string ViewType { get; set; }
        public string ParentViewType { get; set; }
        public string ScreenName { get; set; }
        public List<TemplateObject> Controls { get; set; }
        public List<ITemplateGenerator> CollectionClasses { get; set; }
        public string Service { get; set; }
        public string Version { get; set; }
        public string Package { get; set; }
        public string Customer { get; set; }
    }
}
