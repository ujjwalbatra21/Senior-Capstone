using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VCU_ERAS_Application.Views;
using VCU_ERAS_Application.Services;
using VCU_ERAS_Application.Models;
using Condition = VCU_ERAS_Application.Models.Condition;
using Location = VCU_ERAS_Application.Models.Location;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VCU_ERAS_Application
{
    public partial class App : Application
    {
        public static DatabaseEntryManager DatabaseManager { get; private set; }
        public static List<DatabaseEntry> DatabaseContent;
        public static List<Surgery> Surgeries;
        public static List<Condition> Conditions;
        public static ObservableCollection<Condition> PatientConditions;
        public static List<Location> Locations;

        public static Surgery ChosenSurgery;
        public static String AltSurgeryInfo;
        public static String DoctorName;
        public static DateTime ChosenDate;
        public static TimeSpan ChosenTime;
        public static Location ChosenLocation;

        public App()
        {
            InitializeComponent();
            DatabaseManager = new DatabaseEntryManager(new RestService());
            DatabaseContent = new List<DatabaseEntry>();
            Surgeries = new List<Surgery>();
            Conditions = new List<Condition>();
            Locations = new List<Location>();
            PatientConditions = new ObservableCollection<Condition>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
