using Sales.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Sales.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get { return this.products; }
            set { SetValue(ref this.products, value); }
        }
        //https://www.youtube.com/watch?v=VQSj7fKbngg&index=7&list=PLuEZQoW9bRnRnzwx4z1kzoY2Pt2nve6L_
        // Video minuto 26:28
    }
}
