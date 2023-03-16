using Microsoft.EntityFrameworkCore;
using Productos_wpf.DataContext;
using Productos_wpf.Models;
using Productos_wpf.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Productos_wpf.ViewModel
{
    public class ProductEditViewModel : INotifyPropertyChanged
    {
        private readonly ProductsContext productsContext;

        public event PropertyChangedEventHandler? PropertyChanged;

        void ExecPropertyChanged(string propertyName)
        {
            if (PropertyChanged is not null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ProductAction Action { get; set; }
        public ICommand AceptarCommand { get; set; }

        public Product Product { get; set; }

        public ProductEditViewModel(ProductsContext productsContext)
        {
            this.productsContext = productsContext;
            AceptarCommand = new
                CommandHandler(SeleccionarAccion, () => true);
        }

        void SeleccionarAccion() 
        {
            if (Action == ProductAction.Crear)
            {
                CrearProducto();
                return;
            }

            EditarProducto();
        }

        void CrearProducto() 
        {
            productsContext.Add(Product);
            productsContext.SaveChanges();
        }

        void EditarProducto() 
        {
            productsContext.Entry(Product).State = EntityState.Modified;
            productsContext.SaveChanges();
        }


    }

    public enum ProductAction
    {
        Crear,
        Editar,
        Eliminar
    }
}
