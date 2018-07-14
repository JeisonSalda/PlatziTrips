using Foundation;
using PlatziTrips.Clases;
using System;
using UIKit;

namespace PlatziTrips.iOS
{
    public partial class ViewController : UIViewController
    {
        bool puedeNavegar = false;

        public ViewController (IntPtr handle) : base (handle)
        {
            
        }

        public override void ViewDidLoad()         {             base.ViewDidLoad();              inicioSesionButton.TouchUpInside += InicioSesionButton_TouchUpInside; 
            NavigationController.SetNavigationBarHidden(true, false);         }          void InicioSesionButton_TouchUpInside(object sender, EventArgs e)         {                     }           public override void DidReceiveMemoryWarning()         {             base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.       
        }

		public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
		{
            InicioSesion inicioSesion = new InicioSesion();
            return segueIdentifier == "inicioSesionSegue" && inicioSesion.iniciarSesion(usuarioTextField.Text, passwordTextField.Text);
		}

	}
}