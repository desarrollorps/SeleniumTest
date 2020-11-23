    
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
    public partial class CuMealType:Screen
    {
        public CuMealType():base()
        {
            this.URL = "general.cumealtype";
            InitViews();
           
           
        }       
        protected void InitViews()
        {
            CuMealTypeCollectionView  = new CuMealTypeCollectionView(this); 
            CuMealTypeView  = new CuMealTypeView(this); 
            CuMealTypeCollectionView.InitializeControls(); 
            CuMealTypeView.InitializeControls(); 
           
        }
      
            public CuMealTypeCollectionView CuMealTypeCollectionView {get; set; } 
            public CuMealTypeView CuMealTypeView {get; set; } 
    }
            
    public partial class CuMealTypeCollectionView : View
    {
        public CuMealTypeCollectionView(CuMealType screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            NewButton = RPSControlFactory.RPSNewButton<CuMealTypeCollectionView,CuMealTypeView>( this,Screen.CuMealTypeView);
 

        }
        public IRPSButton<CuMealTypeCollectionView,CuMealTypeView> NewButton { get; set; } 
        public CuMealType Screen { get; set; }
        public CuMealTypeCollectionView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  
            
    public partial class CuMealTypeView : View
    {
        public CuMealTypeView(CuMealType screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            SaveButton = RPSControlFactory.RPSSaveButton<CuMealTypeView>( this);
 
            DeleteButton = RPSControlFactory.RPSDeleteButton<CuMealTypeView>( this);
 
            ConfirmDeleteButton = RPSControlFactory.RPSConfirmDeleteButton<CuMealTypeView>( this);
 
            BackButton = RPSControlFactory.RPSBackButton<CuMealTypeView,CuMealTypeCollectionView>( this,Screen.CuMealTypeCollectionView);
 
            CodCuMealType = RPSControlFactory.CreateRPSTextBox<CuMealTypeView>("79011b51-9e77-41ed-a6da-14289c308eab","","",true, this);
 
            Description = RPSControlFactory.CreateRPSTextBox<CuMealTypeView>("e47468a0-4df6-4f2f-915c-0e01f95e003e","","",false, this);
 
            Observ = RPSControlFactory.CreateRPSTextBox<CuMealTypeView>("b21d6c8e-81f2-43ca-84fe-f01de8e96205","","",false, this);
 
            CuMealTypeSection = RPSControlFactory.CreateRPSSection<CuMealTypeView>( "","ul li[rpsid='6f246176-c150-420d-a006-66fe2d9dd88a']","",this);
 
            Section = RPSControlFactory.CreateRPSSection<CuMealTypeView>( "","ul li[rpsid='451618a3-db0d-40fa-a673-a089d642e497']","",this);
 

        }
        public IRPSButton<CuMealTypeView> SaveButton { get; set; } 
        public IRPSButton<CuMealTypeView> DeleteButton { get; set; } 
        public IRPSButton<CuMealTypeView> ConfirmDeleteButton { get; set; } 
        public IRPSButton<CuMealTypeView,CuMealTypeCollectionView> BackButton { get; set; } 
        public IRPSTextBox<CuMealTypeView> CodCuMealType { get; set; } 
        public IRPSTextBox<CuMealTypeView> Description { get; set; } 
        public IRPSTextBox<CuMealTypeView> Observ { get; set; } 
        public IRPSSection<CuMealTypeView> CuMealTypeSection { get; set; } 
        public IRPSSection<CuMealTypeView> Section { get; set; } 
        public CuMealType Screen { get; set; }
        public CuMealTypeView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  


}