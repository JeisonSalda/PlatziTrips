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
    [Register ("NuevoLugarViewController")]
    partial class NuevoLugarViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView categoriasPickerView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField filtrotextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem guardarLugarBarButtonItem { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView lugaresTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (categoriasPickerView != null) {
                categoriasPickerView.Dispose ();
                categoriasPickerView = null;
            }

            if (filtrotextField != null) {
                filtrotextField.Dispose ();
                filtrotextField = null;
            }

            if (guardarLugarBarButtonItem != null) {
                guardarLugarBarButtonItem.Dispose ();
                guardarLugarBarButtonItem = null;
            }

            if (lugaresTableView != null) {
                lugaresTableView.Dispose ();
                lugaresTableView = null;
            }
        }
    }
}