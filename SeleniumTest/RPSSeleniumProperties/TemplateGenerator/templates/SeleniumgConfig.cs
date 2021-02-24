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
        public string Url { get; set; }
        public string Password { get; set; }
        public string User { get; set; }
        public string CodCompany { get; set; }
    }
}
