using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace VCU_ERAS_Application.Views
{
    public partial class PatientPortalPage : ContentPage
    {

        string url;

        public PatientPortalPage()
        {
            InitializeComponent();
        }

        void OnButtonClicked(System.Object sender, System.EventArgs e)
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    url = String.Format("https://apps.apple.com/us/app/healthelife/id912509516");
                    break;

                case Device.Android:
                    url = String.Format("https://play.google.com/store/apps/details?id=com.cerner.iris.play&hl=en&gl=US");
                    break;
            }
            Xamarin.Essentials.Launcher.OpenAsync(url);
        }
    }
}
