    
using RPSSeleniumProperties;
using RPSSeleniumProperties.Interactables;
using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.Interactables;
using RPSSeleniumProperties.viewmodels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace SeleniumGeneratedClasses.ToolTest.ShoppingCart.Services.General
{
    //RPS VERSION Version2020
    public partial class CuShoppingCartConsultView:Screen
    {
        public CuShoppingCartConsultView():base()
        {
            this.URL = "general.cushoppingcartconsultview";
            InitViews();
           
           
        }       
        protected void InitViews()
        {
            CuShoppingCartConsultViewQueryView  = new CuShoppingCartConsultViewQueryView(this); 
            CuShoppingCartConsultViewView  = new CuShoppingCartConsultViewView(this); 
            CuShoppingCartConsultViewQueryView.InitializeControls(); 
            CuShoppingCartConsultViewView.InitializeControls(); 
           
        }
      
            public CuShoppingCartConsultViewQueryView CuShoppingCartConsultViewQueryView {get; set; } 
            public CuShoppingCartConsultViewView CuShoppingCartConsultViewView {get; set; } 
    }
            
    public partial class CuShoppingCartConsultViewQueryView : View
    {
        public CuShoppingCartConsultViewQueryView(CuShoppingCartConsultView screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            NewButton = RPSControlFactory.RPSNewButton<CuShoppingCartConsultViewQueryView,CuShoppingCartConsultViewView>( this,Screen.CuShoppingCartConsultViewView);
 
            ConsultButton = RPSControlFactory.RPSConsultButton<CuShoppingCartConsultViewQueryView>( this);
 
            CuShoppingCartConsultView_ShoppingDate_filter = RPSControlFactory.CreateRPSTextBox<CuShoppingCartConsultViewQueryView>("83153734-5f74-4b3f-8e15-1ea677b5997a","","",false, this);
 
            CuShoppingCartConsultView_DeliveryDate_filter = RPSControlFactory.CreateRPSTextBox<CuShoppingCartConsultViewQueryView>("9766dda4-0dd6-418c-8fbe-f7bdab185de0","","",false, this);
 
            CollectionInit params_CuShoppingCartConsultViewConsult = new CollectionInit(){IDDescriptor = "6eaa0b96-b96f-4e58-86ae-bffb1a0bcc6b",CSSSelectorDescriptor = "",XPathDescriptor = ""};
            CuShoppingCartConsultViewConsult = RPSControlFactory.RPSCreateCollection<CuShoppingCartConsultViewQueryView,CuShoppingCartConsultViewView>( params_CuShoppingCartConsultViewConsult,this,Screen.CuShoppingCartConsultViewView);
 

        }
        public IRPSButton<CuShoppingCartConsultViewQueryView,CuShoppingCartConsultViewView> NewButton { get; set; } 
        public IRPSButton<CuShoppingCartConsultViewQueryView> ConsultButton { get; set; } 
        public IRPSTextBox<CuShoppingCartConsultViewQueryView> CuShoppingCartConsultView_ShoppingDate_filter { get; set; } 
        public IRPSTextBox<CuShoppingCartConsultViewQueryView> CuShoppingCartConsultView_DeliveryDate_filter { get; set; } 
        public IRPSCollectionEditor<CuShoppingCartConsultViewQueryView,CuShoppingCartConsultViewView> CuShoppingCartConsultViewConsult { get; set; } 
        public CuShoppingCartConsultView Screen { get; set; }
        public CuShoppingCartConsultViewQueryView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  
            
    public partial class CuShoppingCartConsultViewView : View
    {
        public CuShoppingCartConsultViewView(CuShoppingCartConsultView screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            SaveButton = RPSControlFactory.RPSSaveButton<CuShoppingCartConsultViewView>( this);
 
            DeleteButton = RPSControlFactory.RPSDeleteButton<CuShoppingCartConsultViewView>( this);
 
            ConfirmDeleteButton = RPSControlFactory.RPSConfirmDeleteButton<CuShoppingCartConsultViewView>( this);
 
            BackButton = RPSControlFactory.RPSBackButton<CuShoppingCartConsultViewView,CuShoppingCartConsultViewQueryView>( this,Screen.CuShoppingCartConsultViewQueryView);
 
            IDShoppingCart = RPSControlFactory.CreateRPSComboBox<CuShoppingCartConsultViewView>("7ebf8fd2-53e2-41c7-93ee-bb3e5a941a28","","",true, this);
 
            IDCustomer = RPSControlFactory.CreateRPSComboBox<CuShoppingCartConsultViewView>("a191b2e3-110c-427b-9403-8967959d1e26","","",true, this);
 
            Total = RPSControlFactory.CreateRPSTextBox<CuShoppingCartConsultViewView>("757bd54d-5e5d-402b-aec2-a7c164df839d","","",true, this);
 
            DeliveryDate = RPSControlFactory.CreateRPSTextBox<CuShoppingCartConsultViewView>("a2cbb186-1897-4d34-9c25-d5d325747e4a","","",false, this);
 
            ShoppingDate = RPSControlFactory.CreateRPSTextBox<CuShoppingCartConsultViewView>("b098230f-1b29-48eb-8b33-0ef9cdae590d","","",false, this);
 
            CuShoppingCartConsultViewSection = RPSControlFactory.CreateRPSSection<CuShoppingCartConsultViewView>( "","ul li[rpsid='2c7f95cc-96e8-4f74-bee4-4d63a7af1e5c']","",this);
 

        }
        public IRPSButton<CuShoppingCartConsultViewView> SaveButton { get; set; } 
        public IRPSButton<CuShoppingCartConsultViewView> DeleteButton { get; set; } 
        public IRPSButton<CuShoppingCartConsultViewView> ConfirmDeleteButton { get; set; } 
        public IRPSButton<CuShoppingCartConsultViewView,CuShoppingCartConsultViewQueryView> BackButton { get; set; } 
        public IRPSComboBox<CuShoppingCartConsultViewView> IDShoppingCart { get; set; } 
        public IRPSComboBox<CuShoppingCartConsultViewView> IDCustomer { get; set; } 
        public IRPSTextBox<CuShoppingCartConsultViewView> Total { get; set; } 
        public IRPSTextBox<CuShoppingCartConsultViewView> DeliveryDate { get; set; } 
        public IRPSTextBox<CuShoppingCartConsultViewView> ShoppingDate { get; set; } 
        public IRPSSection<CuShoppingCartConsultViewView> CuShoppingCartConsultViewSection { get; set; } 
        public CuShoppingCartConsultView Screen { get; set; }
        public CuShoppingCartConsultViewView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  


}