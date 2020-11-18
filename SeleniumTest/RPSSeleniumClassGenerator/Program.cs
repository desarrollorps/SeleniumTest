using System;
using System.Collections.Generic;
using System.IO;

namespace RPSSeleniumClassGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string from = @"D:\BasoaCustomization\Version2020\ToolTest\Source\CuGeneral\CuGeneral\CuGeneral.UIHTML5\components\ShoppingCart";
            string to = "";
            if (args.Length != 2 && string.IsNullOrEmpty(from))
            {
                Console.WriteLine("Welcome to Selenium class generator");
                do
                {
                    Console.WriteLine("Enter the folder of the project that has the UIModels/Customizations");
                    from = Console.ReadLine();
                    if (!Directory.Exists(from))
                    {
                        Console.WriteLine($"The folder {from} does not exists, please try again");
                    }
                } while (!Directory.Exists(from));

                do
                {
                    Console.WriteLine("Enter the folder of the project where the classes will be generated");
                    from = Console.ReadLine();
                    if (!Directory.Exists(to))
                    {
                        Console.WriteLine($"The folder {to} does not exists, please try again");
                    }
                } while (!Directory.Exists(to));
            }
            else if (string.IsNullOrEmpty(from))
            {
                from = args[0];
                to = args[1];
            }
            var files = Directory.GetFiles(Path.GetDirectoryName(from), "*.uimodel", SearchOption.AllDirectories);
            List<RPSUIModelParser.UIModel> models = new List<RPSUIModelParser.UIModel>();
            List<string> modelStrings = new List<string>();
            foreach(var file in files)
            {
                var model = new RPSUIModelParser.UIModel(file);
                models.Add(model);
                modelStrings.Add(UIModelToString.GenerateCS(model));
            }

            Console.ReadLine();

        }
    }
}
