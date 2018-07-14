using Foundation;
using PlatziTrips.Clases;
using System;
using System.IO;
using UIKit;

namespace PlatziTrips.iOS
{
    public partial class NuevoViajeViewController : UIViewController
    {
        public NuevoViajeViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            guardarButtonItem.Clicked += guardarButtonItem_Clicked; 
        }

        void guardarButtonItem_Clicked( object sender, EventArgs e ){

            ConfiguratorPathBD configurator = new ConfiguratorPathBD("/Users/jeisonsaldarriaga/Projects/DBPlatziTrips");

            var nuevoViaje = new Viaje()
            {
                Nombre = ciudadTextField.Text,
                FechaInicio = (DateTime)idaDatePicker.Date,
                FechaRegreso = (DateTime)regresoDatePicker.Date

            };

            if( DataBaseHelper.Insertar(ref nuevoViaje, configurator.RutaCompleta) ){
                NavigationController.PopViewController(true);
                Console.WriteLine("Insercion Exitosa");
            }else{
                Console.WriteLine("Hubo un error");
            }


        }
    }
}