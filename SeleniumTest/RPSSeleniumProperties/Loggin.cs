using OpenQA.Selenium;
using RPSSeleniumProperties.Constants;
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
            User = new RPSTextBox<Loggin>() { CSSSelector = $"[id='{Identifiers.UserLoginTextBox}']" };
            Password = new RPSTextBox<Loggin>() { CSSSelector = $"[id='{Identifiers.PasswordLoginTextBox}']" };
            Login = new RPSButton<Loggin>() { ID = Identifiers.IniciarSessionLoginButton};
            
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
