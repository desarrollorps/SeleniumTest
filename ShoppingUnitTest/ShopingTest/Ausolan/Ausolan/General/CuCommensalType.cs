    
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
    public partial class CuCommensalType:Screen
    {
        public CuCommensalType():base()
        {
            this.URL = "general.cucommensaltype";
            InitViews();
           
           
        }       
        protected void InitViews()
        {
            CuCommensalTypeCollectionView  = new CuCommensalTypeCollectionView(this); 
            CuCommensalTypeView  = new CuCommensalTypeView(this); 
            CuCommensalTypeCollectionView.InitializeControls(); 
            CuCommensalTypeView.InitializeControls(); 
           
        }
      
            public CuCommensalTypeCollectionView CuCommensalTypeCollectionView {get; set; } 
            public CuCommensalTypeView CuCommensalTypeView {get; set; } 
    }
            
    public partial class CuCommensalTypeCollectionView : View
    {
        public CuCommensalTypeCollectionView(CuCommensalType screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            NewButton = RPSControlFactory.RPSNewButton<CuCommensalTypeCollectionView,CuCommensalTypeView>( this,Screen.CuCommensalTypeView);
 

        }
        public IRPSButton<CuCommensalTypeCollectionView,CuCommensalTypeView> NewButton { get; set; } 
        public CuCommensalType Screen { get; set; }
        public CuCommensalTypeCollectionView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  
            
    public partial class CuCommensalTypeView : View
    {
        public CuCommensalTypeView(CuCommensalType screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            SaveButton = RPSControlFactory.RPSSaveButton<CuCommensalTypeView>( this);
 
            DeleteButton = RPSControlFactory.RPSDeleteButton<CuCommensalTypeView>( this);
 
            ConfirmDeleteButton = RPSControlFactory.RPSConfirmDeleteButton<CuCommensalTypeView>( this);
 
            BackButton = RPSControlFactory.RPSBackButton<CuCommensalTypeView,CuCommensalTypeCollectionView>( this,Screen.CuCommensalTypeCollectionView);
 
            CodCuCommensalType = RPSControlFactory.CreateRPSTextBox<CuCommensalTypeView>("b98ab0bf-721a-4d99-b508-a3b060cf6016","","",true, this);
 
            Description = RPSControlFactory.CreateRPSTextBox<CuCommensalTypeView>("bc5b0187-438f-4099-95f4-616763cf452f","","",false, this);
 
            Observ = RPSControlFactory.CreateRPSTextBox<CuCommensalTypeView>("61a194e0-3b3e-41dd-b114-0503e907976a","","",false, this);
 
            CuCommensalTypeSection = RPSControlFactory.CreateRPSSection<CuCommensalTypeView>( "","ul li[rpsid='70aeb46b-813c-4a14-b32b-498a39cdd003']","",this);
 
            Section = RPSControlFactory.CreateRPSSection<CuCommensalTypeView>( "","ul li[rpsid='68496371-0af3-46a5-b12b-2673bca569c2']","",this);
 

        }
        public IRPSButton<CuCommensalTypeView> SaveButton { get; set; } 
        public IRPSButton<CuCommensalTypeView> DeleteButton { get; set; } 
        public IRPSButton<CuCommensalTypeView> ConfirmDeleteButton { get; set; } 
        public IRPSButton<CuCommensalTypeView,CuCommensalTypeCollectionView> BackButton { get; set; } 
        public IRPSTextBox<CuCommensalTypeView> CodCuCommensalType { get; set; } 
        public IRPSTextBox<CuCommensalTypeView> Description { get; set; } 
        public IRPSTextBox<CuCommensalTypeView> Observ { get; set; } 
        public IRPSSection<CuCommensalTypeView> CuCommensalTypeSection { get; set; } 
        public IRPSSection<CuCommensalTypeView> Section { get; set; } 
        public CuCommensalType Screen { get; set; }
        public CuCommensalTypeView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  


}