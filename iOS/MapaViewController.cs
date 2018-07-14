using Foundation;
using MapKit;
using PlatziTrips.Clases.Helper;
using System;
using System.Collections.Generic;
using UIKit;

namespace PlatziTrips.iOS
{
    public partial class MapaViewController : UIViewController
    {
        public List<LugarDeInteres> lstLugaresInteres;

        public MapaViewController (IntPtr handle) : base (handle)
        {


        }

		public override void ViewDidAppear(bool animated)
		{
            base.ViewDidAppear(animated);

            foreach(var lugar in lstLugaresInteres){
                mapaMapView.AddAnnotation(new MKPointAnnotation()
                {
                    Title = lugar.Nombre,
                    Coordinate = new CoreLocation.CLLocationCoordinate2D(lugar.lat, lugar.lng) 
                });
            }
		}
	}
}