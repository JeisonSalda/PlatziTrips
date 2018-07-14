using Foundation;
using PlatziTrips.Clases;
using System;
using System.Collections.Generic;
using UIKit;

namespace PlatziTrips.iOS
{
    public partial class ListaViajesViewController : UITableViewController
    {
        List<Viaje> viajes;

        public ListaViajesViewController (IntPtr handle) : base (handle)
        {
            
        }

		public override void ViewDidLoad()
		{
            base.ViewDidLoad();
            viajes = new List<Viaje>();

            NavigationItem.SetHidesBackButton(true, false);

            NavigationController.SetNavigationBarHidden(false, true);

		}

		public override void ViewDidAppear(bool animated)
		{
            base.ViewDidAppear(animated);

            ConfiguratorPathBD configurator = new ConfiguratorPathBD( "/Users/jeisonsaldarriaga/Projects/DBPlatziTrips" );

            viajes = DataBaseHelper.leerViaje(configurator.RutaCompleta);

            TableView.ReloadData();

		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
            var celda = TableView.DequeueReusableCell("viajeReuseIdentifier", indexPath);
            var datos = viajes[indexPath.Row];

            celda.TextLabel.Text = datos.Nombre;
            celda.DetailTextLabel.Text = $"{datos.FechaInicio:d} - {datos.FechaRegreso:d}";

            return celda;
		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{
            return viajes.Count;
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
            if( segue.Identifier == "detallesSegueIdentifier" ){
                var viewControllerDestino = segue.DestinationViewController as DetallesTableViewController;
                viewControllerDestino.ViajeSeleted.Nombre = viajes[TableView.IndexPathForSelectedRow.Row].Nombre;
                viewControllerDestino.ViajeSeleted.Id = viajes[TableView.IndexPathForSelectedRow.Row].Id;
            }

            base.PrepareForSegue(segue, sender);
		}
	}
}