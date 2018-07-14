using System;
using System.Collections.Generic;

namespace PlatziTrips.Clases.Helper
{
    public class Response
    {
        public List<Category> categories { get; set; }
        public List<Venue> venues { get; set; }
        public Response()
        {
        }
    }
}
