using System;
namespace PlatziTrips.Clases
{
    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }

        public Category()
        {
        }

		public override string ToString()
		{
            return name;
		}
	}
}
