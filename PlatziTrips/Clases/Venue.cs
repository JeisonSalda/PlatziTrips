using System;
using System.Collections.Generic;

namespace PlatziTrips.Clases
{
    public class Venue
    {
        public string Id { get; set; }
        public string name { get; set; }
        public Location location { get; set; }
        public List<Category> categories { get; set; }

        public Venue(){
            categories = new List<Category>();
        }

		public override string ToString()
		{
            if(categories != null && categories.Count > 0 ){
                return $"{name} ({categories[0].name})";
            }else{
                return name;
            }
		}
	}
}
