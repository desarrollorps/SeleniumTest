    
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
    public partial class CuHistoryType:Screen
    {
        public CuHistoryType():base()
        {
            this.URL = "general.cuhistorytype";
            InitViews();
           
           
        }       
        protected void InitViews()
        {
            CuHistoryTypeCollectionView  = new CuHistoryTypeCollectionView(this); 
            CuHistoryTypeView  = new CuHistoryTypeView(this); 
            CuHistoryTypeLogView  = new CuHistoryTypeLogView(this); 
            CuHistoryTypeCollectionView.InitializeControls(); 
            CuHistoryTypeView.InitializeControls(); 
            CuHistoryTypeLogView.InitializeControls(); 
           
        }
      
            public CuHistoryTypeCollectionView CuHistoryTypeCollectionView {get; set; } 
            public CuHistoryTypeView CuHistoryTypeView {get; set; } 
            public CuHistoryTypeLogView CuHistoryTypeLogView {get; set; } 
    }
            
    public partial class CuHistoryTypeCollectionView : View
    {
        public CuHistoryTypeCollectionView(CuHistoryType screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            NewButton = RPSControlFactory.RPSNewButton<CuHistoryTypeCollectionView,CuHistoryTypeView>( this,Screen.CuHistoryTypeView);
 

        }
        public IRPSButton<CuHistoryTypeCollectionView,CuHistoryTypeView> NewButton { get; set; } 
        public CuHistoryType Screen { get; set; }
        public CuHistoryTypeCollectionView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  
            
    public partial class CuHistoryTypeView : View
    {
        public CuHistoryTypeView(CuHistoryType screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            SaveButton = RPSControlFactory.RPSSaveButton<CuHistoryTypeView>( this);
 
            DeleteButton = RPSControlFactory.RPSDeleteButton<CuHistoryTypeView>( this);
 
            ConfirmDeleteButton = RPSControlFactory.RPSConfirmDeleteButton<CuHistoryTypeView>( this);
 
            BackButton = RPSControlFactory.RPSBackButton<CuHistoryTypeView,CuHistoryTypeCollectionView>( this,Screen.CuHistoryTypeCollectionView);
 
            CodEntityType = RPSControlFactory.CreateRPSTextBox<CuHistoryTypeView>("b962accf-1c32-43f9-b34d-f78562e660ca","","",true, this);
 
            Description = RPSControlFactory.CreateRPSTextBox<CuHistoryTypeView>("7b9e0326-559e-4588-895f-727a159cdd95","","",true, this);
 
            StoredProcedure = RPSControlFactory.CreateRPSTextBox<CuHistoryTypeView>("3926b89c-372b-4464-8964-966b514fb707","","",false, this);
 
            CollectionInit params_CuHistoryTypeLogs = new CollectionInit(){IDDescriptor = "",CSSSelectorDescriptor = "",XPathDescriptor = ""};
            CuHistoryTypeLogs = RPSControlFactory.RPSCreateCollection<CuHistoryTypeView,CuHistoryTypeLogView>( params_CuHistoryTypeLogs,this,Screen.CuHistoryTypeLogView);
 
            CuHistoryTypeSection = RPSControlFactory.CreateRPSSection<CuHistoryTypeView>( "","ul li[rpsid='1d82471d-d670-4e59-9206-c656160f1a6f']","",this);
 
            CuHistoryTypeLogSection = RPSControlFactory.CreateRPSSection<CuHistoryTypeView>( "","ul li[rpsid='c7eb9817-5847-4c42-a69d-bb5d47aba605']","",this);
 

        }
        public IRPSButton<CuHistoryTypeView> SaveButton { get; set; } 
        public IRPSButton<CuHistoryTypeView> DeleteButton { get; set; } 
        public IRPSButton<CuHistoryTypeView> ConfirmDeleteButton { get; set; } 
        public IRPSButton<CuHistoryTypeView,CuHistoryTypeCollectionView> BackButton { get; set; } 
        public IRPSTextBox<CuHistoryTypeView> CodEntityType { get; set; } 
        public IRPSTextBox<CuHistoryTypeView> Description { get; set; } 
        public IRPSTextBox<CuHistoryTypeView> StoredProcedure { get; set; } 
        public IRPSCollectionEditor<CuHistoryTypeView,CuHistoryTypeLogView> CuHistoryTypeLogs { get; set; } 
        public IRPSSection<CuHistoryTypeView> CuHistoryTypeSection { get; set; } 
        public IRPSSection<CuHistoryTypeView> CuHistoryTypeLogSection { get; set; } 
        public CuHistoryType Screen { get; set; }
        public CuHistoryTypeView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  
            
    public partial class CuHistoryTypeLogView : View
    {
        public CuHistoryTypeLogView(CuHistoryType screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            SaveButton = RPSControlFactory.RPSSaveButton<CuHistoryTypeLogView>( this);
 
            DeleteButton = RPSControlFactory.RPSDeleteButton<CuHistoryTypeLogView>( this);
 
            ConfirmDeleteButton = RPSControlFactory.RPSConfirmDeleteButton<CuHistoryTypeLogView>( this);
 
            BackButton = RPSControlFactory.RPSBackButton<CuHistoryTypeLogView,CuHistoryTypeView>( this,Screen.CuHistoryTypeView);
 
            LastDateTo = RPSControlFactory.CreateRPSTextBox<CuHistoryTypeLogView>("e2b9dcaa-9934-4e79-b2b8-67272426c2c9","","",false, this);
 
            CuHistoryTypeLogSection = RPSControlFactory.CreateRPSSection<CuHistoryTypeLogView>( "","ul li[rpsid='1f35592b-7b5b-45dc-8f1f-8c34220a7a00']","",this);
 

        }
        public IRPSButton<CuHistoryTypeLogView> SaveButton { get; set; } 
        public IRPSButton<CuHistoryTypeLogView> DeleteButton { get; set; } 
        public IRPSButton<CuHistoryTypeLogView> ConfirmDeleteButton { get; set; } 
        public IRPSButton<CuHistoryTypeLogView,CuHistoryTypeView> BackButton { get; set; } 
        public IRPSTextBox<CuHistoryTypeLogView> LastDateTo { get; set; } 
        public IRPSSection<CuHistoryTypeLogView> CuHistoryTypeLogSection { get; set; } 
        public CuHistoryType Screen { get; set; }
        public CuHistoryTypeLogView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  


}