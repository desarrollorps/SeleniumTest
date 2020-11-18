using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumHelper
{
    public class WebDriverUnitTest:UnitTest
    {
        protected IWebDriver WebDriver;
        public WebDriverUnitTest(IWebDriver driver)
        {
            WebDriver = driver;
        }
    }
    public class UnitTest
    {
        
        public UnitTest()
        {
            
        }
        public UnitTest(string name)
        {
            this.Name = name;
           
        }
        protected virtual void PrepareTest()
        {

        }
        public string Name { get; set; }
        public List<UnitTestStep> Steps = new List<UnitTestStep>();
        public List<UnitTestStepResut> Results = new List<UnitTestStepResut>();
        public bool? IsCorrect { get; private set; }
        public List<UnitTestStepResut> Execute()
        {
            Results.Clear();
            IsCorrect = null;
            PrepareTest();
            foreach(var s in Steps)
            {
                
                var obj = s.PreExecute();
                var result = s.Execute(obj);
                result.Step = s;
                s.PostExecute(result, obj);
                Results.Add(result);
                if (result.Result == false)
                {
                    IsCorrect = false;
                    break;
                }
            }
            IsCorrect = true;
            return Results;
        }
        public UnitTest Step(string name, Func<object> pre, Func<object, UnitTestStepResut> code, Action<UnitTestStepResut, object> post)
        {
            this.Steps.Add(new UnitTestStep(name,  code, pre, post));
            return this;
        }
        public UnitTest Step(string name, Func<object> pre,Func<object, UnitTestStepResut> code)
        {
            return this.Step(name,  pre,code, null);
        }
        public UnitTest Step(string name, Func<object, UnitTestStepResut> code, Action<UnitTestStepResut, object> post)
        {
            return this.Step(name,  null,code, post);
        }
        public UnitTest Step(string name, Func<object, UnitTestStepResut> code)
        {
            return this.Step(name, null,code, null);
        }
    }
}
