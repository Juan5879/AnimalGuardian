using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinal.model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PetDetails : ContentPage
    {

        string PetName;

        public PetDetails(pets slectedPet)
        {
            InitializeComponent();

            petName.Text = slectedPet.Name;
            petDescription.Text = slectedPet.Description;
        }

        private async void edit_Clicked(object sender, EventArgs e)
        {
            var pet = await GetPetData(PetName);
            await Navigation.PushAsync(new PetView(pet));
        }

        private async void delete_Clicked(object sender, EventArgs e)
        {
            var pet = await GetPetData(PetName);

            var confirmation = await DisplayAlert("Advertencia", $"Realmente quiere eliminar a {pet.Name}?\nNo lo podrá recuperar", "Borrar", "Cancelar");

            if (confirmation == true)
            {
                await App.Database.DeletePet(pet);
                await Navigation.PopAsync();
            }
        }

        public async Task<pets> GetPetData(string nameSelected)
        {
            var pets = await App.Database.ReadPets();
            pets pet = pets.FirstOrDefault(p => p.Name == nameSelected);
            return pet;
        }
    }
}