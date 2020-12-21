using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
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
        public string GetControlName(string name)
        {
            name = String.Concat(name.Where(c => !Char.IsWhiteSpace(c)));
            string originalname = name;
            int counter = 0;
            while (this.Controls.Any(d => d.ObjectName == name))
            {
                counter += 1;
                name = originalname + counter.ToString();
            }
            return name;
        }
        private string _viewType;
        public string ViewType { get {return String.Concat(_viewType.Where(c => !Char.IsWhiteSpace(c))); } set { _viewType = value; } }

        private string _newViewType;
        public string NewVieType { get { return String.Concat(_newViewType.Where(c => !Char.IsWhiteSpace(c))); } set { _newViewType = value; } }

        private string _gridname;
        public string GridName { get { return String.Concat(_gridname.Where(c => !Char.IsWhiteSpace(c))); } set { _gridname = value; } }

        private string _collectionname;
        public string CollectionName { get { return String.Concat(_collectionname.Where(c => !Char.IsWhiteSpace(c))); } set { _collectionname = value; } }

        private string _screenname;
        public string ScreenName { get { return String.Concat(_screenname.Where(c => !Char.IsWhiteSpace(c))); } set { _screenname = value; } }
        public List<TemplateObject> Controls { get; set; }
        public string Service { get; set; }
        public string Version { get; set; }
        public string Package { get; set; }
        public string Customer { get; set; }
    }
}
