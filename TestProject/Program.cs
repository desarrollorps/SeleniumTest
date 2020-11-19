using System;
using RPSSeleniumProperties;
using SeleniumGeneratedClasses.ToolTest.ShoppingCart.Services.General;
using OpenQA.Selenium;

namespace TestProject
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
            CuShoppingCart cart = new CuShoppingCart();
            /*cart.NavigateToScreen<CuShoppingCartQueryView>().
                NewButton.Click().
                CodShoppingCart.Write("001").
                Description.Write("Test Shopping cart").
               
                Address.Write("Mi direccion").
                ShoppingDate.Write("19112020").
                DeliveryDate.Write("20112020").
                 //IDCustomer.Write("001").Wait(5).
                IDCustomer.Select(0).
                
                SaveButton.Click().Wait(5).
                DeleteButton.Click();
            */  
            /*
            string originalAddress = "";
            cart.NavigateToScreen<CuShoppingCartQueryView>().
            ConsultButton.Click().
            Wait(5).
            CuShoppingCartConsult.DescriptorView.Click(0).
            Address.Read(out originalAddress).
            Address.Write("Mi direccion a modificar").
            SaveButton.Click().
            Wait(5).
            Address.Write(originalAddress).
            SaveButton.Click();
            */
            cart.NavigateToScreen<CuShoppingCartQueryView>().
            ConsultButton.Click().
            Wait(5).
            CuShoppingCartConsult.DescriptorView.Click(0).
            CuShoppingCartLineSection.Click();
            Console.ReadLine();
            cart.Dispose();
        }
    }
}
