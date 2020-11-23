    
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
    public partial class CuPrinterLabel:Screen
    {
        public CuPrinterLabel():base()
        {
            this.URL = "general.cuprinterlabel";
            InitViews();
           
           
        }       
        protected void InitViews()
        {
            CuPrinterLabelQueryView  = new CuPrinterLabelQueryView(this); 
            CuPrinterLabelView  = new CuPrinterLabelView(this); 
            CuPrinterLabelByTypeView  = new CuPrinterLabelByTypeView(this); 
            CuPrinterLabelQueryView.InitializeControls(); 
            CuPrinterLabelView.InitializeControls(); 
            CuPrinterLabelByTypeView.InitializeControls(); 
           
        }
      
            public CuPrinterLabelQueryView CuPrinterLabelQueryView {get; set; } 
            public CuPrinterLabelView CuPrinterLabelView {get; set; } 
            public CuPrinterLabelByTypeView CuPrinterLabelByTypeView {get; set; } 
    }
            
    public partial class CuPrinterLabelQueryView : View
    {
        public CuPrinterLabelQueryView(CuPrinterLabel screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            NewButton = RPSControlFactory.RPSNewButton<CuPrinterLabelQueryView,CuPrinterLabelView>( this,Screen.CuPrinterLabelView);
 
            ConsultButton = RPSControlFactory.RPSConsultButton<CuPrinterLabelQueryView>( this);
 
            Company = RPSControlFactory.CreateRPSComboBox<CuPrinterLabelQueryView>("8668ba59-7101-4f76-a186-95429f0020d9","","",false, this);
 
            CollectionInit params_CuPrinterLabelConsult = new CollectionInit(){IDDescriptor = "1f21e6ba-a17a-48fb-beb7-187e70c301f1",CSSSelectorDescriptor = "",XPathDescriptor = ""};
            CuPrinterLabelConsult = RPSControlFactory.RPSCreateCollection<CuPrinterLabelQueryView,CuPrinterLabelView>( params_CuPrinterLabelConsult,this,Screen.CuPrinterLabelView);
 

        }
        public IRPSButton<CuPrinterLabelQueryView,CuPrinterLabelView> NewButton { get; set; } 
        public IRPSButton<CuPrinterLabelQueryView> ConsultButton { get; set; } 
        public IRPSComboBox<CuPrinterLabelQueryView> Company { get; set; } 
        public IRPSCollectionEditor<CuPrinterLabelQueryView,CuPrinterLabelView> CuPrinterLabelConsult { get; set; } 
        public CuPrinterLabel Screen { get; set; }
        public CuPrinterLabelQueryView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  
            
    public partial class CuPrinterLabelView : View
    {
        public CuPrinterLabelView(CuPrinterLabel screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            SaveButton = RPSControlFactory.RPSSaveButton<CuPrinterLabelView>( this);
 
            DeleteButton = RPSControlFactory.RPSDeleteButton<CuPrinterLabelView>( this);
 
            ConfirmDeleteButton = RPSControlFactory.RPSConfirmDeleteButton<CuPrinterLabelView>( this);
 
            BackButton = RPSControlFactory.RPSBackButton<CuPrinterLabelView,CuPrinterLabelQueryView>( this,Screen.CuPrinterLabelQueryView);
 
            CodCompany = RPSControlFactory.CreateRPSComboBox<CuPrinterLabelView>("74ce2368-be7a-4764-a339-808f83160500","","",true, this);
 
            IDSite = RPSControlFactory.CreateRPSComboBox<CuPrinterLabelView>("03d5aea5-361b-422d-b174-e4123bb33029","","",true, this);
 
            IDCuPrinter = RPSControlFactory.CreateRPSComboBox<CuPrinterLabelView>("81a3e4d7-909e-4c1e-8d9d-cc4ca110cb43","","",true, this);
 
            IP = RPSControlFactory.CreateRPSTextBox<CuPrinterLabelView>("dc2d8fed-b678-45bc-8ba7-3d84f039d26e","","",false, this);
 
            CollectionInit params_CuPrinterLabelByTypes = new CollectionInit(){IDDescriptor = "",CSSSelectorDescriptor = "",XPathDescriptor = ""};
            CuPrinterLabelByTypes = RPSControlFactory.RPSCreateCollection<CuPrinterLabelView,CuPrinterLabelByTypeView>( params_CuPrinterLabelByTypes,this,Screen.CuPrinterLabelByTypeView);
 
            CuPrinterLabelSection = RPSControlFactory.CreateRPSSection<CuPrinterLabelView>( "","ul li[rpsid='46d43a17-39fc-435a-b62f-d84173e57a21']","",this);
 

        }
        public IRPSButton<CuPrinterLabelView> SaveButton { get; set; } 
        public IRPSButton<CuPrinterLabelView> DeleteButton { get; set; } 
        public IRPSButton<CuPrinterLabelView> ConfirmDeleteButton { get; set; } 
        public IRPSButton<CuPrinterLabelView,CuPrinterLabelQueryView> BackButton { get; set; } 
        public IRPSComboBox<CuPrinterLabelView> CodCompany { get; set; } 
        public IRPSComboBox<CuPrinterLabelView> IDSite { get; set; } 
        public IRPSComboBox<CuPrinterLabelView> IDCuPrinter { get; set; } 
        public IRPSTextBox<CuPrinterLabelView> IP { get; set; } 
        public IRPSCollectionEditor<CuPrinterLabelView,CuPrinterLabelByTypeView> CuPrinterLabelByTypes { get; set; } 
        public IRPSSection<CuPrinterLabelView> CuPrinterLabelSection { get; set; } 
        public CuPrinterLabel Screen { get; set; }
        public CuPrinterLabelView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  
            
    public partial class CuPrinterLabelByTypeView : View
    {
        public CuPrinterLabelByTypeView(CuPrinterLabel screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            SaveButton = RPSControlFactory.RPSSaveButton<CuPrinterLabelByTypeView>( this);
 
            DeleteButton = RPSControlFactory.RPSDeleteButton<CuPrinterLabelByTypeView>( this);
 
            ConfirmDeleteButton = RPSControlFactory.RPSConfirmDeleteButton<CuPrinterLabelByTypeView>( this);
 
            BackButton = RPSControlFactory.RPSBackButton<CuPrinterLabelByTypeView,CuPrinterLabelView>( this,Screen.CuPrinterLabelView);
 
            IDCuProductionLabelType = RPSControlFactory.CreateRPSComboBox<CuPrinterLabelByTypeView>("5f1aa523-605d-41cb-a6bc-b6dfb13eacc6","","",true, this);
 
            CuPrinterLabelByTypeSection = RPSControlFactory.CreateRPSSection<CuPrinterLabelByTypeView>( "","ul li[rpsid='656caeb8-0803-4432-8167-98da6724dfa1']","",this);
 

        }
        public IRPSButton<CuPrinterLabelByTypeView> SaveButton { get; set; } 
        public IRPSButton<CuPrinterLabelByTypeView> DeleteButton { get; set; } 
        public IRPSButton<CuPrinterLabelByTypeView> ConfirmDeleteButton { get; set; } 
        public IRPSButton<CuPrinterLabelByTypeView,CuPrinterLabelView> BackButton { get; set; } 
        public IRPSComboBox<CuPrinterLabelByTypeView> IDCuProductionLabelType { get; set; } 
        public IRPSSection<CuPrinterLabelByTypeView> CuPrinterLabelByTypeSection { get; set; } 
        public CuPrinterLabel Screen { get; set; }
        public CuPrinterLabelByTypeView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  


}