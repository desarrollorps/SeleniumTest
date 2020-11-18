using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumHelper
{
    public class UnitTestStepResut
    {
        public bool Result { get; set; }
        public List<string> Messages { get; set; }
        public UnitTestStep Step { get; set; }
    }

    public class UnitTestStep
    {
      
        public string Name { get; set; }
        private Func<object, UnitTestStepResut> ExecutionCode { get; set; }
        private Func<object> PreExecutionCode { get; set; }
        private Action<UnitTestStepResut,object> PostExecutionCode { get; set; }
        public UnitTestStep(string name, Func<object, UnitTestStepResut> code )
        {
           
            this.Name = name;
            this.ExecutionCode = code;
        }
        public UnitTestStep(string name,  Func<object, UnitTestStepResut> code, Func<object> pre, Action<UnitTestStepResut, object>post)
        {
            
            this.Name = name;
            this.ExecutionCode = code;
            this.PreExecutionCode = pre;
            this.PostExecutionCode = post;
        }
       
        public virtual object PreExecute()
        {
            if (this.PreExecutionCode != null)
            {
                return PreExecutionCode();
            }
            return null;
        }
        public virtual UnitTestStepResut Execute(object data)
        {
            if (ExecutionCode != null)
            {
                return ExecutionCode(data);
            }
            else
            {
                return new UnitTestStepResut { Result = true };
            }
        }
        public void PostExecute(UnitTestStepResut result, object data)
        {
           if (PostExecutionCode != null)
            {
                PostExecutionCode(result,data);
            }
        }

    }
}
