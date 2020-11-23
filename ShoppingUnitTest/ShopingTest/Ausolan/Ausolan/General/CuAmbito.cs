    
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
    public partial class CuAmbito:Screen
    {
        public CuAmbito():base()
        {
            this.URL = "general.cuambito";
            InitViews();
           
           
        }       
        protected void InitViews()
        {
            CuAmbitoCollectionView  = new CuAmbitoCollectionView(this); 
            CuAmbitoEntityView  = new CuAmbitoEntityView(this); 
            CuAmbitoCollectionView.InitializeControls(); 
            CuAmbitoEntityView.InitializeControls(); 
           
        }
      
            public CuAmbitoCollectionView CuAmbitoCollectionView {get; set; } 
            public CuAmbitoEntityView CuAmbitoEntityView {get; set; } 
    }
            
    public partial class CuAmbitoCollectionView : View
    {
        public CuAmbitoCollectionView(CuAmbito screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            NewButton = RPSControlFactory.RPSNewButton<CuAmbitoCollectionView,CuAmbitoEntityView>( this,Screen.CuAmbitoEntityView);
 

        }
        public IRPSButton<CuAmbitoCollectionView,CuAmbitoEntityView> NewButton { get; set; } 
        public CuAmbito Screen { get; set; }
        public CuAmbitoCollectionView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  
            
    public partial class CuAmbitoEntityView : View
    {
        public CuAmbitoEntityView(CuAmbito screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            SaveButton = RPSControlFactory.RPSSaveButton<CuAmbitoEntityView>( this);
 
            DeleteButton = RPSControlFactory.RPSDeleteButton<CuAmbitoEntityView>( this);
 
            ConfirmDeleteButton = RPSControlFactory.RPSConfirmDeleteButton<CuAmbitoEntityView>( this);
 
            BackButton = RPSControlFactory.RPSBackButton<CuAmbitoEntityView,CuAmbitoCollectionView>( this,Screen.CuAmbitoCollectionView);
 
            CodCuAmbito = RPSControlFactory.CreateRPSTextBox<CuAmbitoEntityView>("0310eeec-e850-4e00-90fb-653638792e5d","","",true, this);
 
            Description = RPSControlFactory.CreateRPSTextBox<CuAmbitoEntityView>("72bfe29e-6f7a-44a1-a59d-09ca47fbe89c","","",false, this);
 
            Observ = RPSControlFactory.CreateRPSTextBox<CuAmbitoEntityView>("d2fdc9de-504a-40c1-b122-009b85a532d8","","",false, this);
 
            SectionGeneralData = RPSControlFactory.CreateRPSSection<CuAmbitoEntityView>( "","ul li[rpsid='756d9ca0-a13b-463e-82da-fe800e6b5ab9']","",this);
 
            SectionObservations = RPSControlFactory.CreateRPSSection<CuAmbitoEntityView>( "","ul li[rpsid='87781a79-3222-4d70-a6ab-6fc4aacd51d2']","",this);
 

        }
        public IRPSButton<CuAmbitoEntityView> SaveButton { get; set; } 
        public IRPSButton<CuAmbitoEntityView> DeleteButton { get; set; } 
        public IRPSButton<CuAmbitoEntityView> ConfirmDeleteButton { get; set; } 
        public IRPSButton<CuAmbitoEntityView,CuAmbitoCollectionView> BackButton { get; set; } 
        public IRPSTextBox<CuAmbitoEntityView> CodCuAmbito { get; set; } 
        public IRPSTextBox<CuAmbitoEntityView> Description { get; set; } 
        public IRPSTextBox<CuAmbitoEntityView> Observ { get; set; } 
        public IRPSSection<CuAmbitoEntityView> SectionGeneralData { get; set; } 
        public IRPSSection<CuAmbitoEntityView> SectionObservations { get; set; } 
        public CuAmbito Screen { get; set; }
        public CuAmbitoEntityView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  


}