

namespace Sales.Infrastructure
{
    using System;
    using Sales.ViewModels;
    
    public class InstanceLocator
    {
        public ProductsViewModel Products { get; set; }
        public InstanceLocator()
        {
            this.Products = new ProductsViewModel();
        }
    }
}
