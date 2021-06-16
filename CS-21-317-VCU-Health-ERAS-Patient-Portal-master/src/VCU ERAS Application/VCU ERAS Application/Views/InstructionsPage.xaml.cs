using System;
using System.Collections.Generic;

using Xamarin.Forms;
using VCU_ERAS_Application.Models;
using Condition = VCU_ERAS_Application.Models.Condition;

namespace VCU_ERAS_Application.Views
{
    public partial class InstructionsPage : TabbedPage
    {
        public InstructionsPage()
        {
            InitializeComponent();
            GetText();
        }

        protected override void OnAppearing()
        {
            GetText();
        }

        public void GetText()
        {
            DietText();
            PostText();
            DayOfText();
        }

        public void DietText()
        {
            if (App.PatientConditions.Count == 0)
            {
                DietLabel.Text = "•No solid foods after midnight\n•You may have clear liquids until two hours prior to your arrival time, which include:\n   •Water\n   •Clear juice\n   •Black coffee and tea(NO milk or cream)\n   •Non-particulate sports drinks\n   •Other clear drinks you can read print through\n•All tube feedings mut stop 6 hours prior to your surgery";
            }
            else
            {
                string s = "";
                foreach (Condition condition in App.PatientConditions)
                {
                    s += "\n";
                    s += condition.dietinstructions;
                }
                DietLabel.Text = s;
            }
        }

        public void PostText()
        {
            if (App.PatientConditions.Count == 0)
            {
                PostLabel.Text = "•Plan to stay the night in the hospital after your surgery\n•Do NOT smoke or drink alcohol\n•Monitor your bowel movements\n•Drink plently of fluids\n•Make sure to schedule your follow-up appointment before you leave and call your doctor's office if you need to reschedule";
            }
            else
            {
                string s = "";
                foreach (Condition condition in App.PatientConditions)
                {
                    s += "\n";
                    s += condition.postinstructions;
                }
                PostLabel.Text = s;
            }
        }

        public void DayOfText()
        {
            if(App.ChosenLocation == null)
            {
                DayOfLabel.Text = "•Please arrive 2 hours before the start of your surgery\n•If applicable, please choose one person to be your spokesperson\n•Make sure you have viewed the all of the tabs on the Instructions page\n•Check your blood sugar when you wake up\n•You will have a team of health care providers that will be with you during your surgery. They work together to make sure your care is safe at all times";
            }
            else
            {
                DayOfLabel.Text = App.ChosenLocation.dayofinformation;
                DayOfLabel.Text += "\n";
                DayOfLabel.Text += "•Please arrive 2 hours before the start of your surgery\n•If applicable, please choose one person to be your spokesperson\n•Make sure you have viewed the all of the tabs on the Instructions page\n•Check your blood sugar when you wake up\n•You will have a team of health care providers that will be with you during your surgery. They work together to make sure your care is safe at all times";
            }
        }
    }
}
