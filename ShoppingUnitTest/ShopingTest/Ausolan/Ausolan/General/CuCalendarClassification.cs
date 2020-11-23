    
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
    public partial class CuCalendarClassification:Screen
    {
        public CuCalendarClassification():base()
        {
            this.URL = "general.cucalendarclassification";
            InitViews();
           
           
        }       
        protected void InitViews()
        {
            CuCalendarClassificationCollectionView  = new CuCalendarClassificationCollectionView(this); 
            CuCalendarClassificationView  = new CuCalendarClassificationView(this); 
            CuCalendarClassificationCollectionView.InitializeControls(); 
            CuCalendarClassificationView.InitializeControls(); 
           
        }
      
            public CuCalendarClassificationCollectionView CuCalendarClassificationCollectionView {get; set; } 
            public CuCalendarClassificationView CuCalendarClassificationView {get; set; } 
    }
            
    public partial class CuCalendarClassificationCollectionView : View
    {
        public CuCalendarClassificationCollectionView(CuCalendarClassification screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            NewButton = RPSControlFactory.RPSNewButton<CuCalendarClassificationCollectionView,CuCalendarClassificationView>( this,Screen.CuCalendarClassificationView);
 

        }
        public IRPSButton<CuCalendarClassificationCollectionView,CuCalendarClassificationView> NewButton { get; set; } 
        public CuCalendarClassification Screen { get; set; }
        public CuCalendarClassificationCollectionView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  
            
    public partial class CuCalendarClassificationView : View
    {
        public CuCalendarClassificationView(CuCalendarClassification screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            SaveButton = RPSControlFactory.RPSSaveButton<CuCalendarClassificationView>( this);
 
            DeleteButton = RPSControlFactory.RPSDeleteButton<CuCalendarClassificationView>( this);
 
            ConfirmDeleteButton = RPSControlFactory.RPSConfirmDeleteButton<CuCalendarClassificationView>( this);
 
            BackButton = RPSControlFactory.RPSBackButton<CuCalendarClassificationView,CuCalendarClassificationCollectionView>( this,Screen.CuCalendarClassificationCollectionView);
 
            CodCuCalendarClassification = RPSControlFactory.CreateRPSTextBox<CuCalendarClassificationView>("aa8f8ade-9781-41be-9b48-8923bec6c22e","","",true, this);
 
            Description = RPSControlFactory.CreateRPSTextBox<CuCalendarClassificationView>("983f987f-ae73-4e40-a778-6adc6fd261cb","","",false, this);
 
            IDCodingSerie = RPSControlFactory.CreateRPSComboBox<CuCalendarClassificationView>("b124d361-a607-4ccc-84d8-97ea030be23f","","",true, this);
 
            Observ = RPSControlFactory.CreateRPSTextBox<CuCalendarClassificationView>("86e76f0f-bff0-47d6-addb-863bf3199d5d","","",false, this);
 
            CuCalendarClassificationSection = RPSControlFactory.CreateRPSSection<CuCalendarClassificationView>( "","ul li[rpsid='e1da41f2-b2ac-4719-b415-3f018ab93fc3']","",this);
 
            ObservSection = RPSControlFactory.CreateRPSSection<CuCalendarClassificationView>( "","ul li[rpsid='64f12c1a-356b-44c5-9f6e-bbfb6ca5a118']","",this);
 

        }
        public IRPSButton<CuCalendarClassificationView> SaveButton { get; set; } 
        public IRPSButton<CuCalendarClassificationView> DeleteButton { get; set; } 
        public IRPSButton<CuCalendarClassificationView> ConfirmDeleteButton { get; set; } 
        public IRPSButton<CuCalendarClassificationView,CuCalendarClassificationCollectionView> BackButton { get; set; } 
        public IRPSTextBox<CuCalendarClassificationView> CodCuCalendarClassification { get; set; } 
        public IRPSTextBox<CuCalendarClassificationView> Description { get; set; } 
        public IRPSComboBox<CuCalendarClassificationView> IDCodingSerie { get; set; } 
        public IRPSTextBox<CuCalendarClassificationView> Observ { get; set; } 
        public IRPSSection<CuCalendarClassificationView> CuCalendarClassificationSection { get; set; } 
        public IRPSSection<CuCalendarClassificationView> ObservSection { get; set; } 
        public CuCalendarClassification Screen { get; set; }
        public CuCalendarClassificationView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  


}