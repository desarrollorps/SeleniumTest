    
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
    public partial class CuSegment:Screen
    {
        public CuSegment():base()
        {
            this.URL = "general.cusegment";
            InitViews();
           
           
        }       
        protected void InitViews()
        {
            CuSegmentCollectionView  = new CuSegmentCollectionView(this); 
            CuSegmentView  = new CuSegmentView(this); 
            CuSubSegmentView  = new CuSubSegmentView(this); 
            CuSegmentCollectionView.InitializeControls(); 
            CuSegmentView.InitializeControls(); 
            CuSubSegmentView.InitializeControls(); 
           
        }
      
            public CuSegmentCollectionView CuSegmentCollectionView {get; set; } 
            public CuSegmentView CuSegmentView {get; set; } 
            public CuSubSegmentView CuSubSegmentView {get; set; } 
    }
            
    public partial class CuSegmentCollectionView : View
    {
        public CuSegmentCollectionView(CuSegment screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            NewButton = RPSControlFactory.RPSNewButton<CuSegmentCollectionView,CuSegmentView>( this,Screen.CuSegmentView);
 

        }
        public IRPSButton<CuSegmentCollectionView,CuSegmentView> NewButton { get; set; } 
        public CuSegment Screen { get; set; }
        public CuSegmentCollectionView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  
            
    public partial class CuSegmentView : View
    {
        public CuSegmentView(CuSegment screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            SaveButton = RPSControlFactory.RPSSaveButton<CuSegmentView>( this);
 
            DeleteButton = RPSControlFactory.RPSDeleteButton<CuSegmentView>( this);
 
            ConfirmDeleteButton = RPSControlFactory.RPSConfirmDeleteButton<CuSegmentView>( this);
 
            BackButton = RPSControlFactory.RPSBackButton<CuSegmentView,CuSegmentCollectionView>( this,Screen.CuSegmentCollectionView);
 
            CodCuSegment = RPSControlFactory.CreateRPSTextBox<CuSegmentView>("102a22d0-3cba-4e09-ac08-11f7c0b86758","","",true, this);
 
            Description = RPSControlFactory.CreateRPSTextBox<CuSegmentView>("0462dc97-1912-489f-a520-db719018c074","","",false, this);
 
            Observ = RPSControlFactory.CreateRPSTextBox<CuSegmentView>("3e514faf-d09e-4371-8171-24db2387cf61","","",false, this);
 
            CollectionInit params_CuSubSegments = new CollectionInit(){IDDescriptor = "",CSSSelectorDescriptor = "",XPathDescriptor = ""};
            CuSubSegments = RPSControlFactory.RPSCreateCollection<CuSegmentView,CuSubSegmentView>( params_CuSubSegments,this,Screen.CuSubSegmentView);
 
            CuSegmentSection = RPSControlFactory.CreateRPSSection<CuSegmentView>( "","ul li[rpsid='a8da9c8b-e484-4014-af01-691acd70648c']","",this);
 
            Section = RPSControlFactory.CreateRPSSection<CuSegmentView>( "","ul li[rpsid='7ddeb664-315c-4e89-9137-1792bf78b2e5']","",this);
 
            CuSubSegmentSection = RPSControlFactory.CreateRPSSection<CuSegmentView>( "","ul li[rpsid='9b2db17f-6540-43c8-8d11-4c495a3c2597']","",this);
 

        }
        public IRPSButton<CuSegmentView> SaveButton { get; set; } 
        public IRPSButton<CuSegmentView> DeleteButton { get; set; } 
        public IRPSButton<CuSegmentView> ConfirmDeleteButton { get; set; } 
        public IRPSButton<CuSegmentView,CuSegmentCollectionView> BackButton { get; set; } 
        public IRPSTextBox<CuSegmentView> CodCuSegment { get; set; } 
        public IRPSTextBox<CuSegmentView> Description { get; set; } 
        public IRPSTextBox<CuSegmentView> Observ { get; set; } 
        public IRPSCollectionEditor<CuSegmentView,CuSubSegmentView> CuSubSegments { get; set; } 
        public IRPSSection<CuSegmentView> CuSegmentSection { get; set; } 
        public IRPSSection<CuSegmentView> Section { get; set; } 
        public IRPSSection<CuSegmentView> CuSubSegmentSection { get; set; } 
        public CuSegment Screen { get; set; }
        public CuSegmentView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  
            
    public partial class CuSubSegmentView : View
    {
        public CuSubSegmentView(CuSegment screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

         public void InitializeControls()
        {
            SaveButton = RPSControlFactory.RPSSaveButton<CuSubSegmentView>( this);
 
            DeleteButton = RPSControlFactory.RPSDeleteButton<CuSubSegmentView>( this);
 
            ConfirmDeleteButton = RPSControlFactory.RPSConfirmDeleteButton<CuSubSegmentView>( this);
 
            BackButton = RPSControlFactory.RPSBackButton<CuSubSegmentView,CuSegmentView>( this,Screen.CuSegmentView);
 
            CodCuSubSegment = RPSControlFactory.CreateRPSTextBox<CuSubSegmentView>("d03c0de9-3a07-4ae2-a27a-a31335be3ed9","","",true, this);
 
            Description = RPSControlFactory.CreateRPSTextBox<CuSubSegmentView>("4aa91ccd-a656-4440-ba34-825a21d686d3","","",false, this);
 
            Observ = RPSControlFactory.CreateRPSTextBox<CuSubSegmentView>("56d2b4b4-a93c-4362-8424-ecfaae5d9534","","",false, this);
 
            CuSubSegmentSection = RPSControlFactory.CreateRPSSection<CuSubSegmentView>( "","ul li[rpsid='3160437d-6320-4f4a-a8e2-6169489eab0f']","",this);
 
            Section = RPSControlFactory.CreateRPSSection<CuSubSegmentView>( "","ul li[rpsid='0545c816-6933-44bf-8886-8f7ad89e39a9']","",this);
 

        }
        public IRPSButton<CuSubSegmentView> SaveButton { get; set; } 
        public IRPSButton<CuSubSegmentView> DeleteButton { get; set; } 
        public IRPSButton<CuSubSegmentView> ConfirmDeleteButton { get; set; } 
        public IRPSButton<CuSubSegmentView,CuSegmentView> BackButton { get; set; } 
        public IRPSTextBox<CuSubSegmentView> CodCuSubSegment { get; set; } 
        public IRPSTextBox<CuSubSegmentView> Description { get; set; } 
        public IRPSTextBox<CuSubSegmentView> Observ { get; set; } 
        public IRPSSection<CuSubSegmentView> CuSubSegmentSection { get; set; } 
        public IRPSSection<CuSubSegmentView> Section { get; set; } 
        public CuSegment Screen { get; set; }
        public CuSubSegmentView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
      
    }
  


}