
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PlatziTrips.Clases;

namespace PlatziTrips.Droid
{
    [Activity(Label = "ListaViajesActivity")]
    public class ListaViajesActivity : Activity
    {
        Toolbar viajesToolbar;
        ListView viajesListView;
        List<Viaje> lstViajes;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ListaViajes);


            viajesToolbar = FindViewById<Toolbar>(Resource.Id.viajesToolbar);
            viajesListView = FindViewById<ListView>(Resource.Id.viajesListView);
            viajesListView.ItemClick += ViajesListView_ItemClick;

            SetActionBar(viajesToolbar);
            ActionBar.Title = "Mis Viajes";
            var pp = new double[10];

            getListaViajes();
        }

        void ViajesListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var viajeSeleccionado = lstViajes[e.Position];
            var intent = new Intent(this, typeof(DetallesViajeActivity));
            var bundle = new Bundle();
            bundle.PutString("ciudad_seleccionada", viajeSeleccionado.Nombre);
            bundle.PutInt("ciudad_seleccionada_id", viajeSeleccionado.Id);
            bundle.PutString("fecha_ida_string", viajeSeleccionado.FechaInicio.ToString());
            bundle.PutString("fecha_regreso_string", viajeSeleccionado.FechaRegreso.ToString());

            intent.PutExtras(bundle);

            StartActivity(intent);

        }


		protected override void OnRestart()
		{
            base.OnRestart();
            // Create your application here
            getListaViajes();

		}

        private void getListaViajes()
        {
            ConfiguratorPathBD configurator = new ConfiguratorPathBD(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));

            // Create your application here
            lstViajes = new List<Viaje>();
            lstViajes = DataBaseHelper.leerViaje(configurator.RutaCompleta);

            var arrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, lstViajes);
            viajesListView.Adapter = arrayAdapter;
        }

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
            MenuInflater.Inflate(Resource.Menu.agregar, menu);

            return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
            if( item.TitleFormatted.ToString() == "agregar" ){
                Intent intent = new Intent(this, typeof(NuevoViajeActivity));
                StartActivity(intent);
            }

            return base.OnOptionsItemSelected(item);
		}
	}
}
