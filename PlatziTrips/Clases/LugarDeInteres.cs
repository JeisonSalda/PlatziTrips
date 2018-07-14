using System;
using System.Linq;

namespace PlatziTrips.Clases.Helper
{
    public class LugarDeInteres
    {
        public LugarDeInteres() { 
        }

        public LugarDeInteres(Venue venue, int idViaje)
        {
            IdViaje = idViaje;
            Nombre = venue.name;
            lat = venue.location.Lat;
            lng = venue.location.Lng;
            Categoria = venue.categories.First().name;
        }

        public int Id
        {
            get;
            set;
        }

        public string Nombre
        {
            get;
            set;
        }

        public double lat
        {
            get;
            set;
        }

        public double lng
        {
            get;
            set;
 
        }

        public int IdViaje
        {
            get;
            set;
   
        }

        public string Categoria
        {
            get;
            set;
        }

		public override string ToString()
		{
            return Nombre;
		}
	}
}
