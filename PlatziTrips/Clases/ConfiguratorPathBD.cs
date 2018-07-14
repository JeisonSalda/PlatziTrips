using System;
using System.IO;

namespace PlatziTrips.Clases
{
    public class ConfiguratorPathBD
    {
        public string RutaCarpeta
        {
            get;
            set;
        }

        public string RutaCompleta
        {
            get;
        }

        private const string NombreBD = "ViajesBD.sqlite";

        public ConfiguratorPathBD(string rutaCarpeta)
        {
            RutaCarpeta = rutaCarpeta;
            RutaCompleta = Path.Combine(RutaCarpeta, NombreBD);
        }
    }
}
