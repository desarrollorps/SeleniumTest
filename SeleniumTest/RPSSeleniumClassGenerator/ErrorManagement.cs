using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSSeleniumClassGenerator
{
    public static class ErrorManagement
    {
        private static ConcurrentBag<Error> _errors;
        public static void Clear()
        {
            _errors = new ConcurrentBag<Error>();
        }
           
        public static ConcurrentBag<Error> Errors
        {
            get { return _errors; }
        }
        static ErrorManagement()
        {
            _errors = new ConcurrentBag<Error>();
        }
        public static void AddError(Error err)
        {
            Errors.Add(err);
        }
        public static void ToScreen()
        {
            Console.WriteLine();
            var errors = Errors.Where(d => d.EType != ErrorType.IgnoredControl && d.EType != ErrorType.IgnoredControlInGrid).ToList();
            var groupedErrors = errors.GroupBy(d => d.EType).ToList();
            Console.WriteLine("Details of errors-------------------------------");
            foreach (var g in groupedErrors)
            {
                Console.WriteLine();
                Console.WriteLine("*******" + g.Key.ToString() + " " + g.Count()+" ***********");
                var listErros = g.ToList();
                var byeditor = listErros.GroupBy(d => d.EditorType).ToList();
                foreach (var editor in byeditor)
                {
                    Console.WriteLine();
                    Console.WriteLine("-------"+editor.Key.ToString() + " " + editor.Count());
                    var error = editor.FirstOrDefault();
                    if (error != null)
                    {
                        Console.WriteLine("+ "+error.ToString());
                    }
                }

            }
            Console.WriteLine();
            var ignored = Errors.Where(d => d.EType == ErrorType.IgnoredControl && d.EType == ErrorType.IgnoredControlInGrid).Select(d => new { d.EditorType, d.EType }).Distinct().OrderBy(d => d.EType).ThenBy(d => d.EditorType).ToList();
            Console.WriteLine("Ignored control types-------------------------------");
            ignored.ToList().ForEach(i => { Console.WriteLine($"{i.EType} {i.EditorType}"); });
        }
        public static void ToFile(string path)
        {
            StringBuilder sb = new StringBuilder();
            var errors = Errors.Where(d => d.EType != ErrorType.IgnoredControl && d.EType != ErrorType.IgnoredControlInGrid).ToList();
            var groupedErrors = errors.GroupBy(d => d.EType).ToList();
            sb.AppendLine("Details of errors-------------------------------");
            foreach (var g in groupedErrors)
            {
                sb.AppendLine();
                sb.AppendLine("*******" + g.Key.ToString() + " " + g.Count() + " ***********");
                var listErros = g.ToList();
                var byeditor = listErros.GroupBy(d => d.EditorType).ToList();
                foreach (var editor in byeditor)
                {
                    sb.AppendLine();
                    sb.AppendLine("-------" + editor.Key.ToString() + " " + editor.Count());
                    foreach(var error in editor.OrderBy(d=>d.FileName))
                    {
                        sb.AppendLine("+ "+error.ToString());
                    }                    
                }

            }
            var ignored = Errors.Where(d => d.EType == ErrorType.IgnoredControl && d.EType == ErrorType.IgnoredControlInGrid).ToList();
            sb.AppendLine();
            sb.AppendLine("Ignored control types-------------------------------");
            ignored.ToList().OrderBy(d => d.EditorType).ThenBy(d => d.FileName).ThenBy(d => d.EditorType).ToList().ForEach(d => sb.AppendLine(d.ToString()));
            File.WriteAllText(path, sb.ToString());
        }


    }
    public class Error
    {
        public string FileName { get; set; }
        public string ViewName { get; set; }
        public string Message { get; set; }   
        public string CollectionName { get; set; }
        public string ColName { get; set; }
        public string GridID { get; set; }
        public string EditorType { get; set; }
        public string EditorId { get; set; }
        public ErrorType EType { get; set; }
        public override string ToString()
        {
            return $"{FileName} {ViewName} {EType} {EditorType} {EditorId} {CollectionName} {GridID}";
        }
    }
    public enum ErrorType
    {
        ControlNotGenerated,
        ControlNotGeneratedInGrid,
        IgnoredControl,
        IgnoredControlInGrid,
        CollectionNotGenerated,
        SectionNotGenerated,
        ViewEditorNotGenerated
    }
}
