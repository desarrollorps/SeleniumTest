    
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
    public partial class CuPackingMode:Screen
    {
        public CuPackingMode():base()
        {
            this.URL = "general.cupackingmode";
            InitViews();
           
           
        }       
        protected void InitViews()
        {
            CuPackingModeCollectionView  = new CuPackingModeCollectionView(this); 
            CuPackingModeView  = new CuPackingModeView(this); 
            CuPackingModeCollectionView.InitializeControls(); 
            CuPackingModeView.InitializeControls(); 
           
        }
      
            public CuPackingModeCollectionView CuPackingModeCollectionView {get; set; } 
            public CuPackingModeView CuPackingModeView {get; set; } 
    }
            
    public partial class CuPackingModeCollectionView : View
    {
        public CuPackingModeCollectionView(CuPackingMode screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            NewButton = RPSControlFactory.RPSNewButton<CuPackingModeCollectionView,CuPackingModeView>( this,Screen.CuPackingModeView);
 

        }
        public IRPSButton<CuPackingModeCollectionView,CuPackingModeView> NewButton { get; set; } 
        public CuPackingMode Screen { get; set; }
        public CuPackingModeCollectionView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  
            
    public partial class CuPackingModeView : View
    {
        public CuPackingModeView(CuPackingMode screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            SaveButton = RPSControlFactory.RPSSaveButton<CuPackingModeView>( this);
 
            DeleteButton = RPSControlFactory.RPSDeleteButton<CuPackingModeView>( this);
 
            ConfirmDeleteButton = RPSControlFactory.RPSConfirmDeleteButton<CuPackingModeView>( this);
 
            BackButton = RPSControlFactory.RPSBackButton<CuPackingModeView,CuPackingModeCollectionView>( this,Screen.CuPackingModeCollectionView);
 
            CodCuPackingMode = RPSControlFactory.CreateRPSTextBox<CuPackingModeView>("ee5bbe91-a060-43f5-b502-4d4219908fe1","","",true, this);
 
            Description = RPSControlFactory.CreateRPSTextBox<CuPackingModeView>("5fb92df1-dc96-4b57-aa2d-c89b7cd356f6","","",false, this);
 
            Observ = RPSControlFactory.CreateRPSTextBox<CuPackingModeView>("b50750b6-7866-4302-ac3e-2cb4693d27c2","","",false, this);
 
            CuPackingModeSection = RPSControlFactory.CreateRPSSection<CuPackingModeView>( "","ul li[rpsid='479bf6dc-3877-44fb-b274-9059b0c4cf76']","",this);
 
            Section = RPSControlFactory.CreateRPSSection<CuPackingModeView>( "","ul li[rpsid='938c8843-d7eb-4c15-bebb-265bb96194f8']","",this);
 

        }
        public IRPSButton<CuPackingModeView> SaveButton { get; set; } 
        public IRPSButton<CuPackingModeView> DeleteButton { get; set; } 
        public IRPSButton<CuPackingModeView> ConfirmDeleteButton { get; set; } 
        public IRPSButton<CuPackingModeView,CuPackingModeCollectionView> BackButton { get; set; } 
        public IRPSTextBox<CuPackingModeView> CodCuPackingMode { get; set; } 
        public IRPSTextBox<CuPackingModeView> Description { get; set; } 
        public IRPSTextBox<CuPackingModeView> Observ { get; set; } 
        public IRPSSection<CuPackingModeView> CuPackingModeSection { get; set; } 
        public IRPSSection<CuPackingModeView> Section { get; set; } 
        public CuPackingMode Screen { get; set; }
        public CuPackingModeView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  


}