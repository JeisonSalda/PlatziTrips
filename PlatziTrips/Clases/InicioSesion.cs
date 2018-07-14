using System;
namespace PlatziTrips.Clases
{
    public class InicioSesion
    {
        public InicioSesion()
        {
        }

        public bool iniciarSesion(string nombreUsuario, string password){
            return !(string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(password));
        }
    }
}
