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
        public string userName { get; set; }
        User userdata { get; set; }

        public UserPage()
        {
            userdata = new User
            {
                Name = Application.Current.Properties.ContainsKey("Usuario") ? (string)Application.Current.Properties["Usuario"] : string.Empty,
                Email = Application.Current.Properties.ContainsKey("Email") ? (string)Application.Current.Properties["Email"] : string.Empty,
                Password = Application.Current.Properties.ContainsKey("Contraseña") ? (string)Application.Current.Properties["Contraseña"] : string.Empty
            };

            userName = userdata.Name;
            
            BindingContext = this;

            InitializeComponent();
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
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
            Application.Current.Properties["Usuario"] = null;
            Application.Current.Properties["Contraseña"] = null;

            await Navigation.PushAsync(new Login());
        }

        private void notification_Clicked(object sender, EventArgs e)
        {
            CrossLocalNotifications.Current.Show("AnimalGuardian", "Notificación", 0, DateTime.Now.AddSeconds(2));
        }

        private async void config_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AccountDetails(userdata));
        }
    }
}
