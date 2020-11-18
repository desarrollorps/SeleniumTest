using OpenQA.Selenium;
using RPSSeleniumProperties.Interactables;
using RPSSeleniumProperties.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties
{
    public class Loggin:View
    {
        public RPSTextBox<Loggin> User { get; set; }
        public RPSTextBox<Loggin> Password { get; set; }
        public RPSButton<Loggin> Login { get; set; }
       
        public Loggin()
        {
            User = new RPSTextBox<Loggin>() { CSSSelector = "[id='4641df06-8908-4cf1-a249-5f42988b5b83'] input" };
            Password = new RPSTextBox<Loggin>() { CSSSelector = "[id='54213cb3-3cbd-40dc-a533-e7a8809b64ca'] input" };
            Login = new RPSButton<Loggin>() { ID = "8bf1080a-f56a-45f4-8771-2647825f082a" };
            
        }
    }
    public static class ILoginFactory
    {
        public static Loggin Create(IWebDriver driver)
        {
            return new Loggin() { WebDriver = driver };
        }
    }
}
