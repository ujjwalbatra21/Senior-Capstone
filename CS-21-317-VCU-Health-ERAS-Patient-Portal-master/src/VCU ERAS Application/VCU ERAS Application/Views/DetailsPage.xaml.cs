using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Essentials;
using System.Windows.Input;

namespace VCU_ERAS_Application.Views
{
    public partial class DetailsPage : ContentPage
    {

        public DetailsPage()
        {
            InitializeComponent();
        }

        public DetailsPage(string surgeryName, string additionalDetails, string doctor, DateTime surgeryDate, TimeSpan surgeryTime, string checkIn)
        {
            InitializeComponent();
            SurgeryNameDetails.Text = surgeryName;
            AltSurgeryInfo.Text = additionalDetails; 
            DoctorNameDetails.Text = doctor;
            SurgeryDateDetails.Date = surgeryDate;
            SurgeryTime.Time = surgeryTime;
            SurgeryLocationDetails.Text = checkIn;
        }

        async void OnButtonClicked(System.Object sender, System.EventArgs e)
        {
            await DisplayAlert("Alert", "Please make sure you are confirming with your doctor if you are about to edit any details", "Confirm");
            SurgeryNameDetails.IsEnabled = false;
            AltSurgeryInfo.IsEnabled = false;
            DoctorNameDetails.IsEnabled = false;
            SurgeryLocationDetails.IsEnabled = false;

            SurgeryDateDetails.IsEnabled = true;
            SurgeryTime.IsEnabled = true;

            CancelButton.IsVisible = true;
            SaveButton.IsVisible = true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SurgeryTime.IsEnabled = false;
            SurgeryDateDetails.IsEnabled = false;

            if (App.ChosenSurgery == null) { 
                EditButton.IsEnabled = false;
                SurgeryNameDetails.Text = "";
            }
            else
            {
                EditButton.IsEnabled = true;
                SurgeryNameDetails.Text = App.ChosenSurgery.surgeryname;
            }
            DoctorNameDetails.Text = App.DoctorName;
            if (App.ChosenDate == default)
                SurgeryDateDetails.Date = DateTime.Today;
            else
                SurgeryDateDetails.Date = App.ChosenDate;
            SurgeryTime.Time = App.ChosenTime;
            if (App.ChosenLocation == null)
            {
                SurgeryLocationDetails.Text = "";
                LocationPhoneNumber.Text = "";
            }
            else
            {
                SurgeryLocationDetails.Text = App.ChosenLocation.locationname;
                LocationPhoneNumber.Text = App.ChosenLocation.phonenumber;
            }

            AltSurgeryInfo.Text = App.AltSurgeryInfo;
        }

        async void Save_Clicked(System.Object sender, System.EventArgs e)
        {
            App.ChosenDate = SurgeryDateDetails.Date;
            App.ChosenTime = SurgeryTime.Time;

            AltSurgeryInfo.IsEnabled = false;
            DoctorNameDetails.IsEnabled = false;
            SurgeryDateDetails.IsEnabled = false;
            SurgeryTime.IsEnabled = false;

            await DisplayAlert("Successful", "Surgery Saved! If you have made a mistake, please delete your surgery and enter the correct information", "Confirm");

            CancelButton.IsVisible = false;
            SaveButton.IsVisible = false;
        }

        async void Cancel_Clicked(System.Object sender, System.EventArgs e)
        {
            var result = await DisplayAlert("Warning!", "This will cancel all surgery changes", "Confirm", "Cancel");
            if (result)
            {
                SurgeryDateDetails.Date = App.ChosenDate;
                SurgeryTime.Time = App.ChosenTime;

                SurgeryDateDetails.IsEnabled = false;
                SurgeryTime.IsEnabled = false;

                CancelButton.IsVisible = false;
                SaveButton.IsVisible = false;
            }
        }
    }
}