
using DeliveriesApp.Model;
using Foundation;
using System;
using System.Drawing;
using UIKit;

namespace DeliveriesApp.ios
{
    public partial class RegisterViewController : UIViewController
    {
        public RegisterViewController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.

            // //Un comment code below when i buy mac
            //registerButton.TouchUpInside += RegisterButton_TouchUpInside;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion


        private async void RegisterButton_TouchUpInside(object sender, EventArgs e)
        {
            var result = await AppUser.Register(emailTextField.Text, passwordTextField.Text, confirmpasswordTextField.Text);
            UIAlertController alert = null;

            if (result)
            {
                alert = UIAlertController.Create("Success", "User inserted", UIAlertControllerStyle.Alert);
            }
            else
            {
                alert = UIAlertController.Create("Failure", "Try again", UIAlertControllerStyle.Alert);
            }

            alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

            PresentViewController(alert, true, null);
        }
    }
}