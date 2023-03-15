using Productos_wpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos_wpf.ViewModel
{
    public class ProductsViewModel
    {
        private IList<Product> _ProductList;

        public List<Product> productList { get { return _ProductList.ToList(); } }



        public ProductsViewModel()
        {
            _ProductList = new List<Product>
            {
                 new Product {
                     Id=1000,
                     Category="Muebles",
                     Description="Bonito escritorio",
                     Name="Escritorio de madera",
                     Price=100m
                 },
                 new Product
                 {
                    Id=1001,
                     Category="Computo",
                     Description="laptop hp 2323",
                     Name="laptop hp 12 gb ram",
                     Price=400m
                 }

             };
        }
    }
}


