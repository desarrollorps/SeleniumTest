using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RPSSeleniumProperties.TemplateGenerator.templates.EntityMaintenance
{
    public partial class Screen: ITemplateGenerator
    {

        public ScreenVM Model { get; set; }
    }
    public class ScreenVM
    {
        public ScreenVM()
        {
            Views = new List<TemplateView>();
        }
        public string GetViewName(string name)
        {
            name = String.Concat(name.Where(c => !Char.IsWhiteSpace(c)));
            string originalname = name;
            int counter = 0;
            while (this.Views.Any(d => d.ObjectName == name))
            {
                counter += 1;
                name = originalname + counter.ToString();
            }
            return name;
        }
        public string GetViewType(string name)
        {
            name = String.Concat(name.Where(c => !Char.IsWhiteSpace(c)));
            string originalname = name;
            int counter = 0;
            while (this.Views.Any(d => d.ViewType == name))
            {
                counter += 1;
                name = originalname + counter.ToString();
            }
            return name;
        }
        private string _name;
        /// <summary>
        /// The name of the uimodel
        /// </summary>
        public string Name { get { return String.Concat(_name.Where(c => !Char.IsWhiteSpace(c))); } set { _name = value; } }
        private string _fulltype;
        /// <summary>
        /// For example general.Sites
        /// </summary>
        public string FullType { get { return String.Concat(_fulltype.Where(c => !Char.IsWhiteSpace(c))); } set { _fulltype = value; } }
        //List with the views of the screen, the right side of the screen in the editor
        public List<TemplateView> Views { get; set; }
        public string Service { get; set; }
        public string Package { get; set; }
        public string Customer { get; set; }
        public string Version { get; set; }
    }
}
