using BDTienda.Models;
using BDTienda.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BDTienda.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListUser : ContentPage
    {
        public ListUser()
        {
            InitializeComponent();
            OnAppearing();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var Servi = new Service<Usuarios>();
            UserList.ItemsSource = await Servi.GetAll();
        }
    }
}