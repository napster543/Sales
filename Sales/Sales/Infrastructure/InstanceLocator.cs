

namespace Sales.Infrastructure
{
    using System;
    using Sales.ViewModels;
    
    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}
