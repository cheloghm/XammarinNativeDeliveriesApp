//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;

namespace DeliveriesApp.ios
{
    [Register("RegisterViewController")]
    partial class RegisterViewController
    {
        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UIKit.UITextField confirmpasswordTextField { get; set; }

        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UIKit.UITextField emailTextField { get; set; }

        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UIKit.UITextField passwordTextField { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (confirmpasswordTextField != null)
            {
                confirmpasswordTextField.Dispose();
                confirmpasswordTextField = null;
            }

            if (emailTextField != null)
            {
                emailTextField.Dispose();
                emailTextField = null;
            }

            if (passwordTextField != null)
            {
                passwordTextField.Dispose();
                passwordTextField = null;
            }
        }
    }
}