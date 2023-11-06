using ProyectoFinal.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNotificationPage : ContentPage
    {
        public AddNotificationPage()
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

        private async void lstPets_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedPet = (pets)e.SelectedItem;

            await Navigation.PushAsync(new ParamNotificationPage(selectedPet));

            lstPets.SelectedItem = null;
        }
    }
}