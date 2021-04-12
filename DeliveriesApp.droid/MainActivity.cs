using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Linq;

namespace DeliveriesApp.droid
{
    [Activity(Label = "Delivery App", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public static MobileServiceClient MobileService = new MobileServiceClient("https://xamarindeliveriesapp.azurewebsites.net");
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

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                Toast.MakeText(this, "Email and password cannot be empty", ToastLength.Long).Show();
            }
            else
            {
                var user = (await MobileService.GetTable<AppUser>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();

                if (user.Password == password)
                    Toast.MakeText(this, "Login successfull", ToastLength.Long).Show();
                else
                    Toast.MakeText(this, "Incorrect password", ToastLength.Long).Show();
            }
        }
    
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}