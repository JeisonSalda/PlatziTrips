using Foundation;
using PlatziTrips.Clases;
using PlatziTrips.Clases.Helper;
using System;
using System.Collections.Generic;
using UIKit;

namespace PlatziTrips.iOS
{
    public partial class DetallesTableViewController : UITableViewController
    {
        public Viaje ViajeSeleted
        {
            get;
            set;
        }

        List<LugarDeInteres> lstLugaresInteres;
        ConfiguratorPathBD configurator = new ConfiguratorPathBD("/Users/jeisonsaldarriaga/Projects/DBPlatziTrips");

        public DetallesTableViewController (IntPtr handle) : base (handle)
        {
            ViajeSeleted = new Viaje();
        }

        public DetallesTableViewController(){
            ViajeSeleted = new Viaje();
        }

		public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NavigationItem.Title = ViajeSeleted.Nombre;
            lstLugaresInteres = new List<LugarDeInteres>();
		}

		public override void ViewDidAppear(bool animated)
		{
            base.ViewDidAppear(animated);
            lstLugaresInteres = DataBaseHelper.leerLugaresDeInteres(ViajeSeleted.Id, configurator.RutaCompleta);
            TableView.ReloadData();
		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{
            return lstLugaresInteres.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
            var celda = tableView.DequeueReusableCell("lugarInteresIdentifier", indexPath);
            var datos = lstLugaresInteres[indexPath.Row];

            celda.TextLabel.Text = datos.Nombre;
            celda.DetailTextLabel.Text = datos.Categoria;

            return celda;
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
            if( segue.Identifier == "nuevoLugarSegueIdentifier" ){
                var destinationViewController = segue.DestinationViewController as NuevoLugarViewController;
                destinationViewController.ViajeSeleccionado.Nombre = ViajeSeleted.Nombre;
                destinationViewController.ViajeSeleccionado.Id = ViajeSeleted.Id;
            }else if( segue.Identifier == "mapaSegueIdentifier" ){
                var destinationViewController = segue.DestinationViewController as MapaViewController;
                destinationViewController.lstLugaresInteres = lstLugaresInteres;
            }

            base.PrepareForSegue(segue, sender);

		}

	}
}