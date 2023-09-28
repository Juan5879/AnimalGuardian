using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoFinal.model;
using Xamarin.Essentials;

namespace ProyectoFinal.views
{ 

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class enclosurePet : ContentPage
    {
        public enclosurePet()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                lstPets.ItemsSource = await App.Database.ReadPets(); 
            }
            catch
            {

            }
            //lista estatica
            /*
            var listamascota = new List<petTS>
            {
                new petTS { Name = "Raul estatico", Description = "Una lista estatica"},
                new petTS { Name = "Raul estatico 2", Description = "Una lista estatica 2"},
                new petTS { Name = "Raul estatico 3", Description = "Una lista estatica 3"}
            };
            lstPets.ItemsSource = listamascota;*/
        }

        private async void btn_addPet_Clicked(object sender, EventArgs e)
        {           
            await Navigation.PushAsync(new AddPet());
        }

        private async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var pet = item.CommandParameter as pets;
            await Navigation.PushAsync(new PetView(pet));
        }

        private async void SwipeItem_Invoked_1(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var pet = item.CommandParameter as pets;
            var result = await DisplayAlert("Borrar", $"Desea deshacerse de {pet.Name}? una vez eliminado no se podrá recuperar", "Eliminar", "Cancelar");
            if (result)
            {
                await App.Database.DeletePet(pet);
                lstPets.ItemsSource = await App.Database.ReadPets();
            }
        }

        async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstPets.ItemsSource = await App.Database.SearchPet(e.NewTextValue);
        }

        private async void lstPets_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedPet = (pets)e.SelectedItem;

            await Navigation.PushAsync(new PetDetails(selectedPet));

            lstPets.SelectedItem = null;
        }

    }
}

                                                              /*▄︻デPAN̷══━一*/