    
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
    public partial class CuOrganizationUnit:Screen
    {
        public CuOrganizationUnit():base()
        {
            this.URL = "general.cuorganizationunit";
            InitViews();
           
           
        }       
        protected void InitViews()
        {
            CuOrganizationUnitCollectionView  = new CuOrganizationUnitCollectionView(this); 
            CuOrganizationUnitView  = new CuOrganizationUnitView(this); 
            CuOrganizationUnitCollectionView.InitializeControls(); 
            CuOrganizationUnitView.InitializeControls(); 
           
        }
      
            public CuOrganizationUnitCollectionView CuOrganizationUnitCollectionView {get; set; } 
            public CuOrganizationUnitView CuOrganizationUnitView {get; set; } 
    }
            
    public partial class CuOrganizationUnitCollectionView : View
    {
        public CuOrganizationUnitCollectionView(CuOrganizationUnit screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            NewButton = RPSControlFactory.RPSNewButton<CuOrganizationUnitCollectionView,CuOrganizationUnitView>( this,Screen.CuOrganizationUnitView);
 

        }
        public IRPSButton<CuOrganizationUnitCollectionView,CuOrganizationUnitView> NewButton { get; set; } 
        public CuOrganizationUnit Screen { get; set; }
        public CuOrganizationUnitCollectionView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  
            
    public partial class CuOrganizationUnitView : View
    {
        public CuOrganizationUnitView(CuOrganizationUnit screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            SaveButton = RPSControlFactory.RPSSaveButton<CuOrganizationUnitView>( this);
 
            DeleteButton = RPSControlFactory.RPSDeleteButton<CuOrganizationUnitView>( this);
 
            ConfirmDeleteButton = RPSControlFactory.RPSConfirmDeleteButton<CuOrganizationUnitView>( this);
 
            BackButton = RPSControlFactory.RPSBackButton<CuOrganizationUnitView,CuOrganizationUnitCollectionView>( this,Screen.CuOrganizationUnitCollectionView);
 
            CodCuOrganizationUnit = RPSControlFactory.CreateRPSTextBox<CuOrganizationUnitView>("3634db4b-7554-460a-993f-1d7ba08f7167","","",true, this);
 
            Description = RPSControlFactory.CreateRPSTextBox<CuOrganizationUnitView>("8c051851-bdb8-4699-9b96-78e4c7ad718c","","",false, this);
 
            Observ = RPSControlFactory.CreateRPSTextBox<CuOrganizationUnitView>("80eeeb26-e2a6-4826-9441-a0c015114d45","","",false, this);
 
            CuOrganizationUnitSection = RPSControlFactory.CreateRPSSection<CuOrganizationUnitView>( "","ul li[rpsid='13525bb2-7784-4ba9-88ae-644833076f03']","",this);
 
            Section = RPSControlFactory.CreateRPSSection<CuOrganizationUnitView>( "","ul li[rpsid='63b54d2f-bf13-402a-ad06-8d633970c24f']","",this);
 

        }
        public IRPSButton<CuOrganizationUnitView> SaveButton { get; set; } 
        public IRPSButton<CuOrganizationUnitView> DeleteButton { get; set; } 
        public IRPSButton<CuOrganizationUnitView> ConfirmDeleteButton { get; set; } 
        public IRPSButton<CuOrganizationUnitView,CuOrganizationUnitCollectionView> BackButton { get; set; } 
        public IRPSTextBox<CuOrganizationUnitView> CodCuOrganizationUnit { get; set; } 
        public IRPSTextBox<CuOrganizationUnitView> Description { get; set; } 
        public IRPSTextBox<CuOrganizationUnitView> Observ { get; set; } 
        public IRPSSection<CuOrganizationUnitView> CuOrganizationUnitSection { get; set; } 
        public IRPSSection<CuOrganizationUnitView> Section { get; set; } 
        public CuOrganizationUnit Screen { get; set; }
        public CuOrganizationUnitView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  


}