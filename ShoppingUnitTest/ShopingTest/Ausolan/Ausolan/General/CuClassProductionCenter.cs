    
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
    public partial class CuClassProductionCenter:Screen
    {
        public CuClassProductionCenter():base()
        {
            this.URL = "general.cuclassproductioncenter";
            InitViews();
           
           
        }       
        protected void InitViews()
        {
            CuClassProductionCenterCollectionView  = new CuClassProductionCenterCollectionView(this); 
            CuClassProductionCenterView  = new CuClassProductionCenterView(this); 
            CuClassProductionCenterCollectionView.InitializeControls(); 
            CuClassProductionCenterView.InitializeControls(); 
           
        }
      
            public CuClassProductionCenterCollectionView CuClassProductionCenterCollectionView {get; set; } 
            public CuClassProductionCenterView CuClassProductionCenterView {get; set; } 
    }
            
    public partial class CuClassProductionCenterCollectionView : View
    {
        public CuClassProductionCenterCollectionView(CuClassProductionCenter screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            NewButton = RPSControlFactory.RPSNewButton<CuClassProductionCenterCollectionView,CuClassProductionCenterView>( this,Screen.CuClassProductionCenterView);
 

        }
        public IRPSButton<CuClassProductionCenterCollectionView,CuClassProductionCenterView> NewButton { get; set; } 
        public CuClassProductionCenter Screen { get; set; }
        public CuClassProductionCenterCollectionView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  
            
    public partial class CuClassProductionCenterView : View
    {
        public CuClassProductionCenterView(CuClassProductionCenter screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            SaveButton = RPSControlFactory.RPSSaveButton<CuClassProductionCenterView>( this);
 
            DeleteButton = RPSControlFactory.RPSDeleteButton<CuClassProductionCenterView>( this);
 
            ConfirmDeleteButton = RPSControlFactory.RPSConfirmDeleteButton<CuClassProductionCenterView>( this);
 
            BackButton = RPSControlFactory.RPSBackButton<CuClassProductionCenterView,CuClassProductionCenterCollectionView>( this,Screen.CuClassProductionCenterCollectionView);
 
            CodCuClassProductionCenter = RPSControlFactory.CreateRPSTextBox<CuClassProductionCenterView>("97861550-c7a7-4fdd-a948-946b6a3c599f","","",true, this);
 
            Description = RPSControlFactory.CreateRPSTextBox<CuClassProductionCenterView>("d2c79f4b-804a-43db-9e9f-9f61d1d7d4be","","",false, this);
 
            CuClassProductionCenterSection = RPSControlFactory.CreateRPSSection<CuClassProductionCenterView>( "","ul li[rpsid='083c7e96-4cc5-4a1e-b986-abda47249746']","",this);
 

        }
        public IRPSButton<CuClassProductionCenterView> SaveButton { get; set; } 
        public IRPSButton<CuClassProductionCenterView> DeleteButton { get; set; } 
        public IRPSButton<CuClassProductionCenterView> ConfirmDeleteButton { get; set; } 
        public IRPSButton<CuClassProductionCenterView,CuClassProductionCenterCollectionView> BackButton { get; set; } 
        public IRPSTextBox<CuClassProductionCenterView> CodCuClassProductionCenter { get; set; } 
        public IRPSTextBox<CuClassProductionCenterView> Description { get; set; } 
        public IRPSSection<CuClassProductionCenterView> CuClassProductionCenterSection { get; set; } 
        public CuClassProductionCenter Screen { get; set; }
        public CuClassProductionCenterView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  


}