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
                Email = user.Text,
                Password = password.Text
            };

            var confirmation = await apiservice.UserAuth(userAuth);

            if (confirmation == true)
            {
                string authToken = "authUserLogged";
                await SecureStorage.SetAsync("AuthToken", authToken);
                try
                {
                    string userAuthData = JsonConvert.SerializeObject(userAuth);
                    await SecureStorage.SetAsync("UserData", userAuthData);
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", $"Hubo un problema al guardar los datos, no se guardará la sesión pero puede seguir usandola. Error: {ex}", "Ok");
                }
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Error", "No se pudieron validar los datos, asegurese que los campos sean correctos, en caso contrario intente en otro momento", "Ok");
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