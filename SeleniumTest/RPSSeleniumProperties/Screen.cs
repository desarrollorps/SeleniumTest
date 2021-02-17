using OpenQA.Selenium;
using RPSSeleniumProperties.Interfaces;
using System;
using System.Linq;
using System.Threading;

namespace RPSSeleniumProperties
{
    public class Screen : IScreen,IDisposable
    {
        public Screen()
        {
            WebDriver = SeleniumHelper.SeleniumFactory.CreateDefault();
            
        }

        public IWebDriver WebDriver { get; set; }
        public string URL { get; set; }
       
        public string Name { get; set; }
        protected string _codUser;
        public string CodUser { get => string.IsNullOrEmpty(this._codUser)?RPSEnvironment.DefaultUser :this._codUser; set => this._codUser = value; }
        protected string _password;
        public string Password { get => string.IsNullOrEmpty(this._password) ? RPSEnvironment.DefaultPassword : this._password; set => this._password = value; }

        protected string _codCompany;
        public string CodCompany { get => string.IsNullOrEmpty(this._codCompany) ? RPSEnvironment.DefaultCodCompany : this._codCompany; set => this._codCompany = value; }

        public virtual T NavigateToScreen<T>(string detailedUrl = "") where T:class,IView
        {

            WebDriver.Navigate().GoToUrl(GetFullUrl(detailedUrl));
            //Aqui hay que hacer el Login.
            var loggin = ILoginFactory.Create(this.WebDriver);
            loggin.User.Write(this.CodUser,this.WebDriver);
            loggin.Password.Write(this.Password, this.WebDriver);
            loggin.Login.Click(this.WebDriver);
            var prop = this.GetType().GetProperties().Where(d => d.PropertyType == typeof(T)).FirstOrDefault();
            var value = prop.GetValue(this, new object[] { });
            return value as T;
        }
        
        protected string GetFullUrl(string detailedURL)
        {
            if (string.IsNullOrEmpty(detailedURL))
            {
                return $"{RPSEnvironment.RPSBaseURL}app/{this.CodCompany}/{this.URL}";
            }
            else
            {
                return $"{RPSEnvironment.RPSBaseURL}app/{this.CodCompany}/{this.URL}/{detailedURL}";
            }
        }
        public IView CreateView<T>(string Name) where T:View
        {
            var c = typeof(T).GetConstructor(new Type[] { });
            T instance = c.Invoke(new object[] { }) as T;            
            instance.WebDriver = this.WebDriver;
            instance.Name = Name;
            return instance;
        }

        public void Dispose()
        {
            if (WebDriver != null)
            {
                
                WebDriver.Quit();
                WebDriver.Dispose();
                WebDriver = null;
            }
        }

        public T GetViewInstance<T>() where T : class, IView
        {
            var prop = this.GetType().GetProperties().Where(d => d.PropertyType == typeof(T)).FirstOrDefault();
            var value = prop.GetValue(this, new object[] { });
            return value as T;
        }
    }
}
