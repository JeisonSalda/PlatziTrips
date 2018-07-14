using System;
namespace PlatziTrips.Clases
{
    public class Constants
    {
        public const string CLIENTE_ID = "NUVUGMWDXDLTG1OLVA2NPSTW0U35X1ENXA5TVQEKHBLFHQFE";

        public const string CLIENTE_SECRET = "UAXJQRWUDEMGZLHWCF3ECDLJL3ICHBJJD524YX3SY3QBWN41";

        public Constants()
        {



        }

        public static string obtenerUrlCategories(){
            return "https://api.foursquare.com/v2/venues/categories?client_id=" + CLIENTE_ID + "&client_secret=" + CLIENTE_SECRET 
                    + "&v=" + DateTime.Now.ToString("yyyyMMdd");
        }

        public static string obtenerUrlPorLugares(string ciudad, string idCategoria)
        {
            return "https://api.foursquare.com/v2/venues/search?near=" + ciudad + "&categoryId=" + idCategoria + "&client_id=" + CLIENTE_ID
                + "&client_secret=" + CLIENTE_SECRET + "&v=" + DateTime.Now.ToString("yyyyMMdd");
        }
            
    }
}
