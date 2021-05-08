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
    [Activity(Label = "NewDeliveryActivity")]
    public class NewDeliveryActivity : Activity
    {
        Button saveButton;
        EditText packageNameEditText;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NewDelivery);

            saveButton = FindViewById<Button>(Resource.Id.saveButton);
            packageNameEditText = FindViewById<EditText>(Resource.Id.packageNameEditText);

            saveButton.Click += SaveButton_Click;
        }
        private async void SaveButton_Click(object sender, EventArgs e)
        {
            Delivery delivery = new Delivery()
            {
                Name = packageNameEditText.Text,
                Status = 0
            };

            await Delivery.InsertDelivery(delivery);
        }
    }
}