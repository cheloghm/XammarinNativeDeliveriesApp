using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
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
            if (!string.IsNullOrEmpty(passwordEditText.Text))
            {
                if (passwordEditText.Text == confirmPasswordEditText.Text)
                {
                    var appuser = new AppUser()
                    {
                        Email = emailEditText.Text,
                        Password = passwordEditText.Text
                    };

                    await MainActivity.MobileService.GetTable<AppUser>().InsertAsync(appuser);
                    Toast.MakeText(this, "Success", ToastLength.Long).Show();
                    return;
                }

                Toast.MakeText(this, "Passwords don't match", ToastLength.Long).Show();
            }

            Toast.MakeText(this, "Password cannot be empty", ToastLength.Long).Show();
        }
    }
    
}