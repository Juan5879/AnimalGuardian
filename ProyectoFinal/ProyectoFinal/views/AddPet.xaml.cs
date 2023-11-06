using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoFinal.model;

namespace ProyectoFinal.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPet : ContentPage
    {

        public AddPet()
        {
            InitializeComponent();
        }
        async void Btn_SavePet(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(petName.Text) || string.IsNullOrWhiteSpace(petDescription.Text))
            {
                await DisplayAlert("datos invalidos", "Los campos esán vacíos", "Ok");
            }
            else
            {
                AddNewPet();
            }
        }
        async void AddNewPet()
        {
            await App.Database.CreatePet(new model.pets
            {
                IdPet = Guid.NewGuid(),
                Name = petName.Text,
                Description = petDescription.Text,
                ImagePet = null
            });
            await Navigation.PopAsync();
        }

        public bool ValidarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(petName.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(petDescription.Text))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }

        private async void SelectImage_Clicked(object sender, EventArgs e)
        {

        }
    }
}