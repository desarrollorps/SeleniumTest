    
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
    public partial class CuServiceType:Screen
    {
        public CuServiceType():base()
        {
            this.URL = "general.cuservicetype";
            InitViews();
           
           
        }       
        protected void InitViews()
        {
            CuServiceTypeCollectionView  = new CuServiceTypeCollectionView(this); 
            CuServiceTypeView  = new CuServiceTypeView(this); 
            CuServiceTypeCollectionView.InitializeControls(); 
            CuServiceTypeView.InitializeControls(); 
           
        }
      
            public CuServiceTypeCollectionView CuServiceTypeCollectionView {get; set; } 
            public CuServiceTypeView CuServiceTypeView {get; set; } 
    }
            
    public partial class CuServiceTypeCollectionView : View
    {
        public CuServiceTypeCollectionView(CuServiceType screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            NewButton = RPSControlFactory.RPSNewButton<CuServiceTypeCollectionView,CuServiceTypeView>( this,Screen.CuServiceTypeView);
 

        }
        public IRPSButton<CuServiceTypeCollectionView,CuServiceTypeView> NewButton { get; set; } 
        public CuServiceType Screen { get; set; }
        public CuServiceTypeCollectionView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  
            
    public partial class CuServiceTypeView : View
    {
        public CuServiceTypeView(CuServiceType screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            SaveButton = RPSControlFactory.RPSSaveButton<CuServiceTypeView>( this);
 
            DeleteButton = RPSControlFactory.RPSDeleteButton<CuServiceTypeView>( this);
 
            ConfirmDeleteButton = RPSControlFactory.RPSConfirmDeleteButton<CuServiceTypeView>( this);
 
            BackButton = RPSControlFactory.RPSBackButton<CuServiceTypeView,CuServiceTypeCollectionView>( this,Screen.CuServiceTypeCollectionView);
 
            CodCuServiceType = RPSControlFactory.CreateRPSTextBox<CuServiceTypeView>("79dd6eae-8744-4a39-8ec8-8c8781f63c1e","","",true, this);
 
            Description = RPSControlFactory.CreateRPSTextBox<CuServiceTypeView>("ee9fb3d7-8a01-4ed5-bfc8-67d969475f94","","",false, this);
 
            Observ = RPSControlFactory.CreateRPSTextBox<CuServiceTypeView>("ee059158-aa26-4e6e-902c-7f6b8b1d7c1e","","",false, this);
 
            CuServiceTypeSection = RPSControlFactory.CreateRPSSection<CuServiceTypeView>( "","ul li[rpsid='b45f0f4e-afdc-42c0-8f31-349ab7048258']","",this);
 
            Section = RPSControlFactory.CreateRPSSection<CuServiceTypeView>( "","ul li[rpsid='6208cf98-bfde-4f11-83f5-35456da112c6']","",this);
 

        }
        public IRPSButton<CuServiceTypeView> SaveButton { get; set; } 
        public IRPSButton<CuServiceTypeView> DeleteButton { get; set; } 
        public IRPSButton<CuServiceTypeView> ConfirmDeleteButton { get; set; } 
        public IRPSButton<CuServiceTypeView,CuServiceTypeCollectionView> BackButton { get; set; } 
        public IRPSTextBox<CuServiceTypeView> CodCuServiceType { get; set; } 
        public IRPSTextBox<CuServiceTypeView> Description { get; set; } 
        public IRPSTextBox<CuServiceTypeView> Observ { get; set; } 
        public IRPSSection<CuServiceTypeView> CuServiceTypeSection { get; set; } 
        public IRPSSection<CuServiceTypeView> Section { get; set; } 
        public CuServiceType Screen { get; set; }
        public CuServiceTypeView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  


}