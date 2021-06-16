using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Essentials;
using VCU_ERAS_Application.Models;
using VCU_ERAS_Application.Data;
using Condition = VCU_ERAS_Application.Models.Condition;
using Location = VCU_ERAS_Application.Models.Location;
using Plugin.InputKit;
using System.Threading.Tasks;

namespace VCU_ERAS_Application.Views
{
    public partial class GettingStartedPage : ContentPage
    {
        public List<DatabaseEntry> DatabaseContent;
        public GettingStartedPage()
        {
            DatabaseContent = new List<DatabaseEntry>();
            InitializeComponent();
            SetDatabaseContent();
            SetDefaults();
            BindingContext = this;
           
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (App.ChosenDate == default)
                SurgeryDate.Date = DateTime.Today;
            else
                SurgeryDate.Date = App.ChosenDate;
            SurgeryTime.Time = App.ChosenTime;
        }

        public void SetDatabaseContent()
        {
            GetDatabaseContent();
            SetSurgeryData();
            SetLocationData();
            SetConditions();
        }

        public void GetDatabaseContent()
        {
            App.DatabaseContent = Task.Run(async () => await App.DatabaseManager.GetTasksAsync()).Result;
            //App.DatabaseContent = DatabaseEntryData.Databasecontent;
        }
        public void SetConditions()
        {
            App.Conditions.Clear();
            ConditionData cd = new ConditionData(App.DatabaseContent);
            foreach(Condition condition in cd._Conditions)
            {
                if(!App.Conditions.Contains(condition))
                    App.Conditions.Add(condition);
            }
            List<Condition> c = App.Conditions;
            conditionsListView.ItemsSource = App.Conditions;
        }

        public List<String> GetConditionNames(List<Condition> conditions)
        {
            List<String> names = new List<String>();
            foreach (Condition condition in conditions)
            {
                names.Add(condition.conditionname);
            }
            return names;
        }

        public void CheckBox_CheckChanged(object sender, EventArgs e)
        {
            Condition c = App.Conditions.Find(x => x.conditionname == (sender as Plugin.InputKit.Shared.Controls.CheckBox).Text);
            if ((sender as Plugin.InputKit.Shared.Controls.CheckBox).IsChecked)
            {
                App.PatientConditions.Add(c);
            }
            else
            {
                App.PatientConditions.Remove(c);
            }
        }

        public void PickerChanged(object sender, EventArgs e)
        {
            try
            {
                if ((sender as Picker).SelectedItem.ToString() == "Other")
                {
                    AltSurgeryName.IsVisible = true;
                    AltSurgeryName.IsEnabled = true;
                }
                else
                {
                    AltSurgeryName.Text = "";
                    AltSurgeryName.IsVisible = false;
                }
            }
            catch (NullReferenceException)
            {
                //this is for when deleting the surgery
            }
        }

        public void SetDefaults()
        {
            if (App.ChosenSurgery != null)//surgery has already been chosen
            {
                surgery.IsEnabled = false;
                location.IsEnabled = false;
                AltSurgeryName.IsEnabled = false;
                AltSurgeryInfo.IsEnabled = false;
                DoctorName.IsEnabled = false;
                SurgeryDate.IsEnabled = false;
                SurgeryTime.IsEnabled = false;
                conditionsListView.IsEnabled = false;

                if (App.Surgeries.Exists(x => x.surgeryname == App.ChosenSurgery.surgeryname))
                {
                    surgery.SelectedItem = App.ChosenSurgery.surgeryname;
                }
                else
                {
                    surgery.SelectedItem = "Other";
                    AltSurgeryName.IsVisible = true;
                    AltSurgeryName.IsEnabled = false;
                    AltSurgeryName.Text = App.ChosenSurgery.surgeryname;
                }
                AltSurgeryInfo.Text = App.AltSurgeryInfo;
                location.SelectedItem = App.ChosenLocation;
                DoctorName.Text = App.DoctorName;
                SurgeryDate.Date = App.ChosenDate;
                SurgeryTime.Time = App.ChosenTime;
            }
            else {//no surgery chosen
                surgery.SelectedItem = null;
                location.SelectedItem = null;
                DoctorName.Text = "";
                AltSurgeryName.IsVisible = false;
                AltSurgeryInfo.Text = "";
                SurgeryDate.Date = DateTime.Today;
                SurgeryTime.Time = ToTimeSpan("12:00");
            }
        }

        public TimeSpan ToTimeSpan(String timestr)
        {
            TimeSpan time = TimeSpan.Parse(timestr);
            return time;
        }

        async void Save_Clicked(System.Object sender, System.EventArgs e)
        {
            if(surgery.IsEnabled == false)
            {
                //do nothing if the surgery is already set
            }
            else if (surgery.SelectedItem == null)
            {
                await DisplayAlert("Warning!", "Please choose a surgery.", "Confirm");
            }
            else if (surgery.SelectedItem.ToString() == "Other" && AltSurgeryName.Text == "")
            {
                await DisplayAlert("Warning!", "Please enter a surgery name.", "Confirm");
            }
            else if (location.SelectedItem == null)
            {
                await DisplayAlert("Warning!", "Please choose a location.", "Confirm");
            }
            else
            {
                String surgeryName = "";

                if (surgery.SelectedItem.ToString() == "Other")
                {
                    surgeryName = AltSurgeryName.Text;
                    Surgery newSurgery = new Surgery
                    {
                        surgeryname = surgeryName
                    };
                    App.ChosenSurgery = newSurgery;
                }
                else
                {
                    surgeryName = surgery.SelectedItem.ToString();
                    App.ChosenSurgery = App.Surgeries.Find(x => x.surgeryname == surgeryName);
                }

                ;
                App.ChosenLocation = App.Locations.Find(x => x.locationname == location.SelectedItem.ToString());
                App.AltSurgeryInfo = AltSurgeryInfo.Text;
                App.DoctorName = DoctorName.Text;
                App.ChosenDate = SurgeryDate.Date;
                App.ChosenTime = SurgeryTime.Time;

                surgery.IsEnabled = false;
                location.IsEnabled = false;
                AltSurgeryName.IsEnabled = false;
                AltSurgeryInfo.IsEnabled = false;
                DoctorName.IsEnabled = false;
                SurgeryDate.IsEnabled = false;
                SurgeryTime.IsEnabled = false;
                conditionsListView.IsEnabled = false;

                await DisplayAlert("Successful", "Surgery Saved! If you have made a mistake, please delete your surgery and enter the correct information", "Confirm");
            }
        }

        async void Clear_Clicked(System.Object sender, System.EventArgs e)
        {
            if(App.ChosenSurgery != null) {
                var result = await DisplayAlert("Warning!", "This will clear all surgery details", "Confirm", "Cancel");
                if (result)
                {
                    App.ChosenSurgery = null;
                    App.ChosenLocation = null;
                    App.AltSurgeryInfo = null;
                    App.DoctorName = null;
                    App.ChosenDate = default;
                    App.ChosenTime = default;

                    surgery.SelectedItem = null;
                    location.SelectedItem = null;
                    AltSurgeryName.Text = "";
                    AltSurgeryInfo.Text = "";
                    DoctorName.Text = "";
                    SurgeryDate.Date = DateTime.Today;
                    SurgeryTime.Time = default;

                    surgery.IsEnabled = true;
                    location.IsEnabled = true;
                    AltSurgeryName.IsEnabled = true;
                    AltSurgeryInfo.IsEnabled = true;
                    DoctorName.IsEnabled = true;
                    SurgeryDate.IsEnabled = true;
                    SurgeryTime.IsEnabled = true;
                    conditionsListView.IsEnabled = true;

                    SetDatabaseContent();

                    await DisplayAlert("Successful", "Surgery Cleared", "Confirm");
                }
            }
        }

        public void SetSurgeryData()
        {
            SurgeryData sd = new SurgeryData(App.DatabaseContent);
            App.Surgeries = sd.Surgeries;
            List<String> surgeryNames = GetSurgeryNames(App.Surgeries);
            surgeryNames.Add("Other");
            surgery.ItemsSource = surgeryNames;
        }

        public List<String> GetSurgeryNames(List<Surgery> surgeries)
        {
            List<String> names = new List<String>();
            foreach(Surgery surgery in surgeries)
            {
                names.Add(surgery.surgeryname);
            }
            return names;
        }

        public void SetLocationData()
        {
            LocationData ld = new LocationData(App.DatabaseContent);
            App.Locations = ld._Locations;
            List<String> locationNames = GetLocationNames(App.Locations);
            location.ItemsSource = locationNames;
        }

        public List<String> GetLocationNames(List<Location> locations)
        {
            List<String> names = new List<String>();
            foreach (Location location in locations)
            {
                names.Add(location.locationname);
            }
            return names;
        }
    }
}