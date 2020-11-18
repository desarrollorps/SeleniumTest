using OpenQA.Selenium;
using SeleniumHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTest
{
    public class GoToWebUnitTest: WebDriverUnitTest
    {
        public GoToWebUnitTest(IWebDriver driver):base(driver)
        {
            this.Name = "GoToWebExtension";
        }
        protected override void PrepareTest()
        {
          
            UnitTest navigation = new UnitTest("navigation");
            this.Step("gotoweb", (o) =>
            {
                this.WebDriver.Navigate().GoToUrl(@"https://selenium.dev");
                return new UnitTestStepResut { Result = true };
            }).Step("gotootherweb",(o)=> {
                this.WebDriver.Navigate().GoToUrl(@"https://www.googe.com");
                return new UnitTestStepResut { Result = true };
            });
        }
    }
}
