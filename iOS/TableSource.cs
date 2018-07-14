using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using PlatziTrips.Clases;
using UIKit;

namespace PlatziTrips.iOS
{
    public class TableSource : UITableViewSource
    {
        List<Venue> lstVenues;

        public TableSource()
        {
        }

        public TableSource(List<Venue> lstLugares)
        {
            this.lstVenues = lstLugares;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var celda = tableView.DequeueReusableCell("lugarCellIdentifier");

            var datos = lstVenues[indexPath.Row];

            celda.TextLabel.Text = datos.name;
            celda.DetailTextLabel.Text = datos.categories.FirstOrDefault().name;
            return celda;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return lstVenues.Count;
        }

    }
}
