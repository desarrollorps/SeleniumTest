    
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
    public partial class CuProductLineUsers:Screen
    {
        public CuProductLineUsers():base()
        {
            this.URL = "general.cuproductlineusers";
            InitViews();
           
           
        }       
        protected void InitViews()
        {
            CuProductLineUsersQueryView  = new CuProductLineUsersQueryView(this); 
            CuProductLineUsersView  = new CuProductLineUsersView(this); 
            CuProductLineUsersQueryView.InitializeControls(); 
            CuProductLineUsersView.InitializeControls(); 
           
        }
      
            public CuProductLineUsersQueryView CuProductLineUsersQueryView {get; set; } 
            public CuProductLineUsersView CuProductLineUsersView {get; set; } 
    }
            
    public partial class CuProductLineUsersQueryView : View
    {
        public CuProductLineUsersQueryView(CuProductLineUsers screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            NewButton = RPSControlFactory.RPSNewButton<CuProductLineUsersQueryView,CuProductLineUsersView>( this,Screen.CuProductLineUsersView);
 
            ConsultButton = RPSControlFactory.RPSConsultButton<CuProductLineUsersQueryView>( this);
 
            CollectionInit params_CuProductLineUsersConsult = new CollectionInit(){IDDescriptor = "01a662e7-46f5-44f0-92a0-554c1395bf00",CSSSelectorDescriptor = "",XPathDescriptor = ""};
            CuProductLineUsersConsult = RPSControlFactory.RPSCreateCollection<CuProductLineUsersQueryView,CuProductLineUsersView>( params_CuProductLineUsersConsult,this,Screen.CuProductLineUsersView);
 

        }
        public IRPSButton<CuProductLineUsersQueryView,CuProductLineUsersView> NewButton { get; set; } 
        public IRPSButton<CuProductLineUsersQueryView> ConsultButton { get; set; } 
        public IRPSCollectionEditor<CuProductLineUsersQueryView,CuProductLineUsersView> CuProductLineUsersConsult { get; set; } 
        public CuProductLineUsers Screen { get; set; }
        public CuProductLineUsersQueryView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  
            
    public partial class CuProductLineUsersView : View
    {
        public CuProductLineUsersView(CuProductLineUsers screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            SaveButton = RPSControlFactory.RPSSaveButton<CuProductLineUsersView>( this);
 
            DeleteButton = RPSControlFactory.RPSDeleteButton<CuProductLineUsersView>( this);
 
            ConfirmDeleteButton = RPSControlFactory.RPSConfirmDeleteButton<CuProductLineUsersView>( this);
 
            BackButton = RPSControlFactory.RPSBackButton<CuProductLineUsersView,CuProductLineUsersQueryView>( this,Screen.CuProductLineUsersQueryView);
 
            CodUser = RPSControlFactory.CreateRPSComboBox<CuProductLineUsersView>("1250df86-dd1e-4cae-af0e-d7cae88dda9f","","",true, this);
 
            IDCuProductLine = RPSControlFactory.CreateRPSComboBox<CuProductLineUsersView>("a333b9c4-c2eb-45d7-bcbc-888d3e30b308","","",true, this);
 
            CuProductLineUsersSection = RPSControlFactory.CreateRPSSection<CuProductLineUsersView>( "","ul li[rpsid='f2ddda7c-fc21-4511-bfc6-3f7ac572bd1b']","",this);
 

        }
        public IRPSButton<CuProductLineUsersView> SaveButton { get; set; } 
        public IRPSButton<CuProductLineUsersView> DeleteButton { get; set; } 
        public IRPSButton<CuProductLineUsersView> ConfirmDeleteButton { get; set; } 
        public IRPSButton<CuProductLineUsersView,CuProductLineUsersQueryView> BackButton { get; set; } 
        public IRPSComboBox<CuProductLineUsersView> CodUser { get; set; } 
        public IRPSComboBox<CuProductLineUsersView> IDCuProductLine { get; set; } 
        public IRPSSection<CuProductLineUsersView> CuProductLineUsersSection { get; set; } 
        public CuProductLineUsers Screen { get; set; }
        public CuProductLineUsersView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  


}