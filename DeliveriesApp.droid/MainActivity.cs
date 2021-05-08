using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using DeliveriesApp.Model;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Linq;

namespace DeliveriesApp.droid
{
    [Activity(Label = "Delivery App", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        
        EditText emailEditText, passwordEditText;
        Button signinButton, registerButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            signinButton = FindViewById<Button>(Resource.Id.signinButton);
            registerButton = FindViewById<Button>(Resource.Id.registerButton);

            signinButton.Click += SigninButton_Click;
            registerButton.Click += RegisterButton_Click;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(RegisterActivity));
            intent.PutExtra("email", emailEditText.Text);
            StartActivity(intent);
        }

        private async void SigninButton_Click(object sender, EventArgs e)
        {
            var email = emailEditText.Text;
            var password = passwordEditText.Text;

            var result = await AppUser.Login(email, password);

            if (result)
            {
                Toast.MakeText(this, "Welcome", ToastLength.Long).Show();
                Intent intent = new Intent(this, typeof(TabsActivity));
                StartActivity(intent);
                Finish();
            }
            else
                Toast.MakeText(this, "Try again later", ToastLength.Long).Show();
        }
    
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}