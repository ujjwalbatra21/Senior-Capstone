using System;
using System.Collections.Generic;
using VCU_ERAS_Application.Views;
using Xamarin.Forms;
using VCU_ERAS_Application.Models;
using Condition = VCU_ERAS_Application.Models.Condition;
using VCU_ERAS_Application.Data;
using Xamarin.Essentials;
using Location = VCU_ERAS_Application.Models.Location;

namespace VCU_ERAS_Application
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        Random rand = new Random();
        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes { get { return routes; } } //delete 3 lines if doesn't work

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;  //delete 2 lines if doesn't work
        } 

        void RegisterRoutes()
        {
            routes.Add("details", typeof(DetailsPage));
            routes.Add("surgeryinfo", typeof(SurgeryInfoPage));
            routes.Add("instructions", typeof(InstructionsPage));
            routes.Add("checklist", typeof(ChecklistPage));
            routes.Add("gettingstarted", typeof(GettingStartedPage));
            routes.Add("patientPortal", typeof(PatientPortalPage));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        } //Could delete if doesn't work 
    }
}
