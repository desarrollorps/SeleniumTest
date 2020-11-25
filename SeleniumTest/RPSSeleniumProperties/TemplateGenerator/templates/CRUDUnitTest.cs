using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
