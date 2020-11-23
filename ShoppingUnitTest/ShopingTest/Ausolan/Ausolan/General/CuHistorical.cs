    
using RPSSeleniumProperties;
using RPSSeleniumProperties.Interactables;
using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.Interactables;
using RPSSeleniumProperties.viewmodels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace SeleniumGeneratedClasses.Ausolan.Ausolan.Services.General
{
    //RPS VERSION Version2020
    public partial class CuHistorical:Screen
    {
        public CuHistorical():base()
        {
            this.URL = "general.cuhistorical";
            InitViews();
           
           
        }       
        protected void InitViews()
        {
            CuHistoricalView  = new CuHistoricalView(this); 
            CuHistoricalView.InitializeControls(); 
           
        }
      
            public CuHistoricalView CuHistoricalView {get; set; } 
    }
            
    public partial class CuHistoricalView : View
    {
        public CuHistoricalView(CuHistorical screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            DateTo = RPSControlFactory.CreateRPSTextBox<CuHistoricalView>("68db9fed-7206-4def-9223-742b24414f70","","",true, this);
 
            HistorifyButton = RPSControlFactory.CreateRPSButton<CuHistoricalView>( "e6d5ddbf-10d1-4569-889f-3998ac6ebeea","","",this);
 

        }
        public IRPSTextBox<CuHistoricalView> DateTo { get; set; } 
        public IRPSButton<CuHistoricalView> HistorifyButton { get; set; } 
        public CuHistorical Screen { get; set; }
        public CuHistoricalView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  


}