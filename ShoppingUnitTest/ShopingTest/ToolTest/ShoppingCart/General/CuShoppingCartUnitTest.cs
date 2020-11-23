
using System;
using Xunit;
using RPSSeleniumProperties;
using SeleniumGeneratedClasses.ToolTest.ShoppingCart.Services.General;
using OpenQA.Selenium;
namespace ShopingTest.ToolTest.ShoppingCart.General
{
    
    public class CuShoppingCartUnitTest_Delete
    {   
         [Fact]
        public void Delete()
        {
            var config = SeleniumConfig.Current;
            CuShoppingCart cart = new CuShoppingCart();
            cart.NavigateToScreen<CuShoppingCartQueryView>().
            NewButton.Click().
            CodShoppingCart.Write("011").
            Description.Write("Test Shopping cart").
            
            Address.Write("Mi direccion").
            ShoppingDate.Write("19112020").
            DeliveryDate.Write("20112020").
                //IDCustomer.Write("001").Wait(5).
            IDCustomer.Select(0).
            
            SaveButton.Click().Wait(5).
            DeleteButton.Click().Wait(2).
            ConfirmDeleteButton.Click();
            cart.Dispose();
        }    
    }
    public class CuShoppingCartUnitTest_Update
    {   
        [Fact]
        public void Update()
        {
            var config = SeleniumConfig.Current;
            string originalAddress = "";
            CuShoppingCart cart = new CuShoppingCart();
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
            cart.Dispose();
        }
    }
    public class CuShoppingCartUnitTest_Create
    {        
        [Fact]
        public void Create()
        {
            var config = SeleniumConfig.Current;
             CuShoppingCart cart = new CuShoppingCart();
            cart.NavigateToScreen<CuShoppingCartQueryView>().
                NewButton.Click().
                CodShoppingCart.Write("010").
                Description.Write("Test Shopping cart").
               
                Address.Write("Mi direccion").
                ShoppingDate.Write("19112020").
                DeliveryDate.Write("20112020").
                 //IDCustomer.Write("001").Wait(5).
                IDCustomer.Select(0).
                
                SaveButton.Click().Wait(5).
                DeleteButton.Click();
                cart.Dispose();
              
        }        
           
    }
}
