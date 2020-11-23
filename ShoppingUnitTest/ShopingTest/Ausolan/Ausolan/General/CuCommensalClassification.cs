    
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
    public partial class CuCommensalClassification:Screen
    {
        public CuCommensalClassification():base()
        {
            this.URL = "general.cucommensalclassification";
            InitViews();
           
           
        }       
        protected void InitViews()
        {
            CuCommensalClassificationQueryView  = new CuCommensalClassificationQueryView(this); 
            CuCommensalClassificationView  = new CuCommensalClassificationView(this); 
            CuCommensalClassificationQueryView.InitializeControls(); 
            CuCommensalClassificationView.InitializeControls(); 
           
        }
      
            public CuCommensalClassificationQueryView CuCommensalClassificationQueryView {get; set; } 
            public CuCommensalClassificationView CuCommensalClassificationView {get; set; } 
    }
            
    public partial class CuCommensalClassificationQueryView : View
    {
        public CuCommensalClassificationQueryView(CuCommensalClassification screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            NewButton = RPSControlFactory.RPSNewButton<CuCommensalClassificationQueryView,CuCommensalClassificationView>( this,Screen.CuCommensalClassificationView);
 
            ConsultButton = RPSControlFactory.RPSConsultButton<CuCommensalClassificationQueryView>( this);
 
            CollectionInit params_CuCommensalClassificationConsult = new CollectionInit(){IDDescriptor = "18560041-ff8d-4c85-aa6c-86d0c07ac60b",CSSSelectorDescriptor = "",XPathDescriptor = ""};
            CuCommensalClassificationConsult = RPSControlFactory.RPSCreateCollection<CuCommensalClassificationQueryView,CuCommensalClassificationView>( params_CuCommensalClassificationConsult,this,Screen.CuCommensalClassificationView);
 

        }
        public IRPSButton<CuCommensalClassificationQueryView,CuCommensalClassificationView> NewButton { get; set; } 
        public IRPSButton<CuCommensalClassificationQueryView> ConsultButton { get; set; } 
        public IRPSCollectionEditor<CuCommensalClassificationQueryView,CuCommensalClassificationView> CuCommensalClassificationConsult { get; set; } 
        public CuCommensalClassification Screen { get; set; }
        public CuCommensalClassificationQueryView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  
            
    public partial class CuCommensalClassificationView : View
    {
        public CuCommensalClassificationView(CuCommensalClassification screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            SaveButton = RPSControlFactory.RPSSaveButton<CuCommensalClassificationView>( this);
 
            DeleteButton = RPSControlFactory.RPSDeleteButton<CuCommensalClassificationView>( this);
 
            ConfirmDeleteButton = RPSControlFactory.RPSConfirmDeleteButton<CuCommensalClassificationView>( this);
 
            BackButton = RPSControlFactory.RPSBackButton<CuCommensalClassificationView,CuCommensalClassificationQueryView>( this,Screen.CuCommensalClassificationQueryView);
 
            CodCuCommensalClassification = RPSControlFactory.CreateRPSTextBox<CuCommensalClassificationView>("56926864-0c2d-4ce3-96b8-99b7c38bbfc0","","",true, this);
 
            Description = RPSControlFactory.CreateRPSTextBox<CuCommensalClassificationView>("c1c3fa63-d692-4caa-9a12-6c34454681ae","","",false, this);
 
            IDCuAmbito = RPSControlFactory.CreateRPSComboBox<CuCommensalClassificationView>("f3952e24-05fb-4d72-85b8-ce939dbbcf40","","",true, this);
 
            IDCuCommensalType = RPSControlFactory.CreateRPSComboBox<CuCommensalClassificationView>("92d0b896-a476-4261-b113-fd1e17a6c6b4","","",true, this);
 
            Observ = RPSControlFactory.CreateRPSTextBox<CuCommensalClassificationView>("5f3ae960-1947-4ce7-a4e1-870e64a9eb29","","",false, this);
 
            CuCommensalClassificationSection = RPSControlFactory.CreateRPSSection<CuCommensalClassificationView>( "","ul li[rpsid='b33fb5d7-1782-44a3-a73b-c7b9a5c3ee2f']","",this);
 
            ObservSection = RPSControlFactory.CreateRPSSection<CuCommensalClassificationView>( "","ul li[rpsid='d6768c50-ef18-402b-9ac7-cdb1e4ec8643']","",this);
 

        }
        public IRPSButton<CuCommensalClassificationView> SaveButton { get; set; } 
        public IRPSButton<CuCommensalClassificationView> DeleteButton { get; set; } 
        public IRPSButton<CuCommensalClassificationView> ConfirmDeleteButton { get; set; } 
        public IRPSButton<CuCommensalClassificationView,CuCommensalClassificationQueryView> BackButton { get; set; } 
        public IRPSTextBox<CuCommensalClassificationView> CodCuCommensalClassification { get; set; } 
        public IRPSTextBox<CuCommensalClassificationView> Description { get; set; } 
        public IRPSComboBox<CuCommensalClassificationView> IDCuAmbito { get; set; } 
        public IRPSComboBox<CuCommensalClassificationView> IDCuCommensalType { get; set; } 
        public IRPSTextBox<CuCommensalClassificationView> Observ { get; set; } 
        public IRPSSection<CuCommensalClassificationView> CuCommensalClassificationSection { get; set; } 
        public IRPSSection<CuCommensalClassificationView> ObservSection { get; set; } 
        public CuCommensalClassification Screen { get; set; }
        public CuCommensalClassificationView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  


}