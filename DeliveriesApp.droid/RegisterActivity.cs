using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DeliveriesApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliveriesApp.droid
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        EditText emailEditText, passwordEditText, confirmPasswordEditText;
        Button registerButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Register);

            emailEditText = FindViewById<EditText>(Resource.Id.registerEmailEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.registerPasswordEditText);
            confirmPasswordEditText = FindViewById<EditText>(Resource.Id.confirmPasswordEditText);
            registerButton = FindViewById<Button>(Resource.Id.registerUserButton);

            registerButton.Click += RegisterButton_ClickAsync;

            string email = Intent.GetStringExtra("email");
            emailEditText.Text = email;
        }

        private async void RegisterButton_ClickAsync(object sender, EventArgs e)
        {
            var result = await AppUser.Register(emailEditText.Text, passwordEditText.Text, confirmPasswordEditText.Text);

            if (result)
                Toast.MakeText(this, "Success", ToastLength.Long).Show();
            else
                Toast.MakeText(this, "Try again", ToastLength.Long).Show();
        }
    }
    
}