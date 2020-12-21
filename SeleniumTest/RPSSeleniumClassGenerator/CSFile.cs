using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RPSSeleniumClassGenerator
{
    public class CSFile:IDisposable
    {
        public string FileName { get; set; }
        public string FolderPath { get; set; } 
        public string Content { get; set; }
        public string Service { get; set; }
        public string Version { get; set; }
        public string Package { get; set; }
        public string Customer { get; set; }

        public void Dispose()
        {
           
        }

        public async Task Save()
        {
            string folderpath = Path.Combine(FolderPath,  Customer, Package, Service);
            if(!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
            }
            await File.WriteAllTextAsync(Path.Combine(folderpath, FileName), Content);
        }
    }
}
