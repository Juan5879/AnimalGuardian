using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.LocalNotifications;
using ProyectoFinal.model;

namespace ProyectoFinal.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        public string UserName { get; set; } 

        public UserPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            User userData = await App.Database.GetUserById(1);

            if (userData != null)
            {
                UserName = userData.Name;
            }
        }

        private async void btn_nav_config_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage());
        }

        private void btn_nav_contact_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_nav_closesion_Clicked(object sender, EventArgs e)
        {

        }

        private async void login_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }

        private void notification_Clicked(object sender, EventArgs e)
        {
            CrossLocalNotifications.Current.Show("AnimalGuardian", "Notificación", 0, DateTime.Now.AddSeconds(2));
        }

        private async void TakePickFromgallery_Clicked(object sender, EventArgs e)
        {
            var photo = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Seleccionar imagen"
            });

            if (photo != null)
            {

            }
        }

        private async void TakePickFromCamera_Clicked(object sender, EventArgs e)
        {
            var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
            {
                Title = "Tomar foto"
            });

            if (photo != null)
            {
            }
        }
    }
}
