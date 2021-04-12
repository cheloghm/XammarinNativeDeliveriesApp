using Foundation;
using System;
using UIKit;

namespace DeliveriesApp.ios
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.
            //helloButton.TouchUpInside += HelloButton_TouchUpInside;
        }

        private async void SigninButton_TouchUpInside(object sender, EventArgs e)
        {
            var email = emailTextField.Text;
            var password = passwordTextField.Text;
            UIAlertController alert = null;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                alert = UIAlertController.Create("Incomplete", "Email and password cannot be empty", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
            }
            else
            {
                var user = (await AppDelegate.MobileService.GetTable<AppUser>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();

                if (user.Password == password)
                {
                    alert = UIAlertController.Create("Succeed", "Welcome", UIAlertControllerStyle.Alert);
                    alert.AddAction(UIAlertAction.Create("Thanks", UIAlertActionStyle.Default, null));
                }
                else
                {
                    alert = UIAlertController.Create("Failure", "Password is incorrect", UIAlertControllerStyle.Alert);
                    alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                }
            }

            PresentViewController(alert, true, null);
        }


        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}