using RPSSeleniumProperties.TemplateGenerator.templates.SeleniumConfig;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSSeleniumClassGenerator
{
    public class SeleniumConfigToStrign
    {
        public void GenerateCS(string path, string url, string username, string password, string codcompany)
        {
            DirectoryInfo d = new DirectoryInfo(path);
            string fullpath = Path.Combine(d.FullName, "SeleniumConfig.cs");
            if (!File.Exists(fullpath))
            {
                Console.WriteLine("-------------------");
                Console.WriteLine("Generating SeleniumConfig.cs");
                Console.WriteLine("-------------------");
                SeleniumConfigVM vm = new SeleniumConfigVM() { Namespace = d.Name, CodCompany = codcompany, Password = password, User = username, Url = url };
                SeleniumConfig file = new SeleniumConfig();
                file.Model = vm;
                var test = file.TransformText();
                File.WriteAllText(fullpath, test);

            }
            else
            {
                Console.WriteLine("-------------------");
                Console.WriteLine("Skipping SeleniumConfig.cs, the file already exists");
                Console.WriteLine("-------------------");
            }
        }
    }
}
