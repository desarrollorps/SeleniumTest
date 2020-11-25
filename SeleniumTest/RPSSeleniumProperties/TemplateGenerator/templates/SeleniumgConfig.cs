using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.TemplateGenerator.templates.SeleniumConfig
{
    public partial class SeleniumConfig
    {
        public SeleniumConfigVM Model { get; set; }
    }
    public class SeleniumConfigVM
    {
        public string Namespace { get; set; }
    }
}
