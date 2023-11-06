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
    public partial class NotificationPage : ContentPage
    {
        public NotificationPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                var petsList = await App.Database.ReadNotification();
                lstNotification.ItemsSource = petsList.ToList();
            }
            catch
            {

            }
        }
        private async void CreateNotification_Clicked(object sender, EventArgs e)
        {
            var petstrue = await App.Database.ReadPets();
            if (petstrue != null)
            {
                await Navigation.PushAsync(new AddNotificationPage());

            }
            else
            {
                await DisplayAlert("Error", "No se encontró ninguna mascota, cree una antes de crear notificaciones", "ok");
            }
        }

        private async void lstNotification_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            var SelectedNotification = (Notification)e.SelectedItem;

            await Navigation.PushAsync(new NotificationDetails(SelectedNotification));
            lstNotification.SelectedItem = null;
        }
    }
}