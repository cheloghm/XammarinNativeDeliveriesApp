﻿using Android.App;
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
    public class AppUser
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}