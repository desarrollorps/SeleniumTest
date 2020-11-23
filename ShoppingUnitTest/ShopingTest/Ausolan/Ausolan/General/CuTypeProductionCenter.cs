    
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
    public partial class CuTypeProductionCenter:Screen
    {
        public CuTypeProductionCenter():base()
        {
            this.URL = "general.cutypeproductioncenter";
            InitViews();
           
           
        }       
        protected void InitViews()
        {
            CuTypeProductionCenterCollectionView  = new CuTypeProductionCenterCollectionView(this); 
            CuTypeProductionCenterView  = new CuTypeProductionCenterView(this); 
            CuTypeProductionCenterCollectionView.InitializeControls(); 
            CuTypeProductionCenterView.InitializeControls(); 
           
        }
      
            public CuTypeProductionCenterCollectionView CuTypeProductionCenterCollectionView {get; set; } 
            public CuTypeProductionCenterView CuTypeProductionCenterView {get; set; } 
    }
            
    public partial class CuTypeProductionCenterCollectionView : View
    {
        public CuTypeProductionCenterCollectionView(CuTypeProductionCenter screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            NewButton = RPSControlFactory.RPSNewButton<CuTypeProductionCenterCollectionView,CuTypeProductionCenterView>( this,Screen.CuTypeProductionCenterView);
 

        }
        public IRPSButton<CuTypeProductionCenterCollectionView,CuTypeProductionCenterView> NewButton { get; set; } 
        public CuTypeProductionCenter Screen { get; set; }
        public CuTypeProductionCenterCollectionView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  
            
    public partial class CuTypeProductionCenterView : View
    {
        public CuTypeProductionCenterView(CuTypeProductionCenter screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            SaveButton = RPSControlFactory.RPSSaveButton<CuTypeProductionCenterView>( this);
 
            DeleteButton = RPSControlFactory.RPSDeleteButton<CuTypeProductionCenterView>( this);
 
            ConfirmDeleteButton = RPSControlFactory.RPSConfirmDeleteButton<CuTypeProductionCenterView>( this);
 
            BackButton = RPSControlFactory.RPSBackButton<CuTypeProductionCenterView,CuTypeProductionCenterCollectionView>( this,Screen.CuTypeProductionCenterCollectionView);
 
            CodCuTypeProductionCenter = RPSControlFactory.CreateRPSTextBox<CuTypeProductionCenterView>("6eda10f2-4c75-4874-9234-fb19b42e6c3f","","",true, this);
 
            Description = RPSControlFactory.CreateRPSTextBox<CuTypeProductionCenterView>("29e9fd89-1bb2-4649-9afa-37d27f4bbd22","","",false, this);
 
            CuTypeProductionCenterSection = RPSControlFactory.CreateRPSSection<CuTypeProductionCenterView>( "","ul li[rpsid='67506ec0-876b-4211-84e8-7d312e5580eb']","",this);
 

        }
        public IRPSButton<CuTypeProductionCenterView> SaveButton { get; set; } 
        public IRPSButton<CuTypeProductionCenterView> DeleteButton { get; set; } 
        public IRPSButton<CuTypeProductionCenterView> ConfirmDeleteButton { get; set; } 
        public IRPSButton<CuTypeProductionCenterView,CuTypeProductionCenterCollectionView> BackButton { get; set; } 
        public IRPSTextBox<CuTypeProductionCenterView> CodCuTypeProductionCenter { get; set; } 
        public IRPSTextBox<CuTypeProductionCenterView> Description { get; set; } 
        public IRPSSection<CuTypeProductionCenterView> CuTypeProductionCenterSection { get; set; } 
        public CuTypeProductionCenter Screen { get; set; }
        public CuTypeProductionCenterView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  


}