using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RPSSeleniumProperties.TemplateGenerator.templates.UnitTest
{
    public partial class CRUDUnitTest
    {
        public CRUDUnitTestVM Model { get; set; }

    }
    public class CRUDUnitTestVM
    {
        public string SeleniumConfigNamespace { get; set; }
        public string Namespace { get; set; }
        public string FileNameNoExtension { get; set; }
        public string UsingToSeleniumGeneratedClasses { get; set; }
        private string _viewtype;
        public string MainViewType { get { return String.Concat(_viewtype.Where(c => !Char.IsWhiteSpace(c))); } set { _viewtype = value; } }
    }
}
