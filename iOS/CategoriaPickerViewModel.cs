using System;
using System.Collections.Generic;
using PlatziTrips.Clases;
using PlatziTrips.Clases.Helper;
using UIKit;

namespace PlatziTrips.iOS
{
    public class CategoriaPickerViewModel : UIPickerViewModel
    {
        List<Category> lstCategorias;
        public string IdcategoriaSeleccionada
        {
            get;
            set;
        }

        public event EventHandler Categoria_Seleccionada;

        public CategoriaPickerViewModel()
        {
        }

        public CategoriaPickerViewModel(List<Category> lstCategorias)
        {
            this.lstCategorias = lstCategorias;
            IdcategoriaSeleccionada = this.lstCategorias[0].id;
        }

		public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
		{
            return lstCategorias.Count;
		}

		public override nint GetComponentCount(UIPickerView pickerView)
		{
            return 1;
		}

		public override string GetTitle(UIPickerView pickerView, nint row, nint component)
		{
            return lstCategorias[(int)row].name;
		}

		public override void Selected(UIPickerView pickerView, nint row, nint component)
		{
            IdcategoriaSeleccionada = lstCategorias[(int)row].id;
            Categoria_Seleccionada(this, null);
		}

	}
}
