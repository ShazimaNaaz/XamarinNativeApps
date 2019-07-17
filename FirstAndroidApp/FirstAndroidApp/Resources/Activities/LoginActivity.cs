
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FirstAndroidApp.Interfaces;
using Refit;

namespace FirstAndroidApp.Resources.Activities
{
    [Activity(Label = "LoginActivity" , MainLauncher = true) ]
    public class LoginActivity : Activity
    {
        EditText userNameText;
        Button recyclerViewbtn;
        Button listViewBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Login);
            userNameText = FindViewById<EditText>(Resource.Id.userIdTxt);
            listViewBtn = FindViewById<Button>(Resource.Id.ListViewBtn);
            listViewBtn.Click += LoginButton_Click;
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            if(userNameText.Text.Length !=0)
            {
                try
                {
                    Toast.MakeText(this, "Login successfully done!", ToastLength.Long).Show();
                    StartActivity(typeof(HomeView));
                }
                catch(Exception ex)
                {

                }

            }
            else
            { 
                Toast.MakeText(this, "Wrong credentials found!", ToastLength.Long).Show();
            }
        }

    }
}
