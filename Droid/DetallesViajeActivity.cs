
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PlatziTrips.Clases;
using PlatziTrips.Clases.Helper;

namespace PlatziTrips.Droid
{
    [Activity(Label = "DetallesViajeActivity")]
    public class DetallesViajeActivity : Activity
    {
        Toolbar detallesToolBar;
        TextView fechaTextView, ciudadTextView;
        ListView detallesListView;
        Viaje viaje = new Viaje();
        List<LugarDeInteres> lstLugares;
        ConfiguratorPathBD configurator = new ConfiguratorPathBD(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DetallesViaje);

            // Create your application here
            detallesToolBar = FindViewById<Toolbar>(Resource.Id.detalleToolbar);
            fechaTextView = FindViewById<TextView>(Resource.Id.fechaTextView);
            ciudadTextView = FindViewById<TextView>(Resource.Id.ciudadTextView);
            detallesListView = FindViewById<ListView>(Resource.Id.detallesListView);

            viaje.Id = Intent.Extras.GetInt("ciudad_seleccionada_id");
            viaje.Nombre = Intent.Extras.GetString("ciudad_seleccionada");
            viaje.FechaInicio = DateTime.Parse(Intent.Extras.GetString("fecha_ida_string"));
            viaje.FechaRegreso = DateTime.Parse(Intent.Extras.GetString("fecha_regreso_string"));


            ciudadTextView.Text = viaje.Nombre;
            fechaTextView.Text = $"{viaje.FechaInicio:MMM dd} - {viaje.FechaRegreso:MMM dd}";

            SetActionBar(detallesToolBar);

            setLugaresListView();

            ciudadTextView.Click += CiudadTextView_Click;

        }

        private void setLugaresListView()
        {
            lstLugares = DataBaseHelper.leerLugaresDeInteres(viaje.Id, configurator.RutaCompleta);
            var arrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, lstLugares);
            detallesListView.Adapter = arrayAdapter;
        }

		protected override void OnRestart()
		{
            setLugaresListView();
            base.OnRestart();
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
            MenuInflater.Inflate(Resource.Menu.agregar, menu);

            return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
            if(  item.TitleFormatted.ToString() == "agregar" ){
                Intent intent = new Intent(this, typeof(VenuesActivity));
                Bundle bundle = new Bundle();
                bundle.PutInt("ciudad_seleccionada_id", viaje.Id);
                bundle.PutString("ciudad_seleccionada", viaje.Nombre);

                intent.PutExtras(bundle);

                StartActivity(intent);
            }

            return base.OnOptionsItemSelected(item);
		}

        void CiudadTextView_Click(object sender, EventArgs e)
        {
            double[] longitudes = new double[lstLugares.Count], latitudes = new double[lstLugares.Count];
            int contador = 0;
            foreach(var lugar in lstLugares){
                latitudes[contador] = lugar.lat;
                longitudes[contador] = lugar.lng;
                contador++;
            }

            Intent intent = new Intent(this, typeof(MapaActivity));

            Bundle bundle = new Bundle();
            bundle.PutDoubleArray("latitudes", latitudes);
            bundle.PutDoubleArray("longitudes", longitudes);

            intent.PutExtras(bundle);
            StartActivity(intent);

        }

	}
}
