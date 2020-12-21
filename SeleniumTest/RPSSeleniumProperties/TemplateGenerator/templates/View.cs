using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
        private string _viewtype;
        public string ViewType { get { return String.Concat(_viewtype.Where(c => !Char.IsWhiteSpace(c))); } set { _viewtype = value; } }

        private string _parentviewtype;
        public string ParentViewType { get { return String.Concat(_parentviewtype.Where(c => !Char.IsWhiteSpace(c))); } set { _parentviewtype = value; } }
        public string GetControlName(string name)
        {
            name = String.Concat(name.Where(c => !Char.IsWhiteSpace(c)));
            List<string> invalidstrings = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "Screen" };
            if (invalidstrings.Any(d=>name.StartsWith(d)))
            {
                name = "_" + name;
            }
            string originalname = name;
            int counter = 0;
            while(this.Controls.Any(d=>d.ObjectName == name))
            {
                counter += 1;
                name = originalname + counter.ToString();
            }
            return name;
        }
        private string _screenname;
        public string ScreenName { get { return String.Concat(_screenname.Where(c => !Char.IsWhiteSpace(c))); } set { _screenname = value; } }
        public List<TemplateObject> Controls { get; set; }
        public List<ITemplateGenerator> CollectionClasses { get; set; }
        public string Service { get; set; }
        public string Version { get; set; }
        public string Package { get; set; }
        public string Customer { get; set; }
    }
}
