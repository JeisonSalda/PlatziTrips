
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PlatziTrips.Clases;

namespace PlatziTrips.Droid
{
    [Activity(Label = "NuevoViajeActivity")]
    public class NuevoViajeActivity : Activity
    {
        EditText lugarEditText;
        DatePicker idaDatePicker, regresoDatePicker;
        Button guardarButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NuevoViaje);

            lugarEditText = FindViewById<EditText>(Resource.Id.lugarEditText);
            idaDatePicker = FindViewById<DatePicker>(Resource.Id.idaDatePicker);
            regresoDatePicker = FindViewById<DatePicker>(Resource.Id.regresoDatePicker);
            guardarButton = FindViewById<Button>(Resource.Id.guardarButton);

            guardarButton.Click += GuardarButton_Click;
        }

        void GuardarButton_Click(object sender, EventArgs e)
        {
            ConfiguratorPathBD configurator = new ConfiguratorPathBD( System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) );

            var nuevoViaje = new Viaje()
            {
                Nombre = lugarEditText.Text,
                FechaInicio = idaDatePicker.DateTime,
                FechaRegreso = regresoDatePicker.DateTime

            };

            if(  DataBaseHelper.Insertar(ref nuevoViaje, configurator.RutaCompleta) ) {
                Toast.MakeText(this, "Registro insertado correctamente", ToastLength.Short).Show();
            }else{
                Toast.MakeText(this, "Hubo error", ToastLength.Short).Show();
            }

        }

    }
}
