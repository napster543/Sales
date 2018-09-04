
namespace Sales.ViewModels
{
    using Xamarin.Forms;
using Sales.Common.Models;
using Sales.Services;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;

    public class ProductsViewModel : BaseViewModel
    {
        private ApiServices apiService;
        private bool isRefreshing;
        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get { return this.products; }
            set { SetValue(ref this.products, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadProducts);
            }
        }
        public ProductsViewModel()
        {
            this.apiService = new ApiServices();
            this.LoadProducts();
        }
        public async void LoadProducts()
        {
            this.IsRefreshing = true;
            var url = Application.Current.Resources["UrlAPI"].ToString();
            var response = await this.apiService.GetList<Product>("http:192.168.1.20/", "api/", "Product/");
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }
            var list = (List<Product>)response.Result;
            this.Products = new ObservableCollection<Product>(list);
            this.IsRefreshing = false;
        }
        //https://www.youtube.com/watch?v=ZwDWwxc0KG0&list=PLuEZQoW9bRnRnzwx4z1kzoY2Pt2nve6L_&index=8
        //Video 8 minuto 00:00
    }
}
