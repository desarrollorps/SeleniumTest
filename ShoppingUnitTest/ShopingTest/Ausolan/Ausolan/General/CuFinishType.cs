    
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
    public partial class CuFinishType:Screen
    {
        public CuFinishType():base()
        {
            this.URL = "general.cufinishtype";
            InitViews();
           
           
        }       
        protected void InitViews()
        {
            CuFinishTypeCollectionView  = new CuFinishTypeCollectionView(this); 
            CuFinishTypeView  = new CuFinishTypeView(this); 
            CuFinishTypeCollectionView.InitializeControls(); 
            CuFinishTypeView.InitializeControls(); 
           
        }
      
            public CuFinishTypeCollectionView CuFinishTypeCollectionView {get; set; } 
            public CuFinishTypeView CuFinishTypeView {get; set; } 
    }
            
    public partial class CuFinishTypeCollectionView : View
    {
        public CuFinishTypeCollectionView(CuFinishType screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            NewButton = RPSControlFactory.RPSNewButton<CuFinishTypeCollectionView,CuFinishTypeView>( this,Screen.CuFinishTypeView);
 

        }
        public IRPSButton<CuFinishTypeCollectionView,CuFinishTypeView> NewButton { get; set; } 
        public CuFinishType Screen { get; set; }
        public CuFinishTypeCollectionView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  
            
    public partial class CuFinishTypeView : View
    {
        public CuFinishTypeView(CuFinishType screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            SaveButton = RPSControlFactory.RPSSaveButton<CuFinishTypeView>( this);
 
            DeleteButton = RPSControlFactory.RPSDeleteButton<CuFinishTypeView>( this);
 
            ConfirmDeleteButton = RPSControlFactory.RPSConfirmDeleteButton<CuFinishTypeView>( this);
 
            BackButton = RPSControlFactory.RPSBackButton<CuFinishTypeView,CuFinishTypeCollectionView>( this,Screen.CuFinishTypeCollectionView);
 
            CodCuFinishType = RPSControlFactory.CreateRPSTextBox<CuFinishTypeView>("cacb0f89-c5df-43b7-94bb-a7f300bbda79","","",true, this);
 
            Description = RPSControlFactory.CreateRPSTextBox<CuFinishTypeView>("7105d65d-e26e-49ee-9e9a-d19e54bb0950","","",false, this);
 
            Observ = RPSControlFactory.CreateRPSTextBox<CuFinishTypeView>("b11db7a6-325a-4a64-a021-d2f43adf80db","","",false, this);
 
            CuFinishTypeSection = RPSControlFactory.CreateRPSSection<CuFinishTypeView>( "","ul li[rpsid='00ea5f0a-a102-47c8-a1bd-b19ef1b3bdce']","",this);
 
            Section = RPSControlFactory.CreateRPSSection<CuFinishTypeView>( "","ul li[rpsid='7fe42f15-f94e-419c-b194-366337834428']","",this);
 

        }
        public IRPSButton<CuFinishTypeView> SaveButton { get; set; } 
        public IRPSButton<CuFinishTypeView> DeleteButton { get; set; } 
        public IRPSButton<CuFinishTypeView> ConfirmDeleteButton { get; set; } 
        public IRPSButton<CuFinishTypeView,CuFinishTypeCollectionView> BackButton { get; set; } 
        public IRPSTextBox<CuFinishTypeView> CodCuFinishType { get; set; } 
        public IRPSTextBox<CuFinishTypeView> Description { get; set; } 
        public IRPSTextBox<CuFinishTypeView> Observ { get; set; } 
        public IRPSSection<CuFinishTypeView> CuFinishTypeSection { get; set; } 
        public IRPSSection<CuFinishTypeView> Section { get; set; } 
        public CuFinishType Screen { get; set; }
        public CuFinishTypeView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  


}