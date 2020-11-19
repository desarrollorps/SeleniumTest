using RPSSeleniumProperties;
using RPSSeleniumProperties.Interactables;
using RPSSeleniumProperties.Interfaces;
using RPSSeleniumProperties.Interfaces.Interactables;
using RPSSeleniumProperties.viewmodels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RPStestSelenium
{
    public partial class StandardCategorias:Screen
    {
        public StandardCategorias():base()
        {
            this.URL = "general.category";
            InitViews();
           
           
        }       
        protected void InitViews()
        {
            Main = new ConsultView(this);
            New = new EditView(this);
            Main.InitializeButtons();
            New.InitializeButtons();
        }
      
        public ConsultView Main { get; set; }
        public EditView New { get; set; }
    }
    public partial class ConsultView:View
    {
        public ConsultView(StandardCategorias screen):base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
                
        }
        public void InitializeButtons()
        {
            Nuevo = RPSControlFactory.RPSNewButton<ConsultView, EditView>(                
                this,
               this.Screen.New);

        }
        public IRPSButton<ConsultView,EditView> Nuevo { get; set; }
        public StandardCategorias Screen { get; set; }
        public ConsultView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
    }
    public partial class EditView : View
    {
        public EditView(StandardCategorias screen) : base()
        {
            this.WebDriver = screen.WebDriver;
            this.Screen = screen;
           
        }

        public void InitializeButtons()
        {
            CodCategoria = RPSControlFactory.CreateRPSTextBox<EditView>("", "[id='0c5f8780-71d3-431f-af3b-4aa7482223af'] input","", true, this);
            Description = RPSControlFactory.CreateRPSTextBox<EditView>("", "[id='0f00a49f-6101-4d79-a5d5-a97b73292dde'] input","", true, this);
            Save = RPSControlFactory.RPSSaveButton<EditView>( this);
            Delete = RPSControlFactory.RPSDeleteButton<EditView>( this);
            Back = RPSControlFactory.RPSBackButton<EditView, ConsultView>(this, Screen.Main);

        }
        public EditView Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            return this;
        }
        public  StandardCategorias Screen { get; set; }
        public IRPSTextBox<EditView> CodCategoria { get; set; }
        public IRPSTextBox<EditView> Description { get; set; }
        public IRPSButton<EditView> Save { get; set; }
        public IRPSButton<EditView> Delete { get; set; }
        public IRPSButton<EditView, ConsultView> Back { get; set; }
    }
}
