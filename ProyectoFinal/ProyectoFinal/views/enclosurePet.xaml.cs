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
                var petsList = await App.Database.ReadPets();
                lstPets.ItemsSource = petsList.ToList();
            }
            catch
            {

            }
        }

        private async void btn_addPet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPet());
        }
        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
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