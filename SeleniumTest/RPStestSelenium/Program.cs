using OpenQA.Selenium;
using RPSSeleniumProperties;
using System;

namespace RPStestSelenium
{
    class Program
    {
        static void Main(string[] args)
        {
            SeleniumHelper.SeleniumFactoryConfig.ChromeDriverPath = $"U:\\Selenium\\";
            RPSEnvironment.RPSBaseURL = "http://localhost/RPSNextShopping/";
            RPSEnvironment.DefaultUser = "admin";
            RPSEnvironment.DefaultPassword = "admin";
            RPSEnvironment.DefaultCodCompany = "DEMOS";
            StandardCategorias cat = new StandardCategorias();
            cat.NavigateToScreen<ConsultView>().
                Nuevo.Click().
                CodCategoria.Write("2").
                Description.Write("Categoria Test").
                Save.Click().Wait(5).
                Description.Write("Categoria Test Modificada").
                Save.Click().Wait(5).
                Delete.Click();
                

            
            Console.ReadLine();
            cat.Dispose();
        }
    }
}
