using System;
using System.Collections.Generic;
using System.Linq;
using PlatziTrips.Clases.Helper;

namespace PlatziTrips.Clases
{
    public class DataBaseHelper
    {
        public DataBaseHelper()
        {
        }

        public static bool Insertar<T>(ref T item, string rutaBD){
            
            using( var conexion = new SQLite.SQLiteConnection(rutaBD) )
            {
                conexion.CreateTable<T>();
                if( conexion.Insert(item) != 0){
                    return true;
                };
            }
            return false;
        }

        public static List<Viaje> leerViaje(string rutaBD){
            List<Viaje> lstViajes = new List<Viaje>();
            using (var conexion = new SQLite.SQLiteConnection(rutaBD))
            {
                lstViajes = conexion.Table<Viaje>().ToList();
            }

            return lstViajes;
        }

        public static List<LugarDeInteres> leerLugaresDeInteres(int idViaje, string rutaBD)
        {
            List<LugarDeInteres> lstLugaresDeInteres = new List<LugarDeInteres>();
            using (var conexion = new SQLite.SQLiteConnection(rutaBD))
            {
                conexion.CreateTable<LugarDeInteres>();
                lstLugaresDeInteres = conexion.Table<LugarDeInteres>().Where( l => l.IdViaje == idViaje ).ToList();
            }

            return lstLugaresDeInteres;
        }
    }
}
