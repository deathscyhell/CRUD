using BDTienda.Models;
using BDTienda.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace BDTienda.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        #region Atributos
        public Usuarios _user;

        private string nombre;
        private string apellido;
        private string genero;
        private int edad;
      

        #endregion

        #region propiedades

        public string Nombre
        {
            get { return nombre; }
            set
            {
                SetValue(ref nombre, value);
            }
        }

        public string Apellido
        {
            get { return nombre; }
            set
            {
                SetValue(ref nombre, value);
            }
        }

        public string Genero
        {
            get { return genero; }
            set
            {
                SetValue(ref genero, value);
            }
        }

        public int Edad
        {
            get { return edad; }
            set
            {
                SetValue(ref edad, value);
            }
        }

        public List<Usuarios> ListUsuarios { get; set; } = new List<Usuarios>(); 
        #endregion

        #region Constructor
        public UserViewModel(Usuarios user): this()
        {
            this._user = user;
            if (user != null  )
            {
                Nombre = user.Nombre;
                Apellido = user.Apellido;
                Genero = user.Genero;
                Edad = user.Edad;
                
            }
        }

        public UserViewModel()
        {   GetUsers();
            GuardarCommand = new Command(Insert);
        }
        #endregion

        #region Command

        public Command GuardarCommand { get; set; }
        #endregion


        #region metodos

        public async void GetUsers()
        {
            var Servi = new Service<Usuarios>();
            ListUsuarios = await Servi.GetAll();
           
        }
        private async void Insert(object obj)
        {
            var Servi = new Service<Usuarios>();
            var user = new Usuarios();
            user.Nombre = Nombre;
            user.Apellido = Apellido;
            user.Genero = Genero;
            user.Edad = Edad;
            

            if (string.IsNullOrEmpty(user.Nombre))
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", "Debe ingresar su nombre/s", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(user.Apellido))
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", "Debe ingresar su apellido/s", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(user.Genero))
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", "Debe ingresar su apellido/s", "Aceptar");
                return;
            }
            if (user.Edad.Equals(0))
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", "Debe ingresar su edad", "Aceptar");
                return;
            }
            else
            {
                if (user.Edad < 0)
                {
                    await App.Current.MainPage.DisplayAlert("Advertencia", "Su edad tiene que ser mayor a cero", "Aceptar");
                    return;
                }
            }
           
           
            var result = await Servi.Insert(user);
            if (result == 1)
            {
                await App.Current.MainPage.DisplayAlert("Mensaje de Aviso", "Registro Guardado con exito!!!", "Aceptar");
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Mensaje de Aviso", $"Error al guardar", "Aceptar");
            }
        }
        #endregion
    }
}
