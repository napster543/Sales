
namespace Sales.ViewModels
{
    using Xamarin.Forms;
using Sales.Common.Models;
using Sales.Services;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;

    public class ProductsViewModel : BaseViewModel
    {
        private ApiServices apiService;
        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get { return this.products; }
            set { SetValue(ref this.products, value); }
        }

        public ProductsViewModel()
        {
            this.apiService = new ApiServices();
            this.LoadProducts();
        }
        public async void LoadProducts()
        {
            var response = await this.apiService.GetList<Product>("http:192.168.1.20/", "api/", "Product/");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }
            var list = (List<Product>)response.Result;
            this.Products = new ObservableCollection<Product>(list);
        }
        //https://www.youtube.com/watch?v=ZwDWwxc0KG0&list=PLuEZQoW9bRnRnzwx4z1kzoY2Pt2nve6L_&index=8
        //Video 8 minuto 00:00
    }
}
