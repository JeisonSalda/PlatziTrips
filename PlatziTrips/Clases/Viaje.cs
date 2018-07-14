using System;
using SQLite;
namespace PlatziTrips.Clases
{
    [Table("Viaje")]
    public class Viaje
    {
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get;
            set;
        }
        [MaxLength(150)]
        public string Nombre
        {
            get;
            set;
        }

        public DateTime FechaInicio
        {
            get;
            set;
        }

        public DateTime FechaRegreso
        {
            get;
            set;
        }

		public override string ToString()
		{
            return $"{Nombre} ({FechaInicio:d}) - ({FechaRegreso:d})";
		}

	}
}
