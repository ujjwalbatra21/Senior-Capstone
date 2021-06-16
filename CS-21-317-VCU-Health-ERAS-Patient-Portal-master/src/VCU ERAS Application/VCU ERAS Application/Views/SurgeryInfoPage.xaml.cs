using System;
using System.Collections.Generic;

using Xamarin.Forms;
using VCU_ERAS_Application.Models;
using System.ComponentModel;

namespace VCU_ERAS_Application.Views
{
    public partial class SurgeryInfoPage : ContentPage
    {
        public SurgeryInfoPage()
        {
            InitializeComponent();
            BindingContext = this;
            GetText();
        }

        protected override void OnAppearing()
        {
            GetText();
        }

        public void GetText()
        {
            if (App.ChosenSurgery != null && App.ChosenSurgery.surgeryInfo != null)
            {
                SurgeryInfoLabel.Text = App.ChosenSurgery.surgeryInfo;
            }
            else
            {
                SurgeryInfoLabel.Text = "*Default Surgery Information*";//default text
            }
        }
    }
}
