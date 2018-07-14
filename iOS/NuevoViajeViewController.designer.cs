// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace PlatziTrips.iOS
{
    [Register ("NuevoViajeViewController")]
    partial class NuevoViajeViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField ciudadTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem guardarButtonItem { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIDatePicker idaDatePicker { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIDatePicker regresoDatePicker { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ciudadTextField != null) {
                ciudadTextField.Dispose ();
                ciudadTextField = null;
            }

            if (guardarButtonItem != null) {
                guardarButtonItem.Dispose ();
                guardarButtonItem = null;
            }

            if (idaDatePicker != null) {
                idaDatePicker.Dispose ();
                idaDatePicker = null;
            }

            if (regresoDatePicker != null) {
                regresoDatePicker.Dispose ();
                regresoDatePicker = null;
            }
        }
    }
}