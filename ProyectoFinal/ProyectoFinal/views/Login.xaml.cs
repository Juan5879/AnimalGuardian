using ProyectoFinal.http;
using ProyectoFinal.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft;
using Newtonsoft.Json;

namespace ProyectoFinal.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private readonly APIService apiservice;
        public Login()
        {
            InitializeComponent();
            apiservice = new APIService();
        }

        private async void Btn_login(object sender, EventArgs e)
        {
            User userAuth = new User
            {
                Name = user.Text, 
                Password = password.Text,
                Email = user.Text
            };


            var BodyConfirmation = await apiservice.UserAuth(userAuth);
            var confirmation = BodyConfirmation.status;

            if (confirmation == true)
            {
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                
                await DisplayAlert("problema", "error", "ok");
            }
        }
        private async void Btn_nav_register(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }
        private async void Btn_nav_recoverypass(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecoveryPass());
        }
    }
}
                       /*▁ ▂ ▄ ▅ ▆ ▇ █ PAN █ ▇ ▆ ▅ ▄ ▂ ▁*/