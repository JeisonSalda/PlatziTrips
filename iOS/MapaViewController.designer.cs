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
    [Register ("MapaViewController")]
    partial class MapaViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView mapaMapView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (mapaMapView != null) {
                mapaMapView.Dispose ();
                mapaMapView = null;
            }
        }
    }
}