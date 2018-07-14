using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PlatziTrips.Clases
{
    public class ServiceFourSquare
    {
        public ServiceFourSquare()
        {
        }

        public async Task<List<Category>> obtenerCategorias(){
            List<Category> lstCategories = new List<Category>();

            var url = Constants.obtenerUrlCategories();

            using( HttpClient cliente = new HttpClient() ){
                var respuesta = await cliente.GetStringAsync(url);
                Categorias categorias = JsonConvert.DeserializeObject<Categorias>(respuesta);
                lstCategories = categorias.response.categories;
            }

            return lstCategories;
        }

        public async Task<List<Venue>> obtenerListaLugares(string ciudad, string categoriaId){

            List<Venue> lstVenues = new List<Venue>();

            var url = Constants.obtenerUrlPorLugares(ciudad, categoriaId);

            using( HttpClient cliente = new HttpClient() ){
                var respuesta = await cliente.GetStringAsync(url);
                Venues venues = JsonConvert.DeserializeObject<Venues>(respuesta);
                lstVenues = venues.response.venues;
            }

            return lstVenues;

        }

    }
}
