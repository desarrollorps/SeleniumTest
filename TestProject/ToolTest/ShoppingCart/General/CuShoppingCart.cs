    
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
    public partial class CuShoppingCart:Screen
    {
        public CuShoppingCart():base()
        {
            this.URL = "general.cushoppingcart";
            InitViews();
           
           
        }       
        protected void InitViews()
        {
            CuShoppingCartQueryView  = new CuShoppingCartQueryView(this); 
            CuShoppingCartView  = new CuShoppingCartView(this); 
            CuShoppingCartLineView  = new CuShoppingCartLineView(this); 
            CuShoppingCartQueryView.InitializeControls(); 
            CuShoppingCartView.InitializeControls(); 
            CuShoppingCartLineView.InitializeControls(); 
           
        }
      
            public CuShoppingCartQueryView CuShoppingCartQueryView {get; set; } 
            public CuShoppingCartView CuShoppingCartView {get; set; } 
            public CuShoppingCartLineView CuShoppingCartLineView {get; set; } 
    }
            
    public partial class CuShoppingCartQueryView : View
    {
        public CuShoppingCartQueryView(CuShoppingCart screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            NewButton = RPSControlFactory.RPSNewButton<CuShoppingCartQueryView,CuShoppingCartView>( this,Screen.CuShoppingCartView);
 
            ConsultButton = RPSControlFactory.RPSConsultButton<CuShoppingCartQueryView>( this);
 
            CuShoppingCart_CodShoppingCart_filter = RPSControlFactory.CreateRPSTextBox<CuShoppingCartQueryView>("86648ed4-8925-4e23-b615-6b4bc2c32591","","",false, this);
 
            CuShoppingCart_ShoppingDate_filter = RPSControlFactory.CreateRPSTextBox<CuShoppingCartQueryView>("bc171bae-a445-4538-bde4-2a7b1618845a","","",false, this);
 
            CuShoppingCart_DeliveryDate_filter = RPSControlFactory.CreateRPSTextBox<CuShoppingCartQueryView>("0100c2a3-c99d-49a1-90dd-d82fec078468","","",false, this);
 
            CollectionInit params_CuShoppingCartConsult = new CollectionInit(){IDDescriptor = "4f1523ba-70e3-456f-a2c9-079b6fbde4c6",CSSSelectorDescriptor = "",XPathDescriptor = ""};
            CuShoppingCartConsult = RPSControlFactory.RPSCreateCollection<CuShoppingCartQueryView,CuShoppingCartView>( params_CuShoppingCartConsult,this,Screen.CuShoppingCartView);
 

        }
        public IRPSButton<CuShoppingCartQueryView,CuShoppingCartView> NewButton { get; set; } 
        public IRPSButton<CuShoppingCartQueryView> ConsultButton { get; set; } 
        public IRPSTextBox<CuShoppingCartQueryView> CuShoppingCart_CodShoppingCart_filter { get; set; } 
        public IRPSTextBox<CuShoppingCartQueryView> CuShoppingCart_ShoppingDate_filter { get; set; } 
        public IRPSTextBox<CuShoppingCartQueryView> CuShoppingCart_DeliveryDate_filter { get; set; } 
        public IRPSCollectionEditor<CuShoppingCartQueryView,CuShoppingCartView> CuShoppingCartConsult { get; set; } 
        public CuShoppingCart Screen { get; set; }
        public CuShoppingCartQueryView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  
            
    public partial class CuShoppingCartView : View
    {
        public CuShoppingCartView(CuShoppingCart screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            SaveButton = RPSControlFactory.RPSSaveButton<CuShoppingCartView>( this);
 
            DeleteButton = RPSControlFactory.RPSDeleteButton<CuShoppingCartView>( this);
 
            BackButton = RPSControlFactory.RPSBackButton<CuShoppingCartView,CuShoppingCartQueryView>( this,Screen.CuShoppingCartQueryView);
 
            CodShoppingCart = RPSControlFactory.CreateRPSTextBox<CuShoppingCartView>("be1aacef-1bd7-4322-b6c8-41f23f743428","","",true, this);
 
            Description = RPSControlFactory.CreateRPSTextBox<CuShoppingCartView>("3368bad2-9c38-4796-b64c-102a4e0f822f","","",true, this);
 
            IDCustomer = RPSControlFactory.CreateRPSComboBox<CuShoppingCartView>("8f0a205f-3859-4725-a996-24d55e52c06f","","",true, this);
 
            Address = RPSControlFactory.CreateRPSTextBox<CuShoppingCartView>("3356361e-3941-41fc-a2af-93d4bb1d5757","","",true, this);
 
            ShoppingDate = RPSControlFactory.CreateRPSTextBox<CuShoppingCartView>("1e2ca850-2899-4251-8d71-ee83d2827d56","","",true, this);
 
            TransportPrice = RPSControlFactory.CreateRPSTextBox<CuShoppingCartView>("87a63c7c-3ac0-4182-a8df-98b97994198d","","",true, this);
 
            DeliveryDate = RPSControlFactory.CreateRPSTextBox<CuShoppingCartView>("b5093e0a-a767-4d1f-b33a-4598f3b1a56a","","",false, this);
 
            Observations = RPSControlFactory.CreateRPSTextBox<CuShoppingCartView>("a20e225b-7bb3-4413-afba-2a7d03838b84","","",false, this);
 
            CollectionInit params_CuShoppingCartLines = new CollectionInit(){IDDescriptor = "",CSSSelectorDescriptor = "",XPathDescriptor = ""};
            CuShoppingCartLines = RPSControlFactory.RPSCreateCollection<CuShoppingCartView,CuShoppingCartLineView>( params_CuShoppingCartLines,this,Screen.CuShoppingCartLineView);
 
            CuShoppingCartSection = RPSControlFactory.CreateRPSSection<CuShoppingCartView>( "","ul li[rpsid='5d8a6602-0c0e-4f09-8829-557e9a6229da']","",this);
 
            ObservationsSection = RPSControlFactory.CreateRPSSection<CuShoppingCartView>( "","ul li[rpsid='7a25ee28-f31b-410c-90f3-ab1fa7fc6a77']","",this);
 
            CuShoppingCartLineSection = RPSControlFactory.CreateRPSSection<CuShoppingCartView>( "","ul li[rpsid='514fad1b-a380-43c0-8b9a-8ebceaf9b302']","",this);
 

        }
        public IRPSButton<CuShoppingCartView> SaveButton { get; set; } 
        public IRPSButton<CuShoppingCartView> DeleteButton { get; set; } 
        public IRPSButton<CuShoppingCartView,CuShoppingCartQueryView> BackButton { get; set; } 
        public IRPSTextBox<CuShoppingCartView> CodShoppingCart { get; set; } 
        public IRPSTextBox<CuShoppingCartView> Description { get; set; } 
        public IRPSComboBox<CuShoppingCartView> IDCustomer { get; set; } 
        public IRPSTextBox<CuShoppingCartView> Address { get; set; } 
        public IRPSTextBox<CuShoppingCartView> ShoppingDate { get; set; } 
        public IRPSTextBox<CuShoppingCartView> TransportPrice { get; set; } 
        public IRPSTextBox<CuShoppingCartView> DeliveryDate { get; set; } 
        public IRPSTextBox<CuShoppingCartView> Observations { get; set; } 
        public IRPSCollectionEditor<CuShoppingCartView,CuShoppingCartLineView> CuShoppingCartLines { get; set; } 
        public IRPSSection<CuShoppingCartView> CuShoppingCartSection { get; set; } 
        public IRPSSection<CuShoppingCartView> ObservationsSection { get; set; } 
        public IRPSSection<CuShoppingCartView> CuShoppingCartLineSection { get; set; } 
        public CuShoppingCart Screen { get; set; }
        public CuShoppingCartView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  
            
    public partial class CuShoppingCartLineView : View
    {
        public CuShoppingCartLineView(CuShoppingCart screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            SaveButton = RPSControlFactory.RPSSaveButton<CuShoppingCartLineView>( this);
 
            DeleteButton = RPSControlFactory.RPSDeleteButton<CuShoppingCartLineView>( this);
 
            BackButton = RPSControlFactory.RPSBackButton<CuShoppingCartLineView,CuShoppingCartView>( this,Screen.CuShoppingCartView);
 
            IDArticle = RPSControlFactory.CreateRPSComboBox<CuShoppingCartLineView>("924f9236-bff2-412a-a7a3-ce9eeba3a6ec","","",true, this);
 
            Price = RPSControlFactory.CreateRPSTextBox<CuShoppingCartLineView>("7d97affc-257d-4a56-8575-12d81b80a153","","",true, this);
 
            Quantity = RPSControlFactory.CreateRPSTextBox<CuShoppingCartLineView>("9ea1a975-1e74-42ab-be30-cf0b9ba8a889","","",true, this);
 
            Observations = RPSControlFactory.CreateRPSTextBox<CuShoppingCartLineView>("6e7e97fc-6e96-4b8e-b752-c3ee83b0703e","","",false, this);
 
            CuShoppingCartLineSection = RPSControlFactory.CreateRPSSection<CuShoppingCartLineView>( "","ul li[rpsid='5bbc5240-a0c3-4716-8680-eefb6efadcdb']","",this);
 
            ObservationsSection = RPSControlFactory.CreateRPSSection<CuShoppingCartLineView>( "","ul li[rpsid='07a27152-454e-466a-b193-d57fc276d94c']","",this);
 

        }
        public IRPSButton<CuShoppingCartLineView> SaveButton { get; set; } 
        public IRPSButton<CuShoppingCartLineView> DeleteButton { get; set; } 
        public IRPSButton<CuShoppingCartLineView,CuShoppingCartView> BackButton { get; set; } 
        public IRPSComboBox<CuShoppingCartLineView> IDArticle { get; set; } 
        public IRPSTextBox<CuShoppingCartLineView> Price { get; set; } 
        public IRPSTextBox<CuShoppingCartLineView> Quantity { get; set; } 
        public IRPSTextBox<CuShoppingCartLineView> Observations { get; set; } 
        public IRPSSection<CuShoppingCartLineView> CuShoppingCartLineSection { get; set; } 
        public IRPSSection<CuShoppingCartLineView> ObservationsSection { get; set; } 
        public CuShoppingCart Screen { get; set; }
        public CuShoppingCartLineView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  


}