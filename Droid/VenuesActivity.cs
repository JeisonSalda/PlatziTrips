
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
    [Activity(Label = "VenuesActivity")]
    public class VenuesActivity : Activity
    {
        EditText filtroEditText;
        ListView venuesListView;
        Spinner categoriasSpinner;
        Toolbar nuevoLugarToolbar;

        List<Category> lstCategories = new List<Category>();
        List<Venue> lstVenues = new List<Venue>();
        Viaje viaje = new Viaje();

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.NuevoLugar);

            filtroEditText = FindViewById<EditText>(Resource.Id.filtroEditText);
            venuesListView = FindViewById<ListView>(Resource.Id.venuesListView);
            categoriasSpinner = FindViewById<Spinner>(Resource.Id.categoriasSpinner);
            nuevoLugarToolbar = FindViewById<Toolbar>(Resource.Id.nuevoLugarToolbar);

            venuesListView.ChoiceMode = ChoiceMode.Multiple;

            SetActionBar(nuevoLugarToolbar);

            ActionBar.Title = "Barra";

            viaje.Id = Intent.Extras.GetInt("ciudad_seleccionada_id");
            viaje.Nombre = Intent.Extras.GetString("ciudad_seleccionada");

            ServiceFourSquare servicios = new ServiceFourSquare();

            lstCategories = await servicios.obtenerCategorias();

            var spinneradapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, lstCategories);

            categoriasSpinner.Adapter = spinneradapter;

            categoriasSpinner.ItemSelected += CategoriasSpinner_ItemSelected;

            filtroEditText.TextChanged += FiltroEditText_TextChanged;
        }

        async void CategoriasSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var categoriaSelected = lstCategories[e.Position];
            ServiceFourSquare servicios = new ServiceFourSquare();
            lstVenues = await servicios.obtenerListaLugares(viaje.Nombre, categoriaSelected.id);

            var listAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItemMultipleChoice, lstVenues);
            venuesListView.Adapter = listAdapter;

        }

        void FiltroEditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            var lstFiltrada = lstVenues.Where(v => v.name.ToLower().Contains(filtroEditText.Text.ToLower())).ToList();

            var listAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItemMultipleChoice, lstFiltrada);
            venuesListView.Adapter = listAdapter;
        }

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
            MenuInflater.Inflate(Resource.Menu.guardar, menu);

            return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
            ConfiguratorPathBD configurator = new ConfiguratorPathBD(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));

            if( item.TitleFormatted.ToString() == "guardar" ){
                var posicionesSelected = venuesListView.CheckedItemPositions;
                for (int i = 0; i < posicionesSelected.Size(); i++ ){
                    if( posicionesSelected.ValueAt( i ) ){
                        var textoCelda = venuesListView.Adapter.GetItem(posicionesSelected.KeyAt(i)).ToString();
                        var venueSelected = lstVenues.Where(v => textoCelda.Contains(v.name)).First();

                        LugarDeInteres lugarDeInteres = new LugarDeInteres(venueSelected, viaje.Id);
                        if( DataBaseHelper.Insertar(ref lugarDeInteres, configurator.RutaCompleta) ){
                            Toast.MakeText(this, "Item insertado", ToastLength.Long).Show();
                        }
                    }
                }

            }
            return base.OnOptionsItemSelected(item);
		}

	}
}
