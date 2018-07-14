using Foundation;
using PlatziTrips.Clases;
using PlatziTrips.Clases.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace PlatziTrips.iOS
{
    public partial class NuevoLugarViewController : UIViewController
    {
        List<Category> lstCategorias;
        public Viaje ViajeSeleccionado
        {
            get;
            set;
        }

        List<Venue> lstVenues;
        ConfiguratorPathBD configurator = new ConfiguratorPathBD("/Users/jeisonsaldarriaga/Projects/DBPlatziTrips");

        public NuevoLugarViewController (IntPtr handle) : base (handle)
        {
            ViajeSeleccionado = new Viaje();
        }

        public override async void ViewDidLoad()
		{
            base.ViewDidLoad();

            lugaresTableView.AllowsMultipleSelection = true;

            ServiceFourSquare servicio = new ServiceFourSquare();
            lstCategorias = await servicio.obtenerCategorias();

            var modelo = new CategoriaPickerViewModel(lstCategorias);
            modelo.Categoria_Seleccionada += Modelo_Categoria_Seleccionada;
            categoriasPickerView.Model = modelo;

            guardarLugarBarButtonItem.Clicked += GuardarLugarBarButtonItem_Clicked;

            lstVenues = await servicio.obtenerListaLugares(ViajeSeleccionado.Nombre, modelo.IdcategoriaSeleccionada);
            setTableSource(this.lstVenues);

            filtrotextField.EditingChanged += FiltrotextField_EditingChanged;

		}

        async void Modelo_Categoria_Seleccionada(object sender, EventArgs e)
        {
            var categoria = (sender as CategoriaPickerViewModel).IdcategoriaSeleccionada;

            ServiceFourSquare servicio = new ServiceFourSquare();
            lstVenues = await servicio.obtenerListaLugares(ViajeSeleccionado.Nombre, categoria);
            setTableSource(this.lstVenues);

        }

        private void setTableSource(List<Venue> venues)
        {
            var tableSource = new TableSource(venues);
            lugaresTableView.Source = tableSource;
            lugaresTableView.ReloadData();
        }

        void GuardarLugarBarButtonItem_Clicked(object sender, EventArgs e)
        {
            var elementosSelecteds = lugaresTableView.IndexPathsForSelectedRows;

            if( elementosSelecteds.Count() > 0 ){
                foreach (var elemento in elementosSelecteds)
                {
                    var textCelda = lugaresTableView.CellAt(elemento).TextLabel.Text;
                    var venueSelected = lstVenues.Where(v => v.name.Contains(textCelda)).FirstOrDefault();

                    LugarDeInteres lugarDeInteres = new LugarDeInteres(venueSelected, ViajeSeleccionado.Id);
                    if (DataBaseHelper.Insertar(ref lugarDeInteres, configurator.RutaCompleta))
                    {
                        Console.WriteLine("Item insertado");
                    }
                    else
                    {
                        Console.WriteLine("Item NO insertado");
                    }

                }
            }
           

            NavigationController.PopViewController(true);
        }

        void FiltrotextField_EditingChanged(object sender, EventArgs e)
        {
            var venues = lstVenues.Where(v => v.name.ToLower().Contains(filtrotextField.Text.ToLower())).ToList();

            setTableSource(venues);
        }

    }
}