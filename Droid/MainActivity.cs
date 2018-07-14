using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using PlatziTrips.Clases;

namespace PlatziTrips.Droid
{
    [Activity(Label = "PlatziTrips", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        EditText usuarioEditText, passwordEditText;
        Button loginButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            usuarioEditText = FindViewById<EditText>(Resource.Id.usuarioEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            loginButton = FindViewById<Button>(Resource.Id.loginButton);

            loginButton.Click += loginButton_Clicked;


        }

        private void loginButton_Clicked(object sender, EventArgs e)
        {
            InicioSesion inicioSesion = new InicioSesion();
            if (inicioSesion.iniciarSesion(usuarioEditText.Text, passwordEditText.Text))
            {
                Intent intent = new Intent(this, typeof(ListaViajesActivity));
                StartActivity(intent);
            }
        }
    }
}

